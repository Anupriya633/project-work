using System.Web.Http;
using Unity;
using Unity.WebApi;
using PatientDemographics.BusinessAccessLayer;


namespace PatientDemographics
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
           // internal static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() => new UnityContainer());

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. 
            container.RegisterType<IGetPatientInfoBusinessLayer, GetPatientInfoBusinessLayer>();
            container.RegisterType<ISavePatientInfoBusinessLayer, SavePatientInfoBusinessLayer>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}