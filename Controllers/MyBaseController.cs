using bank.model.model;
using Microsoft.AspNetCore.Mvc;

namespace bankApi.controllers
{
    public class MyBaseController : ControllerBase
    {
        protected readonly IDataRepository _dataRepo;

        public MyBaseController(IDataRepository repo)
        {
            _dataRepo = repo;
        }
    }
}