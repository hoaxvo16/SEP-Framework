using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SEPFramework
{
    public class DataGrid<T>
    {

        //Atributes

        protected DataGrid UIElement;

        protected ObservableCollection<T> data;

        private History<T> history;

        private ActionStore actionStore = new ActionStore();

        //Getter, Setter

        public void SetDataList(List<T> dataList)
        {
            this.data = new ObservableCollection<T>(dataList);
            this.data.CollectionChanged += DataCollectionChanged;
            UpdateHistory();
        }

        public void AddAction(string actionName, Action<object[]> function)
        {
            this.actionStore.AddAction(actionName, function);
        }

        public void AddColumn(DataGridTemplateColumn col)
        {
            this.UIElement.Columns.Add(col);
        }

        //Constructor
        public DataGrid()
        {
            this.UIElement = new DataGrid();
            this.UIElement.IsReadOnly = true;
            this.UIElement.MouseDoubleClick += DataGridMouseDoubleClick;
            this.history = new History<T>();

        }

        //Render
        public void Render(Panel container)
        {

            UIElement.ItemsSource = data;
            container.Children.Add(UIElement);
        }


        //Event handler


        //Click Event

        private void DataGridMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedItem = data[UIElement.SelectedIndex];
            var editForm = new EditForm();
            editForm.Init(selectedItem, FinishUpdate);

        }

        public void AddNewButtonClick(object sender, RoutedEventArgs e)
        {
            var item = this.data[0];
            var addForm = new AddNewForm();
            addForm.Init(item, FinishAddNew);
        }

        public void UndoClick(object sender, RoutedEventArgs e)
        {
            var prev = history.Undo();
            var temp = new ObservableCollection<T>(prev);
            data.Clear();
            foreach (var item in temp)
            {
                data.Add(item);
            }

        }

        public void DeleteItemClick(object sender, RoutedEventArgs e)
        {
            var isAbort = false;
            var parameters = new object[2]{data[UIElement.SelectedIndex],isAbort};
            this.actionStore.ExecuteAction("onRowDelete", parameters);
            if ((bool)parameters[1] == false)
            {
                RemoveAt(UIElement.SelectedIndex);

            }
        }

        public void RedoClick(object sender, RoutedEventArgs e)
        {
            var next = history.Redo();

            var temp = new ObservableCollection<T>(next);
            data.Clear();

            foreach (var item in temp)
            {
                data.Add(item);
            }

        }

        public void EditButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = data[UIElement.SelectedIndex];

            var editForm = new EditForm();
        
            editForm.Init(selectedItem, FinishUpdate);
        }


        //Observerble and update data
        private void DataCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            UIElement.ItemsSource = data;

        }


        private void FinishAddNew(object newData)
        {
            var isAbort = false;
            var parameters = new object[2] { newData, isAbort };
            this.actionStore.ExecuteAction("onAddNew", parameters);
            if (!(bool)parameters[1]) {
                this.data.Add((T)newData);
                UpdateHistory();
            }
        }

        private void FinishUpdate(object result)
        {
            var isAbort = false;
            var parameters = new object[2] { data[UIElement.SelectedIndex], isAbort };
            this.actionStore.ExecuteAction("onRowEdit", parameters);
            if (!(bool)parameters[1])
            {
                data[UIElement.SelectedIndex] = (T)result;
            }
            UpdateHistory();
        }

        //Update history


        private void UpdateHistory()
        {
            this.history.Add(data);
        }




        //Public method for user


        public void RemoveAt(int index)

        {
            try
            {
                data.RemoveAt(index);
                UpdateHistory();
            }
            catch (Exception)
            {

            }
        }

        public void RemoveIfPropertyEqual(string propertyName, object value)
        {
            List<int> indexList = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                var propertyValue = data[i].GetType().GetProperty(propertyName).GetValue(data[i], null);
                if (propertyValue == value)
                {
                    indexList.Add(i);
                }
            }

            foreach (int id in indexList)
            {
                data.RemoveAt(id);
            }
        }
    }
}
