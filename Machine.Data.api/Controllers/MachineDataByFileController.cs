using Machine.Data.api.Entity;
using Machine.Data.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Machine.Data.api.Controllers
{
    [ApiController]
    [Route("assets-data-fromfile")]
    [ApiExplorerSettings(GroupName = "MachineDataFromFile")]
    
    public class MachineDataByFileController : Controller
    {
        private readonly IMachineDataFromFile _machineData;

  
        public MachineDataByFileController(IMachineDataFromFile machineData)
        {
            _machineData = machineData;
        }


        /// <summary>
        /// Get all machine data with asset name and version
        /// </summary>
        /// <param name="filepath">filepath of txt or json file</param>
        /// <returns> all machine data</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Asset>> GetAllMAchines(string filepath)
        {
            var allMachines = _machineData.GetAllMachineData(filepath);

            return new OkObjectResult(allMachines);
        }
        /// <summary>
        /// Get asset names by machine types
        /// </summary>
        /// <param name="filepath">filepath of txt or json file</param>
        /// <param name="machineType">name of machine type</param>
        /// <returns>assets of specific machine type</returns>

        [HttpGet("/asset-machinetypes")]
        public  ActionResult<IEnumerable<Asset>> GetAssetNamesByMachineTypes(string filepath, string machineType)
        {
            var assetNameByMachineType = _machineData.AssetNamesByMachineType(filepath, machineType);

            return new OkObjectResult(assetNameByMachineType);
        }

        /// <summary>
        /// Get machines by asset name
        /// </summary>
        /// <param name="filepath">filepath of txt or json file</param>
        /// <param name="assetName">name of asset </param>
        /// <returns>machines of specific asset</returns>
        [HttpGet("/machine-assetname")]
        public ActionResult<IEnumerable<Asset>> GetMachineByAssetName(string filepath, string assetName)
        {
            var machineTypeByAssetName = _machineData.MachineTypesByAssestName(filepath, assetName);

            return new OkObjectResult(machineTypeByAssetName);
        }

        /// <summary>
        /// Get latest version of machines from data
        /// </summary>
        /// <param name="filepath">filepath of txt or json file</param>
        /// <returns> latest version of machine</returns>
        [HttpGet("/latest-series")]
        public ActionResult<IEnumerable<Asset>> GetLatestSeries(string filepath)
        {
            var GetLatestSeries = _machineData.MachineTypesByLatestSeriesOfAsset(filepath);

            return new OkObjectResult(GetLatestSeries);
        }


    }
}
