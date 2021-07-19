using System.Threading.Tasks;
using bank.model.dto;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpGet]
        public async Task<ActionResult<ZZListResponseDTO>> GetZaposleniciZadaci()
        {
            try
            {
                var rez = await _dataRepo.ZZList();

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZZResponseDTO>> GetZaposleniciZadaciById(int id)
        {
            try
            {
                var rez = await _dataRepo.ZZGetById(id);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseDto>> ZaposleniciZadaciSave(ZZRequestDTO zz)
        {
            try
            {
                var res = await _dataRepo.ZZSave(zz);
                return Ok(res);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}