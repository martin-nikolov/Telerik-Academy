using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

class CreatingPDF
{
    static void Main()
    {
        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream("asd.pdf", FileMode.OpenOrCreate, FileAccess.ReadWrite));
        document.Open();

        using (document)
        {
            PdfPTable table = new PdfPTable(4);
            table.TotalWidth = 100;

            BaseFont baseFont = BaseFont.CreateFont("times.ttf", BaseFont.IDENTITY_H, true);
            Font black = new Font(baseFont, 75f, 0, BaseColor.BLACK);

            String card = "";
            char color = ' ';

            for (int i = 2; i <= 14; i++)
            {
                // ...

                for (int j = 1; j <= 4; j++)
                {
                    switch (j)
                    {
                        case 1:
                            color = '♣';
                            table.AddCell(new Paragraph(card + color + " ", black));
                            break;

                        // ...
                    }
                }
            }

            document.Add(table);
        }
    }
}