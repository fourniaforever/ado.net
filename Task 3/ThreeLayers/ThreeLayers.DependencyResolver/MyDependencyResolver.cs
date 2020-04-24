using System;
using ThreeLayers.BLL;
using ThreeLayers.BLL.Interfaces;
using ThreeLayers.Dao.Interfaces;
using ThreeLayers.DAL;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayers.Ioc
{
    public class MyDependencyResolver
    {
        private static IUserDao _userDao;
        private static IUserDao UserDao => _userDao ?? (_userDao = new UserDAO());


        private static IUserLogic _userLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));

        private static IAwardDao _awardDao;
        private static IAwardDao AwardDao => _awardDao ?? (_awardDao = new AwardDAO());


        private static IAwardLogic _awardLogic;
        public static IAwardLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao));


    }
}
