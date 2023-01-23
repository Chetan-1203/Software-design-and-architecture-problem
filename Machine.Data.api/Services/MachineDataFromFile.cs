using Machine.Data.api.Entity;
using System.Linq;
using System.Text.Json;

namespace Machine.Data.api.Services
{
    public class MachineDataFromFile : IMachineDataFromFile
    {

      
        public IEnumerable<Asset>? GetFileData(string filePath)
        {

            List<string> machineData = new List<string>();
            List<Asset>? allMachineData = new List<Asset>();

            if (File.Exists(filePath) && filePath.EndsWith(".txt") || filePath.EndsWith(".json"))
            {
                

                if (filePath.EndsWith(".txt"))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        machineData = line.Split(",").ToList();
                        Asset asset = new Asset()
                        {
                            MachineName = machineData[0].Trim(),
                            AssetName = machineData[1].Trim(),
                            SeriesNumber = machineData[2].Trim()

                        };

                        allMachineData.Add(asset);
                    }
                }
                else
                {
                    string json = File.ReadAllText(filePath);
                    allMachineData = JsonSerializer.Deserialize<List<Asset>>(json);


                }
                return allMachineData;
            }
            else
            {
                Console.WriteLine("File not found");
                return allMachineData;
            }
        }

        public IEnumerable<Asset> AssetNamesByMachineType(string filepath, string machineType)
        {
            var assetData = GetFileData(filepath);
            if (assetData != null)
            {
                return assetData.Where(asset => asset.MachineName.Equals(machineType)).ToList();

            }

            return new List<Asset>();

        }

        public IEnumerable<Asset> MachineTypesByAssestName(string filepath, string assetName)
        {
            var assetData = GetFileData(filepath);
            if (assetData != null)
            {
                return assetData.Where(asset => asset.AssetName.Equals(assetName)).ToList();

            }

            return new List<Asset>();
        }

        public IEnumerable<Asset> MachineTypesByLatestSeriesOfAsset(string filepath)
        {
            var assetData = GetFileData(filepath);
            Dictionary<string, Asset> latestVersionOfMachine = new Dictionary<string, Asset>();

            List<string> machineType = new List<string>();

          
            if (assetData != null)
                foreach (var asset in assetData)
                {
                    if (!latestVersionOfMachine.ContainsKey(asset.AssetName))
                    {
                        var machineNameByAssetName = MachineTypesByAssestName(filepath, asset.AssetName).ToList();//(List<Asset>)MachineTypesByAssestName(filepath, asset.AssetName);
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
