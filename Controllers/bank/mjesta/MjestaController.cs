using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bank.model.dto;
using bank.model.model;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpGet]
        public async Task<ActionResult<MjestoListResponseDTO>> GetMjesta()
        {
            try
            {
                var mjesta = _dataRepo.MjestoList().Result;

                return Ok(mjesta);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpGet("{pbr}")]
        public async Task<ActionResult<MjestoResponseDTO>> GetMjestaByPbr(int pbr)
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
        public async Task<ActionResult<BaseResponseDto>> MjestaSave(MjestoRequestDTO mjesto)
        {
            try
            {
                var res = await _dataRepo.MjestoSave(mjesto);
                return Ok(res);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}