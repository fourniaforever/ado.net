using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.Entities;

namespace ThreeLayers.BLL
{
    public class UserLogic : IUserLogic
    {
        private static IUserDao _userDao;
        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public void Add(User user)
        {
            _userDao.Add(user);
        }
        public void Remove(int id)
        {
            _userDao.Remove(id);
        }
        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }
        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }
        public void Reward(int userId, Award award)
        {
            _userDao.Reward(userId, award);
        }
    }
}