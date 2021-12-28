using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SEPFramework
{

 
    class History<T>
    {
        private int step = 0;
        private Dictionary<int,List<T>> history = new Dictionary<int,List<T>>();

        public void Add(ObservableCollection<T> data)
        {
            
            step++;
            var temp = new List<T>(data);
            try
            {
                history.Add(step, temp);
            }
            catch (Exception)
            {
               
            }
        }

        public List<T> Undo()
        {
            if (step > 1)
            {
                step--;
            }

            List<T> result = new List<T>();
            this.history.TryGetValue(step,out result);
            return result;
        }

        public List<T> Redo()
        {
            if (step < history.Count)
            {
                step++;
            }
            List<T> result = new List<T>();
           
            this.history.TryGetValue(step, out result);
            return result;
        }

    }
}
