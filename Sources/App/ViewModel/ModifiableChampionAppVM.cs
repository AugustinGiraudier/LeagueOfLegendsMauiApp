using App.Converters;
using App.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public partial class ModifiableChampionAppVM
    {
        // =============================================== //
        //          Member data
        // =============================================== //

        private INavigation navigation;

        public ModifiableChampionVM vm { get; private set; }

        // =============================================== //
        //          Commands
        // =============================================== //

        [RelayCommand(CanExecute = nameof(SaveChangesCanExecute))]
        private async Task SaveChanges()
        {
            vm.saveChanges();
            await navigation.PopAsync();
        }
        private bool SaveChangesCanExecute()
        {
            return vm != null;
        }

        [RelayCommand]
        public async void TakePicture()
        {
            string image = await ImageUtils.ChooseImageB64();
            if (image != null)
            {
                vm.Copy.Base64Image = image;
            }
        }

        [RelayCommand]
        public async void TakeIcon()
        {
            string icon = await ImageUtils.ChooseImageB64();
            if (icon != null)
            {
                vm.Copy.Icon = icon;
            }
        }

        // =============================================== //
        //          Constructors
        // =============================================== //

        public ModifiableChampionAppVM(ModifiableChampionVM vm, INavigation navigation)
        {
            this.navigation = navigation;
            this.vm = vm;
        }

        public ModifiableChampionAppVM(INavigation navigation)
            : this(new ModifiableChampionVM(), navigation)
        {
        }
    }
}
