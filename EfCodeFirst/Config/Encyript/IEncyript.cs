using System.Threading.Tasks;

namespace EfCodeFirst.Config.Encyript
{
    public interface IEncyript
    {
        string Encrypt(string clearText, string EncryptionKey);
        string Decrypt(string cipherText, string EncryptionKey);
    }
}
