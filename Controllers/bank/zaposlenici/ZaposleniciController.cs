using System.Threading.Tasks;
using bank.model.dto;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpGet]
        public async Task<ActionResult<ZaposlenikListResponseDTO>> GetZaposlenici()
        {
            try
            {
                var rez = await _dataRepo.ZaposlenikList();

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZaposlenikResponseDTO>> GetZaposleniciById(int id)
        {
            try
            {
                var rez = await _dataRepo.ZaposlenikGetById(id);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseDto>> ZaposleniciSave(ZaposlenikRequestDTO zaposlenik)
        {
            try
            {
                var res = await _dataRepo.ZaposlenikSave(zaposlenik);
                return Ok(res);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}