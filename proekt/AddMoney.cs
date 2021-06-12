using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proekt
{
    public partial class AddMoney : Form
    {
        public int suma { get; set; }

        public AddMoney()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(!Regex.IsMatch(tbName.Text, @"[a-zA-Z]"))
            {    
                errorProvider1.SetError(tbName, "Внеси име");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbName, null);
                e.Cancel = false;
            }
        }

        

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(tbLastName.Text, @"[a-zA-Z]"))
            {
                errorProvider1.SetError(tbLastName, "Внеси презиме");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbLastName, null);
                e.Cancel = false;
            }
        }

        private void tbNumCard_Validating(object sender, CancelEventArgs e)
        {
            if ((!Regex.IsMatch(tbNumCard.Text, @"[0-9]")) || (tbNumCard.Text.Length!=16))
            {
                errorProvider1.SetError(tbNumCard, "Внеси валиден број на картичка");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbNumCard, null);
                e.Cancel = false;
            }
        }

        private void cbMonth_Validating(object sender, CancelEventArgs e)
        {
            if (cbMonth.Text == "")
            {
                errorProvider1.SetError(cbYear, "Избери месец");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbMonth, null);
                e.Cancel = false;
            }
        }

        private void cbYear_Validating(object sender, CancelEventArgs e)
        {
            if (cbYear.Text == "")
            {
                errorProvider1.SetError(cbYear,"Избери година");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbYear, null);
                e.Cancel = false;
            }
        }

        private void tbSafeCode_Validating(object sender, CancelEventArgs e)
        {
            if ((!Regex.IsMatch(tbSafeCode.Text, @"[0-9]")) || (tbSafeCode.Text.Length != 3))
            {
                errorProvider1.SetError(tbSafeCode, "Внеси валиден код");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbSafeCode, null);
                e.Cancel = false;
            }
        }

        private void tbSuma_Validating(object sender, CancelEventArgs e)
        {
            if(!Regex.IsMatch(tbSuma.Text, @"[0-9]"))
            {
                
                errorProvider1.SetError(tbSuma, "Внеси сума");
                e.Cancel = true;
            }
            else if(Convert.ToInt32(tbSuma.Text)<100)
            {
                errorProvider1.SetError(tbSuma, "Минималниот износ на сума треба да е 100");
                e.Cancel = true;
            }
            else
            {
                
                suma = Convert.ToInt32(tbSuma.Text);
                errorProvider1.SetError(tbSuma, null);
                e.Cancel = false;
            }
        }
    }
}
