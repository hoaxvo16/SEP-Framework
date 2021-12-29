using System;
using System.Collections.Generic;
using System.Text;

namespace SEPFramework
{
    internal class ActionStore
    {
        private Dictionary<string, Action> actions = new Dictionary<string, Action>();

        private List<string> acctionNames;

        public ActionStore()
        {
            acctionNames = new List<string>();
            acctionNames.Add("onCellDelete");
            acctionNames.Add("onCellEdit");

        }
        public void AddAction(string actionName,Action action)
        {
            if(this.acctionNames.Contains(actionName))
            this.actions.Add(actionName, action);
            else
            {
                throw new Exception($"Action {actionName} does not exit in FormData");
            }
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
