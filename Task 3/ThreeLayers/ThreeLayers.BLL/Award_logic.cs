
using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private static IAwardDao _awardDao;
        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }
        public void Add(Award award)
        {
            _awardDao.Add(award);
        }
        public void Remove(int id)
        {
            _awardDao.Remove(id);
        }
        public Award GetById(int id)
        {
            return _awardDao.GetById(id);
        }
        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }
    }
}