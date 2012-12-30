using System.Collections.ObjectModel;

namespace WpfApplication1
{
    public class TreeViewModel
    {
        public TreeViewModel()
        {
            var item1 = new TreeViewItemViewModel { Text = "Item1" };
            var item2 = new TreeViewItemViewModel { Text = "Item2" };
            var item2_1 = new TreeViewItemViewModel { Text = "Item2.1.1" };
            var item2_1_1 = new TreeViewItemViewModel { Text = "Item2.1.1" };
            var item3 = new TreeViewItemViewModel { Text = "Item3" };
            var item3_1 = new TreeViewItemViewModel { Text = "Item3.1" };
            var item3_2 = new TreeViewItemViewModel { Text = "Item3.2" };
            item3.Nodes.Add(item3_1);
            item3.Nodes.Add(item3_2);
            var item4 = new TreeViewItemViewModel { Text = "Item4" };
            item2.Nodes.Add(item2_1);
            item2_1.Nodes.Add(item2_1_1);
            Nodes = new ObservableCollection<TreeViewItemViewModel>(new[] { item1, item2,item3 ,item4});
        }
        public ObservableCollection<TreeViewItemViewModel> Nodes { get; private set; }
    }
}
