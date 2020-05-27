using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;
using ThreeLayers.DAL;

namespace ThreeLayers.BLL
{
    public class CountriesLogic:ICountriesLogic
    {
        private static ICountriesDao _cDao;
        public CountriesLogic()
        {
            _cDao = new CountriesDAO(); 
        }
        public void Add(Countries c)
        {
            _cDao.Add(c);
        }
        public void Remove(int id)
        {
            _cDao.Remove(id);
        }
        public Countries GetById(int id)
        {
            return _cDao.GetById(id);
        }
        public IEnumerable<Countries> GetAll()
        {
            return _cDao.GetAll();
        }
    }
}
