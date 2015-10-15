using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace BreadcrumbControl
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BreadcrumbControl"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BreadcrumbControl;assembly=BreadcrumbControl"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:BreadcrumbButton/>
    ///
    /// </summary>
    public class BreadcrumbButton : ToggleButton
    {
        private const string partContextMenu = "PART_ContextMenu";
        private ContextMenu _contextMenu;

        public static readonly DependencyProperty IsMouseOverRenderProperty = DependencyProperty.Register("IsMouseOverRender", typeof (bool), typeof (BreadcrumbButton), new PropertyMetadata(default(bool)));
        public bool IsMouseOverRender
        {
            get { return (bool) GetValue(IsMouseOverRenderProperty); }
            set { SetValue(IsMouseOverRenderProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof (IEnumerable), typeof (BreadcrumbButton), new PropertyMetadata(default(IEnumerable)));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register(
            "SelectedValue", typeof (object), typeof (BreadcrumbButton), new PropertyMetadata(default(object)));

        public object SelectedValue
        {
            get { return (object) GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        static BreadcrumbButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BreadcrumbButton), new FrameworkPropertyMetadata(typeof(BreadcrumbButton)));
        }


    }
}
