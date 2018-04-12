namespace diginote_exchange_system
{
    partial class SystemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.signOutButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.currentQuoteLabel = new MaterialSkin.Controls.MaterialLabel();
            this.CurrentQuoteTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.DiginotesTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SellRadioButton = new System.Windows.Forms.RadioButton();
            this.PurchaseRadioButton = new System.Windows.Forms.RadioButton();
            this.CreateOrderGroupBox = new System.Windows.Forms.GroupBox();
            this.PlaceOrderButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DiginoteNumberNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PurchaseOrdersGridView = new System.Windows.Forms.DataGridView();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.HistoryButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SellOrdersGridView = new System.Windows.Forms.DataGridView();
            this.btnDeleteSellOrders = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnUpdateOrders = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnDeletePurchaseOrders = new MaterialSkin.Controls.MaterialFlatButton();
            this.CreateOrderGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiginoteNumberNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrdersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellOrdersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // signOutButton
            // 
            this.signOutButton.AutoSize = true;
            this.signOutButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.signOutButton.Depth = 0;
            this.signOutButton.Location = new System.Drawing.Point(714, 73);
            this.signOutButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.signOutButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Primary = false;
            this.signOutButton.Size = new System.Drawing.Size(73, 36);
            this.signOutButton.TabIndex = 0;
            this.signOutButton.Text = "Sign Out";
            this.signOutButton.UseVisualStyleBackColor = true;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // currentQuoteLabel
            // 
            this.currentQuoteLabel.AutoSize = true;
            this.currentQuoteLabel.Depth = 0;
            this.currentQuoteLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.currentQuoteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.currentQuoteLabel.Location = new System.Drawing.Point(12, 122);
            this.currentQuoteLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.currentQuoteLabel.Name = "currentQuoteLabel";
            this.currentQuoteLabel.Size = new System.Drawing.Size(106, 19);
            this.currentQuoteLabel.TabIndex = 1;
            this.currentQuoteLabel.Text = "Current Quote:";
            // 
            // CurrentQuoteTextField
            // 
            this.CurrentQuoteTextField.Depth = 0;
            this.CurrentQuoteTextField.Enabled = false;
            this.CurrentQuoteTextField.Hint = "";
            this.CurrentQuoteTextField.Location = new System.Drawing.Point(124, 122);
            this.CurrentQuoteTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.CurrentQuoteTextField.Name = "CurrentQuoteTextField";
            this.CurrentQuoteTextField.PasswordChar = '\0';
            this.CurrentQuoteTextField.SelectedText = "";
            this.CurrentQuoteTextField.SelectionLength = 0;
            this.CurrentQuoteTextField.SelectionStart = 0;
            this.CurrentQuoteTextField.Size = new System.Drawing.Size(53, 23);
            this.CurrentQuoteTextField.TabIndex = 2;
            this.CurrentQuoteTextField.Text = "N/A";
            this.CurrentQuoteTextField.UseSystemPasswordChar = false;
            // 
            // DiginotesTextField
            // 
            this.DiginotesTextField.Depth = 0;
            this.DiginotesTextField.Enabled = false;
            this.DiginotesTextField.Hint = "";
            this.DiginotesTextField.Location = new System.Drawing.Point(124, 90);
            this.DiginotesTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.DiginotesTextField.Name = "DiginotesTextField";
            this.DiginotesTextField.PasswordChar = '\0';
            this.DiginotesTextField.SelectedText = "";
            this.DiginotesTextField.SelectionLength = 0;
            this.DiginotesTextField.SelectionStart = 0;
            this.DiginotesTextField.Size = new System.Drawing.Size(53, 23);
            this.DiginotesTextField.TabIndex = 4;
            this.DiginotesTextField.Text = "0";
            this.DiginotesTextField.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(41, 90);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(77, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Diginotes:";
            // 
            // SellRadioButton
            // 
            this.SellRadioButton.AutoSize = true;
            this.SellRadioButton.Checked = true;
            this.SellRadioButton.Location = new System.Drawing.Point(6, 19);
            this.SellRadioButton.Name = "SellRadioButton";
            this.SellRadioButton.Size = new System.Drawing.Size(42, 17);
            this.SellRadioButton.TabIndex = 8;
            this.SellRadioButton.TabStop = true;
            this.SellRadioButton.Text = "Sell";
            this.SellRadioButton.UseVisualStyleBackColor = true;
            // 
            // PurchaseRadioButton
            // 
            this.PurchaseRadioButton.AutoSize = true;
            this.PurchaseRadioButton.Location = new System.Drawing.Point(6, 42);
            this.PurchaseRadioButton.Name = "PurchaseRadioButton";
            this.PurchaseRadioButton.Size = new System.Drawing.Size(70, 17);
            this.PurchaseRadioButton.TabIndex = 9;
            this.PurchaseRadioButton.Text = "Purchase";
            this.PurchaseRadioButton.UseVisualStyleBackColor = true;
            // 
            // CreateOrderGroupBox
            // 
            this.CreateOrderGroupBox.Controls.Add(this.PlaceOrderButton);
            this.CreateOrderGroupBox.Controls.Add(this.label1);
            this.CreateOrderGroupBox.Controls.Add(this.DiginoteNumberNumericUpDown);
            this.CreateOrderGroupBox.Controls.Add(this.SellRadioButton);
            this.CreateOrderGroupBox.Controls.Add(this.PurchaseRadioButton);
            this.CreateOrderGroupBox.Location = new System.Drawing.Point(286, 81);
            this.CreateOrderGroupBox.Name = "CreateOrderGroupBox";
            this.CreateOrderGroupBox.Size = new System.Drawing.Size(317, 68);
            this.CreateOrderGroupBox.TabIndex = 10;
            this.CreateOrderGroupBox.TabStop = false;
            this.CreateOrderGroupBox.Text = "Create Order";
            // 
            // PlaceOrderButton
            // 
            this.PlaceOrderButton.AutoSize = true;
            this.PlaceOrderButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PlaceOrderButton.Depth = 0;
            this.PlaceOrderButton.Location = new System.Drawing.Point(256, 19);
            this.PlaceOrderButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.PlaceOrderButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.PlaceOrderButton.Name = "PlaceOrderButton";
            this.PlaceOrderButton.Primary = false;
            this.PlaceOrderButton.Size = new System.Drawing.Size(54, 36);
            this.PlaceOrderButton.TabIndex = 12;
            this.PlaceOrderButton.Text = "Place";
            this.PlaceOrderButton.UseVisualStyleBackColor = true;
            this.PlaceOrderButton.Click += new System.EventHandler(this.PlaceOrderButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "No. of Diginotes:";
            // 
            // DiginoteNumberNumericUpDown
            // 
            this.DiginoteNumberNumericUpDown.Location = new System.Drawing.Point(179, 29);
            this.DiginoteNumberNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.DiginoteNumberNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DiginoteNumberNumericUpDown.Name = "DiginoteNumberNumericUpDown";
            this.DiginoteNumberNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.DiginoteNumberNumericUpDown.TabIndex = 10;
            this.DiginoteNumberNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PurchaseOrdersGridView
            // 
            this.PurchaseOrdersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PurchaseOrdersGridView.Location = new System.Drawing.Point(414, 217);
            this.PurchaseOrdersGridView.Name = "PurchaseOrdersGridView";
            this.PurchaseOrdersGridView.Size = new System.Drawing.Size(374, 262);
            this.PurchaseOrdersGridView.TabIndex = 11;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(110, 195);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(161, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Incomplete Sell Orders";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(510, 195);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(198, 19);
            this.materialLabel3.TabIndex = 13;
            this.materialLabel3.Text = "Incomplete Purchase Orders";
            // 
            // HistoryButton
            // 
            this.HistoryButton.AutoSize = true;
            this.HistoryButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HistoryButton.Depth = 0;
            this.HistoryButton.Location = new System.Drawing.Point(718, 113);
            this.HistoryButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.HistoryButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Primary = false;
            this.HistoryButton.Size = new System.Drawing.Size(69, 36);
            this.HistoryButton.TabIndex = 14;
            this.HistoryButton.Text = "History";
            this.HistoryButton.UseVisualStyleBackColor = true;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // SellOrdersGridView
            // 
            this.SellOrdersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SellOrdersGridView.Location = new System.Drawing.Point(12, 217);
            this.SellOrdersGridView.Name = "SellOrdersGridView";
            this.SellOrdersGridView.Size = new System.Drawing.Size(384, 262);
            this.SellOrdersGridView.TabIndex = 7;
            // 
            // btnDeleteSellOrders
            // 
            this.btnDeleteSellOrders.AutoSize = true;
            this.btnDeleteSellOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteSellOrders.Depth = 0;
            this.btnDeleteSellOrders.Location = new System.Drawing.Point(286, 488);
            this.btnDeleteSellOrders.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeleteSellOrders.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeleteSellOrders.Name = "btnDeleteSellOrders";
            this.btnDeleteSellOrders.Primary = false;
            this.btnDeleteSellOrders.Size = new System.Drawing.Size(94, 36);
            this.btnDeleteSellOrders.TabIndex = 15;
            this.btnDeleteSellOrders.Text = "Delete Sell";
            this.btnDeleteSellOrders.UseVisualStyleBackColor = true;
            this.btnDeleteSellOrders.Click += new System.EventHandler(this.btnDeleteOrders_Click);
            // 
            // btnUpdateOrders
            // 
            this.btnUpdateOrders.AutoSize = true;
            this.btnUpdateOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateOrders.Depth = 0;
            this.btnUpdateOrders.Location = new System.Drawing.Point(556, 488);
            this.btnUpdateOrders.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdateOrders.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdateOrders.Name = "btnUpdateOrders";
            this.btnUpdateOrders.Primary = false;
            this.btnUpdateOrders.Size = new System.Drawing.Size(64, 36);
            this.btnUpdateOrders.TabIndex = 17;
            this.btnUpdateOrders.Text = "UPDATE";
            this.btnUpdateOrders.UseVisualStyleBackColor = true;
            this.btnUpdateOrders.Click += new System.EventHandler(this.btnUpdateOrders_Click);
            // 
            // btnDeletePurchaseOrders
            // 
            this.btnDeletePurchaseOrders.AutoSize = true;
            this.btnDeletePurchaseOrders.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeletePurchaseOrders.Depth = 0;
            this.btnDeletePurchaseOrders.Location = new System.Drawing.Point(414, 488);
            this.btnDeletePurchaseOrders.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeletePurchaseOrders.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeletePurchaseOrders.Name = "btnDeletePurchaseOrders";
            this.btnDeletePurchaseOrders.Primary = false;
            this.btnDeletePurchaseOrders.Size = new System.Drawing.Size(134, 36);
            this.btnDeletePurchaseOrders.TabIndex = 18;
            this.btnDeletePurchaseOrders.Text = "Delete Purchase";
            this.btnDeletePurchaseOrders.UseVisualStyleBackColor = true;
            this.btnDeletePurchaseOrders.Click += new System.EventHandler(this.btnDeletePurchaseOrders_Click);
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.btnDeletePurchaseOrders);
            this.Controls.Add(this.btnUpdateOrders);
            this.Controls.Add(this.btnDeleteSellOrders);
            this.Controls.Add(this.HistoryButton);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.PurchaseOrdersGridView);
            this.Controls.Add(this.CreateOrderGroupBox);
            this.Controls.Add(this.SellOrdersGridView);
            this.Controls.Add(this.DiginotesTextField);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.CurrentQuoteTextField);
            this.Controls.Add(this.currentQuoteLabel);
            this.Controls.Add(this.signOutButton);
            this.Name = "SystemForm";
            this.Text = "Diginote Exchange System";
            this.Shown += new System.EventHandler(this.SystemForm_Shown);
            this.CreateOrderGroupBox.ResumeLayout(false);
            this.CreateOrderGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiginoteNumberNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseOrdersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SellOrdersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton signOutButton;
        private MaterialSkin.Controls.MaterialLabel currentQuoteLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField CurrentQuoteTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField DiginotesTextField;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.RadioButton SellRadioButton;
        private System.Windows.Forms.RadioButton PurchaseRadioButton;
        private System.Windows.Forms.GroupBox CreateOrderGroupBox;
        private MaterialSkin.Controls.MaterialFlatButton PlaceOrderButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DiginoteNumberNumericUpDown;
        private System.Windows.Forms.DataGridView PurchaseOrdersGridView;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialFlatButton HistoryButton;
        private System.Windows.Forms.DataGridView SellOrdersGridView;
        private MaterialSkin.Controls.MaterialFlatButton btnDeleteSellOrders;
        private MaterialSkin.Controls.MaterialFlatButton btnUpdateOrders;
        private MaterialSkin.Controls.MaterialFlatButton btnDeletePurchaseOrders;
    }
}