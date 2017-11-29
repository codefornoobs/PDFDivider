using PDFDivider;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfSpliter lol = new PdfSpliter();

            lol.Load("Blogging_Course_Workbook_v2.pdf");
            lol.SplitDocumentInto("lol", 2);
        }
    }
}
