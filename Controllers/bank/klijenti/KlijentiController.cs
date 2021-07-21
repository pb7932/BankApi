using System.Threading.Tasks;
using bank.model.dto;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpPost]
        public async Task<ActionResult<KlijentListResponseDTO>> GetKlijenti(BaseRequestDto req)
        {
            try
            {
                var rez = await _dataRepo.KlijentList(req);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KlijentResponseDTO>> GetKlijentiById(int id)
        {
            try
            {
                var rez = await _dataRepo.KlijentGetById(id);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseDto>> KlijentiSave(KlijentRequestDTO klijent)
        {
            try
            {
                var res = await _dataRepo.KlijentSave(klijent);
                return Ok(res);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}