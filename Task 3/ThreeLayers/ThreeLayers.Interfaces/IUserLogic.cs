
using System;
using ThreeLayers.Entities;
using System.Collections.Generic;

namespace ThreeLayers.BLL.Interfaces
{
    public interface IUserLogic
    {
        void Add(User user);

        void Remove(int id);

        User GetById(int id);
        IEnumerable<User> GetAll();
        void Reward(int userId, Award award);
    }
}