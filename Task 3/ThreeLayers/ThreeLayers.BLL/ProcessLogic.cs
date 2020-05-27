using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL
{
    public class ProcessLogic:IProcessLogic
    {
        private static IProcessDAO _prDao;
        public ProcessLogic(IProcessDAO prDao)
        {
            _prDao = prDao;
        }
        public void Add(Process pr)
        {
            _prDao.Add(pr);
        }
        public void Remove(int id)
        {
            _prDao.Remove(id);
        }
        public Process GetById(int id)
        {
            return _prDao.GetById(id);
        }
        public IEnumerable<Process> GetAll()
        {
            return _prDao.GetAll();
        }
    }
}
