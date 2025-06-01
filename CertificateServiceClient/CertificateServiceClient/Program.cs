using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using CertificateServiceClient;

var text = File.ReadLines("C:\\Users\\Veljko Veljovic\\Desktop\\AWS.txt").ToList();

var pubslichCert = new PublishCertificate(new AmazonSQSClient(text[0], text[1], RegionEndpoint.USEast1));

var model = new CertificatesModel("Nemanja", "Antic", "Management", 3.3);

await pubslichCert.Publish(model);