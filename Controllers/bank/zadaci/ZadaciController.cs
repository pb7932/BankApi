using System.Threading.Tasks;
using bank.model.dto;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpGet]
        public async Task<ActionResult<ZadatakListResponseDTO>> GetZadaci()
        {
            try
            {
                var rez = await _dataRepo.ZadatakList();

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZadatakResponseDTO>> GetZadaciById(int id)
        {
            try
            {
                var rez = await _dataRepo.ZadatakGetById(id);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseDto>> ZadatakSave(ZadatakRequestDTO zadatak)
        {
            try
            {
                var res = await _dataRepo.ZadatakSave(zadatak);
                return Ok(res);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}