using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Linq;

namespace UXM
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class FileView : UserControl, INotifyPropertyChanged
    {
        private string Prefix;

        public ObservableCollection<TreeNode> TreeNodesCollection { get; set; }
        public List<TreeNode> AllNodes { get; set; }

        private string _filterItems = "";
        public string ItemFilter
        {
            get => _filterItems;
            set
            {
                SetField(ref _filterItems, value);
                Testy();
                OnPropertyChanged(nameof(TreeNodesCollection));
                //Files.Refresh();
            }
        }

        public ICollectionView Files { get; set; }

        public FileView()
        {
            DataContext = this;
            InitializeComponent();
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

        public void PopulateTreeview(string exePath)
        {

            Util.Game game;
            if (File.Exists(exePath))
                game = Util.GetExeVersion(exePath);
            else
                return;

            Prefix = GameInfo.GetPrefix(game);

#if DEBUG
            var fileList = File.ReadAllLines($@"..\..\dist\res\{Prefix}Dictionary.txt").Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

#else
            var fileList = File.ReadAllLines($@"{GameInfo.ExeDir}\res\{Prefix}Dictionary.txt").Where(s => !s.StartsWith("#") && !string.IsNullOrWhiteSpace(s)).ToArray();
#endif
            Dispatcher.Invoke(() =>
            {
                AllNodes = new List<TreeNode>();
                AllNodes.Add(PopulateTreeNodes(fileList, @"/", Prefix));
                TreeNodesCollection = new ObservableCollection<TreeNode>(AllNodes);
            });

            //Files = CollectionViewSource.GetDefaultView(HierarchicalDataSource);
            //Files.Filter += FilterFiles;
            OnPropertyChanged(nameof(TreeNodesCollection));
        }

        private bool FilterFiles(object obj)
        {
            if (obj is TreeNode node)
                return node.Name.ToLower().Contains(ItemFilter) || node.HasChildWithName(ItemFilter);

            return false;
        }

        private TreeNode PopulateTreeNodes(string[] paths, string pathSeparator, string prefix)
        {
            if (paths == null)
                return null;

            TreeNode thisnode = new TreeNode(this, prefix);
            TreeNode currentnode;
            char[] cachedpathseparator = pathSeparator.ToCharArray();
            bool sound = false;

            for (int i = 0; i < paths.Length; i++)
            {
                if (paths[i] == "#sd")
                    sound = true;

                if (paths[i].StartsWith("#"))
                    continue;

                if (sound)
                    paths[i] = $"/sound/{paths[i]}";
                currentnode = thisnode;
                foreach (string subPath in paths[i].Split(cachedpathseparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (currentnode[subPath] == null)
                        currentnode.NodeCollection.Add(new TreeNode(this, subPath));

                    currentnode = currentnode[subPath];
                }
            }

            return thisnode;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TreeViewItem_Collapsed(object sender, RoutedEventArgs e)
        {
            (sender as TreeViewItem).IsExpanded = true;
        }



        public void Testy()
        {
            foreach (TreeNode n in AllNodes[0].Traverse())
            {

                if (n.Name.ToLower().Contains(ItemFilter) || n.HasChildWithName(ItemFilter))
                {
                    if (!TreeNodesCollection.Contains(n))
                        TreeNodesCollection.Add(n);
                }
                else
                {
                    TreeNodesCollection.Remove(n);
                }
            }
        }
    }
}
