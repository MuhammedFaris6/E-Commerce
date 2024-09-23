using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace E_Commerce.Application.NewFolder
{
    internal class Class1
    {

    }
    private string ExtractTextFromPdf(string pdfPath)

    {

        StringBuilder textBuilder = new StringBuilder();

        try

        {

            using (var document = PdfDocument.Open(pdfPath))

            {

                foreach (var page in document.GetPages())

                {

                    var text = page.Text;

                    textBuilder.Append(text);

                }

            }

        }

        catch (Exception ex)

        {

            Console.WriteLine($"Error extracting text from PDF: {ex.Message}");

        }

        return textBuilder.ToString();

    }

    // Determine file type and extract text

    string text = string.Empty;

if (file.ContentType == "application/pdf")

{

    text = ExtractTextFromPdf(filePath);

}

else if (file.ContentType.StartsWith("image"))
{

    text = ExtractTextFromImage(filePath);

}

else

{

    return BadRequest("Unsupported file type.");

}
 
}






1.Set Up the Project
a. Create a New ASP.NET Core Project
Open Visual Studio or use the .NET CLI to create a new ASP.NET Core Web API project.
Add Necessary NuGet Packages
Tesseract: For optical character recognition.
AngleSharp: For HTML parsing.
2. Create the OCR Service
Implement a service to handle image processing with Tesseract OCR.
OcrService.cs
csharpCopy codeusing System.IO;using Tesseract;
public class OcrService
{
    private readonly string _tessDataPath;
    public OcrService(string tessDataPath) { _tessDataPath = tessDataPath; }
    public string ExtractTextFromImage(Stream imageStream)
    {
        using var engine = new TesseractEngine(_tessDataPath, "eng", EngineMode.Default);
        using var img = Pix.LoadFromMemory(imageStream.ToArray());
        using var page = engine.Process(img);
        return page.GetText();
    }
}

3.Create the Parsing Service
Implement a service to parse HTML and extract specific fields like date and amount.
HtmlParsingService.cs
csharpCopy codeusing AngleSharp;using AngleSharp.Dom;using System.Threading.Tasks;
public class HtmlParsingService
{
    private readonly IConfiguration _config;
    public HtmlParsingService() { _config = Configuration.Default.WithDefaultLoader(); }
    public async Task<(string Date, string Amount)> ExtractInvoiceDataAsync(string htmlText)
    {
        var context = BrowsingContext.New(_config);
        var document = await context.ParseDocumentAsync(htmlText);
        // Replace with appropriate selectors or logicvar dateElement = document.QuerySelector(".invoice-date"); // Adjust selector as neededvar amountElement = document.QuerySelector(".invoice-amount"); // Adjust selector as neededvar date = dateElement?.TextContent ?? "Date not found";
        var amount = amountElement?.TextContent ?? "Amount not found";
        return (date, amount);
    }
}

4.Create the Controller
Implement an API controller to handle file uploads, process the image, and extract the required information.
InvoiceController.cs
csharpCopy codeusing Microsoft.AspNetCore.Http;using Microsoft.AspNetCore.Mvc;using System.IO;using System.Threading.Tasks;
[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly OcrService _ocrService;
    private readonly HtmlParsingService _htmlParsingService;
    public InvoiceController(OcrService ocrService, HtmlParsingService htmlParsingService) { _ocrService = ocrService; _htmlParsingService = htmlParsingService; }
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");
        // Extract text from image using Tesseractusing var stream = file.OpenReadStream();
        var extractedText = _ocrService.ExtractTextFromImage(stream);
        // Parse extracted text using AngleSharpvar (date, amount) = await _htmlParsingService.ExtractInvoiceDataAsync(extractedText);
        return Ok(new { Date = date, Amount = amount });
    }
}

5.Configure Services
Register the OcrService and HtmlParsingService in Program.cs or Startup.cs.
Program.cs (for .NET 6 or later)
csharpCopy codevar builder = WebApplication.CreateBuilder(args);
// Add services to the containerbuilder.Services.AddControllers();
builder.Services.AddSingleton(new OcrService(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "tessdata")));
builder.Services.AddSingleton<HtmlParsingService>();
var app = builder.Build();
// Configure the HTTP request pipeline.app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
6.Testing and Deployment
Testing: Test your API by uploading invoice images and verifying that the extracted date and amount are correct.
Deployment: Deploy the application to your preferred hosting provider (e.g., Azure, AWS, etc.).
Summary
Set Up: Create a new ASP.NET Core project and add Tesseract and AngleSharp packages.
OCR Service: Implement a service to handle OCR with Tesseract.
Parsing Service: Implement a service to parse HTML and extract specific fields using AngleSharp.
Controller: Create an API endpoint to handle file uploads, process the image, and return extracted data.
Configuration: Register services and configure the application.
Testing: Ensure everything works correctly by testing with sample invoice images.
bashCopy codedotnet new webapi - n InvoiceExtractorcd InvoiceExtractor
 
 
preprocessing
 
 
 
using System;

using System.IO;

using Tesseract;

using ImageSharp; // or your preferred library
 
class Program

{

    static void Main(string[] args)

    {

        string imagePath = "path/to/image.jpg";

        if (File.Exists(imagePath))

        {

            using (var img = Pix.LoadFromFile(imagePath))

            {

                var processedImg = PreprocessImage(img);

                string extractedText = ExtractTextFromImage(processedImg);

                Console.WriteLine("Extracted Text:");

                Console.WriteLine(extractedText);

            }

        }

        else

        {

            Console.WriteLine("File not found.");

        }

    }

    static Pix PreprocessImage(Pix img)

    {

        // Example preprocessing steps

        var grayImg = img.ConvertToGray();

        var binaryImg = grayImg.Binarize();

        var resizedImg = binaryImg.Resize(2.0); // Example resizing

        return resizedImg;

    }

    static string ExtractTextFromImage(Pix img)

    {

        using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))

        {

            using (var page = engine.Process(img))

            {

                return page.GetText();

            }

        }

    }

}

