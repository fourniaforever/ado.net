using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL
{
    public class ProductsLogic : IProductsLogic
    {
        private static IProductsDAO _prodDao;
        public ProductsLogic()
        {
        }
        public ProductsLogic(IProductsDAO prodDao)
        {
            _prodDao = prodDao;
        }
        public void Add(Products user)
        {
            _prodDao.Add(user);
        }
        public void Remove(int id)
        {
            _prodDao.Remove(id);
        }
        public Products GetById(int id)
        {
            return _prodDao.GetById(id);
        }
        public IEnumerable<Products> GetAll()
        {
            return _prodDao.GetAll();
        }

        public void GreateProducts()
        {
            _prodDao.GreateProducts();
        }
    }
}