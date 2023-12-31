using App.ViewModel;
using VM;

namespace App.views;

public partial class UpdateChampion : ContentPage
{

    // =============================================== //
    //          Member data
    // =============================================== //

    public ModifiableChampionAppVM Vm { get; private set; }

    // =============================================== //
    //          Constructors
    // =============================================== //

    public UpdateChampion(ChampionVM champ)
    {
        this.Vm = new ModifiableChampionAppVM(new ModifiableChampionVM(champ), Navigation);
        InitializeComponent();
        BindingContext = Vm;
    }

    public UpdateChampion()
    {
        this.Vm = new ModifiableChampionAppVM(Navigation);
        InitializeComponent();
        BindingContext = Vm;
    }





}