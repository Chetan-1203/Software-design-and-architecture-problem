using Machine.Data.api.Entity;
using Microsoft.AspNetCore.Mvc;
using SharpCompress.Common;
using System;
using System.Net.Http.Json;

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
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets")?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetAssetsByMachineType(string machineType)
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets/machinetypes?machineType={machineType}") ?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetLatestVersion()
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets/latestseries") ?? Enumerable.Empty<Asset>();
        }

        public async Task<IEnumerable<Asset>> GetMachineByAssetType(string assetType)
        {
            return await httpClient.GetFromJsonAsync<Asset[]>($"assets/assetname?assetName={assetType}") ?? Enumerable.Empty<Asset>();
        }

        public async Task LoadMachineData()
        {
            await httpClient.PostAsync("assets/uploaddata",null );
        }

        public async  Task DeleteMachineData()
        {
            await httpClient.DeleteAsync("assets/deletedata");
        }
    }
}
