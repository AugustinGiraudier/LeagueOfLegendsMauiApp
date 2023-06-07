using System.Windows.Input;
using VM;
using App.views;

namespace App.ViewModel
{
    public class ChampionManagerAppVM
    {
        public INavigation Navigation { get; set; }

        public ChampionManagerVM vm { get; private set; }

        public ChampionManagerAppVM(ChampionManagerVM vm)
        {
            this.vm = vm;

            // commands : 

            NavigateToChampion = new Command<ChampionVM>(
                execute: async (ChampionVM cvm) => await NavigateToChamp(cvm),
                canExecute: (ChampionVM cvm) => Navigation is not null);

        }

        private async Task NavigateToChamp(ChampionVM cvm)
        {
            Console.WriteLine("Test");
            await Navigation.PushAsync(new ChampionPage(cvm));
        }

        // Commands :
        public ICommand NavigateToChampion { get; private set; }
    }
}
