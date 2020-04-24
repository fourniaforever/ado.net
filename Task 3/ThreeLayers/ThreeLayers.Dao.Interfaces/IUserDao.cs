using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.Entities;

namespace ThreeLayers.Dao.Interfaces
{
    public interface IUserDao
    {
        void Add(User user);

        void Remove(int id);

        User GetById(int id);
        IEnumerable<User> GetAll();
        void Reward(int userId, Award award);
    }
}