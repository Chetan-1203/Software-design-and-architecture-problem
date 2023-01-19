using Machine.Data.api.Entity;

namespace Machine.Data.api.Services
{
    public interface IFileDataReader
    {
        IEnumerable<Asset>?GetFileData(string filePath);



    }
}
