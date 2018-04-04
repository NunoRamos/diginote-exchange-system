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
    public partial class CreateSellOrderForm : MaterialForm
    {
        public CreateSellOrderForm(FormManager formManager)
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Tuple<Exception, OrderNotSatisfiedException> result = StateManager.getInstance().CreateSellOrder(int.Parse(QuantityTextField.Text), float.Parse(ValueTextField.Text));

            MessageBox.Show(result.ToString());
        }
    }
}
