using Machine.Data.api.Entity;
using Machine.Data.api.Properties;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using SharpCompress.Common;
using System.Runtime.InteropServices;

namespace Machine.Data.api.Services
{
    public class MachineDataFromDatabase : IMachineDataFromDatabase
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<Asset> _mongoCollection;
        string filePath;
        public MachineDataFromDatabase(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["Database:ConnectionString"]);
            var _MongoDatabase = _mongoClient.GetDatabase(_configuration["Database:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<Asset>(_configuration["Database:CollectionName"]);
             filePath = @"C:\Users\Badg_Che\source\repos\Software design and architecture problem\Machine.Data.api\Resources\matrix.txt";
          
       
           
        }
        public  async Task  InsertMachineData()
        {
            List<string> machineData=new List<string>();  
            if (filePath.EndsWith(".txt"))
            {

                string[] machines = File.ReadAllLines(filePath);

                foreach (string machine in machines)
                {
                    machineData = machine.Split(",").ToList();
                    Asset asset = new Asset()
                    {
                        MachineName = machineData[0].Trim(),
                        AssetName = machineData[1].Trim(),
                        SeriesNumber = machineData[2].Trim()

                    };

                     await _mongoCollection.InsertOneAsync(asset);

                }
            }
            else
            {
                string json = File.ReadAllText(filePath);
                var allMachineData = JsonConvert.DeserializeObject<List<Asset>>(json);
                await _mongoCollection.InsertManyAsync(allMachineData);   
            }
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

        public async Task DeleteMachineData()
        {


            await _mongoCollection.DeleteManyAsync(asset => true);
        }
    }
}
