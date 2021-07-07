using System.Threading.Tasks;
using bank.model.dto;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpGet]
        public async Task<ActionResult<ZavodListResponseDTO>> GetZavodi()
        {
            try
            {
                var rez = await _dataRepo.ZavodiList();

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZavodResponseDTO>> GetZavodiById(int id)
        {
            try
            {
                var rez = await _dataRepo.ZavodGetById(id);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseDto>> ZavodiSave(ZavodRequestDTO zavod)
        {
            try
            {
                var res = await _dataRepo.ZavodSave(zavod);
                return Ok(res);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}