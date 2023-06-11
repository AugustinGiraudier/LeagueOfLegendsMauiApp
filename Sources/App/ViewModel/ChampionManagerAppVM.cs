using System.Windows.Input;
using VM;
using App.views;

namespace App.ViewModel
{
    public class ChampionManagerAppVM
    {
        public INavigation Navigation { get; private set; }

        public ChampionManagerVM vm { get; private set; }

        public ChampionManagerAppVM(ChampionManagerVM vm, INavigation nav)
        {
            this.vm = vm;
            this.Navigation = nav;

            // commands : 

            NavigateToChampionCommand = new Command<ChampionVM>(
                execute: async (ChampionVM cvm) => await NavigateToChamp(cvm),
                canExecute: (ChampionVM cvm) => Navigation is not null);

            ModifyChampionCommand = new Command<ChampionVM>(
                execute: async (ChampionVM cvm) => await Navigation.PushAsync(new UpdateChampion(cvm)),
                canExecute: (ChampionVM cvm) => Navigation != null
            );

        }

        private async Task NavigateToChamp(ChampionVM cvm)
        {
            Console.WriteLine("Test");
            await Navigation.PushAsync(new ChampionPage(cvm));
        }

        // Commands :
        public ICommand NavigateToChampionCommand { get; private set; }
        public ICommand ModifyChampionCommand { get; private set; }
    }
}
