using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.Dao.Interfaces
{
    public interface IAwardDao
    {
        void Add(Award award);

        void Remove(int id);

        Award GetById(int id);
        IEnumerable<Award> GetAll();
    }
}