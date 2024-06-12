using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthors : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookAuthors(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<BookAuthors>
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_unitOfWork._bookAuthor.GetAll().AsQueryable());
        }

        // GET api/<BookAuthors>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookAuthors>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookAuthors>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookAuthors>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
