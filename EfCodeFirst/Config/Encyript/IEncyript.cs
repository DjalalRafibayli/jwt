namespace EfCodeFirst.Config.Encyript
{
    public interface IEncyript
    {
        string Encyription(string text,string key);
        string Decyription(string cipherText, string key);
    }
}
