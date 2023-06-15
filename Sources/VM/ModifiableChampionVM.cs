using Microsoft.Maui.Platform;
using MvvmToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VM
{
    public class ModifiableChampionVM : BaseVM
    {
        private ChampionVM vm;
        public ChampionVM Copy { get; private set; }

        public string CharacteristicToAdd { get; set; } = "";
        public int CharacteristicValueToAdd { get; set; } = 0;

        public string Name { get; set; }

        public bool isNewChampion { get; private init; } = false;

        public ModifiableChampionVM(ChampionVM championVM)
        {
            vm = championVM;
            Copy = championVM.Clone();
            Name = championVM.Name;

            AddCurrentCharacteristic = new Command(() => DoAddCurrentCharacteristic());
        }
        public ModifiableChampionVM()
            :this(new ChampionVM())
        {
            isNewChampion = true;
        }

        public void saveChanges()
        {
            vm.update(Copy);


            // cas d'une creation de champion :
            if(isNewChampion)
            {
                ManagerProvider.Instance?.addChampion(this);
            }
        }

        private void DoAddCurrentCharacteristic()
        {
            if(CharacteristicToAdd != String.Empty)
                Copy.AddCharacteristic(CharacteristicToAdd, CharacteristicValueToAdd);
        }

        public ICommand AddCurrentCharacteristic { get; private set; }
    }
}
