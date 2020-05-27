using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL.Interfaces
{
    public interface IProductsLogic
    {
        void Add(Products g);

        void Remove(int id);

        Products GetById(int id);
        IEnumerable<Products> GetAll();

        void GreateProducts();
    }
}
