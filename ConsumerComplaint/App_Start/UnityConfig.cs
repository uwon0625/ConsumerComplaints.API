using ConsumerComplaints.API.Models;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ConsumerComplaints.API
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IComplaintContext, ComplaintContext>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        }
    }
}