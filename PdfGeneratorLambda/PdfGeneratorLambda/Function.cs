using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.S3;
using Amazon.S3.Model;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Text.Json;


[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace PdfGeneratorLambda;

public class Function
{
    private readonly IAmazonS3 s3Client; 
    public Function()
    {
        s3Client = new AmazonS3Client();
    }

    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        foreach(var message in evnt.Records)
        {
            await ProcessMessageAsync(message, context);
        }
    }

    private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed message {message.Body}");

        var certificate = JsonSerializer.Deserialize<CertificatesModel>(message.Body);
        using var stream = GeneratePdfInMemory(certificate);

        var request = new PutObjectRequest
        {
            BucketName = "pdf-certificates-veljko-test",
            Key = $"{certificate.FirstName}-{certificate.LastName}-{certificate.CourseName}",
            InputStream = stream,
            ContentType = "application/pdf"
        };
        await s3Client.PutObjectAsync(request);
    }

    public static MemoryStream GeneratePdfInMemory(CertificatesModel model)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var pdfBytes =  Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Size(PageSizes.A4);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(20).FontFamily("Times New Roman"));

                page.Header().Text("Certificate of Completion")
                    .FontSize(36)
                    .Bold()
                    .FontColor(Colors.Blue.Medium)
                    .AlignCenter();

                page.Content().PaddingVertical(50).Column(column =>
                {
                    column.Item().AlignCenter().Text("This certificate is proudly presented to").FontSize(20);
                column.Item().PaddingVertical(15).AlignCenter().Text($"{model.FirstName} {model.LastName}").FontSize(30).Bold();
                    column.Item().AlignCenter().Text("for successfully completing the course:").FontSize(20);
                    column.Item().PaddingBottom(10).AlignCenter().Text(model.CourseName).FontSize(26).Bold();
                    column.Item().AlignCenter().Text($"Date: {DateTime.Today:MMMM dd, yyyy}").FontSize(16);
                    column.Item().PaddingTop(50).AlignRight().Text("____________________").FontSize(20);
                    column.Item().AlignRight().Text("Instructor's Signature").FontSize(16);
                });

                page.Footer().AlignCenter().Text("Congratulations!").FontSize(18).Italic().FontColor(Colors.Green.Darken1);
            });
        }).GeneratePdf();

        return new MemoryStream(pdfBytes);
    }

}