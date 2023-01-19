using Machine.Data.api.Entity;
using System.Text.Json;

namespace Machine.Data.api.Services
{
    public class FileDataReader 
    {
        public  IEnumerable<Asset>? GetFileData(string filePath)
        {    
            
            List<string> machineData = new List<string>();
             List<Asset> ?allMachineData = new List<Asset>();

            if (File.Exists(filePath) && filePath.EndsWith(".txt") || filePath.EndsWith(".json"))
            {
                ;

                if (filePath.EndsWith(".txt"))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        machineData = line.Split(",").ToList();
                        Asset asset = new Asset()
                        {
                            MachineName = machineData[0],
                            AssetName = machineData[1],
                            SeriesNumber = machineData[2]

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
    }
}
