using Machine.Data.api.Entity;
using SharpCompress.Common;
using System;

namespace Machine.Data.Server.Services
{
    public class MachineDataFromDatabase : IMachineDataFromDatabase
    {
        private readonly HttpClient httpClient;
        public MachineDataFromDatabase(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Asset>> GetAllMachineData()
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets-database")?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetAssetsByMachineType(string machineType)
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets-database/asset-machinetypes?machineType={machineType}") ?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetLatestVersion()
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets-database/latest-series") ?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetMachineByAssetType(string assetType)
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets-database/machine-assetname?assetName={assetType}") ?? Enumerable.Empty<Asset>();
        }
    }
}
