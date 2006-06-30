using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace netTiers.Petshop.Inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Control c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    TextBox currentBox = (TextBox) c;
                    int i = ParseInt(currentBox);
                    if(i == int.MinValue)
                    {
                        ShowError(currentBox);
                    }
                }
            }
        }
        
        public int ParseInt(TextBox txtBox)
        {
            return  (txtBox.Text != null && txtBox.Text.Length != 0) ? Int32.Parse(txtBox.Text.Trim()) : int.MinValue;
        }  
        public void ShowError(TextBox box)
        {
            MessageBox.Show("There was an error with a value.");
        }
    }
}