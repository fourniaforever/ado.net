using System;
using ThreeLayers.Entities;
using ThreeLayers.Dao.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.DAL
{
    public class UserDAO: IUserDao
    {
        private static Dictionary<int, User> _users = new Dictionary<int, User>();
        public void Add(User user)
        {
            int lastKey = _users.Keys.LastOrDefault();
            user.Id = lastKey + 1;
            _users.Add(user.Id, user);
        }
        public void Remove(int id)
        {
            _users.Remove(id);
        }

        public User GetById(int id)
        {
            try
            {
                return _users[id];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }
        public void Reward(int userId, Award award)
        {
            GetById(userId).Awards.Add(award);
        }
    }
}
