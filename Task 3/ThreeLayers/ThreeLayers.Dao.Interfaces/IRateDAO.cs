using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.Dao.Interfaces
{
    public interface IRateDAO
    {

        void Add(Rate d);

        void Remove(int id);

        Rate GetById(int id);
        IEnumerable<Rate> GetAll();
    }
}
