using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmToolkit
{
    public abstract class BaseVMWithModel<ModelT> : ObservableObject
    {

        // =============================================== //
        //          Member Data
        // =============================================== //

        public ModelT Model { get; set; }

        // =============================================== //
        //          Constructor
        // =============================================== //

        public BaseVMWithModel(ModelT model)
        {
            Model = model;
        }

    }
}
