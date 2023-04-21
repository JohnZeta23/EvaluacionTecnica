using CapaData;
using CapaData.Models;
using CapaNegocios.CRUD;
using CapaNegocios.Interfaces;
using CapaNegocios.Tools;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace EvaluacionTecnica
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICRUD<Usuario>, UsuariosCRUD>();
            container.RegisterType<ICRUD<Role>, RoleCRUD>();
            container.RegisterType<ILoginAuthentication, LoginAuthenticationcs>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}