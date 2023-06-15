using Model;
using MvvmToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VM.Utils;

namespace VM
{
    public class ModifiableSkinVM : BaseVM
    {
        public ChampionVM Champion { get; private set; }

        public ModifiableSkinVM(ChampionVM ch)
        {
            Champion = ch;
        }

        public string Name { get; set; } = "New Skin";

        private string icon = DefaultImagesUtil.DEFAULT_CHAMPION_ICON;
        public string Icon
        {
            get => icon;
            set
            {
                icon = value;
                OnPropertyChanged();
            }
        }

        public void saveChanges()
        {
            ManagerProvider.Instance?.addSkin(this);
            Champion.addSkin(new SkinVM(new Skin(Name, Champion.Model, icon:Icon)));
        }

    }
}
