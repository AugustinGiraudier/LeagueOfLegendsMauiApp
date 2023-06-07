
using VM;

namespace App.views;


public partial class ChampionPage : ContentPage
{

	public ChampionVM champVM { get; private set; }

	public ChampionPage(ChampionVM champ)
	{
		this.champVM = champ;
		InitializeComponent();
		BindingContext = champVM;
	}
}