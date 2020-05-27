using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL.Interfaces
{
    public interface ICountriesLogic
    {
        void Add(Countries g);

        void Remove(int id);

        Countries GetById(int id);
        IEnumerable<Countries> GetAll();
    }
}
