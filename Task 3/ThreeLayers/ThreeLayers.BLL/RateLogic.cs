using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL
{
    public class RateLogic:IRateLogic
    {
        private static IRateDAO _rDao;
        public RateLogic(IRateDAO rDao)
        {
            _rDao = rDao;
        }
        public void Add(Rate r)
        {
            _rDao.Add(r);
        }
        public void Remove(int id)
        {
            _rDao.Remove(id);
        }
        public Rate GetById(int id)
        {
            return _rDao.GetById(id);
        }
        public IEnumerable<Rate> GetAll()
        {
            return _rDao.GetAll();
        }
    }
}
