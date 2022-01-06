using System;
using System.Collections.Generic;
using System.Text;

namespace SEPFramework.Memento
{
    internal class CareTaker<T>
    {
        private List<Memento<T>> history;
        private int step = 0;
        public void AddMemento(List<T> data)
        {

            step++;
            var temp = new Memento<T>(data);
            try
            {
                history.Add(temp);
            }
            catch (Exception)
            {

            }
        }

        public Memento<T> Undo()
        {
            if (step > 1)
            {
                step--;
            }

         
            return history[step];
           
        }

        public Memento<T> Redo()
        {
            if (step < history.Count)
            {
                step++;
            }
            List<T> result = new List<T>();
            return history[step];
        }

    }
}
