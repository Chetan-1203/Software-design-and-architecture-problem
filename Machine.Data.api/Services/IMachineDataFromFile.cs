using Machine.Data.api.Entity;

namespace Machine.Data.api.Services
{
    public interface IMachineDataFromFile
    {
        IEnumerable<Asset> AssetNamesByMachineType(string filepath ,string machineType);
        IEnumerable<Asset> MachineTypesByAssestName(string filepath);
        IEnumerable<Asset>MachineTypesByLatestSeriesOfAsset(string filepath);

       

    }
}
