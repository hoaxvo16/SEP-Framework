using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SEPFramework
{
    public class FormData<T>
    {

        //Atributes

        protected DataGrid dataGrid;

        protected ObservableCollection<T> data;

        private History<T> history;

        private ActionStore actionStore = new ActionStore();


        //Constructor
        public FormData()
        {
            this.dataGrid = new DataGrid();
            this.dataGrid.IsReadOnly = true;
            this.dataGrid.MouseDoubleClick += DataGridMouseDoubleClick;
            this.history = new History<T>();

        }

        //Build an render

        public FormData<T> BuildData(List<T> dataList)
        {

            data = new ObservableCollection<T>(dataList);
            data.CollectionChanged += DataCollectionChanged;
            UpdateHistory();

            return this;
        }

        public FormData<T> BuildAction(string actionName, Action function)
        {
            this.actionStore.AddAction(actionName, function);
            return this;
        }

        public FormData<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent, int width)
        {

            DataGridTemplateColumn col = ControlBuilder.BuilDataGridColButton(colHeader, buttonContent, clickEvent, width);
            dataGrid.Columns.Add(col);
            return this;

        }

        private StackPanel BuildStackPanel()
        {
            var panel = ControlBuilder.BuildStackPanel();
            var addButton = ControlBuilder.BuildButton("Add new", AddNewButtonClick, 100);
            var undoButton = ControlBuilder.BuildButton("Undo", UndoClick, 100);
            var redoButton = ControlBuilder.BuildButton("Redo", RedoClick, 100);
            panel.Children.Add(addButton);
            panel.Children.Add(undoButton);
            panel.Children.Add(redoButton);
            return panel;
        }

        private void BuildActionButtons()
        {
            this.BuildButtonColumn("Delete", "Delete", DeleteItemClick, 100);
            this.BuildButtonColumn("Edit", "Edit", EditButtonClick, 100);
        }


        public void Render(Panel container)
        {

            dataGrid.ItemsSource = data;
            var stackPanel = BuildStackPanel();
            container.Children.Add(stackPanel);
            container.Children.Add(dataGrid);
            BuildActionButtons();


        }


        //Event handler


        //Click Event

        private void DataGridMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedItem = data[dataGrid.SelectedIndex];
            var editForm = new EditForm();
            editForm.Init(selectedItem, FinishUpdate);

        }

        private void AddNewButtonClick(object sender, RoutedEventArgs e)
        {
            var item = this.data[0];
            var addForm = new AddNewForm();
            addForm.Init(item, FinishAddNew);
        }

        private void UndoClick(object sender, RoutedEventArgs e)
        {
            var prev = history.Undo();
            var temp = new ObservableCollection<T>(prev);
            data.Clear();
            foreach (var item in temp)
            {
                data.Add(item);
            }

        }

        private void DeleteItemClick(object sender, RoutedEventArgs e)
        {
            RemoveAt(dataGrid.SelectedIndex);
            this.actionStore.ExecuteAction("onCellDelete");
        }

        private void RedoClick(object sender, RoutedEventArgs e)
        {
            var next = history.Redo();

            var temp = new ObservableCollection<T>(next);
            data.Clear();

            foreach (var item in temp)
            {
                data.Add(item);
            }

        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = data[dataGrid.SelectedIndex];

            var editForm = new EditForm();
            editForm.Init(selectedItem, FinishUpdate);
        }






        //Observerble and update data
        private void DataCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            dataGrid.ItemsSource = data;

        }


        private void FinishAddNew(object data)
        {

            this.data.Add((T)data);
            UpdateHistory();
        }

        private void FinishUpdate(object result)
        {
            data[dataGrid.SelectedIndex] = (T)result;
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
