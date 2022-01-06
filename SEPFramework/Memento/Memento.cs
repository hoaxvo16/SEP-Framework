using System;
using System.Collections.Generic;
using System.Text;

namespace SEPFramework.Memento
{
    public class Memento<T>
    {
       private  List<T> state;
  
      public  Memento(List<T> data)
        {
            this.state = new List<T>(data);
        }

        public List<T> GetSate()
        {
            return this.state;
        }
    }
}
