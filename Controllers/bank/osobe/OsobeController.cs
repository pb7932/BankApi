using System.Threading.Tasks;
using bank.model.dto;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public partial class MyDataController : MyBaseController
    {
        [HttpPost]
        public async Task<ActionResult<OsobaListResponseDTO>> GetOsobe(BaseRequestDto req)
        {
            try
            {
                var rez = await _dataRepo.OsobaList(req);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OsobaResponseDTO>> GetOsobeById(int id)
        {
            try
            {
                var rez = await _dataRepo.OsobaGetById(id);

                return Ok(rez);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponseDto>> OsobeSave(OsobaRequestDTO osoba)
        {
            try
            {
                var res = await _dataRepo.OsobaSave(osoba);
                return Ok(res);
            }
            finally
            {
                await _dataRepo.ConnectionClose();
            }
        }
    }
}