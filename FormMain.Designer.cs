namespace MyDPFManager
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSaveData = new System.Windows.Forms.ToolStripButton();
            this.toolStripLoadData = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCompareIdentityFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUpdateData = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMerge = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlLeft = new System.Windows.Forms.TabControl();
            this.tabPageLable = new System.Windows.Forms.TabPage();
            this.treeViewLable = new System.Windows.Forms.TreeView();
            this.contextMenuLable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.改名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageDir = new System.Windows.Forms.TabPage();
            this.treeViewDir = new System.Windows.Forms.TreeView();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelLable = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.LableFilePath = new System.Windows.Forms.Label();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlLeft.SuspendLayout();
            this.tabPageLable.SuspendLayout();
            this.contextMenuLable.SuspendLayout();
            this.tabPageDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpenFolder,
            this.toolStripSaveData,
            this.toolStripLoadData,
            this.toolStripButtonCompareIdentityFile,
            this.toolStripButtonUpdateData,
            this.toolStripButtonDel,
            this.toolStripButtonMerge});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(886, 39);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripOpenFolder
            // 
            this.toolStripOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripOpenFolder.Image = global::MyDPFManager.Properties.Resources._new;
            this.toolStripOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOpenFolder.Name = "toolStripOpenFolder";
            this.toolStripOpenFolder.Size = new System.Drawing.Size(36, 36);
            this.toolStripOpenFolder.Text = "toolStripButton1";
            this.toolStripOpenFolder.ToolTipText = "重新扫描目录";
            this.toolStripOpenFolder.Click += new System.EventHandler(this.toolStripOpenFolder_Click);
            // 
            // toolStripSaveData
            // 
            this.toolStripSaveData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripSaveData.Image = global::MyDPFManager.Properties.Resources.save;
            this.toolStripSaveData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSaveData.Name = "toolStripSaveData";
            this.toolStripSaveData.Size = new System.Drawing.Size(36, 36);
            this.toolStripSaveData.Text = "toolStripButton2";
            this.toolStripSaveData.ToolTipText = "保存数据";
            this.toolStripSaveData.Click += new System.EventHandler(this.toolStripSaveData_Click);
            // 
            // toolStripLoadData
            // 
            this.toolStripLoadData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripLoadData.Image = global::MyDPFManager.Properties.Resources.folder;
            this.toolStripLoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLoadData.Name = "toolStripLoadData";
            this.toolStripLoadData.Size = new System.Drawing.Size(36, 36);
            this.toolStripLoadData.Text = "toolStripButton1";
            this.toolStripLoadData.ToolTipText = "加载数据";
            this.toolStripLoadData.Click += new System.EventHandler(this.toolStripLoadData_Click);
            // 
            // toolStripButtonCompareIdentityFile
            // 
            this.toolStripButtonCompareIdentityFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripButtonCompareIdentityFile.Image = global::MyDPFManager.Properties.Resources.search;
            this.toolStripButtonCompareIdentityFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCompareIdentityFile.Name = "toolStripButtonCompareIdentityFile";
            this.toolStripButtonCompareIdentityFile.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonCompareIdentityFile.Text = "toolStripButton1";
            this.toolStripButtonCompareIdentityFile.ToolTipText = "检测相同文件";
            this.toolStripButtonCompareIdentityFile.Click += new System.EventHandler(this.toolStripButtonCompareIdentityFile_Click);
            // 
            // toolStripButtonUpdateData
            // 
            this.toolStripButtonUpdateData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripButtonUpdateData.Image = global::MyDPFManager.Properties.Resources.date;
            this.toolStripButtonUpdateData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdateData.Name = "toolStripButtonUpdateData";
            this.toolStripButtonUpdateData.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonUpdateData.Text = "toolStripButton1";
            this.toolStripButtonUpdateData.ToolTipText = "更新数据";
            this.toolStripButtonUpdateData.Click += new System.EventHandler(this.toolStripButtonUpdateData_Click);
            // 
            // toolStripButtonDel
            // 
            this.toolStripButtonDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripButtonDel.Image = global::MyDPFManager.Properties.Resources.bug;
            this.toolStripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDel.Name = "toolStripButtonDel";
            this.toolStripButtonDel.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonDel.Text = "toolStripButtonDel";
            this.toolStripButtonDel.ToolTipText = "delete selected files";
            this.toolStripButtonDel.Click += new System.EventHandler(this.toolStripButtonDel_Click);
            // 
            // toolStripButtonMerge
            // 
            this.toolStripButtonMerge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.toolStripButtonMerge.Image = global::MyDPFManager.Properties.Resources.drawer;
            this.toolStripButtonMerge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMerge.Name = "toolStripButtonMerge";
            this.toolStripButtonMerge.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonMerge.Text = "toolStripButtonMerge";
            this.toolStripButtonMerge.ToolTipText = "Merge";
            this.toolStripButtonMerge.Click += new System.EventHandler(this.toolStripButtonMerge_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerRight);
            this.splitContainer1.Size = new System.Drawing.Size(886, 567);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControlLeft
            // 
            this.tabControlLeft.Controls.Add(this.tabPageLable);
            this.tabControlLeft.Controls.Add(this.tabPageDir);
            this.tabControlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlLeft.Location = new System.Drawing.Point(0, 0);
            this.tabControlLeft.Name = "tabControlLeft";
            this.tabControlLeft.SelectedIndex = 0;
            this.tabControlLeft.Size = new System.Drawing.Size(186, 567);
            this.tabControlLeft.TabIndex = 1;
            // 
            // tabPageLable
            // 
            this.tabPageLable.Controls.Add(this.treeViewLable);
            this.tabPageLable.Location = new System.Drawing.Point(4, 22);
            this.tabPageLable.Name = "tabPageLable";
            this.tabPageLable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLable.Size = new System.Drawing.Size(178, 541);
            this.tabPageLable.TabIndex = 0;
            this.tabPageLable.Text = "Lable";
            this.tabPageLable.UseVisualStyleBackColor = true;
            // 
            // treeViewLable
            // 
            this.treeViewLable.AllowDrop = true;
            this.treeViewLable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewLable.ContextMenuStrip = this.contextMenuLable;
            this.treeViewLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewLable.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewLable.LabelEdit = true;
            this.treeViewLable.Location = new System.Drawing.Point(3, 3);
            this.treeViewLable.Name = "treeViewLable";
            this.treeViewLable.ShowLines = false;
            this.treeViewLable.Size = new System.Drawing.Size(172, 535);
            this.treeViewLable.TabIndex = 0;
            this.treeViewLable.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewLable_AfterLabelEdit);
            this.treeViewLable.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewLable_ItemDrag);
            this.treeViewLable.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLable_AfterSelect);
            this.treeViewLable.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewLable_DragDrop);
            this.treeViewLable.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewLable_DragEnter);
            this.treeViewLable.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewLable_DragOver);
            // 
            // contextMenuLable
            // 
            this.contextMenuLable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加标签ToolStripMenuItem,
            this.删除标签ToolStripMenuItem,
            this.改名ToolStripMenuItem});
            this.contextMenuLable.Name = "contextMenuLable";
            this.contextMenuLable.Size = new System.Drawing.Size(125, 70);
            this.contextMenuLable.Opened += new System.EventHandler(this.contextMenuLable_Opened);
            // 
            // 添加标签ToolStripMenuItem
            // 
            this.添加标签ToolStripMenuItem.Name = "添加标签ToolStripMenuItem";
            this.添加标签ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加标签ToolStripMenuItem.Text = "添加标签";
            this.添加标签ToolStripMenuItem.Click += new System.EventHandler(this.AddLableMenuItem_Click);
            // 
            // 删除标签ToolStripMenuItem
            // 
            this.删除标签ToolStripMenuItem.Name = "删除标签ToolStripMenuItem";
            this.删除标签ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除标签ToolStripMenuItem.Text = "删除标签";
            this.删除标签ToolStripMenuItem.Click += new System.EventHandler(this.DelLableMenuItem_Click);
            // 
            // 改名ToolStripMenuItem
            // 
            this.改名ToolStripMenuItem.Name = "改名ToolStripMenuItem";
            this.改名ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.改名ToolStripMenuItem.Text = "改名";
            this.改名ToolStripMenuItem.Click += new System.EventHandler(this.ChangeLableNameMenuItem_Click);
            // 
            // tabPageDir
            // 
            this.tabPageDir.Controls.Add(this.treeViewDir);
            this.tabPageDir.Location = new System.Drawing.Point(4, 22);
            this.tabPageDir.Name = "tabPageDir";
            this.tabPageDir.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDir.Size = new System.Drawing.Size(178, 541);
            this.tabPageDir.TabIndex = 1;
            this.tabPageDir.Text = "Directory";
            this.tabPageDir.UseVisualStyleBackColor = true;
            // 
            // treeViewDir
            // 
            this.treeViewDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDir.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewDir.Location = new System.Drawing.Point(3, 3);
            this.treeViewDir.Name = "treeViewDir";
            this.treeViewDir.ShowLines = false;
            this.treeViewDir.Size = new System.Drawing.Size(172, 535);
            this.treeViewDir.TabIndex = 0;
            this.treeViewDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.IsSplitterFixed = true;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.label1);
            this.splitContainerRight.Panel1.Controls.Add(this.flowLayoutPanelLable);
            this.splitContainerRight.Panel1.Controls.Add(this.textBoxFilePath);
            this.splitContainerRight.Panel1.Controls.Add(this.labelFileSize);
            this.splitContainerRight.Panel1.Controls.Add(this.LableFilePath);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.listViewFile);
            this.splitContainerRight.Size = new System.Drawing.Size(696, 567);
            this.splitContainerRight.SplitterDistance = 97;
            this.splitContainerRight.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(175, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "标签";
            // 
            // flowLayoutPanelLable
            // 
            this.flowLayoutPanelLable.Location = new System.Drawing.Point(222, 50);
            this.flowLayoutPanelLable.Name = "flowLayoutPanelLable";
            this.flowLayoutPanelLable.Size = new System.Drawing.Size(439, 30);
            this.flowLayoutPanelLable.TabIndex = 3;
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFilePath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxFilePath.Location = new System.Drawing.Point(79, 18);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(582, 16);
            this.textBoxFilePath.TabIndex = 2;
            // 
            // labelFileSize
            // 
            this.labelFileSize.AutoSize = true;
            this.labelFileSize.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFileSize.Location = new System.Drawing.Point(38, 54);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(35, 14);
            this.labelFileSize.TabIndex = 1;
            this.labelFileSize.Text = "大小";
            // 
            // LableFilePath
            // 
            this.LableFilePath.AutoSize = true;
            this.LableFilePath.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LableFilePath.Location = new System.Drawing.Point(38, 21);
            this.LableFilePath.Name = "LableFilePath";
            this.LableFilePath.Size = new System.Drawing.Size(35, 14);
            this.LableFilePath.TabIndex = 0;
            this.LableFilePath.Text = "路径";
            // 
            // listViewFile
            // 
            this.listViewFile.AllowDrop = true;
            this.listViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewFile.GridLines = true;
            this.listViewFile.Location = new System.Drawing.Point(0, 0);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(696, 466);
            this.listViewFile.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewFile.TabIndex = 0;
            this.listViewFile.TileSize = new System.Drawing.Size(1, 3);
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.List;
            this.listViewFile.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFile_ItemDrag);
            this.listViewFile.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listViewFile.DoubleClick += new System.EventHandler(this.listViewFile_DoubleClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 584);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(886, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 606);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Name = "FormMain";
            this.Text = "FileTagger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlLeft.ResumeLayout(false);
            this.tabPageLable.ResumeLayout(false);
            this.contextMenuLable.ResumeLayout(false);
            this.tabPageDir.ResumeLayout(false);
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel1.PerformLayout();
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ToolStripButton toolStripOpenFolder;
        private System.Windows.Forms.TreeView treeViewDir;
        private System.Windows.Forms.ToolStripButton toolStripSaveData;
        private System.Windows.Forms.ToolStripButton toolStripLoadData;
        private System.Windows.Forms.TabControl tabControlLeft;
        private System.Windows.Forms.TabPage tabPageLable;
        private System.Windows.Forms.TabPage tabPageDir;
        private System.Windows.Forms.TreeView treeViewLable;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuLable;
        private System.Windows.Forms.ToolStripMenuItem 添加标签ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除标签ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 改名ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.Label LableFilePath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCompareIdentityFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdateData;
        private System.Windows.Forms.ToolStripButton toolStripButtonDel;
        private System.Windows.Forms.ToolStripButton toolStripButtonMerge;
    }
}

