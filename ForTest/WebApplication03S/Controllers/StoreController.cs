
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;

using WebApplication03HW2.Models;
using WebApplication03HW2.Models.DTO;
using WebApplication03HW2.Abstraction;
using Microsoft.Extensions.Caching.Memory;
using WebApplication03HW2.Repo;

namespace WebApplication03HW2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {

        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

 
        [HttpGet("get_stores")]
        public IActionResult GetStores()
        {
            var stores = _storeRepository.GetStores();
            return Ok(stores);
        }

        [HttpPost("add_store")]
        public IActionResult AddStore([FromBody] StoreDto storeDto)
        {
            var result = _storeRepository.AddStore(storeDto);
            return Ok(result);
        }

        [HttpDelete("delete_store")]
        public ActionResult Deletestore(int id)
        {
            var res = _storeRepository.DeleteStore(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Delete ok! id = {id}");
        }


        [HttpGet("check_stores")]
        public ActionResult<bool> CheckStore(int id)
        {

            var res = _storeRepository.CheckStore(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"id = {id} Exist ");
        }
    }
}
