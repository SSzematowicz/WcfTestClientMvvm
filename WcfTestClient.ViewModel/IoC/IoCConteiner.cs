using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public static class IoCConteiner
    {
        public static IKernel Kernel { get; set; } = new StandardKernel();

        public static T Get<T>() => Kernel.Get<T>();

        public static ApplicationViewModel Application => Get<ApplicationViewModel>();

        public static void Setup() => BindViewModel();

        private static void BindViewModel()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
    }
}
