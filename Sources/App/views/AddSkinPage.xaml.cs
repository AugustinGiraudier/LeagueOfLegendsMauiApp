using App.ViewModel;
using VM;

namespace App.views;

public partial class AddSkinPage : ContentPage
{
    // =============================================== //
    //          Member data
    // =============================================== //

    public SkinAppVM Vm { get; set; }

    // =============================================== //
    //          Constructors
    // =============================================== //

    public AddSkinPage(ChampionVM vm)
	{
		this.Vm = new SkinAppVM(vm, Navigation);
		InitializeComponent();
		BindingContext = Vm;
	}
}