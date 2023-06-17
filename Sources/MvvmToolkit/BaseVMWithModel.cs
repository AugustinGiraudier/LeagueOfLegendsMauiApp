using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public abstract class BaseVMWithModel<ModelT> : BaseVM
    {

        // =============================================== //
        //          Observable Properties
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
