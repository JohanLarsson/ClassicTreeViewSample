using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class TreeViewItemViewModel : ViewModelBase
    {
        public TreeViewItemViewModel()
        {
            Nodes = new ObservableCollection<TreeViewItemViewModel>();
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public string Text { get; set; }

        public int ItemsCount { get { return Nodes.Count; } }

        public ObservableCollection<TreeViewItemViewModel> Nodes { get; private set; }
    }
}
