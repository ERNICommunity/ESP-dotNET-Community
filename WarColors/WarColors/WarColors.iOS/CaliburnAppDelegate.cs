using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Reflection;
using WarColors.Core.Injection;
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

            container
                .Singleton<WarColors.Application>();
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
            yield return typeof(HelloViewModel).Assembly;
            yield return typeof(HelloView).Assembly;
        }
    }
}