using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SEPFramework
{
    public  class FormData<T> :Interface<T>.IFormBuilder
    {

        protected DataGrid dataGrid;

        protected ObservableCollection<T> data;

        private  History<T> history;

        private Dictionary<string,Action>  actions = new Dictionary<string,Action>();

        

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

        public FormData<T> BuildAction(string actionName,Action callback)
        {
            this.actions[actionName] = callback;
            return this;
        }
        

        public void Render(Panel container)
        {
          
            dataGrid.ItemsSource = data;
            

            AddControl();

            var btn = new Button();
            btn.Content = "Test";
           
            container.Children.Add(dataGrid);
           
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
            this.actions["onDelete"]();
        }
        public void AddControl()
        {
           

            DataGridTemplateColumn col = new DataGridTemplateColumn();
            col.Header = "MyHeader";
            FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            button.SetValue(Button.ContentProperty, "Delete");
            button.AddHandler(Button.ClickEvent, new RoutedEventHandler(Click));
            DataTemplate cellTemplate = new DataTemplate();
            cellTemplate.VisualTree = button;
            col.CellTemplate = cellTemplate;
         
            dataGrid.Columns.Add(col);
            AddDiaLog();
            
        }

        public void AddDiaLog()
        {
            var dialog = new Control();
            dialog.Show();
        }
      
    }
}
