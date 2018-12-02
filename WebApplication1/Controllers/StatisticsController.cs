using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using GameWebApplication.DataAccessObjects;
using GameWebApplication.Models;

namespace GameWebApplication.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly StatisticsDao _statisticsDao = new StatisticsDao();

        public List<Statistics> GetStatistics()
        {
            return _statisticsDao.GetStatistics().ToList();
        }

        // GET: api/Statistics/5
        [ResponseType(typeof(Statistics))]
        public IHttpActionResult GetStatistics(int id)
        {
            var statistics = _statisticsDao.GetStatistics(id);
            if (statistics == null)
            {
                return NotFound();
            }
            return Ok(statistics);
        }

        // PUT: api/Statistics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatistics(int id, Statistics statistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statistics.Id)
            {
                return BadRequest();
            }

            bool isUpdated = _statisticsDao.UpdateStatistics(id, statistics);

            if (!isUpdated)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Statistics
        [ResponseType(typeof(Statistics))]
        public IHttpActionResult PostStatistics(Statistics statistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _statisticsDao.AddStatistics(statistics);

            return CreatedAtRoute("DefaultApi", new { id = statistics.Id }, statistics);
        }

        // DELETE: api/Statistics/5
        [ResponseType(typeof(Statistics))]
        public IHttpActionResult DeleteStatistics(int id)
        {
            Statistics statistics = _statisticsDao.GetStatistics(id);
            if (statistics == null)
            {
                return NotFound();
            }

            _statisticsDao.DeleteStatistics(statistics);

            return Ok(statistics);
        }
        /*
        public ActionResult StatisticsPage()
        {
            ViewBag.Title = "Statistics Page";
            
        }*/
    }
}