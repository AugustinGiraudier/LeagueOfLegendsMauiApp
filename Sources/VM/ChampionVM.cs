using Model;
using MvvmToolkit;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using VM.Mappers;
using VM.Utils;

namespace VM
{
    public partial class ChampionVM : BaseVM<Champion>
    {
        public ReadOnlyObservableCollection<SkinVM> Skins { get; private set; }
        private ObservableCollection<SkinVM> skins = new ObservableCollection<SkinVM>();

        public ReadOnlyObservableDictionary<string, int> Characteristics { get; private set; }
        private ObservableDictionary<string, int> characteristics = new ObservableDictionary<string, int>();
        
        public ChampionVM()
            : this(new Champion("New Champion", ChampionClass.Unknown,
                DefaultImagesUtil.DEFAULT_CHAMPION_ICON,
                DefaultImagesUtil.DEFAULT_CHAMPION_IMAGE,
                "No information..."))
        {}

        public ChampionVM(Champion model)
            : base(model)
        {
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            Characteristics = new ReadOnlyObservableDictionary<string, int>(characteristics);

            foreach (var skin in Model.Skins) {
                this.skins.Add(new SkinVM(skin));
            }
            foreach (var chara in Model.Characteristics)
            {
                this.characteristics.Add(chara.Key, chara.Value);
            }
        }

        public string Name
        {
            get => Model?.Name;
        }

        public string Icon
        {
            get => Model?.Icon;
            set
            {
                if (Model == (null) || Model.Icon.Equals(value)) return;
                Model.Icon = value;
                OnPropertyChanged();
            }
        }

        public string Bio
        {
            get => Model?.Bio;
            set
            {
                if(Model == null || Model.Bio.Equals(value)) return;
                Model.Bio = value;
                OnPropertyChanged();
            }
        }

        public string Base64Image
        {
            get => Model?.Image.Base64;
            set
            {
                if (Model == null || Model.Image == null || Model.Image.Base64.Equals(value)) return;
                Model.Image.Base64 = value;
                OnPropertyChanged();
            }
        }

        public ChampionClassVM Class
        {
            get => ChampionClassMapper.getVM(Model.Class);
            set
            {
                ChampionClass cl = ChampionClassMapper.getModel(value);
                if (Model == (null) || Model.Class.Equals(cl)) return;
                Model.Class = cl;
                OnPropertyChanged();
            }
        }

        public ChampionVM clone()
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
