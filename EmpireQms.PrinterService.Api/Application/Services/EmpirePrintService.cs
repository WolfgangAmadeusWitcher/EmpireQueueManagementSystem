using EmpireQms.PrintService.Api.Application.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace EmpireQms.PrintService.Api.Application.Services
{

    public class EmpirePrintService
    {
        private PrintDocument _printDocument;

        private readonly List<Print> _printObjects;
        private const int PrintWidth = 220;

        public EmpirePrintService(List<Print> printObjects = null)
        {
            _printObjects = printObjects;
            Start();
        }


        private void Start()
        {
            _printDocument = new PrintDocument();
            SetRealPositions();
            _printDocument.PrintPage += PrintDocument_PrintPage;
            _printDocument.Print();

        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            foreach (var item in _printObjects)
            {
                float objectXPosition = 0;

                objectXPosition = SetXStartPosition(item, objectXPosition);

                CreatePrintLines(e, item, objectXPosition);
            }
            e.HasMorePages = false;
        }

        private void CreatePrintLines(PrintPageEventArgs e, Print item, float objectXPosition)
        {
            if (e?.Graphics == null) return;
            switch ((DataType)item.DataType)
            {
                case DataType.Str:
                    var mainPrintingLine = item.Name;
                    int rowWidth;

                    do
                    {
                        var textSize = e.Graphics.MeasureString(mainPrintingLine, item.Font);

                        rowWidth = Convert.ToInt32(textSize.Width);
                        var printCharCount = rowWidth == 0 ? 0 : mainPrintingLine.Length * PrintWidth / rowWidth;
                        if (mainPrintingLine.Length <= printCharCount)
                            printCharCount = mainPrintingLine.Length;
                        var subPrintingLine = mainPrintingLine.Substring(0, printCharCount);
                        if (rowWidth > PrintWidth)
                        {
                            if (subPrintingLine.Contains(' '))
                            {
                                var test = subPrintingLine.Split(" ");
                                subPrintingLine = subPrintingLine.Remove(subPrintingLine.Length - test.Last().Length, test.Last().Length);

                            }
                            mainPrintingLine = mainPrintingLine.Remove(0, subPrintingLine.Length);
                        }

                        e.Graphics.DrawString(subPrintingLine, item.Font, Brushes.Black, new PointF(objectXPosition, item.RealFontSize), item.StringFormat);
                        if (rowWidth > PrintWidth)
                            _printObjects.ForEach(x => x.RealFontSize += textSize.Height);

                    } while (rowWidth > PrintWidth);

                    break;
                case DataType.Pic:
                    if (item.Image != null)
                        e.Graphics.DrawImage(item.Image, new Point(Convert.ToInt32(objectXPosition), Convert.ToInt32(item.RealFontSize)));
                    break;

            }
        }

        private static float SetXStartPosition(Print item, float objectXPosition)
        {
            switch (item.StringFormat.Alignment)
            {
                case StringAlignment.Center:
                    if (item.DataType == 2)
                    {
                        if (item.Image != null)
                            objectXPosition = (PrintWidth - 15) / 2 - item.Image.Width / 2;
                    }
                    else
                        objectXPosition = (float)PrintWidth / 2;

                    break;
                case StringAlignment.Far:
                    if (item.DataType == 2)
                    {
                        if (item.Image != null)
                            objectXPosition = PrintWidth - 15 - item.Image.Width;
                    }
                    else
                        objectXPosition = PrintWidth;
                    break;

            }

            return objectXPosition;
        }

        private void SetRealPositions()
        {
            if (_printObjects == null || !_printObjects.Any())
                return;

            for (var i = 0; i < _printObjects.Count; i++)
            {
                if (i + 1 < _printObjects.Count)

                    _printObjects[i + 1].RealFontSize = (DataType)_printObjects[i].DataType switch
                    {
                        DataType.Str => _printObjects[i].RealFontSize + _printObjects[i].Font.Height,
                        DataType.Pic =>3+ _printObjects[i].RealFontSize + (_printObjects[i].Image == null ? 0 : _printObjects[i].Image.Height),
                        _ => _printObjects[i].RealFontSize,
                    };

                //    switch ((DataType)_printObjects[i].DataType)
                //{
                //    case DataType.Str:
                //        _printObjects[i + 1].RealFontSize = _printObjects[i].RealFontSize + _printObjects[i].Font.Height;
                //        break;
                //    case DataType.Pic:
                //        _printObjects[i + 1].RealFontSize = _printObjects[i].RealFontSize + (_printObjects[i].Image == null ? 0 : _printObjects[i].Image.Height);
                //        break;

                //}
            }
        }

    }

}
