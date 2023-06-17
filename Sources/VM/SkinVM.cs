using MvvmToolkit;
using Model;
using VM.Utils;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VM
{
    public class SkinVM : BaseVMWithModel<Skin>
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        public string Name
        {
            get => Model?.Name;
        }

        public string Description
        {
            get => Model?.Description;
        }

        // =============================================== //
        //          Observable Properties
        // =============================================== //

        public string Icon
        {
            get => Model?.Icon;
            set => SetProperty(Model.Icon, value, Model, (m, d) => m.Description = d);
        }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public SkinVM(Skin model)
            : base(model)
        { }

        // =============================================== //
        //          Methods
        // =============================================== //

        public SkinVM Clone()
        {
            Skin s = new Skin(Name, Model.Champion, icon: Icon);
            return new SkinVM(s);
        }
    }
}
