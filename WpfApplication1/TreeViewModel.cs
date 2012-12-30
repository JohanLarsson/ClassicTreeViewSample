using System.Collections.ObjectModel;

namespace WpfApplication1
{
    public class TreeViewModel
    {
        public TreeViewModel()
        {
            var root = new TreeViewItemViewModel { Text = "Root" };
            var level1 = new TreeViewItemViewModel { Text = "Level 1" };
            var level1_1 = new TreeViewItemViewModel { Text = "Level 1_1" };
            var level2 = new TreeViewItemViewModel { Text = "Level 2" };
            Root = new ObservableCollection<TreeViewItemViewModel>(new[] { root });
            root.Nodes.Add(level1);
            root.Nodes.Add(level1_1);
            level1.Nodes.Add(level2);
        }
        public ObservableCollection<TreeViewItemViewModel> Root { get; private set; }
    }
}
