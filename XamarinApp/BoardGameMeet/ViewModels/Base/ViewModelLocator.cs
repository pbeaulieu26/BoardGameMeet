using Autofac;
using Autofac.Core;
using BoardGameMeet.Services;
using BoardGameMeet.Services.Interfaces;
using BoardGameMeet.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace MenuApplication.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static IContainer _container;
        private static List<Type> _viewModels;
        private static Dictionary<Type, Type> _serviceInstances;

        static ViewModelLocator()
        {
            _viewModels = new List<Type>
            {
               typeof(MainViewModel),
               typeof(UserViewModel)
            };

            _serviceInstances = new Dictionary<Type, Type>
            {
               { typeof(INetworkService), typeof(BoardGameAtlasNetworkService) },
               { typeof(IPageService), typeof(PageService) },
            };
        }

        public static void Initialize()
        {
            if (_container != null)
                throw new InvalidOperationException("ViewModelLocator is already initialized");

            var builder = new ContainerBuilder();

            _serviceInstances.ForEach(si => builder.RegisterType(si.Value).As(si.Key).SingleInstance());
            _viewModels.ForEach(vm => builder.RegisterType(vm));

            _container = builder.Build();
        }

        public static T Resolve<T>(params Parameter[] parameters) where T : class
        {
            if (_container == null)
                Initialize();

            return _container.Resolve<T>(parameters);
        }

        public static void RegisterService<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            if (_container != null)
                throw new InvalidOperationException("Can not regiter service once ViewModelLocator is initialized");

            _serviceInstances[typeof(TInterface)] = typeof(T);
        }
    }
}
