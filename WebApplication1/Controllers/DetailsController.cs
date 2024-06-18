using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Post_put_Get_Del.DataModel;

namespace Post_put_Get_Del.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {

        private readonly DetailerContext _dbcontext;

        public DetailsController(DetailerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("api/servicerequest")]
        public async Task<ActionResult<IEnumerable<Detailer>>> GetDetails()
        {
            try
            {
                if(_dbcontext.Detailer == null)
                {
                    return NoContent();
                }
                var response= await _dbcontext.Detailer.ToListAsync();

                return Ok(response);
            }

            catch(Exception ex)
            {
                throw(ex);
            }
        }

        [HttpGet]

        [Route("api/servicerequest/{id}")]
        public async Task<ActionResult<Detailer>> GetDetails(string id)
        {
            try
            {
                if (_dbcontext.Detailer == null)
                {
                    return NotFound();
                }
                var response = await _dbcontext.Detailer.FindAsync(id);

                if (response == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(response);
                }

                //return Ok(response);
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPost]

        [Route("api/servicerequest")]
        public async Task<ActionResult<Detailer>> InsertDetails(Detailer detailer)
        {
            _dbcontext.Detailer.Add(detailer);
            await _dbcontext.SaveChangesAsync();

            var response= CreatedAtAction(nameof(InsertDetails), new {id=detailer.id},detailer);
            if (response.StatusCode == 201)
            {
                return Created();
            }
            else
            {
                return BadRequest();

            }

        }

        [HttpPut]

        [Route("api/servicerequest/{id}")]
        public async Task<ActionResult<Detailer>> UpdateDetails(string id,Detailer detailer)
        {
            if (id != detailer.id)
            {
                return BadRequest();
            }

            _dbcontext.Entry(detailer).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (CheckDetails(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();

        }

        private bool CheckDetails(string id)
        {
            return (_dbcontext.Detailer?.Any(x => x.id == id)).GetValueOrDefault();
        }

        [HttpDelete]

        [Route("api/servicerequest/{id}")]
        public async Task<ActionResult<Detailer>> DeleteDetails(string id, Detailer detailer)
        {
            if (_dbcontext.Detailer == null)
            {
                return NotFound();
            }

            var response = await _dbcontext.Detailer.FindAsync(id);
            if(response== null)
            {
                return NotFound();
            }
            _dbcontext.Detailer.Remove(detailer);

            await _dbcontext.SaveChangesAsync();

            return Created();
        }


    }

}
