using EmpireQms.PrintService.Api.Application.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;

namespace EmpireQms.PrintService.Api.Application.Services
{

    public class EmpirePrintService
    {
        PrintDocument PrintDocument;

        List<Print> PrintObjects = null;
        int PrintWidth = 220;

        public EmpirePrintService(List<Print> _PrintObjects = null)
        {
            PrintObjects = _PrintObjects;
            Start();
        }


        private void Start()
        {
            PrintDocument = new PrintDocument();
            PrintDocument.DocumentName = new Random().NextDouble().ToString();
            SetRealPositions();
            PrintDocument.PrintPage += PrintDocument_PrintPage;
            //PrintDocument.DefaultPageSettings.PaperSize = new PaperSize("MyPaper", PrintWidth, GetPageHeight());

            PrintDocument.Print();

        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            foreach (var item in PrintObjects)
            {
                float ObjectXPosition = 0;

                ObjectXPosition = SetXStrartPositon(item, ObjectXPosition);

                CreatePrintLines(e, item, ObjectXPosition);
            }
            e.HasMorePages = false;
        }

        private void CreatePrintLines(PrintPageEventArgs e, Print item, float ObjectXPosition)
        {
            switch ((DataType)item.DataType)
            {
                case DataType.str:
                    string MainPrintingLine = item.Name;
                    int RowWidth = PrintWidth;

                    do
                    {
                        SizeF TextSize = e.Graphics.MeasureString(MainPrintingLine, item.Font);

                        RowWidth = Convert.ToInt32(TextSize.Width);
                        int PrintCharCount = RowWidth == 0 ? 0 : MainPrintingLine.Length * PrintWidth / RowWidth;
                        if (MainPrintingLine.Length <= PrintCharCount)
                            PrintCharCount = MainPrintingLine.Length;
                        string SubPrintingLine = MainPrintingLine.Substring(0, PrintCharCount);
                        if (RowWidth > PrintWidth)
                        {
                            if (SubPrintingLine.Contains(' '))
                            {
                                var test = SubPrintingLine.Split(" ");
                                SubPrintingLine = SubPrintingLine.Remove(SubPrintingLine.Length - test.Last().Length, test.Last().Length);

                            }
                            MainPrintingLine = MainPrintingLine.Remove(0, SubPrintingLine.Length);
                        }

                        e.Graphics.DrawString(SubPrintingLine, item.Font, Brushes.Black, new PointF(ObjectXPosition, item.RealFontSize), item.StringFormat);
                        if (RowWidth > PrintWidth)
                            PrintObjects.Select(x => x.RealFontSize += TextSize.Height).ToList();

                    } while (RowWidth > PrintWidth);

                    break;
                case DataType.pic:
                    if (item.Image != null)
                        e.Graphics.DrawImage(item.Image, new Point(Convert.ToInt32(ObjectXPosition), Convert.ToInt32(item.RealFontSize)));
                    break;
                default:
                    break;
            }
        }

        private float SetXStrartPositon(Print item, float ObjectXPosition)
        {
            switch (item.StringFormat.Alignment)
            {
                case StringAlignment.Center:
                    if (item.DataType == 2)
                    {
                        if (item.Image != null)
                            ObjectXPosition = (PrintWidth - 15) / 2 - item.Image.Width / 2;
                    }
                    else
                        ObjectXPosition = PrintWidth / 2;

                    break;
                case StringAlignment.Far:
                    if (item.DataType == 2)
                    {
                        if (item.Image != null)
                            ObjectXPosition = PrintWidth - 15 - item.Image.Width;
                    }
                    else
                        ObjectXPosition = PrintWidth;
                    break;
                default:
                    break;
            }

            return ObjectXPosition;
        }

        private void SetRealPositions()
        {

            if (PrintObjects == null || PrintObjects.Count() < 1)
                return;

            for (int i = 0; i < PrintObjects.Count(); i++)
            {
                if (i + 1 < PrintObjects.Count())
                    switch ((DataType)PrintObjects[i].DataType)
                    {
                        case DataType.str:
                            PrintObjects[i + 1].RealFontSize = PrintObjects[i].RealFontSize + PrintObjects[i].Font.Height;
                            break;
                        case DataType.pic:
                            PrintObjects[i + 1].RealFontSize = PrintObjects[i].RealFontSize + (PrintObjects[i].Image == null ? 0 : PrintObjects[i].Image.Height);
                            break;
                        default:
                            break;
                    }
            }
        }





        private void Test1()
        {
            //_file = File.Open("/dev/usb/lp0", FileMode.Open);

            while (true)
            {

                Process cmd = new Process();
                cmd.StartInfo.FileName = "/bin/bash";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("lpstat -R");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine("\n" + cmd.StandardOutput.ReadToEnd());

                Thread.Sleep(3000);
            }

        }
        private void Test2()
        {
            //PrintQueueCollection printQueues = null;
            //// Get a list of available printers.
            //try
            //{
            //    PrintServer printServer = new PrintServer();
            //    printQueues = printServer.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local });
            //    PrintQueue printQueue1 = printQueues.FirstOrDefault(x => x.Name == "SANEI SK1-21S-UNI-US");
            //        printQueue1.Refresh();
            //    if (printQueue1 == null) return;

            //    while (true)
            //    {

            //        var deneme = printQueue1.GetPrintJobInfoCollection();

            //        if (printQueue1.QueueStatus != laststatus)
            //        {
            //            Console.WriteLine("\n" + printQueue1.QueueStatus.ToString());
            //            laststatus = printQueue1.QueueStatus;

            //        }




            //        foreach (var item in deneme)
            //        {
            //            Console.WriteLine(item.JobIdentifier + " " + item.JobName);
            //        }
            //        Thread.Sleep(300);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}

        }
        private int GetPageHeight()
        {
            int result = 0;
            if (PrintObjects == null || PrintObjects.Count() < 1)
                return 0;

            Print LastObjest = PrintObjects[PrintObjects.Count() - 1];
            switch ((DataType)LastObjest.DataType)
            {
                case DataType.str:
                    result = Convert.ToInt32(LastObjest.RealFontSize) + LastObjest.Font.Height;
                    break;
                case DataType.pic:
                    result = Convert.ToInt32(LastObjest.RealFontSize) + (LastObjest.Image == null ? 0 : LastObjest.Image.Height);
                    break;
                default:
                    break;
            }

            return result;
        }
    }


}
