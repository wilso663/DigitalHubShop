using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            this._context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(101);
            if (thing == null)
            {
                return NotFound(new ApiErrorResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerErrorRequest()
        {
            var thing = _context.Products.Find(101);
            var thingToReturn = thing.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiErrorResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }
    }
}
