﻿//-------------------------------------------------------------------------
//  (c) 2015 Pervasive Digital LLC
//
//  This file is part of Scratch for .Net Micro Framework
//
//  "Scratch for .Net Micro Framework" is free software: you can 
//  redistribute it and/or modify it under the terms of the 
//  GNU General Public License as published by the Free Software 
//  Foundation, either version 3 of the License, or (at your option) 
//  any later version.
//
//  "Scratch for .Net Micro Framework" is distributed in the hope that
//  it will be useful, but WITHOUT ANY WARRANTY; without even the implied
//  warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See
//  the GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with "Scratch for .Net Micro Framework". If not, 
//  see <http://www.gnu.org/licenses/>.
//
//  This file has also been distributed previously under an Apache 2.0
//  license and you may elect to use that license with this file. This 
//  does not affect the licensing of any other file in Scratch for
//  .Net Micro Framework.
//-------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PervasiveDigital.Scratch.DeploymentHelper.Common
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey,TValue>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        private Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void Add(TKey key, TValue value)
        {
            _dict.Add(key, value);
            OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey,TValue>(key,value)));
        }

        public bool ContainsKey(TKey key)
        {
            return _dict.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return _dict.Keys; }
        }

        public bool Remove(TKey key)
        {
            TValue oldValue = default(TValue);
            if (_dict.ContainsKey(key))
                oldValue = _dict[key];
            var result = _dict.Remove(key);
            if (result)
            {
                OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey,TValue>(key,oldValue)));
            }
            return result;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dict.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return _dict.Values; }
        }

        public TValue this[TKey key]
        {
            get
            {
                return _dict[key];
            }
            set
            {
                var exists = _dict.ContainsKey(key);
                _dict[key] = value;
                if (!exists)
                {
                    OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value)));
                }
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _dict.Add(item.Key, item.Value);
            OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public void Clear()
        {
            _dict.Clear();
            OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dict.ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _dict.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            TValue oldValue = default(TValue);
            if (_dict.ContainsKey(item.Key))
                oldValue = _dict[item.Key];
            var result = _dict.Remove(item.Key);
            if (result)
            {
                OnNotifyCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            }
            return result;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        private void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, args);
            if (args.Action == NotifyCollectionChangedAction.Add
                || args.Action == NotifyCollectionChangedAction.Remove
                || args.Action == NotifyCollectionChangedAction.Reset)
            {
                OnNotifyPropertyChanged("Count");
            }
        }

        private void OnNotifyPropertyChanged([CallerMemberName] string member = "unknown")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(member));
        }

    }
}
