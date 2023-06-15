using App.ViewModel;
using VM;

namespace App.views;

public partial class ChampionsPage : ContentPage
{

	public ChampionManagerAppVM Vm { get; private set; }

    public ChampionsPage(ManagerProvider provider)
	{
        Vm = new ChampionManagerAppVM(Navigation);
		InitializeComponent();
		BindingContext = Vm;
	}
}