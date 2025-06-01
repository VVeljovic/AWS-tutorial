namespace CertificateServiceClient
{
    public interface IPublishCertificate
    {
        public Task Publish(CertificatesModel certificate);
    }
}
