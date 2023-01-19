using Machine.Data.api.Entity;

namespace Machine.Data.api.Services
{
    public class MachineDataFromFile : IMachineDataFromFile
    {

        private readonly FileDataReader FileDataReader;
        public MachineDataFromFile(FileDataReader fileDataReader)
        {
            FileDataReader = fileDataReader;
        }
        public IEnumerable<Asset> AssetNamesByMachineType(string filepath, string machineType)
        {
            var assetData = FileDataReader.GetFileData(filepath);
            if (assetData != null)
            {
                return assetData.Where(asset => asset.MachineName.Equals(machineType)).ToList();

            }

            return new List<Asset>();

        }

        public IEnumerable<Asset> MachineTypesByAssestName(string filepath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Asset> MachineTypesByLatestSeriesOfAsset(string filepath)
        {
            throw new NotImplementedException();
        }
    }
}
