using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Common.BL;
using Common.Data;
using Common.Models;

namespace NasaDatabase.Controllers
{
    public class FireballsController : ApiController
    {
        private NasaDbContext db = new NasaDbContext();
        private FireballLogic fl = new FireballLogic();

        [Route("api/allFireballData")]
        [HttpGet]
        public async Task<List<Fireball>> GetFireballs()
        {
            return await db.Fireballs.ToListAsync();
        }

        // GET: api/Fireballs/5
        [ResponseType(typeof(Fireball))]
        public async Task<IHttpActionResult> GetFireball(int id)
        {
            Fireball fireball = await db.Fireballs.FindAsync(id);
            if (fireball == null)
            {
                return NotFound();
            }

            return Ok(fireball);
        }

        // PUT: api/Fireballs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFireball(int id, Fireball fireball)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fireball.Id)
            {
                return BadRequest();
            }

            db.Entry(fireball).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FireballExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Fireballs
        [ResponseType(typeof(Fireball))]
        public async Task<IHttpActionResult> PostFireball(Fireball fireball)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newFireball = await fl.Post(fireball);

            return CreatedAtRoute("DefaultApi", new { id = fireball.Id }, newFireball);
        }

        // DELETE: api/Fireballs/5
        [ResponseType(typeof(Fireball))]
        public async Task<IHttpActionResult> DeleteFireball(int id)
        {
            Fireball fireball = await db.Fireballs.FindAsync(id);
            if (fireball == null)
            {
                return NotFound();
            }

            db.Fireballs.Remove(fireball);
            await db.SaveChangesAsync();

            return Ok(fireball);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FireballExists(int id)
        {
            return db.Fireballs.Count(e => e.Id == id) > 0;
        }
    }
}