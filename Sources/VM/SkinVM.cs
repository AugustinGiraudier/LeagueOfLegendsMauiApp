using MvvmToolkit;
using Model;

namespace VM
{
    public class SkinVM : BaseVM<Skin>
    {
        public SkinVM(Skin model) 
            : base(model)
        {}

        public string Name
        {
            get => Model?.Name;
        }

        public string Description
        {
            get => Model?.Description;
        }

        public string Icon
        {
            get => Model?.Icon;
            set
            {
                if (Model?.Icon == value) return;
                Model.Icon = value;
                OnPropertyChanged();
            }
        }
    }
}
