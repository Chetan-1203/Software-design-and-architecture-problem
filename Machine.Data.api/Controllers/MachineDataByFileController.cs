using Machine.Data.api.Entity;
using Machine.Data.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Machine.Data.api.Controllers
{
    [ApiController]
    [Route("assets-jsonformat")]
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
        /// <param name="filepath"></param>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<IEnumerable<Asset>> GetMachinesData(string filepath)
        {
            var allMachineData = _machineData.GetAllMachineData(filepath);

            return new OkObjectResult(allMachineData);
        }

        [HttpGet("asset-machinetypes")]
        public  ActionResult<IEnumerable<Asset>> GetAssetNamesByMachineTypes(string filepath, string machineType)
        {
            var assetNameByMachineType = _machineData.AssetNamesByMachineType(filepath, machineType);

            return new OkObjectResult(assetNameByMachineType);
        }


        [HttpGet("machine-assetname")]
        public ActionResult<IEnumerable<Asset>> GetMachineByAssetName(string filepath, string assetName)
        {
            var machineTypeByAssetName = _machineData.MachineTypesByAssestName(filepath, assetName);

            return new OkObjectResult(machineTypeByAssetName);
        }


        [HttpGet("latest-series")]
        public ActionResult<IEnumerable<Asset>> GetLatestSeries(string filepath)
        {
            var GetLatestSeries = _machineData.MachineTypesByLatestSeriesOfAsset(filepath);

            return new OkObjectResult(GetLatestSeries);
        }


    }
}
