﻿using Common;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace diginote_exchange_system.Views
{
    public partial class CreateSellOrderForm : MaterialForm
    {
        public CreateSellOrderForm()
        {
            InitializeComponent();
        }

        public FormManager FormManager { get; }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            Tuple<Exception, OrderNotSatisfiedException> result = Client.StateManager.CreateSellOrder(int.Parse(QuantityTextField.Text), float.Parse(ValueTextField.Text));

            MessageBox.Show(result.ToString());

            if (result.Item2 != null)
                FormManager.SellOrderNotSatisfiedForm.ShowDialog(this);
        }
    }
}