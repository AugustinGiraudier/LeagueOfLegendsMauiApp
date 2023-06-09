using App.views;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public class ChampionAppVM
    {
        public INavigation Navigation { get; private set; }

        public ChampionVM vm { get; private set; }

        public ChampionAppVM(ChampionVM vm, INavigation nav)
        {
            this.vm = vm;
            this.Navigation = nav;

            OpenUpdatePage = new Command(
                execute: async () => await Navigation.PushAsync(new UpdateChampion(vm)),
                canExecute: () => Navigation != null
            );
        }

        private async Task NavigateToChamp()
        {
            await Navigation.PushAsync(new ChampionPage(vm));
        }

        public ICommand OpenUpdatePage { get; private set; }
    }
}
