using System;
using System.Collections.Generic;
using System.Text;
using SEPFramework.Interface;
using SEPFramework.Memento;

namespace SEPFramework.Observer
{
    public class ObservableDataSource<T>:IObservableDataSource<T>
    {

        private List<ISubscriber<T>> subscribers = new List<ISubscriber<T>>();

        private List<T> dataSource;

        private CareTaker<T> careTaker = new CareTaker<T>();

        public ObservableDataSource(List<T> source)
        {
            this.dataSource = source;
            this.UpdateCareTaker();
        }


        public T this[int i]
        {
            get => dataSource[i];
        }

        public int Count()
        {
            return dataSource.Count;
        }

        public void AddNewData(T data)
        {
            this.dataSource.Add(data);
            this.UpdateCareTaker();
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
            this.UpdateCareTaker();
            Notify();
        }

        public void RemoveData(T data)
        {
            this.dataSource.Remove(data);
            this.UpdateCareTaker();
            Notify();
        }
        public void RemoveAt(int index)
        {
            this.dataSource.RemoveAt(index);
            this.UpdateCareTaker();
            Notify();
        }


        public void Notify()
        {
            foreach (var subscriber in this.subscribers)
            {
                subscriber.Update(this.dataSource);
            }
        }

        public void Undo()
        {
            var prev = this.careTaker.Undo();
            if (prev != null)
            {
                this.dataSource = prev.GetSate();
                this.Notify();
            }
             
        }

        public void Redo()
        {
            var next = this.careTaker.Redo();
            if (next != null)
            {
                this.dataSource = next.GetSate();
                this.Notify();
            }
        }


        public void RemoveIfPropertyEqual(string propertyName, object value)
        {
            List<int> indexList = new List<int>();
            for (int i = 0; i < dataSource.Count; i++)
            {
                var propertyValue = dataSource[i].GetType().GetProperty(propertyName).GetValue(dataSource[i], null);
                if (propertyValue == value)
                {
                    indexList.Add(i);
                }
            }

            foreach (int id in indexList)
            {
                dataSource.RemoveAt(id);
            }
            this.Notify();
        }

        private void UpdateCareTaker()
        {
            this.careTaker.AddMemento(new Memento<T>(this.dataSource));
        }

        
    }
}
