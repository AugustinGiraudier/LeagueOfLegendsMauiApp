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
    public class ModifiableChampionVM : BaseVmNoModel
    {
        private ChampionVM vm;
        public ChampionVM Copy { get; private set; }

        private ChampionManagerVM manager = null;

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public bool isNewChampion { get; private init; } = false;

        public ModifiableChampionVM(ChampionVM championVM)
        {
            vm = championVM;
            Copy = championVM.clone();
            Name = championVM.Name;
        }
        public ModifiableChampionVM(ChampionManagerVM manager)
            :this(new ChampionVM())
        {
            isNewChampion = true;
            this.manager = manager;
        }

        public void saveChanges()
        {
            vm.update(Copy);


            // cas d'une creation de champion :
            if(isNewChampion)
            {
                manager?.addChampion(this);
            }
        }
    }
}
