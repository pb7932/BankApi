using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank.model.model;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Mjesto>>> GetMjesta()
        {
            try
            {
                var mjesta = _dataRepo.MjestoList().Result.ToList();

                return Ok(mjesta);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}