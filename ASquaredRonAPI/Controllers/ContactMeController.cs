using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASquaredRonModels.Models;
using ASquaredRonDB.Contexts;

namespace ASquaredRonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMeController : ControllerBase
    {
        public IDbAccessContext _dbc;

        public ContactMeController(IDbAccessContext dbc)
        {
            _dbc = dbc;
        }    

        [HttpPost]
        public async Task<ActionResult<int>> PostContactInfo(ContactMeModel contactInfo)
        {
            try
            {
                if (contactInfo == null)
                    return BadRequest();
                else
                {
                    int contactID = await _dbc.SaveContact(contactInfo);
                    if(contactID > 0)
                        return Ok(contactID);
                    else
                        return StatusCode(500, "Server error, try again later.");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;                
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
