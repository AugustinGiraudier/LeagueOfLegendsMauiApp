using Model;
using MvvmToolkit;
using System.Collections.ObjectModel;
using VM.Mappers;

namespace VM
{
    public class ChampionVM : BaseVM<Champion>
    {
        public ChampionVM()
            : this(new Champion("New Champion", ChampionClass.Fighter, "", "", ""))
        {}

        public ChampionVM(Champion model)
            : base(model)
        {}

        public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
        private ObservableCollection<ChampionVM> champions = new ObservableCollection<ChampionVM>();

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

    }
}
