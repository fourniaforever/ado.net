
using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.DAL;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL
{
    public class DishLogic : IDishLogic
    {
        private static IDishDao _dishDao;
        public DishLogic()
        {
            _dishDao = new DishDAO();
        }
        public void Add(Dish award)
        {
            _dishDao.Add(award);
        }
        public void RemoveById(int id)
        {
            _dishDao.RemoveById(id);
        }
        public Dish GetById(int id)
        {
            return _dishDao.GetById(id);
        }
        public IEnumerable<Dish> GetAll()
        {
            return _dishDao.GetAll();
        }
       public  void VegetarianSortByid(int id)
        {
           _dishDao.VegetarianSortByid(id);
        }
       public void PriceAnalysis()
        {
            _dishDao.PriceAnalysis();
        }
       public  void Repricing(int id, int coeficcient)
        {
            _dishDao.Repricing(id, coeficcient);
        }
        public IEnumerable<string> SelectDishesFromCountry(int id)
        {
            return _dishDao.SelectDishesFromCountry(id);
        }
    }
}