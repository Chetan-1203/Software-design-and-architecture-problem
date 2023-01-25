using Machine.Data.api.Entity;

namespace Machine.Data.Server.Services
{
    public interface IMachineDataFromFile
    {
        Task<IEnumerable<Asset>> GetAllMachineData(string filepath);
        Task<IEnumerable<Asset>> GetAssetsByMachineType(string filepath ,string machineType);
        Task<IEnumerable<Asset>> GetMachineByAssetType(string filepath ,string assetType);
        Task<IEnumerable<Asset>> GetLatestVersion(string filepath);


    }
}
