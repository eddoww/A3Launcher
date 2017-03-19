using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using A3Launcher.Properties;
using tessnet2;

namespace A3Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txta3path.Text = (string)Settings.Default["a3res_path"];

            }
        private void button2_Click(object sender, EventArgs e)
        {
            AddAccountForm();
        }

        public void AddAccountForm()
        {
            AddAccountForm testDialog = new AddAccountForm();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                MessageBox.Show(testDialog.AddAccountUserID.Text);
                MessageBox.Show(testDialog.AddAccountPassword.Text);
                }
            else
            {
                MessageBox.Show("Cancelled");
            }
            testDialog.Dispose();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text != null)
            {
                webBrowser1.Show();
                webBrowser1.Navigate(string.Format("http://www.a3res.com/view/{0}/", e.Node.Text));
            }
        }

        public void logintoa3res(string user, string password)
        {
            HttpWebRequest.Create("http://www.a3res.com/account/user/");
            var loginAddress = "http://www.a3res.com/account/";
            var loginData = new NameValueCollection
            {
                {"userid", user},
                {"userpassword", password}
            };

            var client = new CookieAwareWebClient();
            client.Login(loginAddress, loginData);
        }

        private void button4_Click(object sender, EventArgs e)
            {
            using (var findDialog = new FolderBrowserDialog())
                {
                if (findDialog.ShowDialog() == DialogResult.OK)
                    {
                    Settings.Default["a3res_path"] = findDialog.SelectedPath;
                    txta3path.Text = findDialog.SelectedPath;
                    Settings.Default.Save();
                    }
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(txta3path.Text + "/moac.exe"))
            {
                //System.Diagnostics.Process.Start(txta3path.Text + "/moac.exe", string.Format("-u {0} -p {1}", "eddow", "123456"));
                ProcessStartInfo _processStartInfo = new ProcessStartInfo();
                _processStartInfo.WorkingDirectory = txta3path.Text;
                _processStartInfo.FileName = @"moac.exe";
                _processStartInfo.Arguments = string.Format("-u {0} -p {1}", treeView1.SelectedNode.Text, treeView1.SelectedNode.Parent.Tag);
                Process myProcess = Process.Start(_processStartInfo);
                }
            else
            {
                MessageBox.Show("Could not find moac.exe in specified folder.");
            }
            }
        private void populateAccounts()
            {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open XML Document";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            dlg.FileName = Application.StartupPath + "\\..\\..\\example.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
                {
                try
                    {
                    //Just a good practice -- change the cursor to a 
                    //wait cursor while the nodes populate
                    this.Cursor = Cursors.WaitCursor;
                    //First, we'll load the Xml document
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(dlg.FileName);
                    //Now, clear out the treeview, 
                    //and add the first (root) node
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(new
                      TreeNode(xDoc.DocumentElement.Name)); 
                    TreeNode tNode = new TreeNode();
                    tNode = (TreeNode)treeView1.Nodes[0];
                    //We make a call to addTreeNode, 
                    //where we'll add all of our nodes
                    addAccounts(xDoc.DocumentElement, tNode);
                    //Expand the treeview to show all nodes
                    treeView1.ExpandAll();
                    }
                catch (XmlException xExc)
                //Exception is thrown is there is an error in the Xml
                    {
                    MessageBox.Show(xExc.Message);
                    }
                catch (Exception ex) //General exception
                    {
                    MessageBox.Show(ex.Message);
                    }
                finally
                    {
                    this.Cursor = Cursors.Default; //Change the cursor back
                    }
                }
            }
        //This function is called recursively until all nodes are loaded
        private void addAccounts(XmlNode xmlNode, TreeNode treeNode)
            {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
                {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                //Loop through the child nodes
                    {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(xNode.Name);
                    tNode = treeNode.Nodes[x];
                    //addAccounts(xNode, tNode);
                    }
                }
            else //No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = xmlNode.OuterXml.Trim();
            }

        private void button5_Click(object sender, EventArgs e)
            {
            populateAccounts();
            }
        }
}