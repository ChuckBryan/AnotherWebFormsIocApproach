namespace AnotherWebFormsIocApproach.StructureMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using global::StructureMap;
    using Microsoft.Practices.ServiceLocation;

    public interface IBuildUp
    {
        void BuildUp(object obj);
    }
    public class StructureMapDependencyResolver : ServiceLocatorImplBase, IBuildUp
    {
        private const string NestedContainerKey = "StructureMap.NestedC.Container";

        public StructureMapDependencyResolver(IContainer container)
        {
            Container = container;
        }

        public IContainer Container { get; set; }

        private HttpContextBase HttpContext
        {
            get
            {
                var ctx = Container.TryGetInstance<HttpContextBase>();
                return ctx ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            }
        }

        public IContainer CurrentNestedContainer
        {
            get => (IContainer) HttpContext.Items[NestedContainerKey];
            set => HttpContext.Items[NestedContainerKey] = value;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            var container = (CurrentNestedContainer ?? Container);

            if (string.IsNullOrEmpty(key))
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                    ? container.TryGetInstance(serviceType)
                    : container.GetInstance(serviceType);
            }

            return container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return (CurrentNestedContainer ?? Container)
                .GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            CurrentNestedContainer?.Dispose();

            Container.Dispose();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return DoGetAllInstances(serviceType);
        }

        public void DisposeNestedContainer()
        {
            CurrentNestedContainer?.Dispose();
        }

        public void CreateNestedContainer()
        {
            if (CurrentNestedContainer != null) return;
            CurrentNestedContainer = Container.GetNestedContainer();
        }

        public void BuildUp(object obj)
        {
            CurrentNestedContainer.BuildUp(obj);
        }
    }
}