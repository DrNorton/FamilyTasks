﻿using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FamilyTasks.Api;
using FamilyTasks.Api.Controller;
using FamilyTasks.Dao.Repositories;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;

namespace FamilyTasks.Dependencies.Castle.Installers
{
    public class AuthInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<OAuthAuthorizationServerOptions>()
                    .UsingFactoryMethod((kernel, parameters) => new OAuthAuthorizationServerOptions
                    {
                        AllowInsecureHttp = true,
                        TokenEndpointPath = new PathString("/token"),
                        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                        Provider = new SimpleAuthorizationServerProvider(kernel.Resolve<IAuthRepository>())
                    })
                    .LifestyleTransient());
        }
    }
}
