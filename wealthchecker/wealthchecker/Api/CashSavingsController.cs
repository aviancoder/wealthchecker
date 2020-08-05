using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wealthchecker.Data;

namespace wealthchecker.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CashSavingsController : ControllerBase
    {
        [HttpGet]
        public List<CashSavingsData> Get()
        {
            return WealthTrackerOutputModel.CashSavingsList;
        }
    }
}
