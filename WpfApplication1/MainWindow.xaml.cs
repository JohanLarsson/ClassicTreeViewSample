using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TreeViewModel _treeViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _treeViewModel = new TreeViewModel();
            this.DataContext = _treeViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            _treeViewModel.Nodes.Skip(1).First().Nodes.Remove(_treeViewModel.Nodes.Skip(1).First().Nodes.First());
        }

        //private void AddCondition(TreeViewItem branch, int index)
        //{
        //    if (index >= 0)
        //    {
        //        TreeViewItem tviCondition = new TreeViewItem();
        //        tviCondition.Tag = "Condition";
        //        ComboBox cmbFields = new ComboBox();
        //        ComboBox cmbOperators = new ComboBox();
        //        cmbOperators.Margin = new Thickness(5, 0, 5, 0);
        //        StackPanel spCondition = new StackPanel();
        //        spCondition.Orientation = Orientation.Horizontal;
        //        TextBox txtValue1 = new TextBox();
        //        txtValue1.Width = 70;
        //        Button imgRemove = new Button();
        //        imgRemove.Cursor = Cursors.Hand;
        //        imgRemove.ToolTip = "Remove";
        //        imgRemove.Margin = new Thickness(5, 0, 0, 0);
        //        imgRemove.Content = "PRESS THIS BUTTON SISYPHE";
        //        imgRemove.VerticalAlignment = VerticalAlignment.Center;

        //        StackPanel spBetween = new StackPanel();
        //        spBetween.Orientation = Orientation.Horizontal;
        //        Label lblAnd = new Label();
        //        lblAnd.Content = " And ";
        //        TextBox txtValue2 = new TextBox();
        //        txtValue2.Width = 70;
        //        spBetween.Children.Add(lblAnd);
        //        spBetween.Children.Add(txtValue2);
        //        spBetween.Visibility = Visibility.Collapsed;

        //        spCondition.Children.Add(cmbFields);
        //        spCondition.Children.Add(cmbOperators);
        //        spCondition.Children.Add(txtValue1);
        //        spCondition.Children.Add(spBetween);
        //        spCondition.Children.Add(imgRemove);
        //        tviCondition.Header = spCondition;
        //        branch.Items.Insert(index, tviCondition);

        //        imgRemove.Click+= (s, evnt) =>
        //        {
        //            branch.Items.Remove(tviCondition);
        //        };
        //    }
        //}
    }
}
