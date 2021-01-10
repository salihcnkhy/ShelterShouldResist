using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Game.Generic.SKObserver
{
    public abstract class SKObservable<T>
    {
        private T _wrappedValue;
        protected T Wrapped
        {
            get => _wrappedValue;
            set
            {
                _wrappedValue = value;
                OnChangeEvent?.Invoke(_wrappedValue);
            }
        }

        public T Get() => Wrapped;

        public delegate void OnChange(T newValue);
        public event OnChange OnChangeEvent;
    
    }

    public class SKObservableInt : SKObservable<int>
    {
        public SKObservableInt(int value = 0) => Set(value);
        public void Increase(int value) => Wrapped += value;
        public void Decrease(int value) => Wrapped -= value;
        public void Set(int value) => Wrapped = value;

    }

    public class SKObservableFloat : SKObservable<float>
    {
        public SKObservableFloat(float value = 0) => Set(value);

        public void Increase(float value) => Wrapped += value;
        public void Decrease(float value) => Wrapped -= value;
        public void Set(float value) => Wrapped = value;
    }

    public class SKObservableList<T> : SKObservable<List<T>>
    {
        public SKObservableList() => Set(new List<T>());

        public delegate void OnNewElementAppened(T newValue);
        public event OnNewElementAppened OnNewElementAppenedEvent;

        public delegate void OnElementRemoved(T removedValue);
        public event OnElementRemoved OnElementRemovedEvent;

        public void Append(T value)
        {
            var temp = Wrapped;
            temp.Add(value);
            Wrapped = temp;
            OnNewElementAppenedEvent?.Invoke(value);
        }
        public bool Remove(T value)
        {
            var temp = Wrapped;
            bool success = temp.Remove(value);
            if(success)
            {
                Wrapped = temp;
                OnElementRemovedEvent?.Invoke(value);
            }

            return success;
        }
        public void Set(List<T> value) => Wrapped = value;
    }

}