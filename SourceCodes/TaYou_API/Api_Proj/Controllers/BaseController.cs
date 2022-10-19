using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Proj.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
    }
}
