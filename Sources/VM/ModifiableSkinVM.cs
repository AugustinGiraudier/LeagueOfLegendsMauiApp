using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VM.Utils;

namespace VM
{
    public class ModifiableSkinVM
    {
        public ChampionVM Champion { get; private set; }

        public ModifiableSkinVM(ChampionVM ch)
        {
            Champion = ch;
        }

        public string Name { get; set; } = "New Skin";
        public string Icon { get; set; } = DefaultImagesUtil.DEFAULT_CHAMPION_ICON;

        public void saveChanges()
        {
            ManagerProvider.Instance?.addSkin(this);
            Champion.addSkin(new SkinVM(new Skin(Name, Champion.Model, icon:Icon)));
        }

    }
}
