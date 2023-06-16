using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public abstract class BaseVMWithModel<ModelT> : BaseVM
    {

        // =============================================== //
        //          Observable Properties
        // =============================================== //

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

        // =============================================== //
        //          Constructor
        // =============================================== //

        public BaseVMWithModel(ModelT model)
        {
            Model = model;
        }

    }
}
