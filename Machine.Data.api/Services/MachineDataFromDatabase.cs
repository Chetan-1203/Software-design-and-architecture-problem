using Machine.Data.api.Entity;
using MongoDB.Driver;
using SharpCompress.Common;

namespace Machine.Data.api.Services
{
    public class MachineDataFromDatabase : IMachineDataFromDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<Asset> _mongoCollection;
        public MachineDataFromDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["Database:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["Database:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<Asset>(_configuration["Database:CollectionName"]);
        }
        public async Task<IEnumerable<Asset>> AssetNamesByMachineType(string machineType)
        {
           if(machineType == null)
            {
                throw new ArgumentNullException(nameof(machineType));   
            }

            return await _mongoCollection.Find(asset => asset.MachineName.Equals(machineType)).ToListAsync();

        }

        public async Task<IEnumerable<Asset>> GetAllMachineData()
        {
            return await _mongoCollection.Find(asset => true).ToListAsync();
        }

        public async Task<IEnumerable<Asset>> MachineTypesByAssestName(string assetName)
        {
            if (assetName == null)
            {
                throw new ArgumentNullException(nameof(assetName));
            }

            return await _mongoCollection.Find(asset => asset.AssetName.Equals(assetName)).ToListAsync();
        }

        public async Task<IEnumerable<Asset>> MachineTypesByLatestSeriesOfAsset()
        {
            var assetData = await GetAllMachineData();

            Dictionary<string, Asset> latestVersionOfMachine = new Dictionary<string, Asset>();

            List<string> machineType = new List<string>();


            if (assetData != null)
                foreach (var asset in assetData)
                {
                    if (!latestVersionOfMachine.ContainsKey(asset.AssetName))
                    {
                        var machineNameByAssetName = await _mongoCollection.Find(assettype => assettype.AssetName.Equals(asset.AssetName)).ToListAsync();//(List<Asset>)MachineTypesByAssestName(filepath, asset.AssetName);
                        machineNameByAssetName = machineNameByAssetName.OrderByDescending(asset => int.Parse(asset.SeriesNumber.Substring(1))).ToList();

                        if (!machineType.Contains(machineNameByAssetName[0].MachineName))
                        {
                            latestVersionOfMachine.Add(machineNameByAssetName[0].AssetName, machineNameByAssetName[0]);
                            for (int j = 1; j < machineNameByAssetName.Count; j++)
                            {
                                machineType.Add(machineNameByAssetName[j].MachineName);
                            }


                        }
                    }
                }

            return latestVersionOfMachine.Values.ToList();
        }

        
    }
}
