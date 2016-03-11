using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace EmployeeRecords
{
    public class EmployeeRecordsForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;

        private System.ComponentModel.Container component = null;
        private TreeNode tvRootNode;

        public EmployeeRecordsForm()
        {
            InitializeComponent();
            PopulateTreeView();
            initializeListControl();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (component != null)
                {
                    component.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer Generated Code

        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            this.treeView1.ImageIndex = -1;
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = -1;
            this.treeView1.Size = new System.Drawing.Size(240, 352);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect +=new System.Windows.Forms.TreeViewEventHandler(treeView1_AfterSelect);

            this.listView1.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView1.Location = new System.Drawing.Point(240, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(480, 352);
            this.listView1.TabIndex = 1;
            this.listView1.View = System.Windows.Forms.View.Details;

            this.statusBar1.Location = new System.Drawing.Point(0, 357);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] { this.statusBarPanel1 });
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(720, 24);
            this.statusBar1.TabIndex = 2;

            this.statusBarPanel1.Text = "Click the employee code to view details";
            this.statusBarPanel1.Width = 720;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(720, 381);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.statusBar1, this.listView1, this.treeView1 });
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeRecordsForm";
            this.Text = "Employee Records Monitoring System";
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        protected void PopulateTreeView()
        {
            statusBarPanel1.Text = "Refreshing Employee Codes. Please wait...";
            this.Cursor = Cursors.WaitCursor;
            treeView1.Nodes.Clear();
            tvRootNode = new TreeNode("Employee Records");
            this.Cursor = Cursors.Default;
            treeView1.Nodes.Add(tvRootNode);

            TreeNodeCollection nodeCollect = tvRootNode.Nodes;
            string strVal = "";
            XmlTextReader reader = new XmlTextReader("C:\\EmpRec.xml");
            reader.MoveToElement();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasAttributes && reader.NodeType == XmlNodeType.Element)
                    {
                        reader.MoveToElement();
                        reader.MoveToElement();
                        reader.MoveToAttribute("Id");
                        strVal = reader.Value;
                        reader.Read();
                        reader.Read();
                        if (reader.Name == "Dept")
                        {
                            reader.Read();
                        }
                        TreeNode EcodeNode = new TreeNode(strVal);
                        nodeCollect.Add(EcodeNode);
                    }
                }
                statusBarPanel1.Text = "Click on an employee code to see their record.";
            }
            catch(XmlException e)
            {
                MessageBox.Show("XML Exception : " + e.ToString());
            }
        }

        protected void initializeListControl()
        {
            listView1.Clear();
            listView1.Columns.Add("Employee Name", 225, HorizontalAlignment.Left);
            listView1.Columns.Add("Date of Join", 70, HorizontalAlignment.Right);
            listView1.Columns.Add("Grade", 105, HorizontalAlignment.Left);
            listView1.Columns.Add("Salary", 105, HorizontalAlignment.Left);
        }

        protected void PopulateListView(TreeNode currNode)
        {
            initializeListControl();
            XmlTextReader listRead = new XmlTextReader("C:\\EmpRec.xml");
            listRead.MoveToElement();
            while (listRead.Read())
            {
                string strNodeName;
                string strNodePath;
                string name;
                string grade;
                string doj;
                string sal;
                string[] strItemsArr = new String[4];
                listRead.MoveToFirstAttribute();
                strNodeName = listRead.Value;
                strNodePath = currNode.FullPath.Remove(0, 17);
                if (strNodePath == strNodeName)
                {
                    ListViewItem lvi;
                    listRead.MoveToNextAttribute();
                    name = listRead.Value;
                    lvi = listView1.Items.Add(name);
                    listRead.Read();
                    listRead.Read();
                    listRead.MoveToFirstAttribute();
                    doj = listRead.Value;
                    lvi.SubItems.Add(doj);
                    listRead.MoveToNextAttribute();
                    grade = listRead.Value;
                    lvi.SubItems.Add(grade);
                    listRead.MoveToNextAttribute();
                    sal = listRead.Value;
                    lvi.SubItems.Add(sal);
                    listRead.MoveToNextAttribute();
                    listRead.MoveToElement();
                    listRead.ReadString();
                }
            }
        }

        protected void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            TreeNode currNode = e.Node;
            if (tvRootNode == currNode)
            {
                initializeListControl();
                statusBarPanel1.Text = "Double click the Employee Records";
                return;
            }
            else
            {
                statusBarPanel1.Text = "Click an employee code to view individual records";
            }
            PopulateListView(currNode);
        }

    }
}
