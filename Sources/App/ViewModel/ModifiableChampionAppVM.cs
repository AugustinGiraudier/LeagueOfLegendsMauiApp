using App.Converters;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public class ModifiableChampionAppVM
    {
        private INavigation navigation;
        public ModifiableChamionVM vm { get; private set; }


        public ModifiableChampionAppVM(ModifiableChamionVM vm, INavigation navigation)
        {
            this.navigation = navigation;
            this.vm = vm;

            SaveChangesCommand = new Command(
              execute: () => saveChanges(),
              canExecute: () => vm != null
            );

            TakePictureCommand = new Command(() => TakePhoto());
        }

        private async void saveChanges()
        {
            vm.saveChanges();
            await navigation.PopAsync();
        }

        public ICommand SaveChangesCommand { get; private set; }
        public ICommand TakePictureCommand { get; private set; }

        public async void TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    Console.WriteLine(photo.ToString());
                    var stream = await photo.OpenReadAsync();
                    var source = ImageSource.FromStream(() => stream);
                    string b64 = new Base64ToImageSourceConverter().ConvertBack(source,null, null, null) as string;

                    vm.Copy.Base64Image = b64;
                }

            }
        }
    }
}
