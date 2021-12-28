using System;
using System.Collections.Generic;
using System.Text;

namespace SEPFramework
{
    internal class ActionStore
    {
        private Dictionary<string, Action> actions = new Dictionary<string, Action>();

        private List<string> acctionNames=new List<string>();


        public void AddAction(string actionName,Action action)
        {
            this.actions.Add(actionName, action);
        }

        public void ExecuteAction(string actionName)
        {
            if (this.actions.ContainsKey(actionName))
            {
                this.actions[actionName]();
            }
            else
            {
                throw new Exception($"Action {actionName} does not exit in FormData");
            }
        }

    }
}
