using System.Web.Http;
using Castle.Windsor;
using FamilyTasks.Dependencies.Castle;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace FamilyTasks.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = ConfigureWindsor(GlobalConfiguration.Configuration);
            ConfigureOAuth(app, container);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IWindsorContainer container)
        {
            //// Token Generation
            app.UseOAuthAuthorizationServer(container.Resolve<OAuthAuthorizationServerOptions>());
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        public static IWindsorContainer ConfigureWindsor(HttpConfiguration configuration)
        {
            var container = CastleInstaller.Install();
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;
            return container;
        }    
    }
}