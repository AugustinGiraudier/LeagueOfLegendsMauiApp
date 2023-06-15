using App.ViewModel;
using VM;

namespace App.views;

public partial class UpdateChampion : ContentPage
{
    public ModifiableChampionAppVM Vm { get; private set; }

    public UpdateChampion(ChampionVM champ)
    {
        this.Vm = new ModifiableChampionAppVM(new ModifiableChampionVM(champ), Navigation);
        InitializeComponent();
        BindingContext = Vm;
    }

    public UpdateChampion(ChampionManagerVM manager)
    {
        this.Vm = new ModifiableChampionAppVM(manager, Navigation);
        InitializeComponent();
        BindingContext = Vm;
    }


}