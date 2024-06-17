using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Post_put_Get_Del.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        [HttpGet]
        [Route("api/servicerequest")]
        public string GetDetails()
        {
            return "List of ID";
        }

        [HttpGet("{id}")]

        [Route("api/servicerequest/{id}")]
        public string GetDetails(string id)
        {
            return "Single record";
        }

        [HttpPost]

        [Route("api/servicerequest")]
        public string InsertDetails(string id)
        {
            return "Single record";
        }

        [HttpPut]

        [Route("api/servicerequest/{id}")]
        public string UpdateDetails(string id)
        {
            return "Single record";
        }

        [HttpDelete]

        [Route("api/servicerequest/{id}")]
        public string DeleteDetails(string id)
        {
            return "Single record";
        }


    }
}
