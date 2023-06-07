using App.ViewModel;
using VM;

namespace App.views;

public partial class ChampionsPage : ContentPage
{

	public ChampionManagerAppVM Vm { get; private set; }

    public ChampionsPage(ChampionManagerVM vm)
	{
		Vm = new ChampionManagerAppVM(vm);
		Vm.Navigation = this.Navigation;
		InitializeComponent();
		BindingContext = Vm;
	}
}