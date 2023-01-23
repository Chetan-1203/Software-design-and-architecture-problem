using Machine.Data.api.Entity;

namespace Machine.Data.api.Services
{
    public interface IMachineDataFromFile
    {
        IEnumerable<Asset> AssetNamesByMachineType(string filepath ,string machineType);
        IEnumerable<Asset> MachineTypesByAssestName(string filepath, string assetName);
        IEnumerable<Asset>MachineTypesByLatestSeriesOfAsset(string filepath);
        IEnumerable<Asset>GetAllMachineData(string filepath);

       

    }
}
