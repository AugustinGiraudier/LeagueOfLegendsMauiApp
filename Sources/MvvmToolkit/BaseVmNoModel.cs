﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public class BaseVmNoModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
