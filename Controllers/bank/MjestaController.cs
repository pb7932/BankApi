using System.Collections.Generic;
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
                var mjesta = _dataRepo.MjestoList();

                return Ok(mjesta);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}