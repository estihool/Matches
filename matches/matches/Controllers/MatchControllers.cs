using matches.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchControllers : ControllerBase
    {

        static List<MatchMaking> maker = new List<MatchMaking> { new MatchMaking { Id = 123, FirstName = "Adi", LastName = "Malca", email = "m@gmail.com", phoneNumber = "0348774456", status = Status.single, age = 23, isChoen = false } };
        // GET: api/<MatchControllers>
        [HttpGet]
        public IEnumerable<MatchMaking> Get()
        {
            return maker;
        }

        // GET api/<MatchControllers>/5
        [HttpGet("{id}")]
        public MatchMaking Get(int id)
        {
            for (int i = 0; i < maker.Count; i++)
            {
                if (maker[i].Id == id)
                {
                    return maker[i];
                }
            }
            Response.StatusCode = 404;
            return new MatchMaking();
        }

        // POST api/<MatchControllers>
        [HttpPost]
        public void Post([FromBody] MatchMaking value)
        {
            maker.Add(new MatchMaking { Id = value.Id, FirstName = value.FirstName, LastName = value.LastName, email = value.email, phoneNumber = value.phoneNumber, age = value.age, isChoen = value.isChoen, status = value.status });
        }


        // PUT api/<MatchControllers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MatchMaking value)
        {
            var maker1 = maker.Find(e => e.Id == id);
            maker1.FirstName = value.FirstName;
            maker1.LastName = value.LastName;
            maker1.email = value.email;
            maker1.phoneNumber = value.phoneNumber;
            maker1.age = value.age;
            maker1.isChoen = value.isChoen;
            maker1.status = value.status;


        }

        // DELETE api/<MatchControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var maker1 = maker.Find(e => e.Id == id);
            maker.Remove(maker1);
        }

    }
}
