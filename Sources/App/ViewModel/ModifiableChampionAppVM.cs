﻿using App.Converters;
using System.Windows.Input;
using VM;

namespace App.ViewModel
{
    public class ModifiableChampionAppVM
    {
        private INavigation navigation;
        public ModifiableChampionVM vm { get; private set; }


        public ModifiableChampionAppVM(ModifiableChampionVM vm, INavigation navigation)
        {
            this.navigation = navigation;
            this.vm = vm;

            SaveChangesCommand = new Command(
              execute: async () => await saveChanges(),
              canExecute: () => vm != null
            );

            TakePictureCommand = new Command(() => TakePhoto());
            TakeIconCommand = new Command(() => TakeIcon());
        }
        public ModifiableChampionAppVM(ChampionManagerVM manager, INavigation navigation)
            :this(new ModifiableChampionVM(manager), navigation)
        {
        }

        private async Task saveChanges()
        {
            vm.saveChanges();
            await navigation.PopAsync();
        }

        public ICommand SaveChangesCommand { get; private set; }
        public ICommand TakePictureCommand { get; private set; }
        public ICommand TakeIconCommand { get; private set; }

        public async void TakePhoto()
        {
            string image = await ChooseImageB64();
            if (image != null)
            {
                vm.Copy.Base64Image = image;
            }
        }

        public async void TakeIcon()
        {
            string icon = await ChooseImageB64();
            if(icon != null)
            {
                vm.Copy.Icon = icon;
            }
        }

        private async Task<string> ChooseImageB64()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    Console.WriteLine(photo.ToString());
                    var stream = await photo.OpenReadAsync();
                    var source = ImageSource.FromStream(() => stream);
                    return new Base64ToImageSourceConverter().ConvertBack(source, null, null, null) as string;
                }

            }

            return null;
        }
    }
}
