using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class ObservableDictionary<TKey, TValue> :
            INotifyCollectionChanged, INotifyPropertyChanged
    {
        readonly IDictionary<TKey, TValue> dictionary;

        public event NotifyCollectionChangedEventHandler CollectionChanged = (sender, args) => { };

        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        public ObservableDictionary()
            : this(new Dictionary<TKey, TValue>())
        {
        }

        public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
        {
            this.dictionary = dictionary;
        }

        public void Add(TKey key, TValue value)
        {
            dictionary.Add(key, value);

            CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
                new KeyValuePair<TKey, TValue>(key, value)));
            PropertyChanged(this, new PropertyChangedEventArgs("Count"));
            PropertyChanged(this, new PropertyChangedEventArgs("Keys"));
            PropertyChanged(this, new PropertyChangedEventArgs("Values"));
        }

        public bool Remove(TKey key)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value) && dictionary.Remove(key))
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,
                    new KeyValuePair<TKey, TValue>(key, value)));
                PropertyChanged(this, new PropertyChangedEventArgs("Count"));
                PropertyChanged(this, new PropertyChangedEventArgs("Keys"));
                PropertyChanged(this, new PropertyChangedEventArgs("Values"));

                return true;
            }

            return false;
        }

    }
}
