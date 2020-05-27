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
        private static IDishDao _userDao;
        private static IDishDao UserDao => _userDao ?? (_userDao = new DishDAO());


        private static IGroupOfDishesLogic _userLogic;
        public static IGroupOfDishesLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));

        private static ICountriesDao _awardDao;
        private static ICountriesDao AwardDao => _awardDao ?? (_awardDao = new CountriesDAO());


        private static IRateLogic _awardLogic;
        public static IRateLogic AwardLogic => _awardLogic ?? (_awardLogic = new AwardLogic(AwardDao));


    }
}
