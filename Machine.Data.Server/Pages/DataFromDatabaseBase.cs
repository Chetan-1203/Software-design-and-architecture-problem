using Machine.Data.api.Entity;
using Machine.Data.Server.Services;
using Microsoft.AspNetCore.Components;

namespace Machine.Data.Server.Pages
{
    public class DataFromDatabaseBase :ComponentBase
    {
        [Inject]
        private IMachineDataFromDatabase MachineDataFromDataBase { get; set; }


        [Parameter]
        public string MachineType { get; set; }

        [Parameter]
        public string AssetType { get; set; } 
        public IEnumerable<Asset>? Assets { get; set; }





        protected async void OnButtonClick()
        {

            Assets = (await MachineDataFromDataBase.GetAllMachineData()).ToList() ?? Enumerable.Empty<Asset>();
            StateHasChanged();

        }

        protected async void OnButtonClick2()
        {
            if (MachineType is not null)
            {
                Assets = (await MachineDataFromDataBase.GetAssetsByMachineType(MachineType)).ToList() ?? Enumerable.Empty<Asset>();
                StateHasChanged();
            }
        }

        protected async void OnButtonClick3()
        {
            if (AssetType is not null)
            {
                Assets = (await MachineDataFromDataBase.GetMachineByAssetType(AssetType)).ToList() ?? Enumerable.Empty<Asset>();
                StateHasChanged();
            }
        }


        protected async void OnButtonClick4()
        {

            Assets = (await MachineDataFromDataBase.GetLatestVersion()).ToList() ?? Enumerable.Empty<Asset>();
            StateHasChanged();
        }
    }

}
