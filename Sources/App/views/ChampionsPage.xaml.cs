using VM;

namespace App.views;

public partial class ChampionsPage : ContentPage
{

	public ChampionManagerVM Vm { get; private set; }

    public ChampionsPage(ChampionManagerVM vm)
	{
		Vm = vm;
		InitializeComponent();
		BindingContext = Vm;
	}
}