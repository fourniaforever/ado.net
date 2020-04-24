using System;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.DAL
{
    public class AwardDAO : IAwardDao
    {
        private static Dictionary<int, Award> _awards = new Dictionary<int, Award>();
        public void Add(Award award)
        {
            int lastKey = _awards.Keys.LastOrDefault();
            award.Id = lastKey + 1;
            _awards.Add(award.Id, award);
        }
        public void Remove(int id)
        {
            _awards.Remove(id);
        }
        public Award GetById(int id)
        {
            try
            {
                return _awards[id];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }
    }
}