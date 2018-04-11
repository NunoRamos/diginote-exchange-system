using Common.Serializable;
using MaterialSkin.Controls;
using System.Data;

namespace diginote_exchange_system.Views
{
    public partial class HistoryForm : MaterialForm
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, System.EventArgs e)
        {
            Transaction[] transactions = Client.State.GetTransactions();
            TransactionsDataGridView.DataSource = transactions;
        }
    }
}
