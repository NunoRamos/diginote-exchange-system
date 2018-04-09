using Common;
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
    public partial class CreatePurchaseOrderForm : MaterialForm
    {
        public CreatePurchaseOrderForm()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Tuple<Exception, OrderNotSatisfiedException> result = Client.State.CreatePurchaseOrder(int.Parse(QuantityTextField.Text), float.Parse(ValueTextField.Text));

            MessageBox.Show(result.ToString());

           if (result.Item2 != null)
            {
                Client.Forms.PurchaseOrderNotSatisfiedForm.UpdateDiginotesLeft(result.Item2.Quantity);
                Client.Forms.PurchaseOrderNotSatisfiedForm.ShowDialog(this);
            }
                
        }
    }
}
