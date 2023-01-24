using Machine.Data.api.Entity;
using Machine.Data.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Machine.Data.api.Controllers
{
    [ApiController]
    [Route("assets-jsonformat")]
    [ApiExplorerSettings(GroupName ="MachineDataFromFile")]
    public class MachineDataByFileController : Controller
    {
        private readonly IMachineDataFromFile _machineData;

        public MachineDataByFileController(IMachineDataFromFile machineData)
        {
            _machineData = machineData;
        }

        /// <summary>
        /// Get all machine data
        /// </summary>
        /// <param name="filepath">filepath of text or json</param>
        /// <returns>all machine data with asset name and version</returns>
        [HttpGet()]
        public ActionResult<IEnumerable<Asset>> GetMachinesData(string filepath)
        {
            var allMachineData = _machineData.GetAllMachineData(filepath);

            return new OkObjectResult(allMachineData);
        }

        /// <summary>
        /// Get asset names by machine types
        /// </summary>
        /// <param name="filepath">filepath of text or json</param>
        /// <param name="machineType">value of machine name</param>
        /// <returns>assets of given machine types</returns>
        [HttpGet("asset-machinetypes")]
        public  ActionResult<IEnumerable<Asset>> GetAssetNamesByMachineTypes(string filepath, string machineType)
        {
            var assetNameByMachineType = _machineData.AssetNamesByMachineType(filepath, machineType);

            return new OkObjectResult(assetNameByMachineType);
        }

        /// <summary>
        /// Get all machines by asset names
        /// </summary>
        /// <param name="filepath">filepath of text or json</param>
        /// <param name="assetName">value of asset name</param>
        /// <returns>machines of given asset names</returns>
        [HttpGet("machine-assetname")]
        public ActionResult<IEnumerable<Asset>> GetMachineByAssetName(string filepath, string assetName)
        {
            var machineTypeByAssetName = _machineData.MachineTypesByAssestName(filepath, assetName);

            return new OkObjectResult(machineTypeByAssetName);
        }

        /// <summary>
        /// Get latest series of machine
        /// </summary>
        /// <param name="filepath">filepath of text or json</param>
        /// <returns>latest version of machine</returns>

        [HttpGet("latest-series")]
        public ActionResult<IEnumerable<Asset>> GetLatestSeries(string filepath)
        {
            var GetLatestSeries = _machineData.MachineTypesByLatestSeriesOfAsset(filepath);

            return new OkObjectResult(GetLatestSeries);
        }


    }
}
