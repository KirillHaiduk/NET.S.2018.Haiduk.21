using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Fake;
using DAL.Interface.Repository;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace DependencyResolver
{
    public static class NinjectDependencyResolver
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IBonusCalculator>().To<StandartBonusCalculator>().InSingletonScope();
            kernel.Bind<IAccountNumberGenerator>().To<StandartAccountNumberGenerator>().InSingletonScope();
            kernel.Bind<IRepository>().To<ListRepository>();            
        }
    }
}
