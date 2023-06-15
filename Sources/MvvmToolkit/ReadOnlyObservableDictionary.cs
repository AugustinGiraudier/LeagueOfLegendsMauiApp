using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MvvmToolkit
{
    public class ReadOnlyObservableDictionary<TKey, TValue> : ReadOnlyDictionary<TKey, TValue>,
        INotifyCollectionChanged,
        INotifyPropertyChanged where TKey : notnull
    {
        public ReadOnlyObservableDictionary(ObservableDictionary<TKey, TValue> dictionary) : base(dictionary)
        {
            dictionary.CollectionChanged += HandleCollectionChanged;
            dictionary.PropertyChanged += HandlePropertyChanged;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(this, args);
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            OnPropertyChanged(eventArgs);
        }

        private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            OnCollectionChanged(eventArgs);
        }
    }
}
