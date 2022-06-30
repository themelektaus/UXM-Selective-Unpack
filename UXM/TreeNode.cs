using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UXM
{
    public class TreeNode : INotifyPropertyChanged
    {
        public ObservableCollection<TreeNode> NodeCollection { get; set; }
        public ICollectionView Nodes => CollectionViewSource.GetDefaultView(NodeCollection);
        public string Name { get; set; }
        private bool _visibility = true;
        public bool Visibility
        {
            get => _visibility;
            set => SetField(ref _visibility, value);
        }

        private bool _selected;
        public bool Selected
        {
            get => _selected;
            set => SetField(ref _selected, value);
        }
        public TreeNode(FileView fileView, string name)
        {
            Name = name;
            NodeCollection = new ObservableCollection<TreeNode>();
            //Nodes.Filter += FilterNodes;
            //fileView.PropertyChanged += FileView_PropertyChanged;
        }


        private bool FilterNodes(object obj)
        {
            if (obj is TreeNode node)
                return node.Name.ToLower().Contains(ItemFilter.ToLower()) || node.HasChildWithName(ItemFilter.ToLower());

            return false;
        }

        private string _itemFilter = "";
        public string ItemFilter
        {
            get => _itemFilter;
            set
            {
                if (SetField(ref _itemFilter, value))
                {
                    //Nodes.Refresh();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName ?? "");
            return true;
        }


        private void FileView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FileView.ItemFilter))
                ItemFilter = (sender as FileView).ItemFilter;
        }

        public TreeNode this[string s]
        {
            get
            {
                foreach (TreeNode node in NodeCollection)
                {
                    if (node.Name == s)
                        return node;
                }

                return null;
            }
        }

        public bool HasChildWithName(string itemFilter)
        {
            foreach (TreeNode node in NodeCollection)
            {
                if (node.Name.ToLower().Contains(itemFilter.ToLower()) || node.HasChildWithName(itemFilter))
                    return true;
            }
            return false;
        }
    }
}
