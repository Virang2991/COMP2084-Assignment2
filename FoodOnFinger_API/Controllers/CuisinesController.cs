using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOnFinger_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodOnFinger_API.Controllers
{
    [Route("api/[controller]")]
    public class CuisinesController : Controller
    {
        // connect
        ProductView db;

        public CuisinesController(ProductView db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        [HttpHead("{id}")]
        public IEnumerable<Cuisine> Get()
        {
            return db.Cuisine.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var Cuisine = db.Cuisine.SingleOrDefault(c => c.CuisineID == id);

            if (Cuisine == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Cuisine);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Cuisine Cuisine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Cuisine.Add(Cuisine);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = Cuisine.CuisineID }, Cuisine);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Cuisine Cuisine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(Cuisine).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = Cuisine.CuisineID }, Cuisine);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Cuisine = db.Cuisine.SingleOrDefault(c => c.CuisineID == id);
            if (Cuisine == null)
            {
                return NotFound();
            }
            else
            {
                db.Cuisine.Remove(Cuisine);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
