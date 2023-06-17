using App.views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public partial class ChampionAppVM
    {
        // =============================================== //
        //          Member data
        // =============================================== //

        public INavigation Navigation { get; private set; }

        public ChampionVM vm { get; private set; }

        // =============================================== //
        //          Commands
        // =============================================== //

        [RelayCommand]
        private async Task AddSkin()
        {
            await Navigation.PushAsync(new AddSkinPage(vm));
        }

        [RelayCommand(CanExecute =nameof(NavigationNotNull))]
        private async Task OpenUpdatePage()
        {
            await Navigation.PushAsync(new UpdateChampion(vm));
        }

        //public ICommand AddSkinCommand { get; private set; }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public ChampionAppVM(ChampionVM vm, INavigation nav)
        {
            this.vm = vm;
            this.Navigation = nav;
        }

        // =============================================== //
        //          Methods
        // =============================================== //

        private async Task NavigateToChamp()
        {
            await Navigation.PushAsync(new ChampionPage(vm));
        }

        private bool NavigationNotNull()
        {
            return Navigation != null; 
        }
    }
}
