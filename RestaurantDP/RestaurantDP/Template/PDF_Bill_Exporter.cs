using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
        public PDF_Bill_Exporter()
        {
            _extension = "pdf";
        }

        public override void ExportData()
        {
            Console.WriteLine("Exporting the bill to a PDF file.");
            try
            {

                System.IO.FileStream fs = new FileStream($"{_fullPath}.{_extension}", FileMode.Create);

                // Create an instance of the document class which represents the PDF document itself.  
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                // Create an instance to the PDF file by creating an instance of the PDF   
                // Writer class using the document and the filestrem in the constructor.  

                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                // Open the document to enable you to write to the document  
                document.Open();
                // Add a simple and wellknown phrase to the document in a flow layout manner  
                document.Add(new Paragraph(_data));
                // Close the document  
                document.Close();
                // Close the writer instance  
                writer.Close();
                // Always close open filehandles explicity  
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }
        
    }
}
