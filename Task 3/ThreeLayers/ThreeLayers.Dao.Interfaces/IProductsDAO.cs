using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.Dao.Interfaces
{
    public interface IProductsDAO
    {
        void Add(Products d);

        void Remove(int id);

        Products GetById(int id);
        IEnumerable<Products> GetAll();

        //Самая важная потому что вызывает процедуру GreatProducts которая отправляет все в More10 table
        void GreateProducts();
    }
}
