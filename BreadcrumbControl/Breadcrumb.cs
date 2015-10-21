using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BreadcrumbControl
{
    public class Breadcrumb : ItemsControl
    {
        private const string _partCombobox = "PART_Combobox";
        private string _partItemsView = "PART_ItemsView";
        private string _partRootItem = "PART_RootItem";
        private TextBox _comboboxTextBox;

        private ComboBox _comboBox;
        private Grid _itemsView;
        private BreadcrumbItem _rootItem;

        static Breadcrumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (Breadcrumb),
                new FrameworkPropertyMetadata(typeof (Breadcrumb)));
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof (object), typeof (Breadcrumb), new PropertyMetadata(default(object)));

        public Breadcrumb()
        {
            Loaded += Breadcrumb_Loaded;
        }

        public static readonly DependencyProperty IsDropDownOpenProperty = DependencyProperty.Register(
            "IsDropDownOpen", typeof (bool), typeof (Breadcrumb), new PropertyMetadata(default(bool), (o, args) =>
            {
                var control = (Breadcrumb)o;
                if (control.IsDropDownOpen)
                {
                    if (control._comboBox != null)
                    {
                        control._comboBox.IsDropDownOpen = true;
                    }
 
                    control.IsEditing = true;
                }
                else
                {
                    control.IsEditing = false;
                }
            }));

        public bool IsDropDownOpen
        {
            get { return (bool) GetValue(IsDropDownOpenProperty); }
            set { SetValue(IsDropDownOpenProperty, value); }
        }

        public static readonly DependencyProperty IsEditingProperty = DependencyProperty.Register(
            "IsEditing", typeof (bool), typeof (Breadcrumb), new PropertyMetadata(default(bool), (o, args) =>
            {
                var control = (Breadcrumb) o;
                if (control.IsEditing)
                {
                    control.SetInputState();
                }
                else
                {
                    control.UnsetInputState();
                }

            }));

        public bool IsEditing
        {
            get { return (bool) GetValue(IsEditingProperty); }
            set { SetValue(IsEditingProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            _comboBox = GetTemplateChild(_partCombobox) as ComboBox;
            _itemsView = GetTemplateChild(_partItemsView) as Grid;
            _rootItem = GetTemplateChild(_partRootItem) as BreadcrumbItem;
            if (_comboBox == null)
            {

                Debug.WriteLine(_partCombobox + " not found");
            }
            else
            {
                _comboBox.ApplyTemplate();
                _comboboxTextBox=_comboBox.Template.FindName("PART_EditableTextBox", _comboBox) as TextBox;
                _comboBox.IsKeyboardFocusWithinChanged += _comboBox_IsKeyboardFocusWithinChanged;
            }

            UnsetInputState();
            this.KeyDown += Breadcrumb_KeyDown;
            base.OnApplyTemplate();
        }

        private void Breadcrumb_KeyDown(object sender, KeyEventArgs e)
        {
            if(!IsEditing) return;

            switch (e.Key)
            {
                case Key.Escape:
                    Reset();
                    break;
                case Key.Enter:
                    ApplyPath();
                    break;
            }
        }

        private void Reset()
        {
            IsEditing = false;
        }

        private void ApplyPath()
        {
            IsEditing = false;
        }
        private void _comboBox_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            IsEditing = (bool) e.NewValue;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (e.Handled) return;
            if (e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)
            {
                e.Handled = true;
                SetValue(IsEditingProperty,true);
            }
            base.OnMouseDown(e);
        }

        public void SetInputState()
        {
            if (_comboBox == null) return;
                _comboBox.Visibility = Visibility.Visible;
            _itemsView.Visibility = Visibility.Collapsed;
            _comboboxTextBox.Focus();
           // _comboBox.Focus();
            _comboBox.Items.Clear();
            _comboBox.Items.Add(GetCurrentPath());

        }

        public void UnsetInputState()
        {
            if(_comboBox!=null)
            _comboBox.Visibility = Visibility.Collapsed;
            _itemsView.Visibility = Visibility.Visible;
        }

        private void Breadcrumb_Loaded(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null && Items.Count > 0)
            {
                SetValue(SelectedItemProperty, Items[0]);
            }
        }

        public static readonly DependencyProperty SelectedHeaderTemplateProperty = DependencyProperty.Register(
            "SelectedHeaderTemplate", typeof (DataTemplate), typeof (Breadcrumb), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate SelectedHeaderTemplate
        {
            get { return (DataTemplate) GetValue(SelectedHeaderTemplateProperty); }
            set { SetValue(SelectedHeaderTemplateProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object) GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public IList<BreadcrumbItem> SelectedItems
        {
            get
            {
                var res = new List<BreadcrumbItem>();
                var child = SelectedItem as BreadcrumbItem;
                while (child?.Parent != null)
                {
                    res.Add(child);
                    child = child.Parent as BreadcrumbItem;
                }
                res.Reverse();
                return res;
            }
        }

        private string GetCurrentPath()
        {
            StringBuilder sb= new StringBuilder();
            foreach (var item in SelectedItems)
            {
                sb.Append(item.Header);
                sb.Append(@"\");
            }
            return sb.ToString();
        }

        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
            "Path", typeof (string), typeof (Breadcrumb), new PropertyMetadata(default(string)));



        public string Path
        {
            get { return (string) GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }
    }
}
