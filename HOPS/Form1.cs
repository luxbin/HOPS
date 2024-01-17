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
using System.Xml.Linq;

namespace HOPS
{
    public partial class Form1 : Form
    {
        HopsNode curNode = null;
        string savePath = "";
        string[] imageFileList = null;
        int curFileIndex = 0;

        string categoryXml = "";

        public Form1()
        {
            InitializeComponent();

            /*
            var doc = XDocument.Load(@"c:\temp\testxml.xml");
            foreach (var element in doc.Elements("Products").Elements())
            {
                Console.WriteLine(element.Attribute("category"));
            }
            */

            InitControls();
        }

        private void InitControls()
        {
            LoadXml();
        }

        private void LoadXml()
        {
            var path = Directory.GetCurrentDirectory() + "\\sub.xml";

            TreeNode root = new TreeNode();

            root.Name = "root";
            root.Text = "/";
            HopsNode tagRoot = new HopsNode();
            tagRoot.type = "root";
            root.Tag = tagRoot;

            tvMain.Nodes.Add(root);

            Console.WriteLine(path);

            var doc = XDocument.Parse(HOPS.Properties.Resources.sub);
            //var doc = XDocument.Load(path);

            foreach (var eleMain in doc.Elements("Root").Elements())
            {
                //Console.WriteLine(element.Attribute("category"));
                var txt = eleMain.Attribute("text").Value;
                TreeNode main = new TreeNode();
                main.Name = txt;
                main.Text = txt;

                HopsNode tag = new HopsNode();
                tag.type = "main";
                tag.text = txt;
                main.Tag = tag;
                root.Nodes.Add(main);

                foreach(var eleSub in eleMain.Elements())
                {
                    txt = eleSub.Attribute("text").Value;
                    TreeNode sub = new TreeNode();
                    sub.Name = txt;
                    sub.Text = txt;

                    HopsNode tag1 = new HopsNode();
                    tag1.type = "sub";
                    tag1.conv = eleSub.Attribute("conv").Value;
                    tag1.taken = eleSub.Attribute("taken").Value;
                    tag1.text = txt;
                    sub.Tag = tag1;
                    main.Nodes.Add(sub);
                }
            }

            tvMain.ExpandAll();
        }

        private void AddImagesToList()
        {
            lvImage.Items.Clear();

            /*
            string sitePath = savePath + "//" + txtSiteName.Text;
            Directory.CreateDirectory(sitePath);

            HopsNode parentNode = (HopsNode)tvMain.SelectedNode.Parent.Tag;

            sitePath += "//" + parentNode.text;

            Directory.CreateDirectory(sitePath);

            string lastPath = curNode.conv.Replace("XXXX_", txtLRD.Text + "_");

            string destPath = sitePath + "//" + lastPath;
            Directory.CreateDirectory(destPath);

            int nIndex = Directory.GetFiles(destPath).Length + 1;
            */

            int nIndex = 1;

            foreach (string file in imageFileList)
            {
                string[] items = new string[2];
                items[0] = nIndex.ToString();
                items[1] = Path.GetFileName(file);
                ListViewItem item = new ListViewItem(items);
                lvImage.Items.Add(item);

                nIndex ++;
            }

            lblStatus.Text = imageFileList.Length.ToString() + " file selected.";
        }

        private void txtImagePath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            imageFileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            string s = "";

            foreach (string file in imageFileList)
            {
                FileAttributes attr = File.GetAttributes(file);
                bool isFolder = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                s = s + " " + file;
            }

            AddImagesToList();
        }

        private void tvMain_Click(object sender, EventArgs e)
        {

        }

        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            curNode = (HopsNode)tvMain.SelectedNode.Tag;

            if (curNode.type != "sub")
            {
                txtCategory.Text = "";
                txtConv.Text = "";
            }
            else
            {
                txtCategory.Text = curNode.text;
                txtConv.Text = curNode.conv;
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSavePath.Text = folderDlg.SelectedPath;
                savePath = folderDlg.SelectedPath;
                //Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string siteName = txtSiteName.Text;
            string LRD = txtLRD.Text;

            if (siteName == "")
            {
                MessageBox.Show("Please input Site Name.");
                txtSiteName.Focus();
                return;
            }

            if (LRD == "")
            {
                MessageBox.Show("Please input LRD.");
                txtLRD.Focus();
                return;
            }

            if (txtCategory.Text == "")
            {
                MessageBox.Show("Please select category.");
                return;
            }

            if (lvImage.Items.Count == 0)
            {
                MessageBox.Show("Please drag and drop image files.");
                return;
            }

            if (txtSavePath.Text == "")
            {
                MessageBox.Show("Please select save path.");
                btnBrowser.Focus();
                return;
            }

            string sitePath = savePath + "//" + siteName;
            Directory.CreateDirectory(sitePath);

            HopsNode parentNode = (HopsNode)tvMain.SelectedNode.Parent.Tag;

            sitePath += "//" + parentNode.text;

            Directory.CreateDirectory(sitePath);

            string lastPath = curNode.conv.Replace("XXXX_", LRD + "_");

            string destPath = sitePath + "//" + lastPath;
            Directory.CreateDirectory(destPath);

            int index = Directory.GetFiles(destPath).Length + 1;


            foreach (string srcFilePath in imageFileList)
            {
                FileAttributes attr = File.GetAttributes(srcFilePath);
                bool isFolder = (attr & FileAttributes.Directory) == FileAttributes.Directory;
                if (isFolder) continue;

                //string destFileName = Path.GetFileNameWithoutExtension(srcFilePath);

                string destFileName = lastPath + index.ToString("00"); // "D2"

                string destFilePath = destPath;

                destFilePath += "//" + destFileName + Path.GetExtension(srcFilePath);

                File.Copy(srcFilePath, destFilePath, true);

                index++;
            }

            lblStatus.Text = imageFileList.Length.ToString() + " file copied.";

            lvImage.Items.Clear();
        }
    }

    public class HopsNode
    {
        public string type = "";
        public string conv = "";
        public string taken = "";
        public string text = "";
    }
}
