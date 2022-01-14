using SEPFramework.Interface;
using SEPFramework.Memento;
using SEPFramework.Observer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SEPFramework
{
    public abstract class SEPDataGrid<T>:ISubscriber<T>
    {

        //Atributes

        protected DataGrid UIElement;
        protected ObservableDataSource<T> data;
        protected ActionStore actionStore = new ActionStore();




        //Getter, Setter

        public DataGrid GetUIElement()
        {
            return UIElement;
        }
        public virtual void SetDataList(List<T> dataList)
        {
            this.data = new ObservableDataSource<T>(dataList);
            this.UIElement.ItemsSource = dataList;
            this.data.Subscribe(this);
           
        }

        public virtual void AddAction(string actionName, Action<object[]> function)
        {
            this.actionStore.AddAction(actionName, function);
        }

        public virtual void AddColumn(DataGridTemplateColumn col)
        {
            this.UIElement.Columns.Add(col);
        }

        //Constructor
        public SEPDataGrid()
        {
            this.UIElement = new DataGrid();
            this.UIElement.IsReadOnly = true;
            this.UIElement.MouseDoubleClick += DataGridMouseDoubleClick;
        }

        //Render
        public  void Render(Panel container)
        {
            container.Children.Add(UIElement);
        }

        public void SetCellStyle(Style style)
        {
            this.UIElement.CellStyle = style;

        }

        public void SetHeaderStyle(Style style)
        {
            this.UIElement.ColumnHeaderStyle = style;

        }


        //Event handler


        //Click Event

        private void DataGridMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var selectedItem = data[UIElement.SelectedIndex];
                var editForm = new EditForm();
                editForm.Init(selectedItem, FinishUpdate);
            }
            catch(Exception ex)
            {

            }

        }

        public virtual void AddNewButtonClick(object sender, RoutedEventArgs e)
        {
            var item = this.data[0];
            var addForm = new AddNewForm();
            addForm.Init(item, FinishAddNew);
        }

        public virtual void DeleteItemClick(object sender, RoutedEventArgs e)
        {
            var isAbort = false;
            var parameters = new object[2]{data[UIElement.SelectedIndex],isAbort};
            this.actionStore.ExecuteAction("onRowDelete", parameters);
            if ((bool)parameters[1] == false)
            {
                this.data.RemoveData(data[UIElement.SelectedIndex]);
           
            }
        }

        public virtual void EditButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.data[UIElement.SelectedIndex];

            var editForm = new EditForm();
        
            editForm.Init(selectedItem, FinishUpdate);
        }


  

        public virtual  void FinishAddNew(object newData)
        {
            var isAbort = false;
            var parameters = new object[2] { newData, isAbort };
            this.actionStore.ExecuteAction("onAddNew", parameters);
            if (!(bool)parameters[1]) {
                this.data.AddNewData((T)newData);
               
            }
        }

        public virtual void FinishUpdate(object result)
        {
            var isAbort = false;
            var parameters = new object[2] { result, isAbort };
            this.actionStore.ExecuteAction("onRowEdit", parameters);
            if (!(bool)parameters[1])
            {
                this.data.UpdateData((T)result, UIElement.SelectedIndex);
              
            }
            
        }

        //Undo redo
        public void UndoClick(object sender, RoutedEventArgs e)
        {
            this.data.Undo();
            

        }

        public void RedoClick(object sender, RoutedEventArgs e)
        {
            this.data.Redo();
        }

        //Update history



      

        public virtual void RemoveIfPropertyEqual(string propertyName, object value)
        {
           this.data.RemoveIfPropertyEqual(propertyName, value);
        }

        public void Update(List<T> data)
        {
            this.UIElement.ItemsSource = data;
            this.UIElement.Items.Refresh();
        }

       
    }
}
