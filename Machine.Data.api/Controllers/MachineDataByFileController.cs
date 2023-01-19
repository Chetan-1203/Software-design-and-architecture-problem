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

        [HttpGet]
        public  ActionResult<IEnumerable<Asset>> GetAssetNamesByMachineTypes(string filepath, string machineType)
        {
            var assetNameByMachineType = _machineData.AssetNamesByMachineType(filepath, machineType);

            return new OkObjectResult(assetNameByMachineType);
        }
    }
}
