using System;
using System.Collections.Generic;
using System.Text;

namespace SEPFramework.Memento
{
    public class CareTaker<T>
    {
        private List<Memento<T>> history= new List<Memento<T>>();
        private int step = -1;
        public void AddMemento(Memento<T> memento)
        {

            step++;
            try
            {
                history.Add(memento);
            }
            catch (Exception)
            {

            }
        }

        public Memento<T> Undo()
        {
            if (step >= 1)
            {
                step--;
                return history[step];
            }
            return null;
           
        }

        public Memento<T> Redo()
        {
            if (step < history.Count-1)
            {
                step++;
                return history[step];
            }
            return null;
        }

    }
}
