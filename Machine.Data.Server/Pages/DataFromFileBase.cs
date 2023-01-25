using Machine.Data.api.Entity;
using Machine.Data.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Machine.Data.Server.Pages
{
    public class DataFromFileBase :ComponentBase
    {
        [Inject]
        private IMachineDataFromFile MachineDataFromFile { get; set; }

        
        [Parameter]
        public string FilePath { get; set; } 

        [Parameter]
        public string MachineType { get; set; } 

        [Parameter]
        public string AssetType { get; set; } 
        public IEnumerable<Asset>? Assets { get; set; } 

       

        

        protected async void OnButtonClick()
        {
            if (FilePath is not null)
            {
                Assets = (await MachineDataFromFile.GetAllMachineData(FilePath)).ToList() ?? Enumerable.Empty<Asset>();
                StateHasChanged();
            }
           
        }

        protected async void OnButtonClick2()
        {
            if (FilePath != null && MachineType != null)
            {
                Assets = (await MachineDataFromFile.GetAssetsByMachineType(FilePath, MachineType)).ToList() ?? Enumerable.Empty<Asset>();
                StateHasChanged();
            }
        }

        protected async void OnButtonClick3()
        {
            if (FilePath != null && AssetType != null)
            {
                Assets = (await MachineDataFromFile.GetMachineByAssetType(FilePath, AssetType)).ToList() ?? Enumerable.Empty<Asset>();
                StateHasChanged();
            }
        }


        protected async void OnButtonClick4()
        {
            if (FilePath is not null)
            {
                Assets = (await MachineDataFromFile.GetLatestVersion(FilePath)).ToList() ?? Enumerable.Empty<Asset>();
                StateHasChanged();
            }
        }
    }
}
