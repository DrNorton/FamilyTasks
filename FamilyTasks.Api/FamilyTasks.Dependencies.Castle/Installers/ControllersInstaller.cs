using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FamilyTasks.Api.Controller.ApiResults;

namespace FamilyTasks.Dependencies.Castle.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<ApiResult>()
                    .BasedOn<ApiController>()
                    .LifestyleTransient());
        }
    }
}
