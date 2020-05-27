
using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL.Interfaces
{
    public interface IRateLogic
    {
        void Add(Rate award);
        void Remove(int id);
        Rate GetById(int id);
        IEnumerable<Rate> GetAll();
    }
}