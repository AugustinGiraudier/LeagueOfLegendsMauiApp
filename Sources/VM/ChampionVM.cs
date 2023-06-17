using Model;
using MvvmToolkit;
using System.Collections.ObjectModel;
using VM.Mappers;
using VM.Utils;

namespace VM
{
    public partial class ChampionVM : BaseVMWithModel<Champion>
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        public string Name
        {
            get => Model?.Name;
        }

        // =============================================== //
        //          Observable Properties
        // =============================================== //

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private set; }
        private ObservableCollection<SkinVM> skins = new ObservableCollection<SkinVM>();

        public ReadOnlyObservableDictionary<string, int> Characteristics { get; private set; }
        private ObservableDictionary<string, int> characteristics = new ObservableDictionary<string, int>();

        public string Icon
        {
            get => Model?.Icon;
            set => SetProperty(Model.Icon, value, Model, (m, i) => m.Icon = i);
        }

        public string Base64Image
        {
            get => Model?.Image.Base64;
            set => SetProperty(Model.Image.Base64, value, Model, (m, i) => m.Image.Base64 = i);
        }

        public string Bio
        {
            get => Model?.Bio;
            set => SetProperty(Model.Bio, value, Model, (m, b) => m.Bio = b);
        }

        public ChampionClassVM Class
        {
            get => ChampionClassMapper.getVM(Model.Class);
            set => SetProperty(Model.Class, ChampionClassMapper.getModel(value), Model, (m, c) => m.Class = c);
        }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public ChampionVM()
            : this(new Champion("New Champion", ChampionClass.Unknown,
                        DefaultImagesUtil.DEFAULT_CHAMPION_ICON,
                        DefaultImagesUtil.DEFAULT_CHAMPION_IMAGE,
                        "No information..."))
        { }

        public ChampionVM(Champion model)
            : base(model)
        {
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            Characteristics = new ReadOnlyObservableDictionary<string, int>(characteristics);

            foreach (var skin in Model.Skins)
            {
                this.skins.Add(new SkinVM(skin));
            }
            foreach (var chara in Model.Characteristics)
            {
                this.characteristics.Add(chara.Key, chara.Value);
            }
        }

        // =============================================== //
        //          Methods
        // =============================================== //

        public ChampionVM Clone()
        {
            Champion c = new Champion(Name, ChampionClassMapper.getModel(Class), Icon, Base64Image, Bio);
            foreach(var chara in Characteristics)
            {
                c.AddCharacteristics(Tuple.Create(chara.Key,chara.Value));
            }
            return new ChampionVM(c);
        }

        public void AddCharacteristic(string characteristic, int value)
        {
            Model?.AddCharacteristics(Tuple.Create(characteristic, value));
            characteristics.Remove(characteristic);
            characteristics.Add(characteristic, value);
        }

        public void addSkin(SkinVM skin)
        {
            skins.Add(skin);
        }

        public void update(ChampionVM other)
        {
            if (other == null) return;
            Base64Image = other.Base64Image;
            Bio = other.Bio;
            Class = other.Class;
            Icon = other.Icon;
            characteristics.Clear();
            foreach (var chara in other.Characteristics)
            {
                characteristics.Add(chara.Key, chara.Value);
                Model?.AddCharacteristics(new Tuple<string, int>[] { Tuple.Create(chara.Key, chara.Value) });
            }
        }
    }
}
