using Machine.Data.api.Entity;

namespace Machine.Data.Server.Services
{
    public interface IMachineDataFromDatabase
    {
        Task<IEnumerable<Asset>> GetAllMachineData();
        Task<IEnumerable<Asset>> GetAssetsByMachineType(string machineType);
        Task<IEnumerable<Asset>> GetMachineByAssetType(string assetType);
        Task<IEnumerable<Asset>> GetLatestVersion();
        Task LoadMachineData();
        Task DeleteMachineData();
    }
}
