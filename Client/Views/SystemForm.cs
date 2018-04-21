using Common;
using Common.Serializable;
using diginote_exchange_system.Views;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace diginote_exchange_system
{
    public partial class SystemForm : MaterialForm
    {
        public SystemForm()
        {
            InitializeComponent();
            Client.State.GetCurrentQuote();
            Client.State.QuoteUpdated += OnQuoteUpdated;
            Client.State.AvailableDiginotesUpdated += OnDiginotesUpdated;
            Client.State.PurchaseOrdersUpdated += OnPurchaseOrdersUpdated;
            Client.State.SellOrdersUpdated += OnSellOrdersUpdated;
        }

        private void OnPurchaseOrdersUpdated(object sender, PurchaseOrder[] updatedPurchaseOrders)
        {
            BindingList<PurchaseOrder> dataSource = new BindingList<PurchaseOrder>();
            foreach (PurchaseOrder el in updatedPurchaseOrders)
            {
                dataSource.Add(el);
            }
            PurchaseOrdersGridView.Invoke(new Action(() => PurchaseOrdersGridView.DataSource = dataSource));
        }

        private void OnSellOrdersUpdated(object sender, SellOrder[] updatedSellOrders)
        {
            BindingList<SellOrder> dataSource = new BindingList<SellOrder>();
            foreach (SellOrder el in updatedSellOrders)
            {
                dataSource.Add(el);
            }
            SellOrdersGridView.Invoke(new Action(() => SellOrdersGridView.DataSource = dataSource));
        }

        private void OnDiginotesUpdated(object sender, int diginotes)
        {
            DiginotesTextField.Invoke(new Action(() => DiginotesTextField.Text = diginotes.ToString()));
        }

        private void OnQuoteUpdated(object sender, float newQuote)
        {
            CurrentQuoteTextField.Invoke(new Action(() => CurrentQuoteTextField.Text = newQuote.ToString()));
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            Client.State.SignOut();
            Client.Forms.SystemForm.Hide();
            Client.Forms.AuthenticationForm.Show();
            SellOrdersGridView.DataSource = new BindingList<SellOrder>();
            PurchaseOrdersGridView.DataSource = new BindingList<PurchaseOrder>();
        }

        private void VisibilityChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Client.State.GetAvailableDiginotes();
                Client.State.GetUserIncompleteSellOrders();
                Client.State.GetUserIncompletePurchaseOrders();
                OnQuoteUpdated(this, Client.State.GetCurrentQuote());
            }
        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            OrderType orderType = PurchaseRadioButton.Checked ? OrderType.Purchase : OrderType.Sell;
            int quantity = decimal.ToInt32(DiginoteNumberNumericUpDown.Value);

            Tuple<Exception, OrderNotSatisfiedException> result =
                orderType == OrderType.Purchase
                ? Client.State.CreatePurchaseOrder(quantity)
                : Client.State.CreateSellOrder(quantity);

            if (result.Item1 == null && result.Item2 == null)
            {
                MessageBox.Show("Order placed successfully.");
            }
            else if (result.Item1 == null && result.Item2 != null)
            {
                MessageBox.Show(result.Item2.Quantity + " orders were not matched. Please select a new quote.");
                var form = new OrderNotSatisfiedForm(orderType, result.Item2.Quantity);
                form.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Error placing order.");
                Console.WriteLine(result);
            }

            // Client.State.GetAvailableDiginotes();
            //Client.State.GetUserIncompletePurchaseOrders();
            //Client.State.GetUserIncompleteSellOrders();
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            new HistoryForm().ShowDialog(this);
        }

        private void btnDeleteOrders_Click(object sender, EventArgs e)
        {
            int[] ordersId = new int[this.SellOrdersGridView.SelectedRows.Count];
            int i = 0;
            foreach (DataGridViewRow item in this.SellOrdersGridView.SelectedRows)
            {
                ordersId[i] = (int)item.Cells[0].Value;
                SellOrdersGridView.Rows.RemoveAt(item.Index);
            }

            MessageBox.Show(Client.State.DeleteSellOrders(ordersId));
        }

        private void btnDeletePurchaseOrders_Click(object sender, EventArgs e)
        {
            int[] ordersId = new int[this.PurchaseOrdersGridView.SelectedRows.Count];
            int i = 0;
            foreach (DataGridViewRow item in this.PurchaseOrdersGridView.SelectedRows)
            {
                ordersId[i] = (int)item.Cells[0].Value;
                PurchaseOrdersGridView.Rows.RemoveAt(item.Index);
            }

            MessageBox.Show(Client.State.DeletePurchaseOrders(ordersId));
        }

        private void btnUpdatePurchaseOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrder[] purchaseOrders = new PurchaseOrder[this.PurchaseOrdersGridView.SelectedRows.Count];
            int i = 0;
            foreach (DataGridViewRow item in this.PurchaseOrdersGridView.SelectedRows)
            {
                purchaseOrders[i] = new PurchaseOrder
                {
                    Id = (int)item.Cells[0].Value,
                    CreatedAt = (DateTime)item.Cells[1].Value,
                    Quote = (float)item.Cells[2].Value,
                    Status = (OrderStatus)item.Cells[3].Value,
                    CreatedById = (int)item.Cells[4].Value
                };
            }

            MessageBox.Show(Client.State.UpdatePurchaseOrders(purchaseOrders));
        }

        private void btnUpdateSellOrderstton1_Click(object sender, EventArgs e)
        {
            SellOrder[] sellOrders = new SellOrder[this.SellOrdersGridView.SelectedRows.Count];
            int i = 0;
            foreach (DataGridViewRow item in this.SellOrdersGridView.SelectedRows)
            {
                sellOrders[i] = new SellOrder
                {
                    Id = (int)item.Cells[0].Value,
                    CreatedAt = (DateTime)item.Cells[1].Value,
                    Quote = (float)item.Cells[2].Value,
                    Status = (OrderStatus)item.Cells[3].Value,
                    CreatedById = (int)item.Cells[4].Value,
                    DiginoteId = (int)item.Cells[5].Value
                };
            }

            MessageBox.Show(Client.State.UpdateSellOrders(sellOrders));
        }
    }
}
