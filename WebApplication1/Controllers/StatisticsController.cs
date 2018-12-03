using System.Collections.Generic;
using System.Linq;
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

        // POST: api/Statistics
        [HttpPost]
        public IHttpActionResult CreateStatistics(Statistics statistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_statisticsDao.AddStatistics(statistics));
        }

        // PUT: api/Statistics/5
        [HttpPut]
        public IHttpActionResult UpdateStatistics(int id, Statistics statistics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedStatistics = _statisticsDao.UpdateStatistics(id, statistics);

            if (updatedStatistics == null)
            {
                return NotFound();
            }
            return Ok(updatedStatistics);
        }

        // DELETE: api/Statistics/5
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