using System.Windows.Forms;
using Utils.Extensions;

namespace Mafia2Tool
{
    partial class GameExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameExplorer));
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.folderView = new System.Windows.Forms.TreeView();
            this.imageBank = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.UpButton = new System.Windows.Forms.ToolStripButton();
            this.FolderPath = new System.Windows.Forms.ToolStripTextBox();
            this.buttonStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.SearchEntryText = new System.Windows.Forms.ToolStripTextBox();
            this.fileListView = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GEContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextSDSUnpack = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSDSPack = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSDSUnpackAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextView = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextViewIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextViewSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextViewTile = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextForceBigEndian = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.ContextDeleteSelectedFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextUnpackSelectedSDS = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextPackSelectedSDS = new System.Windows.Forms.ToolStripMenuItem();
            this.topContainer = new System.Windows.Forms.ToolStripContainer();
            this.Toolstrip_ButtonContainer = new System.Windows.Forms.ToolStrip();
            this.Button_Settings = new System.Windows.Forms.ToolStripButton();
            this.Button_PackSDS = new System.Windows.Forms.ToolStripButton();
            this.Button_UnpackSDS = new System.Windows.Forms.ToolStripButton();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.dropdownFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.openMafiaIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runMafiaIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Button_SelectGame = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownView = new System.Windows.Forms.ToolStripDropDownButton();
            this.ViewStripMenuIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewStripMenuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewStripMenuSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewStripMenuList = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewStripMenuTile = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.OptionsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.M2FBXButton = new System.Windows.Forms.ToolStripMenuItem();
            this.UnpackAllSDSButton = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomContainer = new System.Windows.Forms.ToolStripContainer();
            this.status = new System.Windows.Forms.StatusStrip();
            this.infoText = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.GEContext.SuspendLayout();
            this.topContainer.ContentPanel.SuspendLayout();
            this.topContainer.SuspendLayout();
            this.Toolstrip_ButtonContainer.SuspendLayout();
            this.tools.SuspendLayout();
            this.bottomContainer.ContentPanel.SuspendLayout();
            this.bottomContainer.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 55);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.folderView);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.toolStripContainer1);
            this.mainContainer.Panel2.Controls.Add(this.fileListView);
            this.mainContainer.Size = new System.Drawing.Size(800, 369);
            this.mainContainer.SplitterDistance = 266;
            this.mainContainer.TabIndex = 0;
            // 
            // folderView
            // 
            this.folderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderView.ImageIndex = 0;
            this.folderView.ImageList = this.imageBank;
            this.folderView.Location = new System.Drawing.Point(0, 0);
            this.folderView.Name = "folderView";
            this.folderView.SelectedImageIndex = 0;
            this.folderView.Size = new System.Drawing.Size(266, 369);
            this.folderView.TabIndex = 0;
            this.folderView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderViewAfterExpand);
            // 
            // imageBank
            // 
            this.imageBank.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageBank.ImageStream")));
            this.imageBank.TransparentColor = System.Drawing.Color.Transparent;
            this.imageBank.Images.SetKeyName(0, "folderIcon");
            this.imageBank.Images.SetKeyName(1, ".sds");
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(530, 29);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(530, 29);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.CanOverflow = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpButton,
            this.FolderPath,
            this.buttonStripRefresh,
            this.SearchEntryText});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(530, 23);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip1";
            this.toolStrip2.Resize += new System.EventHandler(this.toolStrip1_Resize);
            // 
            // UpButton
            // 
            this.UpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpButton.Image = ((System.Drawing.Image)(resources.GetObject("UpButton.Image")));
            this.UpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(23, 20);
            this.UpButton.Text = "Up a Folder";
            this.UpButton.ToolTipText = "$UP_TOOLTIP";
            this.UpButton.Click += new System.EventHandler(this.OnUpButtonClicked);
            // 
            // FolderPath
            // 
            this.FolderPath.AutoSize = false;
            this.FolderPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FolderPath.Name = "FolderPath";
            this.FolderPath.Size = new System.Drawing.Size(200, 23);
            this.FolderPath.ToolTipText = "$FOLDER_PATH_TOOLTIP";
            this.FolderPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onPathChange);
            // 
            // buttonStripRefresh
            // 
            this.buttonStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonStripRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonStripRefresh.Image")));
            this.buttonStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonStripRefresh.Name = "buttonStripRefresh";
            this.buttonStripRefresh.Size = new System.Drawing.Size(23, 20);
            this.buttonStripRefresh.Text = "$REFRESH";
            this.buttonStripRefresh.Click += new System.EventHandler(this.OnRefreshButtonClicked);
            // 
            // SearchEntryText
            // 
            this.SearchEntryText.AutoSize = false;
            this.SearchEntryText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SearchEntryText.Name = "SearchEntryText";
            this.SearchEntryText.Size = new System.Drawing.Size(200, 23);
            this.SearchEntryText.ToolTipText = "$SEARCH_TOOLTIP";
            this.SearchEntryText.TextChanged += new System.EventHandler(this.SearchBarOnTextChanged);
            // 
            // fileListView
            // 
            this.fileListView.AllowDrop = true;
            this.fileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnType,
            this.columnSize,
            this.columnLastModified});
            this.fileListView.ContextMenuStrip = this.GEContext;
            this.fileListView.HideSelection = false;
            this.fileListView.LargeImageList = this.imageBank;
            this.fileListView.Location = new System.Drawing.Point(3, 30);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(530, 339);
            this.fileListView.SmallImageList = this.imageBank;
            this.fileListView.TabIndex = 0;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.fileListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_ItemSelectionChanged);
            this.fileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListView_OnDragDrop);
            this.fileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListView_OnDragEnter);
            this.fileListView.DragLeave += new System.EventHandler(this.ListView_OnDragLeave);
            this.fileListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ListView_OnKeyUp);
            // 
            // columnName
            // 
            this.columnName.Text = "$NAME";
            this.columnName.Width = 157;
            // 
            // columnType
            // 
            this.columnType.Text = "$TYPE";
            this.columnType.Width = 143;
            // 
            // columnSize
            // 
            this.columnSize.Text = "$SIZE";
            // 
            // columnLastModified
            // 
            this.columnLastModified.Text = "$LAST_MODIFIED";
            this.columnLastModified.Width = 281;
            // 
            // GEContext
            // 
            this.GEContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSDSUnpack,
            this.ContextSDSPack,
            this.ContextOpenFolder,
            this.ContextSDSUnpackAll,
            this.ContextView,
            this.ContextForceBigEndian,
            this.ContextSeperator,
            this.ContextDeleteSelectedFiles,
            this.ContextUnpackSelectedSDS,
            this.ContextPackSelectedSDS});
            this.GEContext.Name = "SDSContext";
            this.GEContext.Size = new System.Drawing.Size(294, 208);
            this.GEContext.Text = "$VIEW";
            this.GEContext.Opening += new System.ComponentModel.CancelEventHandler(this.OnOpening);
            // 
            // ContextSDSUnpack
            // 
            this.ContextSDSUnpack.Name = "ContextSDSUnpack";
            this.ContextSDSUnpack.ShortcutKeyDisplayString = "CTRL + U";
            this.ContextSDSUnpack.Size = new System.Drawing.Size(293, 22);
            this.ContextSDSUnpack.Text = "$UNPACK";
            this.ContextSDSUnpack.Visible = false;
            this.ContextSDSUnpack.Click += new System.EventHandler(this.ContextSDSUnpack_Click);
            // 
            // ContextSDSPack
            // 
            this.ContextSDSPack.Name = "ContextSDSPack";
            this.ContextSDSPack.ShortcutKeyDisplayString = "CTRL + P";
            this.ContextSDSPack.Size = new System.Drawing.Size(293, 22);
            this.ContextSDSPack.Text = "$PACK";
            this.ContextSDSPack.Visible = false;
            this.ContextSDSPack.Click += new System.EventHandler(this.ContextSDSPack_Click);
            // 
            // ContextOpenFolder
            // 
            this.ContextOpenFolder.Name = "ContextOpenFolder";
            this.ContextOpenFolder.Size = new System.Drawing.Size(293, 22);
            this.ContextOpenFolder.Text = "$OPEN_FOLDER_EXPLORER";
            this.ContextOpenFolder.Click += new System.EventHandler(this.ContextOpenFolder_Click);
            // 
            // ContextSDSUnpackAll
            // 
            this.ContextSDSUnpackAll.Name = "ContextSDSUnpackAll";
            this.ContextSDSUnpackAll.Size = new System.Drawing.Size(293, 22);
            this.ContextSDSUnpackAll.Text = "$UNPACK_ALL_SDS";
            this.ContextSDSUnpackAll.Click += new System.EventHandler(this.ContextSDSUnpackAll_Click);
            // 
            // ContextView
            // 
            this.ContextView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextViewIcon,
            this.ContextViewDetails,
            this.ContextViewSmallIcon,
            this.ContextViewList,
            this.ContextViewTile});
            this.ContextView.Name = "ContextView";
            this.ContextView.Size = new System.Drawing.Size(293, 22);
            this.ContextView.Text = "$VIEW";
            // 
            // ContextViewIcon
            // 
            this.ContextViewIcon.CheckOnClick = true;
            this.ContextViewIcon.Name = "ContextViewIcon";
            this.ContextViewIcon.Size = new System.Drawing.Size(151, 22);
            this.ContextViewIcon.Text = "$ICON";
            this.ContextViewIcon.Click += new System.EventHandler(this.OnViewIconClicked);
            // 
            // ContextViewDetails
            // 
            this.ContextViewDetails.CheckOnClick = true;
            this.ContextViewDetails.Name = "ContextViewDetails";
            this.ContextViewDetails.Size = new System.Drawing.Size(151, 22);
            this.ContextViewDetails.Text = "$DETAILS";
            this.ContextViewDetails.Click += new System.EventHandler(this.OnViewDetailsClicked);
            // 
            // ContextViewSmallIcon
            // 
            this.ContextViewSmallIcon.CheckOnClick = true;
            this.ContextViewSmallIcon.Name = "ContextViewSmallIcon";
            this.ContextViewSmallIcon.Size = new System.Drawing.Size(151, 22);
            this.ContextViewSmallIcon.Text = "$SMALL_ICON";
            this.ContextViewSmallIcon.Click += new System.EventHandler(this.OnViewSmallIconClicked);
            // 
            // ContextViewList
            // 
            this.ContextViewList.CheckOnClick = true;
            this.ContextViewList.Name = "ContextViewList";
            this.ContextViewList.Size = new System.Drawing.Size(151, 22);
            this.ContextViewList.Text = "$LIST";
            this.ContextViewList.Click += new System.EventHandler(this.OnViewListClicked);
            // 
            // ContextViewTile
            // 
            this.ContextViewTile.CheckOnClick = true;
            this.ContextViewTile.Name = "ContextViewTile";
            this.ContextViewTile.Size = new System.Drawing.Size(151, 22);
            this.ContextViewTile.Text = "$TILE";
            this.ContextViewTile.Click += new System.EventHandler(this.OnViewTileClicked);
            // 
            // ContextForceBigEndian
            // 
            this.ContextForceBigEndian.Name = "ContextForceBigEndian";
            this.ContextForceBigEndian.Size = new System.Drawing.Size(293, 22);
            this.ContextForceBigEndian.Text = "$FORCE_BIG_ENDIAN";
            this.ContextForceBigEndian.Click += new System.EventHandler(this.ContextForceBigEndian_Click);
            // 
            // ContextSeperator
            // 
            this.ContextSeperator.Name = "ContextSeperator";
            this.ContextSeperator.Size = new System.Drawing.Size(290, 6);
            // 
            // ContextDeleteSelectedFiles
            // 
            this.ContextDeleteSelectedFiles.Name = "ContextDeleteSelectedFiles";
            this.ContextDeleteSelectedFiles.ShortcutKeyDisplayString = "CTRL + DELETE";
            this.ContextDeleteSelectedFiles.Size = new System.Drawing.Size(293, 22);
            this.ContextDeleteSelectedFiles.Text = "$DELETE_SELECTED_FILES";
            this.ContextDeleteSelectedFiles.Click += new System.EventHandler(this.ContextDeleteSelectedFiles_OnClick);
            // 
            // ContextUnpackSelectedSDS
            // 
            this.ContextUnpackSelectedSDS.Name = "ContextUnpackSelectedSDS";
            this.ContextUnpackSelectedSDS.Size = new System.Drawing.Size(293, 22);
            this.ContextUnpackSelectedSDS.Text = "$UNPACK_SELECTED_SDS";
            this.ContextUnpackSelectedSDS.Click += new System.EventHandler(this.ContextUnpackSelectedSDS_OnClick);
            // 
            // ContextPackSelectedSDS
            // 
            this.ContextPackSelectedSDS.Name = "ContextPackSelectedSDS";
            this.ContextPackSelectedSDS.Size = new System.Drawing.Size(293, 22);
            this.ContextPackSelectedSDS.Text = "$PACK_SELECTED_SDS";
            this.ContextPackSelectedSDS.Click += new System.EventHandler(this.ContextPackSelectedSDS_OnClick);
            // 
            // topContainer
            // 
            this.topContainer.BottomToolStripPanelVisible = false;
            // 
            // topContainer.ContentPanel
            // 
            this.topContainer.ContentPanel.Controls.Add(this.Toolstrip_ButtonContainer);
            this.topContainer.ContentPanel.Controls.Add(this.tools);
            this.topContainer.ContentPanel.Size = new System.Drawing.Size(800, 55);
            this.topContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.topContainer.LeftToolStripPanelVisible = false;
            this.topContainer.Location = new System.Drawing.Point(0, 0);
            this.topContainer.Name = "topContainer";
            this.topContainer.RightToolStripPanelVisible = false;
            this.topContainer.Size = new System.Drawing.Size(800, 55);
            this.topContainer.TabIndex = 1;
            this.topContainer.Text = "topContainer";
            this.topContainer.TopToolStripPanelVisible = false;
            // 
            // Toolstrip_ButtonContainer
            // 
            this.Toolstrip_ButtonContainer.AutoSize = false;
            this.Toolstrip_ButtonContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Toolstrip_ButtonContainer.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.Toolstrip_ButtonContainer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_Settings,
            this.Button_PackSDS,
            this.Button_UnpackSDS});
            this.Toolstrip_ButtonContainer.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Toolstrip_ButtonContainer.Location = new System.Drawing.Point(0, 22);
            this.Toolstrip_ButtonContainer.Name = "Toolstrip_ButtonContainer";
            this.Toolstrip_ButtonContainer.Padding = new System.Windows.Forms.Padding(0);
            this.Toolstrip_ButtonContainer.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Toolstrip_ButtonContainer.Size = new System.Drawing.Size(800, 39);
            this.Toolstrip_ButtonContainer.TabIndex = 2;
            this.Toolstrip_ButtonContainer.Text = "toolStrip1";
            // 
            // Button_Settings
            // 
            this.Button_Settings.AutoSize = false;
            this.Button_Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Settings.Image = ((System.Drawing.Image)(resources.GetObject("Button_Settings.Image")));
            this.Button_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Settings.Name = "Button_Settings";
            this.Button_Settings.Size = new System.Drawing.Size(32, 32);
            this.Button_Settings.Text = "toolStripButton1";
            this.Button_Settings.Click += new System.EventHandler(this.OnOptionsItem_Clicked);
            // 
            // Button_PackSDS
            // 
            this.Button_PackSDS.AutoSize = false;
            this.Button_PackSDS.BackColor = System.Drawing.SystemColors.Control;
            this.Button_PackSDS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_PackSDS.Enabled = false;
            this.Button_PackSDS.Image = ((System.Drawing.Image)(resources.GetObject("Button_PackSDS.Image")));
            this.Button_PackSDS.ImageTransparentColor = System.Drawing.Color.White;
            this.Button_PackSDS.Name = "Button_PackSDS";
            this.Button_PackSDS.Size = new System.Drawing.Size(32, 32);
            this.Button_PackSDS.Text = "toolStripButton1";
            this.Button_PackSDS.Click += new System.EventHandler(this.ContextSDSPack_Click);
            // 
            // Button_UnpackSDS
            // 
            this.Button_UnpackSDS.AutoSize = false;
            this.Button_UnpackSDS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_UnpackSDS.Enabled = false;
            this.Button_UnpackSDS.Image = ((System.Drawing.Image)(resources.GetObject("Button_UnpackSDS.Image")));
            this.Button_UnpackSDS.ImageTransparentColor = System.Drawing.Color.White;
            this.Button_UnpackSDS.Name = "Button_UnpackSDS";
            this.Button_UnpackSDS.Size = new System.Drawing.Size(32, 32);
            this.Button_UnpackSDS.Text = "Button_PackSDS";
            this.Button_UnpackSDS.Click += new System.EventHandler(this.ContextSDSUnpack_Click);
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dropdownFile,
            this.dropdownView,
            this.dropdownTools});
            this.tools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(800, 22);
            this.tools.TabIndex = 1;
            this.tools.Text = "toolStrip1";
            // 
            // dropdownFile
            // 
            this.dropdownFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dropdownFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMafiaIIToolStripMenuItem,
            this.runMafiaIIToolStripMenuItem,
            this.Button_SelectGame,
            this.creditsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.dropdownFile.Image = ((System.Drawing.Image)(resources.GetObject("dropdownFile.Image")));
            this.dropdownFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropdownFile.Name = "dropdownFile";
            this.dropdownFile.Size = new System.Drawing.Size(47, 19);
            this.dropdownFile.Text = "$FILE";
            // 
            // openMafiaIIToolStripMenuItem
            // 
            this.openMafiaIIToolStripMenuItem.Name = "openMafiaIIToolStripMenuItem";
            this.openMafiaIIToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openMafiaIIToolStripMenuItem.Text = "$BTN_OPEN_MII";
            this.openMafiaIIToolStripMenuItem.Click += new System.EventHandler(this.OpenMafiaIIClicked);
            // 
            // runMafiaIIToolStripMenuItem
            // 
            this.runMafiaIIToolStripMenuItem.Name = "runMafiaIIToolStripMenuItem";
            this.runMafiaIIToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.runMafiaIIToolStripMenuItem.Text = "$BTN_RUN_MII";
            this.runMafiaIIToolStripMenuItem.Click += new System.EventHandler(this.RunMafiaIIClicked);
            // 
            // Button_SelectGame
            // 
            this.Button_SelectGame.Name = "Button_SelectGame";
            this.Button_SelectGame.Size = new System.Drawing.Size(159, 22);
            this.Button_SelectGame.Text = "$SELECT_GAME";
            this.Button_SelectGame.Click += new System.EventHandler(this.Button_SelectGame_OnClick);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.creditsToolStripMenuItem.Text = "$CREDITS";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.OnCredits_Pressed);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "$EXIT";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolkitClicked);
            // 
            // dropdownView
            // 
            this.dropdownView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dropdownView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewStripMenuIcon,
            this.ViewStripMenuDetails,
            this.ViewStripMenuSmallIcon,
            this.ViewStripMenuList,
            this.ViewStripMenuTile});
            this.dropdownView.Image = ((System.Drawing.Image)(resources.GetObject("dropdownView.Image")));
            this.dropdownView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropdownView.Name = "dropdownView";
            this.dropdownView.Size = new System.Drawing.Size(53, 19);
            this.dropdownView.Text = "$VIEW";
            // 
            // ViewStripMenuIcon
            // 
            this.ViewStripMenuIcon.CheckOnClick = true;
            this.ViewStripMenuIcon.Name = "ViewStripMenuIcon";
            this.ViewStripMenuIcon.Size = new System.Drawing.Size(151, 22);
            this.ViewStripMenuIcon.Text = "$ICON";
            this.ViewStripMenuIcon.Click += new System.EventHandler(this.OnViewIconClicked);
            // 
            // ViewStripMenuDetails
            // 
            this.ViewStripMenuDetails.CheckOnClick = true;
            this.ViewStripMenuDetails.Name = "ViewStripMenuDetails";
            this.ViewStripMenuDetails.Size = new System.Drawing.Size(151, 22);
            this.ViewStripMenuDetails.Text = "$DETAILS";
            this.ViewStripMenuDetails.Click += new System.EventHandler(this.OnViewDetailsClicked);
            // 
            // ViewStripMenuSmallIcon
            // 
            this.ViewStripMenuSmallIcon.CheckOnClick = true;
            this.ViewStripMenuSmallIcon.Name = "ViewStripMenuSmallIcon";
            this.ViewStripMenuSmallIcon.Size = new System.Drawing.Size(151, 22);
            this.ViewStripMenuSmallIcon.Text = "$SMALL_ICON";
            this.ViewStripMenuSmallIcon.Click += new System.EventHandler(this.OnViewSmallIconClicked);
            // 
            // ViewStripMenuList
            // 
            this.ViewStripMenuList.CheckOnClick = true;
            this.ViewStripMenuList.Name = "ViewStripMenuList";
            this.ViewStripMenuList.Size = new System.Drawing.Size(151, 22);
            this.ViewStripMenuList.Text = "$LIST";
            this.ViewStripMenuList.Click += new System.EventHandler(this.OnViewListClicked);
            // 
            // ViewStripMenuTile
            // 
            this.ViewStripMenuTile.CheckOnClick = true;
            this.ViewStripMenuTile.Name = "ViewStripMenuTile";
            this.ViewStripMenuTile.Size = new System.Drawing.Size(151, 22);
            this.ViewStripMenuTile.Text = "$TILE";
            this.ViewStripMenuTile.Click += new System.EventHandler(this.OnViewTileClicked);
            // 
            // dropdownTools
            // 
            this.dropdownTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dropdownTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsItem,
            this.M2FBXButton,
            this.UnpackAllSDSButton});
            this.dropdownTools.Image = ((System.Drawing.Image)(resources.GetObject("dropdownTools.Image")));
            this.dropdownTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropdownTools.Name = "dropdownTools";
            this.dropdownTools.Size = new System.Drawing.Size(61, 19);
            this.dropdownTools.Text = "$TOOLS";
            // 
            // OptionsItem
            // 
            this.OptionsItem.Name = "OptionsItem";
            this.OptionsItem.Size = new System.Drawing.Size(176, 22);
            this.OptionsItem.Text = "$OPTIONS";
            this.OptionsItem.Click += new System.EventHandler(this.OnOptionsItem_Clicked);
            // 
            // M2FBXButton
            // 
            this.M2FBXButton.Name = "M2FBXButton";
            this.M2FBXButton.Size = new System.Drawing.Size(176, 22);
            this.M2FBXButton.Text = "M2 FBX";
            this.M2FBXButton.Click += new System.EventHandler(this.M2FBXButtonClicked);
            // 
            // UnpackAllSDSButton
            // 
            this.UnpackAllSDSButton.Name = "UnpackAllSDSButton";
            this.UnpackAllSDSButton.Size = new System.Drawing.Size(176, 22);
            this.UnpackAllSDSButton.Text = "$UNPACK_ALL_SDS";
            this.UnpackAllSDSButton.Click += new System.EventHandler(this.UnpackAllSDSButton_Click);
            // 
            // bottomContainer
            // 
            this.bottomContainer.BottomToolStripPanelVisible = false;
            // 
            // bottomContainer.ContentPanel
            // 
            this.bottomContainer.ContentPanel.Controls.Add(this.status);
            this.bottomContainer.ContentPanel.Size = new System.Drawing.Size(800, 26);
            this.bottomContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomContainer.LeftToolStripPanelVisible = false;
            this.bottomContainer.Location = new System.Drawing.Point(0, 424);
            this.bottomContainer.Name = "bottomContainer";
            this.bottomContainer.RightToolStripPanelVisible = false;
            this.bottomContainer.Size = new System.Drawing.Size(800, 26);
            this.bottomContainer.TabIndex = 1;
            this.bottomContainer.Text = "bottomContainer";
            this.bottomContainer.TopToolStripPanelVisible = false;
            // 
            // status
            // 
            this.status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoText});
            this.status.Location = new System.Drawing.Point(0, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(800, 26);
            this.status.TabIndex = 0;
            this.status.Text = "statusStrip1";
            // 
            // infoText
            // 
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(0, 21);
            // 
            // GameExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.bottomContainer);
            this.Controls.Add(this.topContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "GameExplorer";
            this.Text = "$MII_TK_GAME_EXPLORER";
            this.Load += new System.EventHandler(this.toolStrip1_Resize);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.GEContext.ResumeLayout(false);
            this.topContainer.ContentPanel.ResumeLayout(false);
            this.topContainer.ContentPanel.PerformLayout();
            this.topContainer.ResumeLayout(false);
            this.topContainer.PerformLayout();
            this.Toolstrip_ButtonContainer.ResumeLayout(false);
            this.Toolstrip_ButtonContainer.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.bottomContainer.ContentPanel.ResumeLayout(false);
            this.bottomContainer.ContentPanel.PerformLayout();
            this.bottomContainer.ResumeLayout(false);
            this.bottomContainer.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.TreeView folderView;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnLastModified;
        private System.Windows.Forms.ColumnHeader columnSize;
        private ToolStripContainer topContainer;
        private ToolStrip tools;
        private ToolStripContainer bottomContainer;
        private StatusStrip status;
        private ToolStripStatusLabel infoText;
        private ContextMenuStrip GEContext;
        private ToolStripMenuItem ContextSDSUnpack;
        private ToolStripMenuItem ContextSDSPack;
        private ToolStripDropDownButton dropdownFile;
        private ToolStripDropDownButton dropdownTools;
        private ToolStripMenuItem openMafiaIIToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem runMafiaIIToolStripMenuItem;
        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip2;
        private ToolStripButton UpButton;
        private ToolStripTextBox FolderPath;
        private ToolStripButton buttonStripRefresh;
        private ToolStripTextBox SearchEntryText;
        private ToolStripMenuItem ContextOpenFolder;
        private ToolStripMenuItem OptionsItem;
        private ToolStripMenuItem ContextSDSUnpackAll;
        private ImageList imageBank;
        private ToolStripMenuItem ContextView;
        private ToolStripMenuItem ContextViewIcon;
        private ToolStripMenuItem ContextViewDetails;
        private ToolStripMenuItem ContextViewSmallIcon;
        private ToolStripMenuItem ContextViewList;
        private ToolStripMenuItem ContextViewTile;
        private ToolStripDropDownButton dropdownView;
        private ToolStripMenuItem ViewStripMenuIcon;
        private ToolStripMenuItem ViewStripMenuDetails;
        private ToolStripMenuItem ViewStripMenuSmallIcon;
        private ToolStripMenuItem ViewStripMenuList;
        private ToolStripMenuItem ViewStripMenuTile;
        private ToolStripMenuItem creditsToolStripMenuItem;
        private ToolStripMenuItem M2FBXButton;
        private ToolStripMenuItem UnpackAllSDSButton;
        private ToolStripMenuItem ContextForceBigEndian;
        private ToolStripMenuItem Button_SelectGame;
        private ToolStripMenuItem ContextDeleteSelectedFiles;
        private ToolStripSeparator ContextSeperator;
        private ToolStripMenuItem ContextUnpackSelectedSDS;
        private ToolStripMenuItem ContextPackSelectedSDS;
        private ToolStrip Toolstrip_ButtonContainer;
        private ToolStripButton Button_PackSDS;
        private ToolStripButton Button_UnpackSDS;
        private ToolStripButton Button_Settings;
    }
}