using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BreadcrumbControl
{
    public class DropDownButton : ToggleButton
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof (IEnumerable), typeof (DropDownButton), new PropertyMetadata(default(IEnumerable)));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof (object), typeof (DropDownButton), new PropertyMetadata(default(object)));

        public object Header
        {
            get { return (object) GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            "SelectedValue", typeof (object), typeof (DropDownButton), new PropertyMetadata(default(object)));

        public object SelectedValue
        {
            get { return (object) GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        static DropDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownButton), new FrameworkPropertyMetadata(typeof(DropDownButton)));
        }

        public override void OnApplyTemplate()
        {
            if (ContextMenu != null)
            {
                ContextMenu.DataContext = this;
                ContextMenu.PlacementTarget = this;
                ContextMenu.Opened += ContextMenu_Opened;
            }
            base.OnApplyTemplate();
        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            var contextMenu = ((ContextMenu)sender);
            foreach (var menu in contextMenu.Items)
            {
                var itemMenu = contextMenu.ItemContainerGenerator.ContainerFromItem(menu) as MenuItem;
                if (itemMenu == null) continue;
                itemMenu.Click -= Menu_Click;
                itemMenu.Click += Menu_Click;
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                SelectedValue = menuItem.DataContext;
            }
        }
    }

}
