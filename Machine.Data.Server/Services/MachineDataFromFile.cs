using Machine.Data.api.Entity;

namespace Machine.Data.Server.Services
{
    public class MachineDataFromFile : IMachineDataFromFile
    {
        private readonly HttpClient httpClient;
        public MachineDataFromFile(HttpClient httpClient)
        {
                this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Asset>> GetAllMachineData(string filepath)
        {
            return await httpClient.GetFromJsonAsync <Asset[]>($"assets-jsonformat?filepath={filepath}") ?? Enumerable.Empty<Asset>(); 
        }

        public async Task<IEnumerable<Asset>> GetAssetsByMachineType(string filepath, string machineType)
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets-jsonformat/asset-machinetypes?filepath={filepath}&machineType={machineType}") ?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetMachineByAssetType(string filepath, string assetType)
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets-jsonformat/machine-assetname?filepath={filepath}&assetName={assetType}") ?? Enumerable.Empty<Asset>();
        }
        public async Task<IEnumerable<Asset>> GetLatestVersion(string filepath)
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets-jsonformat/latest-series?filepath={filepath}") ?? Enumerable.Empty<Asset>();
        }

       
    }
}
