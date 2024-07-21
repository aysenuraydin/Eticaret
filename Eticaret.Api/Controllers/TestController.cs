using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("protected")]
        [Authorize]
        public IActionResult Protected()
        {
            var currentUser = User.Identity!.Name;
            return Ok(new { message = $"Hello {currentUser}, you are authenticated!" });
        }
    }
}


