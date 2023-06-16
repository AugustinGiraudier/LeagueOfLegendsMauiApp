using App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public class SkinAppVM
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        public ModifiableSkinVM vm { get; private init; }

        private INavigation navigation;

        // =============================================== //
        //          Commands
        // =============================================== //

        public ICommand TakeIconCommand { get; private init; }

        public ICommand SaveChangesCommand { get; private init; }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public SkinAppVM(ChampionVM ch, INavigation nav)
        {
            this.vm = new ModifiableSkinVM(ch);
            this.navigation = nav;

            TakeIconCommand = new Command(async () => await TakeIcon());
            SaveChangesCommand = new Command(async () => await SaveChanges());
        }

        // =============================================== //
        //          Methods
        // =============================================== //

        public async Task TakeIcon()
        {
            string image = await ImageUtils.ChooseImageB64();
            if (image != null)
            {
                vm.Icon = image;
            }
        }
        public async Task SaveChanges()
        {
            vm.saveChanges();
            await navigation.PopAsync();
        }

    }
}
