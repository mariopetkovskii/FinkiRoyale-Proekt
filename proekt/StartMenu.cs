using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proekt
{


    public partial class StartMenu : Form
    {


        public StartMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(tbMainSostojba.Text) == 0)
            {
                MessageBox.Show("Внесете пари");
            }
            else
            {
                form2 forma = new form2();
                forma.sostojba = Convert.ToInt32(tbMainSostojba.Text);
                if (forma.ShowDialog() == DialogResult.Cancel)
                {
                    tbMainSostojba.Text = forma.globalna.sostojba.ToString();
                }
               
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMoney addMoney = new AddMoney();

            if (addMoney.ShowDialog() == DialogResult.OK)
            {
                tbMainSostojba.Text = (Convert.ToInt32(tbMainSostojba.Text) + addMoney.suma).ToString();
            }

        }

        private void StartMenu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
