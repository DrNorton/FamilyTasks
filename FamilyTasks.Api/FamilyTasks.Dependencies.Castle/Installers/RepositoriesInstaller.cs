using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FamilyTasks.Dao.Repositories;
using FamilyTasks.EfDao;

namespace FamilyTasks.Dependencies.Castle.Installers
{
    public class RepositoriesInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<EfContext>().LifestyleTransient());

            container.Register(Component.For<IAuthRepository, EfAuthRepository>().LifestyleTransient());

        }
    }
}
