using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Text;

namespace RestaurantDP.Template
{
    class PDF_Bill_Exporter : DataExporter
    {
            public override void ExportData()
            {
                Console.WriteLine("Exporting the bill to a PDF file.");
            try
            {
                string line = null;
                System.IO.TextReader readFile = new StreamReader("second.txt");
                int yPoint = 0;

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "TXT to PDF";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);

                //Nu imi gaseste System.Drawning care ar trebui sa fie in References.
               // XFont font = new XFont("Verdana", 20, XFontStyle.Regular);

                while (true)
                {
                    line = readFile.ReadLine();
                    if (line == null)
                    {
                        break; // TODO: might not be correct. Was : Exit While
                    }
                    else
                    {
                       // graph.DrawString(line, XFont font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        yPoint = yPoint + 40;
                    }
                }

                string pdfFilename = "txttopdf.pdf";
                pdf.Save(pdfFilename);
                readFile.Close();
                readFile = null;
                Process.Start(pdfFilename);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }
        
    }
}
