using App.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public partial class SkinAppVM
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        public ModifiableSkinVM vm { get; private init; }

        private INavigation navigation;

        // =============================================== //
        //          Commands
        // =============================================== //

        [RelayCommand]
        public async Task TakeIcon()
        {
            string image = await ImageUtils.ChooseImageB64();
            if (image != null)
            {
                vm.Icon = image;
            }
        }

        [RelayCommand]
        public async Task SaveChanges()
        {
            vm.saveChanges();
            await navigation.PopAsync();
        }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public SkinAppVM(ChampionVM ch, INavigation nav)
        {
            this.vm = new ModifiableSkinVM(ch);
            this.navigation = nav;
        }

    }
}
