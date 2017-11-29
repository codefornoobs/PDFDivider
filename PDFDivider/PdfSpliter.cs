using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

namespace PDFDivider
{
    public class PdfSpliter
    {

        private PdfReader _pdfDocument;
        private string _inputFilePath;
        private string _outputFilePath;
        private int _numberOfSlipts;
        private Document sourceDocument;
        private PdfCopy pdfCopyProvider;
        private PdfImportedPage importedPage;

        public PdfSpliter()
        {
            _numberOfSlipts = 1;
        }
        public void Load(string path)
        {
            _inputFilePath = path;
            _pdfDocument = new PdfReader(path);
        }

        public void SplitDocumentInto(string outputPath, int numberPages)
        {
            if (numberPages % 2 != 0)
            {
                throw new Exception("Number of pages to spilt must be even");
            }

            _outputFilePath = outputPath;

            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + _outputFilePath);

            int lastPageSlipt = 1;

            for (int i = 1; i <= _pdfDocument.NumberOfPages; i++)
            {
                if (i % numberPages == 0 || i == _pdfDocument.NumberOfPages)
                {
                    JoinPdfPages(lastPageSlipt, i);
                    lastPageSlipt = i + 1;
                }
            }




            _pdfDocument.Close();


        }

        private void JoinPdfPages(int startPage, int endPage)
        {
            sourceDocument = new Document(_pdfDocument.GetPageSizeWithRotation(1));


            pdfCopyProvider = new PdfCopy(sourceDocument,
                new System.IO.FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + _outputFilePath + "\\" + _numberOfSlipts + "_" + _inputFilePath, System.IO.FileMode.Create));

            sourceDocument.Open();

            for (int i = startPage; i <= endPage; i++)
            {
                importedPage = pdfCopyProvider.GetImportedPage(_pdfDocument, i);
                pdfCopyProvider.AddPage(importedPage);

            }

            sourceDocument.Close();
            _numberOfSlipts++;
        }
    }
}
