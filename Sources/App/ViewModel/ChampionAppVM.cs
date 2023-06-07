using App.views;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public class ChampionAppVM
    {
        public INavigation Navigation { get; set; }

        public ChampionVM vm { get; private set; }

        public ChampionAppVM(ChampionVM vm)
        {
            this.vm = vm;

            NavigateToChampion = new Command(
                execute: async () => await NavigateToChamp(),
                canExecute: () => Navigation is not null);
        }

        private async Task NavigateToChamp()
        {
            await Navigation.PushAsync(new ChampionPage(vm));
        }

        public ICommand NavigateToChampion { get; private set; }
    }
}
