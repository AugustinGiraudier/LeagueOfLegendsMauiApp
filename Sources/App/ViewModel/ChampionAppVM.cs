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

            AddSkinCommand = new Command(async () => await NavigateToAddSkin());
        }

        private async Task NavigateToChamp()
        {
            await Navigation.PushAsync(new ChampionPage(vm));
        }

        private async Task NavigateToAddSkin()
        {
            await Navigation.PushAsync(new AddSkinPage(vm));
        }

        public ICommand OpenUpdatePage { get; private set; }
        public ICommand AddSkinCommand { get; private set; }
    }
}
