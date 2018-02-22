using System.Threading.Tasks;
using System.Windows.Input;
using WcfTestClient.WcfCore;

namespace WcfTestClient.ViewModel
{
    public class HostAddressEntryViewModel : ViewModelBase
    {
        public bool LoginIsRuning { get; set; } = false;
        
        /// <summary>
        /// Host Address from user
        /// </summary>
        public string HostAddress { get; set; }

        #region Commads
        /// <summary>
        /// Slide control from above
        /// </summary>
        public ICommand ShowEntryControlCommand { get; private set; }

        /// <summary>
        /// Load date from Hosst address 
        /// </summary>
        public ICommand LoadCommand { get; private set; }
        #endregion //Commads

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HostAddressEntryViewModel()
        {
            ShowEntryControlCommand = new RaleyCommand(parm => IoCConteiner.Get<ApplicationViewModel>().HostAddressControlVisible ^= true);
            LoadCommand = new RaleyCommand(async (parm) => await Load(parm));
        }

        #endregion

        #region Private helpers

        private async Task Load(object parm)
        {
            await RunCommand(() => this.LoginIsRuning, async () =>
            {
                IoCConteiner.Get<ApplicationViewModel>().ServicesListVisible = false;

                await Task.Delay(1000);
                var metadataLoader = new MetadataLoader(new MetadataSetCreator(HostAddress));
                ServiceProxyGenerator proxyGenerator = new ServiceProxyGenerator(metadataLoader);

                IoCConteiner.Get<ApplicationViewModel>().Services = proxyGenerator.CreateGenerator();
                IoCConteiner.Get<ApplicationViewModel>().HostAddressControlVisible = false;
                IoCConteiner.Get<ApplicationViewModel>().ServicesListVisible = true;
            });
        }

        #endregion
    }
}
