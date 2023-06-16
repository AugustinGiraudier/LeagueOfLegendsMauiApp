using Model;
using MvvmToolkit;
using VM.Utils;

namespace VM
{
    public class ModifiableSkinVM : BaseVM
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        public ChampionVM Champion { get; private set; }

        public string Name { get; set; } = "New Skin";

        // =============================================== //
        //          Observable Properties
        // =============================================== //

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
