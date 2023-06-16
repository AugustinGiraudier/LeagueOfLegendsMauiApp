using App.ViewModel;
using VM;

namespace App.views;

public partial class ChampionsPage : ContentPage
{
    // =============================================== //
    //          Member data
    // =============================================== //

    public ChampionManagerAppVM Vm { get; private set; }

    // =============================================== //
    //          Constructors
    // =============================================== //

    public ChampionsPage(ManagerProvider provider)
	{
        Vm = new ChampionManagerAppVM(Navigation);
		InitializeComponent();
		BindingContext = Vm;
	}
}