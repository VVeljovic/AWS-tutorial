using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;

namespace CertificateServiceClient
{
    public sealed class PublishCertificate(IAmazonSQS sqsClient) : IPublishCertificate
    {
        public async Task Publish(CertificatesModel certificate)
        {
            var serializedCertificate = JsonSerializer.Serialize(certificate);

            var messageRequest = new SendMessageRequest()
            {
                QueueUrl = Constants.QueueUrl,
                MessageBody = serializedCertificate
            };

            await sqsClient.SendMessageAsync(messageRequest);
        }
    }
}
