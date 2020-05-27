using System;
using ThreeLayers.Entities;
using ThreeLayers.Ioc;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ThreeLayers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var _userLogic = MyDependencyResolver.UserLogic;
            var _awardLogic = MyDependencyResolver.AwardLogic;

            _userLogic.Add(new Products("Ivan", new DateTime(2000, 3, 16))) ;
            _userLogic.Add(new Products("Anton", new DateTime(2002, 7, 23)));
            _userLogic.Add(new Products("Anna", new DateTime(1993, 1, 12)));
            _userLogic.Add(new Products("Andrey", new DateTime(1995, 12, 1)));
            

            _awardLogic.Add(new Award("За честь и отвагу"));
            _awardLogic.Add(new Award("Медаль лучшего мойщика окон"));
            _awardLogic.Add(new Award("Великий крест странной страны"));

            _userLogic.Reward(1, _awardLogic.GetById(1));
            _userLogic.Reward(2, _awardLogic.GetById(3));
            _userLogic.Reward(3, _awardLogic.GetById(1));
            _userLogic.Reward(4, _awardLogic.GetById(2));


            foreach (var user in _userLogic.GetAll())
            {
                Console.WriteLine(user.ToString());
            }
            Console.ReadLine();
        }
    }
}
