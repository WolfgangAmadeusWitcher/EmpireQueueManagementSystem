using CSharp_HtmlParser_Library.HtmlDocumentStructure;
using EmpireQms.PrintService.Api.Application.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace EmpireQms.PrintService.Api.Application.Services
{
    public class EmpireHtmlParserService
    {
        private readonly string _documentHtml;
        private FontStyle _fontStyle;
        public EmpireHtmlParserService(string documentHtml)
        {
            _documentHtml = documentHtml;
        }

        public List<Print> Parse()
        {
            var htmlDocument = new HtmlDocument(_documentHtml);
            htmlDocument.Parse();

            var printList = new List<Print>();
            foreach (var childNode in htmlDocument.RootNode.ChildNodes)
            {
                _fontStyle = FontStyle.Regular;
                var printObject = new Print()
                {
                    Name = childNode.InnerText.Replace("&nbsp;", " "),
                    DataType = 1
                };

                ConvertToPrintObject(childNode, printObject);
                printObject.Font = new Font(printObject.Font, _fontStyle);
                printList.Add(printObject);

            }

            return printList;
        }

        private void ConvertToPrintObject(HtmlDocumentNode childNode, Print printObject)
        {
            if (childNode == null || printObject == null) return;

            GetPrintPropertiesFromTags(childNode, printObject);
            GetPrintPropertiesFromAttributes(childNode, printObject);

            foreach (var item in childNode.ChildNodes)
                ConvertToPrintObject(item, printObject);
        }

        private void GetPrintPropertiesFromAttributes(HtmlDocumentNode childNode, Print printObject)
        {
            if (childNode.Attributes.All(x => x.Name != "style"))
                return;
            var styleAttribute = childNode.Attributes.Where(x => x.Name == "style").Select(x => x.Value).FirstOrDefault();
            if (styleAttribute == null) return;

            var styles = styleAttribute.Split(';').ToList();
            styles.Remove("");
            var count = 0;
            foreach (var item in styles)
            {

                var style = item.Split(":");

                if (style.Length == 2)
                {
                    switch (style[0].Trim())
                    {
                        case "font-family":
                            if (style[1].Trim() == "&quot")
                            {
                                if (styles.Count > count + 1)
                                {
                                    var fontName = styles[count + 1].Replace("&quot", "");
                                    printObject.Font = new Font(fontName, printObject.Font.Size, printObject.Font.Style);
                                }
                            }
                            else
                                printObject.Font = new Font(style[1].Trim(), printObject.Font.Size, printObject.Font.Style);
                            break;

                        case "font-size":
                            printObject.Font = new Font(printObject.Font.Name, GetPixel(style[1].Trim()), printObject.Font.Style);
                            break;

                        case "font-weight":
                            if (style[1].Trim() == "bolder")
                                _fontStyle |= FontStyle.Bold;
                            break;

                        case "text-align":
                            printObject.StringFormat.Alignment = style[1].Trim() switch
                            {
                                "center" => StringAlignment.Center,
                                "right" => StringAlignment.Far,
                                _ => StringAlignment.Near,
                            };
                            break;

                    }
                }
                count++;
            }

        }

        private void GetPrintPropertiesFromTags(HtmlDocumentNode childNode, Print printObject)
        {
            switch (childNode.Name)
            {
                case "font":
                    if (childNode.Attributes.Any(x => x.Name == "face"))
                    {
                        var fontName = childNode.Attributes.Where(x => x.Name == "face").Select(x => x.Value).FirstOrDefault();
                        if (fontName == null) return;
                        printObject.Font = new Font(fontName, printObject.Font.Size, printObject.Font.Style);
                    }
                    if (childNode.Attributes.Any(x => x.Name == "size"))
                    {
                        var rowFontSize = childNode.Attributes.Where(x => x.Name == "size").Select(x => x.Value).FirstOrDefault();
                        if (rowFontSize == null) return;
                        var fontSize = GetPixel(Convert.ToInt32(rowFontSize));
                        printObject.Font = new Font(printObject.Font.Name, fontSize, printObject.Font.Style);
                    }
                    break;
                case "b":
                    _fontStyle |= FontStyle.Bold;
                    break;
                case "i":
                    _fontStyle |= FontStyle.Italic;
                    break;
                case "u":
                    _fontStyle |= FontStyle.Underline;
                    break;
                case "img":
                    if (childNode.Attributes.Any(x => x.Name == "src"))
                    {
                        var imageRow = childNode.Attributes.Where(x => x.Name == "src").Select(x => x.Value).FirstOrDefault();
                        if (imageRow == null) return;
                        imageRow = imageRow.Replace("data:image/png;base64,", "").Replace("data:image/jpeg;base64,", "").Replace("data:image/bmp;base64,", "");
                        using var ms = new MemoryStream(Convert.FromBase64String(imageRow));
                        printObject.Image = Image.FromStream(ms);
                        printObject.DataType = 2;
                    }
                    break;
                case "p":
                    if (childNode.Attributes.Any(x => x.Name == "style"))
                    {
                        var justifyStyle = childNode.Attributes.Where(x => x.Name == "style").Select(x => x.Value)
                            .FirstOrDefault();
                        if (justifyStyle == null) return;
                        if (justifyStyle.Contains("text-align: center;"))
                            printObject.StringFormat.Alignment = StringAlignment.Center;
                        else if (justifyStyle.Contains("text-align: right;"))
                            printObject.StringFormat.Alignment = StringAlignment.Far;

                    }
                    break;
            }
        }

        private static float GetPixel(int fontSize)
        {
            var result = fontSize switch
            {
                1 => 8.3f,
                2 => 10.5f,
                3 => 13,
                4 => 14.5f,
                5 => 17.5f,
                6 => 24,
                7 => 34,
                _ => 12,
            };

            return result;

        }

        private static float GetPixel(string fontSize)
        {
            var result = fontSize.Trim() switch
            {
                "x-small" => 8.3f,
                "small" => 10.5f,
                "medium" => 13,
                "large" => 14.5f,
                "x-large" => 17.5f,
                "xx-large" => 24,
                "xxx-large" => 34,
                _ => 12,
            };

            return result;
        }
    }
}
