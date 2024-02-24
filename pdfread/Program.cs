using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace pdfread
{
     class Program
    {
        static void Main(string[] args)
        {

            StringBuilder sb = new StringBuilder();

            string file = @"C:\Users\venkatesh.k\Desktop\C#1233.pdf";
            using (PdfReader reader = new PdfReader(file))
            {
                for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                    text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                    sb.Append(text);
                }
            }
            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
}
