using matches.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceControllers : ControllerBase
    {
        static List<PlaceMeeting> place = new List<PlaceMeeting> { new PlaceMeeting { Name = "Kfar Hmacbia", IsActive = true, description = "nice", areYouInjoy=true} };
        // GET: api/<PlaceControllers>
        [HttpGet]
        public IEnumerable<PlaceMeeting> Get()
        {
            return place;
        }

        // GET api/<PlaceControllers>/5
        [HttpGet("{id}")]
        public PlaceMeeting Get(string id)
        {
            for (int i = 0; i < place.Count; i++)
            {
                if (place[i].Name == id)
                {
                    return place[i];
                }
            }
            Response.StatusCode = 404;
            return new PlaceMeeting();
        }

        // POST api/<PlaceControllers>
        [HttpPost]
        public void Post([FromBody] PlaceMeeting value)
        {
            place.Add(new PlaceMeeting { Name = value.Name, IsActive = value.IsActive,description=value.description,areYouInjoy=value.areYouInjoy });
            
            
        }

        // PUT api/<PlaceControllers>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] PlaceMeeting value)
        {
            var placeMeet = place.Find(x => x.Name == id);
            placeMeet.description = value.description;
            placeMeet.IsActive = value.IsActive;
            placeMeet.areYouInjoy = value.areYouInjoy;

        }

        // DELETE api/<PlaceControllers>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var placeMeet= place.Find(x => x.Name == id);
            place.Remove(placeMeet);
        }
    }
}
