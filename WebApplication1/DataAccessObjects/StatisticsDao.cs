using GameWebApplication.Models;
using System.Linq;

namespace GameWebApplication.DataAccessObjects
{
    public class StatisticsDao
    {
        private readonly GameWebApplicationContext _db = new GameWebApplicationContext();

        // GET: api/Statistics
        public IQueryable<Statistics> GetStatistics()
        {
            return _db.Statistics;
        }

        public Statistics GetStatistics(int id)
        {
            return _db.Statistics.Find(id);
        }

        public Statistics AddStatistics(Statistics statistics)
        {
            var createdStatistics = _db.Statistics.Add(statistics);
            _db.SaveChanges();
            return createdStatistics;
        }

        public Statistics UpdateStatistics(int id, Statistics statistics)
        {
            var existingStatistics = _db.Statistics.Find(id);

            if (existingStatistics == null)
            {
                return null;
            }
            existingStatistics.CharacterId = statistics.CharacterId;
            existingStatistics.Deaths = statistics.Deaths;
            existingStatistics.Kills = statistics.Kills;
            existingStatistics.TotalMoney = statistics.TotalMoney;

            _db.SaveChanges();

            return existingStatistics;
        }

        public void DeleteStatistics(Statistics statistics)
        {
            _db.Statistics.Remove(statistics);
            _db.SaveChanges();
        }
    }
}