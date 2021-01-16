using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Game.Generic.SKObserver
{
    public class SKObservable<T>
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
        public SKObservable(T value) => Set(value);
        public void Set(T value) => Wrapped = value;
    }

    public class SKObservableInt : SKObservable<int>
    {
        public SKObservableInt(int value = 0) : base(value) { }

        public void Increase(int value) => Wrapped += value;
        public void Decrease(int value) => Wrapped -= value;

    }

    public class SKObservableFloat : SKObservable<float>
    {
        public SKObservableFloat(float value = 0f) : base(value) { }

        public void Increase(float value) => Wrapped += value;
        public void Decrease(float value) => Wrapped -= value;
    }

    public class SKObservableTrigger
    {
        public delegate void OnTrigger();
        public event OnTrigger OnTriggerEvent;
        public void Fire() => OnTriggerEvent?.Invoke();
    }

    public class SKObservableObjectTrigger
    {
        public delegate void OnTrigger(BaseObject Object);
        public event OnTrigger OnTriggerEvent;
        public void Fire(BaseObject Object) => OnTriggerEvent?.Invoke(Object);
    }

    public class SKObservableList<T> : SKObservable<List<T>>
    {
        public SKObservableList(List<T> value) : base(value == null ? new List<T>() : value ) { }

        public static SKObservableList<T> Empty() => new SKObservableList<T>(null);

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
    }

}