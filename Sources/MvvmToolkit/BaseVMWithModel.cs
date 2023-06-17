using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public abstract class BaseVMWithModel<ModelT> : BaseVM
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
