using Caliburn.Micro;
using MarcelloDB.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using WarColors.Core.Injection;
using WarColors.Data.Marcello;
using WarColors.ViewModels;
using WarColors.Views;

namespace WarColors.iOS
{
    public class CaliburnAppDelegate : CaliburnApplicationDelegate
    {
        private IInjectionContainer container;

        public CaliburnAppDelegate()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleInjectionContainer();

            RegisterServices();

            container
                .Singleton<WarColors.Application>();
        }

        private void RegisterServices()
        {
            string path = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "WarColorsData");

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            container
                .RegisterHandler(typeof(IDatabase), container => new Database(container.GetInstance<IPlatform>(), path));

            container
                .PerRequest<IPlatform, MarcelloDB.netfx.Platform>();
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return GetType().Assembly;
            yield return typeof(ProjectListViewModel).Assembly;
            yield return typeof(ProjectListView).Assembly;
        }
    }
}