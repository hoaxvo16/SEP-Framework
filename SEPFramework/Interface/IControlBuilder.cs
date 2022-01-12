using SEPFramework.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SEPFramework.Interface
{
    public interface IControlBuilder<T>
    {
        public DataGridBuilder<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent, Style buttonStyle = null);

        public DataGridBuilder<T> BuildDefaultButton(Style buttonStyle = null);

        public DataGridBuilder<T> BuildTopPanel(Panel container, Style panelStyle = null, Style buttonStyle = null);
    }
}
