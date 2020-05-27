using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;
namespace ThreeLayers.Dao.Interfaces
{
    public interface INotVeganRecipsDAO
    {
        NotVeganRecips GetByName(string name);
        IEnumerable<NotVeganRecips> GetAll();
    }
}
