using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diginote_exchange_system.Views
{
    public partial class PurchaseOrderNotSatisfiedForm : MaterialForm
    {
        public PurchaseOrderNotSatisfiedForm()
        {
            InitializeComponent();
        }

        public void UpdateDiginotesLeft(int diginotesLeft)
        {
            DiginotesLeftTextField.Text = "" + diginotesLeft;
        }

        private void PurchaseOrderNotSatisfiedForm_Load(object sender, EventArgs e)
        {
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // Do some stuff
        }
    }
}
