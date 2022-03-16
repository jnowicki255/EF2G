using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF2G.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult GetUsers()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{userId}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetUser(int userId)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser(object newUser)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser(object updatedUser)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{userId}")]
        public IActionResult RemoveUser(int userId)
        {
            return Ok();
        }
    }
}
