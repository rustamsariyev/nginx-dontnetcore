using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {


        [HttpGet("{pageNumber}")]
        public FileStreamResult Get(int pageNumber)
        {
            FileStream docStream = new FileStream(@"C:\Users\ayxan\Desktop\ASPNETCoreinAction.pdf", FileMode.Open, FileAccess.Read);

            PdfLoadedDocument loadedDocument1 = new PdfLoadedDocument(docStream);

                //Creates a new document

                PdfDocument document = new PdfDocument();

                //Imports the pages from the loaded document

                document.ImportPage(loadedDocument1, pageNumber);

                MemoryStream stream = new MemoryStream();

                

                document.Save(stream);

                //If the position is not set to '0', then the PDF will be empty.

                stream.Position = 0;

                //Close the document

                loadedDocument1.Close(true);

                //Defining the ContentType for PDF file

                string contentType = "application/pdf";

                //Define the file name

                string fileName = "Output.pdf";

            //Creates a FileContentResult object by using the file contents, content type, and file name

            //return File(stream, contentType, fileName);

            /*
            GcPdfDocument doc = new GcPdfDocument();
            var fs = new FileStream(Path.Combine("Resources", "MonthlyProjectExpenseTracking.pdf"), FileMode.Open, FileAccess.Read);
            doc.Load(fs, null);
            */



            return new FileStreamResult(stream, "application/pdf");


            /*
            //Create a memory stream 

            MemoryStream stream = new MemoryStream();

            //Save the document to stream

            document.Save(stream);

            stream.Position = 0;

            //Close the document

            document.Close(true);

            //Create a file stream

            FileStream fileStream = new FileStream("Output" + pageNumber + ".pdf", FileMode.Create, FileAccess.Write);

            byte[] bytes = stream.ToArray();

            //Write bytes to file

            fileStream.Write(bytes, 0, (int)bytes.Length);

            //Dispose the streams

            stream.Dispose();

            fileStream.Dispose();
            */

            //   return Ok(document);
        }







        /*

        // GET: api/Pdf
        [HttpGet]
        public IActionResult Get()
        {
            //Load the PDF document

            FileStream docStream = new FileStream(@"C:\Users\ayxan\Desktop\ASPNETCoreinAction.pdf", FileMode.Open, FileAccess.Read);

            //Load the PDF document

            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(docStream);

            // Create a page label

            PdfPageLabel pageLabel = new PdfPageLabel();

            //Set the number style with upper case roman letters

            pageLabel.NumberStyle = PdfNumberStyle.UpperRoman;

            //Set the staring number as 1

            pageLabel.StartNumber = 1;

            loadedDocument.LoadedPageLabel = pageLabel;

            //Creating the stream object

            MemoryStream stream = new MemoryStream();

            //Save the document as stream

            loadedDocument.Save(stream);

            //If the position is not set to '0', then the PDF will be empty.

            stream.Position = 0;

            //Close the document

            loadedDocument.Close(true);

            //Defining the ContentType for PDF file

            string contentType = "application/pdf";

            //Define the file name

            string fileName = "Output.pdf";

            //Creates a FileContentResult object by using the file contents, content type, and file name

            return File(stream, contentType, fileName);
        }

        /*
        // GET: api/Pdf/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pdf
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pdf/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
    
}
    
