using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public class ModifiableChampionAppVM
    {
        private INavigation navigation;
        public ModifiableChamionVM vm { get; private set; }


        public ModifiableChampionAppVM(ModifiableChamionVM vm, INavigation navigation)
        {
            this.navigation = navigation;
            this.vm = vm;

            SaveChangesCommand = new Command(
              execute: () => saveChanges(),
              canExecute: () => vm != null
            );
        }

        private async void saveChanges()
        {
            vm.saveChanges();
            await navigation.PopAsync();
        }

        public ICommand SaveChangesCommand { get; private set; }
    }
}
