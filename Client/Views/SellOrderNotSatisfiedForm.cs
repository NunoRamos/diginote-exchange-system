using MaterialSkin.Controls;

namespace diginote_exchange_system.Views
{
    public partial class SellOrderNotSatisfiedForm : MaterialForm
    {
        public SellOrderNotSatisfiedForm()
        {
            InitializeComponent();
            Client.StateManager.Server.OnQuoteUpdated += OnQuoteUpdated;
        }

        private void OnQuoteUpdated(object sender, float? newQuote)
        {
            CurrentQuoteTextField.Text = newQuote == null ? "N/A" : newQuote.ToString();
        }

        private void BackButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            float value = float.Parse(ValueTextField.Text);

        }
    }
}
