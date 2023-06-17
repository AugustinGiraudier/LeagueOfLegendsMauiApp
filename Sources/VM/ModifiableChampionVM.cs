using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class ModifiableChampionVM : ObservableObject
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        private ChampionVM vm;

        public ChampionVM Copy { get; private set; }

        public string CharacteristicToAdd { get; set; } = "";

        public int CharacteristicValueToAdd { get; set; } = 0;

        public string Name { get; set; }

        public bool isNewChampion { get; private init; } = false;

        // =============================================== //
        //          Commands
        // =============================================== //

        [RelayCommand]
        private void AddCurrentCharacteristic()
        {
            if (CharacteristicToAdd != String.Empty)
                Copy.AddCharacteristic(CharacteristicToAdd, CharacteristicValueToAdd);
        }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public ModifiableChampionVM(ChampionVM championVM)
        {
            vm = championVM;
            Copy = championVM.Clone();
            Name = championVM.Name;
        }

        public ModifiableChampionVM()
            : this(new ChampionVM())
        {
            isNewChampion = true;
        }

        // =============================================== //
        //          Methods
        // =============================================== //

        public void saveChanges()
        {
            vm.update(Copy);


            // cas d'une creation de champion :
            if(isNewChampion)
            {
                ManagerProvider.Instance?.addChampion(this);
            }
        }
    }
}
