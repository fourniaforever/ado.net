using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.Dao.Interfaces
{
    public interface IProcessDAO
    {
        void Add(Process d);

        void Remove(int id);

        Process GetById(int id);
        IEnumerable<Process> GetAll();
    }
}
