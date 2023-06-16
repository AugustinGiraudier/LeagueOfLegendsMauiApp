
using App.ViewModel;
using VM;

namespace App.views;


public partial class ChampionPage : ContentPage
{
    // =============================================== //
    //          Member data
    // =============================================== //

    public ChampionAppVM Vm { get; private set; }

    // =============================================== //
    //          Constructors
    // =============================================== //

    public ChampionPage(ChampionVM champ)
	{
		this.Vm = new ChampionAppVM(champ, Navigation);
		InitializeComponent();
		BindingContext = Vm;
	}
}