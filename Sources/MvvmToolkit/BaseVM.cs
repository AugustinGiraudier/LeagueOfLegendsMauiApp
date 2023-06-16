using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public class BaseVM : INotifyPropertyChanged
    {

        // =============================================== //
        //          Member data
        // =============================================== //

        public event PropertyChangedEventHandler PropertyChanged;

        // =============================================== //
        //          Methods
        // =============================================== //

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
