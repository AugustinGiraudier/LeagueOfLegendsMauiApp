
using App.ViewModel;
using VM;

namespace App.views;


public partial class ChampionPage : ContentPage
{

	public ChampionAppVM Vm { get; private set; }

	public ChampionPage(ChampionVM champ)
	{
		this.Vm = new ChampionAppVM(champ, Navigation);
		InitializeComponent();
		BindingContext = Vm;
	}
}