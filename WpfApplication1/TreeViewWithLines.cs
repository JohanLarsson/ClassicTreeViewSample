using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplication1
{

    public class TreeViewItemToLineTranslateTransformFactor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Math.Ceiling((double)value / 2) + 3;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class FirstLeafLineMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Thickness(0, 1, 0, (double)value / 2 - 3);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class LineVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = Visibility.Collapsed;
            var treeViewItem = (TreeViewItem)value;
            var o = treeViewItem.DataContext;
            var owningPanel = treeViewItem.FindAncestor<Panel>();
            if (owningPanel == null)
                throw new Exception();
            if (((string)parameter) == "UpLine")
            {
                var treeViewItemIndex = owningPanel.Children.IndexOf(treeViewItem);
                if (treeViewItemIndex == 0)
                {
                    // try to find a TreeViewItem ancestor
                    var parentTreeViewitem = owningPanel.FindAncestor<TreeViewItem>();
                    if (parentTreeViewitem != null)
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Collapsed;
                    }
                }
                return Visibility.Visible;
            }

            if (((string)parameter) == "DownLine")
            {
                if (owningPanel == null)
                    return Visibility.Collapsed;
                if (owningPanel.Children.IndexOf(treeViewItem) != owningPanel.Children.Count - 1)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            throw new ArgumentException("parameter");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public static class ExtensionMethods
    {
        public static T FindAncestor<T>(this Visual @this, Func<T, bool> predicate = null) where T : Visual
        {
            return @this.FindAncestor(v => v is T && (predicate == null || predicate((T)v))) as T;
        }

        public static Visual FindAncestor(this Visual @this, Predicate<Visual> predicate)
        {
            if (@this == null)
                return null;

            DependencyObject current = @this;
            while ((current = VisualTreeHelper.GetParent(current)) != null)
            {
                var currentVisual = current as Visual;
                if (currentVisual != null && predicate(currentVisual))
                    break;
            }
            return current as Visual;
        }
    }
}
