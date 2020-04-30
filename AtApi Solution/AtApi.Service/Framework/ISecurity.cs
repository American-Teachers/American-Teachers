namespace AtApi.Service.Framework
{
    public interface ISecurity
    {
        string Encrypt(string key, string toEncrypt, bool useHashing = true);
        string Decrypt(string key, string cipherString, bool useHashing = true);
    }
}
