using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmToolkit
{
    public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyCollectionChanged,
        INotifyPropertyChanged where TKey : notnull
    {
        public ObservableDictionary() : base(new Dictionary<TKey, TValue>())
        {
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(this, args);
        }

        private static NotifyCollectionChangedEventArgs AddCollectionEventArgs(TKey key, TValue value)
        {
            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                new KeyValuePair<TKey, TValue>(key, value));
        }

        private static NotifyCollectionChangedEventArgs RemoveCollectionEventArgs(TKey key)
        {
            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, key);
        }

        private static NotifyCollectionChangedEventArgs ReplaceCollectionEventArgs(TKey key, TValue newValue,
            TValue oldValue)
        {
            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace,
                new KeyValuePair<TKey, TValue>(key, newValue),
                new KeyValuePair<TKey, TValue>(key, oldValue));
        }

        private static NotifyCollectionChangedEventArgs ResetCollectionEventArgs()
        {
            return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
        }

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            SendAllCollectionChanged(AddCollectionEventArgs(key, value));
        }

        public new bool TryAdd(TKey key, TValue value)
        {
            if (!base.TryAdd(key, value)) return false;
            SendAllCollectionChanged(AddCollectionEventArgs(key, value));
            return true;
        }

        public new void Clear()
        {
            base.Clear();
            SendAllCollectionChanged(ResetCollectionEventArgs());
        }

        public new bool Remove(TKey key)
        {
            if (!base.Remove(key)) return false;
            SendAllCollectionChanged(RemoveCollectionEventArgs(key));
            return true;
        }

        private void SendAllCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            OnCollectionChanged(args);
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(Keys));
            OnPropertyChanged(nameof(Values));
        }
    }
}
