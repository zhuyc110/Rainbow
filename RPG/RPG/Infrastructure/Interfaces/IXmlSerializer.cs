namespace RPG.Infrastructure.Interfaces
{
    public interface IXmlSerializer
    {
        T DeSerialize<T>(string filePath) where T : class;
        void Serialize<T>(T target);
    }
}