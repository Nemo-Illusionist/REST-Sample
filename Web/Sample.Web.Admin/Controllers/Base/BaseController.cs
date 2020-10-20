
using Microsoft.AspNetCore.Mvc;

namespace Sample.Web.Admin.Controllers.Base
{
    [Produces("application/json")]
    [Route("api/admin/v{version:apiVersion}/[controller]")]
    [ApiController]
    // [Authorize(Roles = RoleNameConstant.Admin)]
    public abstract class BaseController : Controller
    {
    }
}