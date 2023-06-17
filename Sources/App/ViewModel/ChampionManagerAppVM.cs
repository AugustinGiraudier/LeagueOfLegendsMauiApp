using System.Windows.Input;
using VM;
using App.views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModel
{
    public partial class ChampionManagerAppVM
    {
        // =============================================== //
        //          Member data
        // =============================================== //

        public INavigation Navigation { get; private set; }

        public ChampionManagerVM vm { get; private set; }

        // =============================================== //
        //          Commands
        // =============================================== //

        [RelayCommand(CanExecute = nameof(NavigationNotNull))]
        private async Task NavigateToChampion(ChampionVM cvm)
        {
            await Navigation.PushAsync(new ChampionPage(cvm));
        }

        [RelayCommand(CanExecute =nameof(NavigationNotNull))]
        private async Task ModifyChampion(ChampionVM cvm)
        {
            await Navigation.PushAsync(new UpdateChampion(cvm));
        }

        [RelayCommand]
        private async Task AddChampion()
        {
            await Navigation.PushAsync(new UpdateChampion());
        }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public ChampionManagerAppVM(INavigation nav)
        {
            this.Navigation = nav;
            vm = ManagerProvider.Instance;
        }

        // =============================================== //
        //          Methods
        // =============================================== //

        private bool NavigationNotNull()
        {
            return Navigation != null;
        }
    }
}
