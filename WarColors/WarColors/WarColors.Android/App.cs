using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Caliburn.Micro;
using WarColors.Core.Injection;
using WarColors.Views;
using WarColors.ViewModels;
using System.Reflection;
using System.IO;
using MarcelloDB.Platform;
using WarColors.Data.Marcello;

namespace WarColors.Droid
{
    [Application]
    public class App : CaliburnApplication
    {
        private IInjectionContainer container;

        public App(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleInjectionContainer();

            RegisterServices();

            container.Singleton<Application>();
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

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            yield return GetType().Assembly;
            yield return typeof(MasterViewModel).Assembly;
            yield return typeof(MasterView).Assembly;
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
    }
}