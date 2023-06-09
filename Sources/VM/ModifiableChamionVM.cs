using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class ModifiableChamionVM
    {
        private ChampionVM vm;
        public ChampionVM Copy { get; private set; }
        
        public ModifiableChamionVM(ChampionVM championVM)
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
