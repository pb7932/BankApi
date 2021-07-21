using bank.model.model;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    [Route("api/bank/[action]")]
    [ApiController]
    public partial class MyDataController : MyBaseController
    {
        public MyDataController(IDataRepository repo) : base(repo)
        {
        }
    }
}