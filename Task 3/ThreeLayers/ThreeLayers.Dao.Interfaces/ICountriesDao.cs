using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.Dao.Interfaces
{
    public interface ICountriesDao
    {
        void Add(Countries country);

        void Remove(int id);

        Countries GetById(int id);
        IEnumerable<Countries> GetAll();
    }
}