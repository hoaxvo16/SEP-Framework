using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SEPFramework
{
    public class ActionStore
    {
        private Dictionary<string, Action<object[]>> actions = new Dictionary<string, Action<object[]>>();
     

        private List<string> acctionNames;

        public ActionStore()
        {
            acctionNames = new List<string>();
            acctionNames.Add("onRowDelete");
            acctionNames.Add("onRowEdit");
            acctionNames.Add("onAddNew");
            acctionNames.Add("onUndo");
            acctionNames.Add("onRedo");

        }
        public void AddAction(string actionName,Action<object[]> action)
        {
            if(!this.actions.ContainsKey(actionName))
                this.actions.Add(actionName, action);
        }

        public void ExecuteAction(string actionName,object[] parameter)
        {
            if (this.actions.ContainsKey(actionName))
            {
             
                this.actions[actionName](parameter);
            }
            else
            {
               //do sth
            }
        }

  
    }
}
