using matches.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakerController : ControllerBase
    {
        static int count = 100;
        static List<MatchMaker> matchMaker = new List<MatchMaker> { new MatchMaker { Id = count++, FirstName = "Esti", LastName ="Hool", email="st@gmail.com", phoneNumber="09874456" } };
        // GET: api/<MakerController>
        [HttpGet]
        public IEnumerable<MatchMaker> Get()
        {
            return matchMaker;
        }

        // GET api/<MakerController>/5
        [HttpGet("{id}")]
        public MatchMaker Get(int id)
        {
            for (int i = 0; i < matchMaker.Count; i++)
            {
                if (matchMaker[i].Id==id)
                {
                    return matchMaker[i];
                }
            }
            Response.StatusCode = 404;
            return new MatchMaker();


        }
        // POST api/<MakerController>
        [HttpPost]
        public void Post([FromBody] MatchMaker value)
        {
            matchMaker.Add(new MatchMaker { Id = count++,FirstName=value.FirstName,LastName=value.LastName,email=value.email,phoneNumber=value.phoneNumber });
        }

        // PUT api/<MakerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MatchMaker value)
        {
            var match = matchMaker.Find(e => e.Id == id);
            match.FirstName = value.FirstName;
            match.LastName = value.LastName;
            match.email = value.email;
            match.phoneNumber = value.phoneNumber;  
        }

        // DELETE api/<MakerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var match = matchMaker.Find(e => e.Id == id);
            matchMaker.Remove(match);
        }
    }
}
