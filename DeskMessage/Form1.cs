using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DeskMessage
{
    public partial class Form1 : Form
    {
        public bool confirmation = false;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            button1.Enabled = false;
            label1.Text+= System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            notify();
            
            
        }

        private void checkBox1_Validated(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        private void notify()
        {

            notifyIcon1.Icon = new Icon("favicon.ico");

            notifyIcon1.Text = "ete";
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipTitle = "Important!";
            notifyIcon1.BalloonTipText = "You password will expire soon!\n Click for confirmation!";
            notifyIcon1.ShowBalloonTip(10000);
            
            //notifyIcon1.BalloonTipClicked

        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            if (confirmation == false)
            {
                notifyIcon1.Icon = new Icon("favicon.ico");
                notifyIcon1.Text = "ete";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Important!";
                notifyIcon1.BalloonTipText = "Thank for confirmation!";
                notifyIcon1.ShowBalloonTip(10000);
                confirmation = true;
            }
            
        }
    }
    
}
