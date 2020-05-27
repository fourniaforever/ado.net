using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL.Interfaces
{
    public interface IProcessLogic
    {
        void Add(Process g);

        void Remove(int id);

        Process GetById(int id);
        IEnumerable<Process> GetAll();
    }
}
