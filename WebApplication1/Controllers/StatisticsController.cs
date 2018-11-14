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
using GameWebApplication.Models;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers
{
    public class StatisticsController : ApiController
    {
        private GameWebApplicationContext db = new GameWebApplicationContext();

        // GET: api/Statistics
        public IQueryable<Statistics> GetStatistics()
        {
            return db.Statistics;
        }

        // GET: api/Statistics/5
        [ResponseType(typeof(Statistics))]
        public async Task<IHttpActionResult> GetStatistics(int id)
        {
            Statistics statistics = await db.Statistics.FindAsync(id);
            if (statistics == null)
            {
                return NotFound();
            }

            return Ok(statistics);
        }

        // PUT: api/Statistics/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStatistics(int id, Statistics statistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statistics.ID)
            {
                return BadRequest();
            }

            db.Entry(statistics).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatisticsExists(id))
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

        // POST: api/Statistics
        [ResponseType(typeof(Statistics))]
        public async Task<IHttpActionResult> PostStatistics(Statistics statistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statistics.Add(statistics);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = statistics.ID }, statistics);
        }

        // DELETE: api/Statistics/5
        [ResponseType(typeof(Statistics))]
        public async Task<IHttpActionResult> DeleteStatistics(int id)
        {
            Statistics statistics = await db.Statistics.FindAsync(id);
            if (statistics == null)
            {
                return NotFound();
            }

            db.Statistics.Remove(statistics);
            await db.SaveChangesAsync();

            return Ok(statistics);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatisticsExists(int id)
        {
            return db.Statistics.Count(e => e.ID == id) > 0;
        }
    }
}