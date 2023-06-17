using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using MvvmToolkit;
using VM.Utils;

namespace VM
{
    public partial class ModifiableSkinVM : ObservableObject
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        public ChampionVM Champion { get; private set; }

        public string Name { get; set; } = "New Skin";

        // =============================================== //
        //          Observable Properties
        // =============================================== //

        [ObservableProperty]
        private string icon = DefaultImagesUtil.DEFAULT_CHAMPION_ICON;

        // =============================================== //
        //          Constructors
        // =============================================== //

        public ModifiableSkinVM(ChampionVM ch)
        {
            Champion = ch;
        }

        // =============================================== //
        //          Methods
        // =============================================== //

        public void saveChanges()
        {
            ManagerProvider.Instance?.addSkin(this);
            Champion.addSkin(new SkinVM(new Skin(Name, Champion.Model, icon:Icon)));
        }

    }
}
