using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SEPFramework
{
    public  class FormData<T>
    {

        protected DataGrid dataGrid;

        protected ObservableCollection<T> data;

        private  History<T> history;

        private ActionStore actionStore = new ActionStore();
       

        public FormData()
        {
            this.dataGrid = new DataGrid();
            this.history = new History<T>();
        }
      

        public FormData<T> BuildData(List<T> dataList)
        {
            
            data = new ObservableCollection<T>(dataList);
            data.CollectionChanged += DataCollectionChanged;
            history.Add(data);
            return this;
        }

        public FormData<T> BuildAction(string actionName,Action function)
        {
            this.actionStore.AddAction(actionName, function);
            return this;
        }

        public FormData<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent,int width)
        {

            DataGridTemplateColumn col = ControlBuilder.BuilDataGridColButton(colHeader, buttonContent, clickEvent,width);
            dataGrid.Columns.Add(col);
            return this;

        }


        public void Render(Panel container)
        {
             
            dataGrid.ItemsSource = data;
            
            container.Children.Add(dataGrid);
            this.BuildButtonColumn("Delete", "Delete", Click,100);
            this.BuildButtonColumn("Edit", "Edit", Click,100);

        }

        private void DataCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
                dataGrid.ItemsSource = data;
            
        }

        public void LogData()
        {
         
        }


        public void RemoveAt(int index)
        
        {
            try
            {
                data.RemoveAt(index);
                history.Add(data);   
            }
            catch (Exception)
            {

            }
        }

        public void RemoveIfPropertyEqual(string propertyName,object value)
        {
            List<int> indexList = new List<int>();
            for (int i= 0;i < data.Count;i++)
            {
               var propertyValue =  data[i].GetType().GetProperty(propertyName).GetValue(data[i],null);
                if (propertyValue == value)
                {
                    indexList.Add(i);
                }
            }

            foreach(int id in indexList)
            {
                data.RemoveAt(id);
            }
        }


        public void Undo()
        {
            var prev = history.Undo();
            var temp = new ObservableCollection<T>(prev);
            data.Clear();
            foreach(var item in temp)
            {
                data.Add(item);
            }
           
        }

        public void Redo()
        {
            var next = history.Redo();
     
            var temp = new ObservableCollection<T>(next);
            data.Clear();

            foreach (var item in temp)
            {
                data.Add(item);
            }

        }


        private void Click(object sender, RoutedEventArgs e)
        {
            RemoveAt(dataGrid.SelectedIndex);
            this.actionStore.ExecuteAction("onDelete");
        }
      

     
      
    }
}
