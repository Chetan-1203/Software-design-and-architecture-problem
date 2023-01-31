using Machine.Data.api.Entity;

namespace Machine.Data.api.Services
{
    public interface IMachineDataFromDatabase
    {
        Task InsertMachineData();
        Task<IEnumerable<Asset>>AssetNamesByMachineType(string machineType);
        Task<IEnumerable<Asset>> MachineTypesByAssestName(string assetName);
        Task<IEnumerable<Asset>> MachineTypesByLatestSeriesOfAsset();
        Task<IEnumerable<Asset>> GetAllMachineData();

        Task DeleteMachineData();  
    }
}
