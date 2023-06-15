using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VM
{
    public class ModifiableChampionVM
    {
        private ChampionVM vm;
        public ChampionVM Copy { get; private set; }

        
        public ModifiableChampionVM(ChampionVM championVM)
        {
            vm = championVM;
            Copy = championVM.clone();
        }

        public void saveChanges()
        {
            vm.update(Copy);
        }
    }
}
