namespace DocumentSystem
{
    public interface IEncryptable
    {
        bool IsEncrypted { get; }

        void Encrypt();

        void Decrypt();
    }
}