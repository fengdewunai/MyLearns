using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureMapLearn
{
    using Microsoft.Practices.ServiceLocation;

    using StructureMap;
    using StructureMap.Pipeline;

    class Program
    {
        static void Main(string[] args)
        {
            
            //ObjectFactory.Initialize(x =>
            //{
            //    x.For<IContactValidator>().Use<ContactValidator>();
            //    x.For<IContactRepository>().Use<ContactRepository>();
            //    x.Profile(
            //        "DEBUG",
            //        profile =>
            //            {
            //                profile.For<IContactRepository>().Use<ContactRepositoryDebug>();
            //            });
            //});

            //ObjectFactory.Container.Configure(
            //    x =>
            //        {
            //            x.Scan(
            //                a =>
            //                    {
            //                        a.AssembliesFromApplicationBaseDirectory();
            //                        a.WithDefaultConventions();
            //                    });
            //        }
                
            //    );

            ObjectFactory.Initialize(
                x =>
                    { x.PullConfigurationFromAppConfig = true; });
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(ObjectFactory.Container));
            //ObjectFactory.Profile = "DEBUG";
            var param = new Dictionary<string,object>(){{"b","2"}};
            //ContactController controller = ObjectFactory.GetInstance<ContactController>();
            var contactValidator = ServiceLocator.Current.GetInstance<IContactValidator>();
            var contactRepository = ServiceLocator.Current.GetInstance<IContactRepository>();
            var controller = new ContactController(contactValidator, contactRepository);
            controller.Save();
            var what = ObjectFactory.WhatDoIHave();

            Console.ReadLine();
        }
    }
}
