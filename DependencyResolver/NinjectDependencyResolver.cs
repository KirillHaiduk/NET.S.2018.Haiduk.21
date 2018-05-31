using BLL.Interface.Services;
using BLL.Services;
using DAL.Fake;
using DAL.Interface.Repository;
using Ninject;

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
