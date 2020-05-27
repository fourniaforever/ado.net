
using System;
using ThreeLayers.Entities;
using System.Collections.Generic;

namespace ThreeLayers.BLL.Interfaces
{
    public interface IGroupOfDishesLogic
    {
        void Add(GroupOfDishes g);

        void Remove(int id);

        GroupOfDishes GetById(int id);
        IEnumerable<GroupOfDishes> GetAll();
    }
}