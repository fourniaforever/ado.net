using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.Dao.Interfaces
{
    public interface IDishDao
    {
        void Add(Dish d);

        void RemoveById(int id);

        Dish GetById(int id);
        IEnumerable<Dish> GetAll();

        void VegetarianSortByid(int id);
        void PriceAnalysis();
        void Repricing(int id, int coeficcient);
        IEnumerable<string> SelectDishesFromCountry(int id);
    }
}