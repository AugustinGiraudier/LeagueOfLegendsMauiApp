using System.Windows.Input;
using VM;
using App.views;

namespace App.ViewModel
{
    public class ChampionManagerAppVM
    {
        // =============================================== //
        //          Member data
        // =============================================== //

        public INavigation Navigation { get; private set; }

        public ChampionManagerVM vm { get; private set; }

        // =============================================== //
        //          Commands
        // =============================================== //

        public ICommand NavigateToChampionCommand { get; private set; }

        public ICommand ModifyChampionCommand { get; private set; }

        public ICommand AddChampion { get; private set; }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public ChampionManagerAppVM(INavigation nav)
        {
            this.Navigation = nav;
            vm = ManagerProvider.Instance;

            // commands : 

            NavigateToChampionCommand = new Command<ChampionVM>(
                execute: async (ChampionVM cvm) => await NavigateToChamp(cvm),
                canExecute: (ChampionVM cvm) => Navigation is not null);

            ModifyChampionCommand = new Command<ChampionVM>(
                execute: async (ChampionVM cvm) => await UpdateChampion(cvm),
                canExecute: (ChampionVM cvm) => Navigation != null
            );

            AddChampion = new Command(async () => await NavigateToAddChamion());

        }

        // =============================================== //
        //          Methods
        // =============================================== //

        private async Task NavigateToChamp(ChampionVM cvm)
        {
            await Navigation.PushAsync(new ChampionPage(cvm));
        }

        private async Task NavigateToAddChamion()
        {
            await Navigation.PushAsync(new UpdateChampion());
        }

        private async Task UpdateChampion(ChampionVM cvm)
        {
            await Navigation.PushAsync(new UpdateChampion(cvm));
        }
    }
}
