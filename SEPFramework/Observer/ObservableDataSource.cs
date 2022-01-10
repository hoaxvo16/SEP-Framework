using System;
using System.Collections.Generic;
using System.Text;
using SEPFramework.Interface;

namespace SEPFramework.Observer
{
    public class ObservableDataSource<T>:IObservableDataSource<T>
    {

        private List<ISubscriber<T>> subscribers = new List<ISubscriber<T>>();

        private List<T> dataSource;

        public ObservableDataSource(List<T> source)
        {
            this.dataSource = source;
        }


        public T this[int i]
        {
            get => dataSource[i];
        }

        public int Count()
        {
            return dataSource.Count;
        }

        public List<T> GetDataSource()
        {
            return this.dataSource;
        }
        public void AddNewData(T data)
        {
            this.dataSource.Add(data);
            Notify();
        }
        public void SetDataSource(List<T> data)
        {
            this.dataSource=data;
            Notify();
        }

        public void Subscribe(ISubscriber<T> subscriber)
        {
            this.subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber<T> subscriber)
        {
            this.subscribers.Remove(subscriber);
        }

        public void UpdateData(T newData, int index)
        {
            this.dataSource[index] = newData;
            Notify();
        }

        public void RemoveData(T data)
        {
            this.dataSource.Remove(data);
            Notify();
        }
        public void RemoveAt(int index)
        {
            this.dataSource.RemoveAt(index);
            Notify();
        }


        public void Notify()
        {
            foreach (var subscriber in this.subscribers)
            {
                subscriber.Update(this.dataSource);
            }
        }
    }
}
