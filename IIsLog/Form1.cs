using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogComm;

namespace IIsLog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            FolderBrowserDialog fbd = new FolderBrowserDialog();



            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("not select log path");
                return;
            }


            LogParseWapper cls = new LogParseWapper();

            var tst = cls.ParseW3CLog(fbd.SelectedPath, this.txtStateCode.Text);


            this.textBox1.Text = tst;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                var filenames = ofd.FileNames;

                if (filenames == null || filenames.Length == 0)
                {
                    MessageBox.Show("no fileselected");
                    return;
                }
                LogParseWapper cls = new LogParseWapper();

                var tst = cls.ParseW3CLog(filenames, this.txtStateCode.Text);


                this.textBox1.Text = tst;
            }
        }
    }
}
