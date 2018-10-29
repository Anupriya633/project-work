using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using PatientDemographics.BusinessAccessLayer;
using PatientDemographics.Controllers;

namespace PatientDemographics
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();
            container.RegisterType<PatientController>();
            container.RegisterType<IGetPatientInfoBusinessLayer, GetPatientInfoBusinessLayer>();
            container.RegisterType<ISavePatientInfoBusinessLayer, SavePatientInfoBusinessLayer>();
            config.DependencyResolver = new UnityDependencyResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
