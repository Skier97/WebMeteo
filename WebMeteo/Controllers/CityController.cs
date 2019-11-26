using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMeteo.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Web.Configuration;

namespace WebMeteo.Controllers
{
    
    public class CityController : ApiController
    {
        List<City> cities;
        FileDb db = new FileDb();

        // GET api/values
        public IHttpActionResult Get()
        {
            cities = db.ReadCitiesFromFile();
            db.UpdateDbTasks(cities);
            return Json (cities);
        }

        // GET api/values/5
        public IHttpActionResult Get(string name)
        {
            cities = db.ReadCitiesFromFile();
            City tmpCity = null;
            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].NameCity.ToLower() == name.ToLower())
                {
                    tmpCity = cities[i];
                    
                }
            }
            return Json(tmpCity);
        }

        // POST api/values
        [HttpPost]
        public void AddCity(City city)
        {
            cities = db.ReadCitiesFromFile();
            cities.Add(city);
            db.UpdateDbTasks(cities);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        
    }
}
