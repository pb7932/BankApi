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

        [HttpGet("{pbr}")]
        public async Task<ActionResult<Mjesto>> GetMjestoByPbr(int pbr)
        {
            try
            {
                var rez = _dataRepo.MjestoGetById(pbr).Result;

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpPost]
        public async Task<ActionResult> MjestoSave(Mjesto mjesto)
        {
            try
            {
                await _dataRepo.MjestoSave(mjesto);
                return NoContent();
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}