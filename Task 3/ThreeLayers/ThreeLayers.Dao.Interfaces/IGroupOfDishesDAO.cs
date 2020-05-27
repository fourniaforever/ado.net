using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;
namespace ThreeLayers.Dao.Interfaces
{
    public interface IGroupOfDishesDAO
    {
        void Add(GroupOfDishes d);

        void Remove(int id);

        GroupOfDishes GetById(int id);
        IEnumerable<GroupOfDishes> GetAll();
    }
}
