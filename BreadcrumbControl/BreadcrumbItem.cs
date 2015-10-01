using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace BreadcrumbControl
{

    public class BreadcrumbItem : Selector
    {
        private const string partHeaderButton = "PART_HeaderButton";
        private const string partHeader = "PART_Header";
        private const string _button = "PART_Button";
        private const string _partContextMenu = "PART_ContextMenu";
        private Button _headerButton;
        private ContextMenu _contextMenu;

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof (string), typeof (BreadcrumbItem), new PropertyMetadata(default(string)));

        public string Header
        {
            get { return (string) GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(
            "HeaderTemplate", typeof (ControlTemplate), typeof (BreadcrumbItem),
            new PropertyMetadata(default(ControlTemplate)));

        public ControlTemplate HeaderTemplate
        {
            get { return (ControlTemplate) GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof (ImageSource), typeof (BreadcrumbItem), new PropertyMetadata(default(ImageSource)));

        public ImageSource Icon
        {
            get { return (ImageSource) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        static BreadcrumbItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (BreadcrumbItem),
                new FrameworkPropertyMetadata(typeof (BreadcrumbItem)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            var contextMenu = ((ContextMenu) sender);
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
