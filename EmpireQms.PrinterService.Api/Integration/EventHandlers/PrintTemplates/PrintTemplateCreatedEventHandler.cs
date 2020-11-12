using EmpireQms.Domain.Core.Bus;
using EmpireQms.Printer.Api.Domain.Models;
using EmpireQms.PrintService.Api.Application.Services;
using EmpireQms.PrintService.Api.Domain;
using EmpireQms.PrintService.Api.Integration.Events.PrintTemplates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EmpireQms.PrintService.Api.Integration.EventHandlers.PrintTemplates
{
    public class PrintTemplateCreatedEventHandler : IEventHandler<PrintTemplateCreatedEvent>
    {

        private readonly IUnitOfWork _unitOfWork;
        public PrintTemplateCreatedEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task Handle(PrintTemplateCreatedEvent @event)
        {
            //PrintTemplate printTemplate = @event.PrintTemplate;
            //HtmlDocument htmlDocument = new HtmlDocument(printTemplate.PrintText);
            //htmlDocument.Parse();

            //List<PrintObject> PrintList = new List<PrintObject>();
            //foreach (var ChildNode in htmlDocument.RootNode.ChildNodes)
            //{
            //    fontStyle = FontStyle.Regular;
            //    PrintObject printObject = new PrintObject()
            //    {
            //        Name = ChildNode.InnerText.Replace("&nbsp;", " "),
            //        DataType = 1
            //    };

            //    ConvertToPrintObject(ChildNode, printObject);
            //    printObject.Font = new Font(printObject.Font, fontStyle); 
            //    PrintList.Add(printObject);

            //};

           
            var createdPrintTemplate = new PrintTemplate
            {
                 PrintText=@event.PrintTemplate.PrintText
            };

            _unitOfWork.PrintTemplates.Create(createdPrintTemplate);

            EmpireHtmlParserService htmlParserService = new EmpireHtmlParserService(@event.PrintTemplate.PrintText);

            EmpirePrintService printing = new EmpirePrintService(htmlParserService.Parse());
            return Task.CompletedTask;
        }

        //private void ConvertToPrintObject(HtmlDocumentNode childNode, PrintObject printObject)
        //{
        //    if (childNode == null || printObject == null) return;

        //    GetPrintPropertiesfromTags(childNode, printObject);
        //    GetPrintPropertiesFromAttributes(childNode, printObject);

        //    foreach (var item in childNode.ChildNodes)
        //        ConvertToPrintObject(item, printObject);

        //}

        //private void GetPrintPropertiesFromAttributes(HtmlDocumentNode childNode, PrintObject printObject)
        //{
        //    if (childNode.Attributes.Any(x => x.Name == "style"))
        //    {
        //        string StyleAttribute = childNode.Attributes.FirstOrDefault(x => x.Name == "style").Value;
        //        var Styles = StyleAttribute.Split(';').ToList();
        //        Styles.Remove("");
        //        int count = 0;
        //        foreach (var item in Styles)
        //        {

        //            string[] style = item.Split(":");

        //            if (style.Length == 2)
        //            {
        //                switch (style[0].Trim())
        //                {
        //                    case "font-family":
        //                        if (style[1].Trim() == "&quot")
        //                        {
        //                            if (Styles.Count() > count + 1)
        //                            {
        //                                string fontname = Styles[count + 1].Replace("&quot", "");
        //                                printObject.Font = new Font(fontname, printObject.Font.Size, printObject.Font.Style);
        //                            }
        //                        }
        //                        else
        //                            printObject.Font = new Font(style[1].Trim(), printObject.Font.Size, printObject.Font.Style);
        //                        break;

        //                    case "font-size":
        //                        printObject.Font = new Font(printObject.Font.Name, GetPixel(style[1].Trim()), printObject.Font.Style);
        //                        break;

        //                    case "font-weight":
        //                        if (style[1].Trim() == "bolder")
        //                            fontStyle |= FontStyle.Bold;
        //                        break;

        //                    case "text-align":
        //                        if (style[1].Trim() == "center")
        //                            printObject.StringFormat.Alignment = StringAlignment.Center;
        //                        else if (style[1].Trim() == "far")
        //                            printObject.StringFormat.Alignment = StringAlignment.Far;

        //                        break;

        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        count++;

        //    }
        //}

        //private void GetPrintPropertiesfromTags(HtmlDocumentNode childNode, PrintObject printObject)
        //{
        //    switch (childNode.Name)
        //    {
        //        case "font":
        //            if (childNode.Attributes.Any(x => x.Name == "face"))
        //            {
        //                string fontName = childNode.Attributes.FirstOrDefault(x => x.Name == "face").Value;
        //                printObject.Font = new Font(fontName, printObject.Font.Size, printObject.Font.Style);

        //            }
        //            if (childNode.Attributes.Any(x => x.Name == "size"))
        //            {
        //                float fontSize = GetPixel(Convert.ToInt32(childNode.Attributes.FirstOrDefault(x => x.Name == "size").Value));
        //                printObject.Font = new Font(printObject.Font.Name, fontSize, printObject.Font.Style);
        //            }
        //            break;
        //        case "b":
        //            fontStyle |= FontStyle.Bold;
        //            break;
        //        case "i":
        //            fontStyle |= FontStyle.Italic;
        //            break;
        //        case "u":
        //            fontStyle |= FontStyle.Underline;
        //            break;
        //        case "img":
        //            if (childNode.Attributes.Any(x => x.Name == "src"))
        //            {
        //                string imageStr = childNode.Attributes.FirstOrDefault(x => x.Name == "src").Value.Replace("data:image/png;base64,", "").Replace("data:image/jpeg;base64,", "").Replace("data:image/bmp;base64,", "");
        //                using MemoryStream ms = new MemoryStream(Convert.FromBase64String(imageStr));
        //                printObject.Image = Image.FromStream(ms);
        //                printObject.DataType = 2;
        //            }
        //            break;
        //        case "p":
        //            if (childNode.Attributes.Any(x => x.Name == "style"))
        //            {
        //                string justyfStyle = childNode.Attributes.FirstOrDefault(x => x.Name == "style").Value;

        //                if (justyfStyle.Contains("text-align: center;"))
        //                    printObject.StringFormat.Alignment = StringAlignment.Center;
        //                else if (justyfStyle.Contains("text-align: right;"))
        //                    printObject.StringFormat.Alignment = StringAlignment.Far;

        //            }

        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private float GetPixel(int FontSize)
        //{
        //    float result = 10;
        //    switch (FontSize)
        //    {
        //        case 1:
        //            result = 8;
        //            break;
        //        case 2:
        //            result = 10.5f;
        //            break;
        //        case 3:
        //            result = 12.5f;
        //            break;
        //        case 4:
        //            result = 14.2f;
        //            break;
        //        case 5:
        //            result = 17.5f;
        //            break;
        //        case 6:
        //            result = 24;
        //            break;
        //        case 7:
        //            result = 34;
        //            break;
        //        default:
        //            break;
        //    }

        //    return result;
        //}

        //private float GetPixel(string FontSize)
        //{
        //    float result = 10;
        //    switch (FontSize.Trim())
        //    {
        //        case "x-small":
        //            result = 8.3f;
        //            break;
        //        case "small":
        //            result = 10.5f;
        //            break;
        //        case "medium":
        //            result = 13;
        //            break;
        //        case "large":
        //            result = 14.5f;
        //            break;
        //        case "x-large":
        //            result = 17.5f;
        //            break;
        //        case "xx-large":
        //            result = 24;
        //            break;
        //        case "xxx-large":
        //            result = 34;
        //            break;
        //        default:
        //            break;
        //    }

        //    return result;
        //}
    }
}
