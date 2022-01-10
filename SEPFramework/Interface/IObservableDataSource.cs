using System;
using System.Collections.Generic;
using System.Text;

namespace SEPFramework.Interface
{
    public interface IObservableDataSource<T>
    { 

        public void Subscribe(ISubscriber<T> subscriber);
        public void Unsubscribe(ISubscriber<T> subscriber);
        public void Notify();

    }
}
