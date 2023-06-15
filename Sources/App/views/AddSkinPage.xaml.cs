using App.ViewModel;
using VM;

namespace App.views;

public partial class AddSkinPage : ContentPage
{

	public SkinAppVM Vm { get; set; }

	public AddSkinPage(ChampionVM vm)
	{
		this.Vm = new SkinAppVM(vm);
		InitializeComponent();
		BindingContext = Vm;
	}
}