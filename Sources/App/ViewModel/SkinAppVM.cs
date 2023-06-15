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

        public ModifiableSkinVM vm { get; private init; }
        
        public SkinAppVM(ChampionVM ch)
        {
            this.vm = new ModifiableSkinVM(ch);

            TakeIconCommand = new Command(async () => await TakeIcon());
        }

        public async Task TakeIcon()
        {
            string image = await ImageUtils.ChooseImageB64();
            if (image != null)
            {
                vm.Icon = image;
            }
        }

        public ICommand TakeIconCommand { get; private init; }
    }
}
