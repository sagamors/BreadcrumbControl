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

        public object Header
        {
            get { return (string) GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(
            "HeaderTemplate", typeof (DataTemplate), typeof (BreadcrumbItem), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate) GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }


        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon", typeof (ImageSource), typeof (BreadcrumbItem), new PropertyMetadata(default(ImageSource)));

        public ImageSource Icon
        {
            get { return (ImageSource) GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            "Progress", typeof (int), typeof (BreadcrumbItem), new PropertyMetadata(default(int)));

        public int Progress
        {
            get { return (int) GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        internal Breadcrumb ParentBreadcrumb
        {
            get
            {
                Breadcrumb tv = Parent as Breadcrumb;
                if (tv != null)
                    return tv;
             
                ItemsControl parent = Parent as ItemsControl;

                while (parent != null)
                {
                    tv = parent as Breadcrumb;
                    if (tv != null)
                    {
                        return tv;
                    }
                    parent = ItemsControl.ItemsControlFromItemContainer(parent);
                }

                return null;
            }
        }

        static BreadcrumbItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof (BreadcrumbItem),
                new FrameworkPropertyMetadata(typeof (BreadcrumbItem)));
        }
    }
}
