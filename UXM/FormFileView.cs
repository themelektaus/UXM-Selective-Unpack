using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UXM
{
    //Partially my own shitcode, partially shitcode from Stack Overflow
    public partial class FormFileView : Form
    {
        private static string Prefix;

        private static TreeView currentNodes = new TreeView();

        private new FormMain Parent;

        public FormFileView(FormMain parent)
        {
            InitializeComponent();
            Parent = parent;
            if (currentNodes.Nodes.Count > 0)
                fileTreeView.Nodes.Add((TreeNode)currentNodes.Nodes[0].Clone());
        }



        public static void PopulateTreeview(string exePath)
        {
            Util.Game game;
            if (File.Exists(exePath))
                game = Util.GetExeVersion(exePath);
            else
                return;

            currentNodes.Nodes.Clear();

            Prefix = GameInfo.GetPrefix(game);

#if DEBUG
            var fileList = File.ReadAllLines($@"..\..\dist\res\{Prefix}Dictionary.txt").Where(s => !s.StartsWith("#") && !string.IsNullOrWhiteSpace(s)).ToArray();

#else
            var fileList = File.ReadAllLines($@"{GameInfo.ExeDir}\res\{Prefix}Dictionary.txt").Where(s => !s.StartsWith("#") && !string.IsNullOrWhiteSpace(s)).ToArray();
#endif
            currentNodes.Nodes.Add(PopulateTreeNode2(fileList, @"/", Prefix));
        }

        private static TreeNode PopulateTreeNode2(string[] paths, string pathSeparator, string prefix)
        {
            if (paths == null)
                return null;

            TreeNode thisnode = new TreeNode(prefix);
            TreeNode currentnode;
            char[] cachedpathseparator = pathSeparator.ToCharArray();
            foreach (string path in paths)
            {
                currentnode = thisnode;
                foreach (string subPath in path.Split(cachedpathseparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (currentnode.Nodes[subPath] == null)
                        currentnode = currentnode.Nodes.Add(subPath, subPath);
                    else
                        currentnode = currentnode.Nodes[subPath];
                }
            }

            return thisnode;
        }


        private void fileTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                try
                {
                    e.Node.TreeView.BeginUpdate();
                    if (e.Node.Nodes.Count > 0)
                    {
                        var parentNode = e.Node;
                        var nodes = e.Node.Nodes;
                        CheckedOrUnCheckedNodes(parentNode, nodes);
                    }

                    if (!e.Node.Checked)
                    {
                        if (e.Node.Parent != null)
                            UncheckParent(e.Node.Parent);
                    }
                }
                finally
                {
                    e.Node.TreeView.EndUpdate();
                }
            }
        }

        private void UncheckParent(TreeNode parentNode)
        {
            parentNode.Checked = false;

            if (parentNode.Parent != null)
                UncheckParent(parentNode.Parent);
        }

        private void CheckedOrUnCheckedNodes(TreeNode parentNode, TreeNodeCollection nodes)
        {
            if (nodes.Count > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.Checked = parentNode.Checked;
                    CheckedOrUnCheckedNodes(parentNode, node.Nodes);
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            fileTreeView.Nodes[0].Checked = true;
            CheckedOrUnCheckedNodes(fileTreeView.Nodes[0], fileTreeView.Nodes);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fileTreeView.Nodes[0].Checked = false;
            CheckedOrUnCheckedNodes(fileTreeView.Nodes[0], fileTreeView.Nodes);
        }

        public static List<string> SelectedFiles = new List<string>();

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedFiles.Clear();
            AddSelectedFiles(fileTreeView.Nodes);
            Parent.SetSkip(SelectedFiles.Any());
            currentNodes.Nodes.Clear();
            if (fileTreeView.Nodes.Count > 0)
                currentNodes.Nodes.Add((TreeNode)fileTreeView.Nodes[0].Clone());
            Close();
        }

        private void AddSelectedFiles(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count > 0)
                    AddSelectedFiles(node.Nodes);
                else
                    if (node.Checked) SelectedFiles.Add(node.FullPath.Replace(Prefix, ""));
            }
        }
    }
}
