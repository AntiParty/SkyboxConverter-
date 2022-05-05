using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SkyboxConverter
{
    public partial class Form1 : Form
    {
        public Point mouseLocation;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Create Folder strings 
        private string fileName;
        private string filePath1;
    
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //This is all shit code ik
            fileName = Path.GetFileName(openFileDialog1.FileName);
            

            openFileDialog1.InitialDirectory = "Downloads";
            openFileDialog1.Filter = "Image Files(*.PNG;*.JPG)|*.PNG;*.JPG;|All Files (*.*) | *.*";
            // Locate image

            openFileDialog1.ShowDialog();
            filePath1 = openFileDialog1.FileName;
            fileName = Path.GetFileName(openFileDialog1.FileName);

            listBox1.Items.Clear();
            string [] files=openFileDialog1.FileNames;

            foreach(string file in files)
            {
                listBox1.Items.Add(file);
            }
        }

        //Convert button
        private async void button4_Click(object sender, EventArgs e)
        {
            string oldfile = Path.GetFullPath("./testfile.txt");
            string mysourcepath = Path.GetFullPath("./SkyboxConverter.exe");

            MessageBox.Show("Input file: " + mysourcepath);
            string outputPath = Path.Combine(Path.GetDirectoryName(mysourcepath), fileName);
            MessageBox.Show("Folder path: " + outputPath);

            File.Move(filePath1, outputPath);
            MessageBox.Show("OutputPath: " + outputPath);
            // Deletes oldFile
            File.Delete(oldfile);


            // File Renames to proper 
            if (fileName == "top.png")
            {
                File.Move(outputPath, "py.png");
            }
            if (fileName == "right.png")
            {
                File.Move(outputPath, "nx.png");
            }
            if (fileName == "left.png")
            {
                File.Move(outputPath, "px.png");
            }
            if (fileName == "front.png")
            {
                File.Move(outputPath, "nz.png");
            }
            if (fileName == "bottom.png")
            {
                File.Move(outputPath, "ny.png");
            }
            if (fileName == "back.png")
            {
                File.Move(outputPath, "pz.png");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tutorial coming soon...");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Start of mouse move events
        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }
        // End of mouse move events
        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
