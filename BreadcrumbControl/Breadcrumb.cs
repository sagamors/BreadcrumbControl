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
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:Breadcrumb/>
    ///
    /// </summary>
    public class Breadcrumb : ItemsControl
    {
        static Breadcrumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Breadcrumb), new FrameworkPropertyMetadata(typeof(Breadcrumb)));
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof (object), typeof (Breadcrumb), new PropertyMetadata(default(object), (o, args) =>
            {

            }));

        public Breadcrumb()
        {
            Loaded += Breadcrumb_Loaded;
        }

        private void Breadcrumb_Loaded(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null && Items.Count > 0)
            {
                SetValue(Breadcrumb.SelectedItemProperty, Items[0]);
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
    }
}
