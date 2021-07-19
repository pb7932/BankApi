using System.Threading.Tasks;
using bank.model.dto;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpGet]
        public async Task<ActionResult<TransakcijaListResponseDTO>> GetTransakcije()
        {
            try
            {
                var rez = await _dataRepo.TransakcijaList();

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransakcijaResponseDTO>> GetTransakcijeById(int id)
        {
            try
            {
                var rez = await _dataRepo.TransakcijaGetById(id);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseDto>> TransakcijeSave(TransakcijaRequestDTO transakcija)
        {
            try
            {
                var res = await _dataRepo.TransakcijaSave(transakcija);
                return Ok(res);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}