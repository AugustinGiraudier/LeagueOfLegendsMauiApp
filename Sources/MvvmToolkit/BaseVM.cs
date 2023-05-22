using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public abstract class BaseVM<ModelT> : BaseVmNoModel
    {
        public BaseVM(ModelT model)
        {
            Model = model;
        }

        public ModelT Model
        {
            get => model;
            set
            {
                if (model != null && model.Equals(value)) return;
                model = value;
                OnPropertyChanged();
            }
        }
        private ModelT model;


        
    }
}
