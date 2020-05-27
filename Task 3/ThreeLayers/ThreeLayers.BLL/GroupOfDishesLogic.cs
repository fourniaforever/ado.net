using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL
{
    public class GroupOfDishesLogic:IGroupOfDishesLogic
    {
        private static IGroupOfDishesDAO _gDao;
        public GroupOfDishesLogic(IGroupOfDishesDAO gDao)
        {
            _gDao = gDao;
        }
        public void Add(GroupOfDishes group)
        {
            _gDao.Add(group);
        }
        public void Remove(int id)
        {
            _gDao.Remove(id);
        }
        public GroupOfDishes GetById(int id)
        {
            return _gDao.GetById(id);
        }
        public IEnumerable<GroupOfDishes> GetAll()
        {
            return _gDao.GetAll();
        }
    }
}
