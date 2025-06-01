using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using CertificateServiceClient;

while (true)
{
    Console.WriteLine("Enter candidate's first name");
    var name = Console.ReadLine();

    Console.WriteLine("Enter candidate's last name");
    var lastName =  Console.ReadLine();

    Console.WriteLine("Enter course name");
    var courseName = Console.ReadLine();

    var secrets = File.ReadLines("C:\\Users\\Veljko Veljovic\\Desktop\\AWS.txt")
        .ToList();

    var pubslichCert = new PublishCertificate(new AmazonSQSClient(secrets[0],
        secrets[1],
        RegionEndpoint.USEast1));

    var model = new CertificatesModel(name, lastName, courseName);

    await pubslichCert.Publish(model);
}