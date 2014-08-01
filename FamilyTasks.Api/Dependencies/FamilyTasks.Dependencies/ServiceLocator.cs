using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FamilyTasks.Dependencies.Castle;

namespace FamilyTasks.Dependencies
{
    public class ServiceLocator
    {
        public static IWindsorContainer Install()
        {
            return CastleInstaller.Install();
        }
    }
}
