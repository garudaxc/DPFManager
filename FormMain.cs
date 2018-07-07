using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Diagnostics;

namespace MyDPFManager
{
    public partial class FormMain : Form
    {
        private TreeNode m_ClickNode = null;

        public FormMain()
        {
            InitializeComponent();

            Global.Init();

            listViewFile.View = View.Details;
            listViewFile.Columns.Add("File Name", -2, HorizontalAlignment.Left);

            if (Global.Config.LastProject != string.Empty)
            {
                LoadProject(Global.Config.ProjectFullFileName);
            }
        }

        #region TreeViewDir

        private void UpdateTreeView()
        {
            PDFFileModel model = Global.Model;

            List<TreeNode> treeNodes = new List<TreeNode>();
            treeViewDir.BeginUpdate();
            treeViewDir.Nodes.Clear();

            int i = 0;
            foreach (FileDirectory dir in model.Directories)
            {
                TreeNode node = new TreeNode(dir.name);
                node.Tag = i++;
                treeNodes.Add(node);
            }

            for (i = 0; i < model.Directories.Count; i++)
            {
                FileDirectory d = model.Directories[i];
                if (d.parent == -1)
                {
                    treeViewDir.Nodes.Add(treeNodes[i]);
                }
                else
                {
                    treeNodes[d.parent].Nodes.Add(treeNodes[i]);
                }
            }

            treeViewDir.EndUpdate();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }

            int nodeIndex = (int)e.Node.Tag;

            listViewFile.Items.Clear();
            FileDirectory dir = Global.Model.Directories[nodeIndex];

            foreach (int i in dir.files)
            {
                FileData f = Global.Model.Files[i];
                ListViewItem item = new ListViewItem();
                item.Text = f.name;
                item.Tag = i;
                listViewFile.Items.Add(item);
            }
        }

        #endregion

        #region TreeViewLable

        private void UpdateLableTreeView()
        {
            PDFFileModel model = Global.Model;
            
            List<TreeNode> treeNodes = new List<TreeNode>();
            treeViewLable.BeginUpdate();
            treeViewLable.Nodes.Clear();

            int i = 0;
            foreach (Lable l in model.Lables)
            {
                TreeNode node = new TreeNode(l.name);
                node.Tag = i++;
                treeNodes.Add(node);
            }

            for (i = 0; i < model.Lables.Count; i++ )
            {
                Lable l = model.Lables[i];
                if (l.parent == -1)
                {
                    treeViewLable.Nodes.Add(treeNodes[i]);
                }
                else
                {
                    treeNodes[l.parent].Nodes.Add(treeNodes[i]);
                }
            }

            treeViewLable.EndUpdate();
            treeViewLable.ExpandAll();
        }

        private void treeViewLable_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            int index = (int)e.Node.Tag;
            Lable l = Global.Model.Lables[index];
            l.name = e.Label;
        }

        private void treeViewLable_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                return;
            }

            int nodeIndex = (int)e.Node.Tag;

            listViewFile.Items.Clear();
            treeViewDir.SelectedNode = null;

            Lable l = Global.Model.Lables[nodeIndex];
            foreach (int i in l.files)
            {
                FileData f = Global.Model.Files[i];
                ListViewItem item = new ListViewItem();
                item.Text = f.name;
                item.Tag = i;
                listViewFile.Items.Add(item);
            }
        }

        private void treeViewLable_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //当对某节点进行拖拽时，移动拖拽的节点  
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeViewLable_DragDrop(object sender, DragEventArgs e)
        {
            Console.WriteLine("treeViewLable_DragDrop");
            Point point = treeViewLable.PointToClient(new Point(e.X, e.Y));
            TreeNode dragTo = treeViewLable.GetNodeAt(point);

            TreeNode dragFrom = (TreeNode)e.Data.GetData(typeof(TreeNode));
            // 拖拽的是树节点
            if (dragFrom != null)
            {
                if (dragFrom.Equals(dragTo))
                {
                    return;
                }

                if (HasChildNode(dragFrom, dragTo))
                {
                    MessageBox.Show("错误的操作");
                    return;
                }

                dragFrom.Remove();
                if (dragTo == null)
                {
                    treeViewLable.Nodes.Add(dragFrom);
                }
                else
                {
                    dragTo.Nodes.Add(dragFrom);
                    dragTo.Expand();
                }

                BuildLableData();
            }

            ListView.SelectedListViewItemCollection items = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));
            if (items != null && dragTo != null)
            {
                for (int i = 0; i < items.Count; i++ )
                {
                    ListViewItem listItem = items[i];
                    int lableIndex = (int)dragTo.Tag;
                    Lable l = Global.Model.Lables[lableIndex];
                    int index = (int)listItem.Tag;
                    if (!l.files.Contains(index))
                    {
                        l.files.Add(index);
                    }
                }
            }
        }

        private void treeViewLable_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void treeViewLable_DragOver(object sender, DragEventArgs e)
        {
            //获得鼠标的坐标  
            Point point = treeViewLable.PointToClient(new Point(e.X, e.Y));
            // 按鼠标所指示的位置选择节点 
            //treeViewLable.SelectedNode = treeViewLable.GetNodeAt(point);
        }

        #endregion

        #region ListViewFile

        private void PropertyPanelLables_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == null)
            {
                MessageBox.Show("删除文件的标签出错");
                return;
            }

            RemoveLableInfo info = (RemoveLableInfo)btn.Tag;
            Lable l = Global.Model.Lables[info.lable];
            l.files.RemoveAt(info.removeAt);

            flowLayoutPanelLable.Controls.Remove(btn);
            listViewFile.Items.Remove((ListViewItem)info.obj);
        }

        private void PropertyPanelShowLables(int fileIndex, object o)
        {
            for (int i = 0; i < Global.Model.Lables.Count; i++)
            {
                Lable l = Global.Model.Lables[i];
                for (int j = 0; j < l.files.Count; j++)
                {
                    if (l.files[j] != fileIndex)
                    {
                        continue;
                    }

                    Button btn = new Button();
                    btn.Text = l.name;
                    btn.Tag = new RemoveLableInfo(i, j, o);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Click += new EventHandler(this.PropertyPanelLables_Clicked);
                    flowLayoutPanelLable.Controls.Add(btn);
                }
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = listViewFile.SelectedItems.Count;
            if (count > 0)
            {
                string str = string.Format("共{0}项，选中{1}项", listViewFile.Items.Count, count);
                StatusBarShowInfo(str);
            }
            else
            {
                StatusBarShowInfo(string.Empty);
            }

            textBoxFilePath.Text = "";
            flowLayoutPanelLable.Controls.Clear();
            if (count == 1)
            {
                ListViewItem item = listViewFile.SelectedItems[0];
                int index = (int)item.Tag;
                FileData f = Global.Model.Files[index];
                textBoxFilePath.Text = f.filePath;
                PropertyPanelShowLables(index, item);
            }
        }

        private void listViewFile_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(listViewFile.SelectedItems, DragDropEffects.Move);
            }
        }

        private void listViewFile_DoubleClick(object sender, EventArgs e)
        {
            int count = listViewFile.SelectedItems.Count;
            if (count == 1)
            {
                ListViewItem item = listViewFile.SelectedItems[0];
                int index = (int)item.Tag;
                FileData f = Global.Model.Files[index];

                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.FileName = f.filePath;
                    myProcess.StartInfo.CreateNoWindow = false;
                    myProcess.Start();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }  
            }

        }

        #endregion

        #region ContextMenu

        private void AddLableMenuItem_Click(object sender, EventArgs e)
        {
            Lable l = new Lable();
            l.name = "new lable";
            if (m_ClickNode == null)
            {
                l.parent = -1;
            }
            else
            {
                int nodeIndex = (int)m_ClickNode.Tag;
                l.parent = nodeIndex;
            }
            Global.Model.Lables.Add(l);

            UpdateLableTreeView();
        }

        private void DelLableMenuItem_Click(object sender, EventArgs e)
        {
            if (m_ClickNode == null)
            {
                return;
            }

            m_ClickNode.Remove();

            BuildLableData();
        }

        private void ChangeLableNameMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }

        private void contextMenuLable_Opened(object sender, EventArgs e)
        {
            Point point = treeViewLable.PointToClient(Cursor.Position);
            TreeNode node = treeViewLable.GetNodeAt(point);

            m_ClickNode = node;
            if (node == null)
            {
                toolStripStatusLabel.Text = "null";
            }
            else
            {
                toolStripStatusLabel.Text = node.Name;
            }
        }
#endregion

        #region Toolbar

        private void StatusBarShowInfo(string info)
        {
            toolStripStatusLabel.Text = info;
            Application.DoEvents();
        }

        private void toolStripOpenFolder_Click(object sender, EventArgs e)
        {
            FormNewProject form = new FormNewProject();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Global.Config.LastProject = form.ProjectName;
                if (File.Exists(Global.Config.ProjectFullFileName))
                {
                    MessageBox.Show("已有相同项目名，保存时会覆盖!");
                }
            }
            else
            {
                return;
            }

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = Global.Config.SelectPath;
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Console.WriteLine(dlg.SelectedPath);
            Global.Config.SelectPath = dlg.SelectedPath;
            PDFFileModel model = Global.Controller.BuildNewData(dlg.SelectedPath, StatusBarShowInfo);
            if (model == null)
            {
                return;
            }

            Global.Model = model;

            this.Text = "FileTagger - " + Global.Config.LastProject;

            UpdateTreeView();
            UpdateLableTreeView();
            
            if (Global.Controller.MetaOnlyFile.Count > 0)
            {
                foreach (string f in Global.Controller.MetaOnlyFile)
                {
                    listViewFile.Items.Add(f);
                }

                DialogResult result = MessageBox.Show("删除多余的meta文件？", "", MessageBoxButtons.OKCancel);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (string f in Global.Controller.MetaOnlyFile)
                    {
                        File.Delete(f);
                    }
                    listViewFile.Clear();
                }
            }


            StatusBarShowInfo("ok!");
        }

        private void toolStripButtonMerge_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Merge From";
            dlg.SelectedPath = Global.Config.SelectPath;
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string from = dlg.SelectedPath;

            string to = null;
            dlg.Description = "Merge To";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                to = dlg.SelectedPath;
            }
            else
            {
                MessageBox.Show("Merge到当前工程");
            }

            dlg.Description = "Copy To";
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string copyTo = dlg.SelectedPath;

            Global.Controller.MergeDirctory(from, to, copyTo, StatusBarShowInfo);
            StatusBarShowInfo("ok!");
        }

        private void SaveProject()
        {
            if (Global.Model.Path == string.Empty)
            {
                return;
            }

            if (!Global.Model.SaveToFile(Global.Config.ProjectFullFileName))
            {
                MessageBox.Show("保存失败!");
            }
            else
            {
                toolStripStatusLabel.Text = "保存成功!";
            }
        }

        private void toolStripSaveData_Click(object sender, EventArgs e)
        {
            if (Global.Config.LastProject == string.Empty)
            {
                MessageBox.Show("请创建一个新项目");
                return;
            }

            SaveProject();
        }

        private void LoadProject(string pathName)
        {
            if (!File.Exists(pathName))
            {
                MessageBox.Show("文件不存在： " + pathName);
                return;
            }

            Global.Model = PDFFileModel.LoadFromFile(pathName);
            Global.Config.LastProject = Path.GetFileNameWithoutExtension(pathName);

            this.Text = "FileTagger - " + Global.Config.LastProject;

            UpdateTreeView();
            UpdateLableTreeView();
        }

        private void toolStripLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Config.ProjectPath;
            dlg.Filter = "proj files (*.bin)|*.bin";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadProject(dlg.FileName);
            }
        }

        private void toolStripButtonCompareIdentityFile_Click(object sender, EventArgs e)
        {
            List<int> list = Global.Controller.ScanIdentityFiles();

            listViewFile.Items.Clear();
            foreach (int i in list)
            {
                FileData f = Global.Model.Files[i];
                ListViewItem item = new ListViewItem();
                item.Text = f.name;
                item.Tag = i;
                listViewFile.Items.Add(item);
            }
        }

        private void toolStripButtonUpdateData_Click(object sender, EventArgs e)
        {
            Global.Controller.UpdateData(StatusBarShowInfo);
            UpdateTreeView();
            UpdateLableTreeView();
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除选中的文件吗？", "注意", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                int index = (int)item.Tag;

                string pathName = Global.Model.Files[index].filePath;
                File.Delete(pathName);
                string metaFile = pathName + ".met";
                File.Delete(metaFile);

                Global.Controller.DeleteFile(index);
                listViewFile.Items.Remove(item);
            }

            listViewFile.SelectedItems.Clear();
        }

        #endregion


        private void RebuildLableList_r(List<Lable> list, TreeNode node, int parent)
        {
            int origIndex = (int)node.Tag;
            Lable l = Global.Model.Lables[origIndex];
            l.parent = parent;

            int index = list.Count;
            list.Add(l);
            node.Tag = index;
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                RebuildLableList_r(list, node.Nodes[i], index);
            }
        }

        private void BuildLableData()
        {
            List<Lable> list = new List<Lable>();

            for (int i = 0; i < treeViewLable.Nodes.Count; i++)
            {
                RebuildLableList_r(list, treeViewLable.Nodes[i], -1);
            }
            Global.Model.Lables = list;
        }

        //确定node1是否为node2的父亲节点  
        private static bool HasChildNode(TreeNode node1, TreeNode node2)
        {
            if (node1 == null || node2 == null)
            {
                return false;
            }
            // 判断第二个节点是否是父亲节点  
            if (node2.Parent == null)
            {
                return false;
            }

            if (node2.Parent.Equals(node1))
            {
                return true;
            }

            return HasChildNode(node1, node2.Parent);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Config.Save();
            SaveProject();
        }

    }
}
