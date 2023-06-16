using App.Converters;

namespace App.Utils
{
    internal class ImageUtils
    {

        // =============================================== //
        //          Static Methods
        // =============================================== //

        public static async Task<string> ChooseImageB64()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    var source = ImageSource.FromStream(() => stream);
                    return new Base64ToImageSourceConverter().ConvertBack(source, null, null, null) as string;
                }

            }

            return null;
        }

    }
}
