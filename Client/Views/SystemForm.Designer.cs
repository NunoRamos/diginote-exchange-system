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
            this.CreateSellOrderButton = new MaterialSkin.Controls.MaterialFlatButton();
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
            this.DiginotesTextField.Text = "12";
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
            // CreateSellOrderButton
            // 
            this.CreateSellOrderButton.AutoSize = true;
            this.CreateSellOrderButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateSellOrderButton.Depth = 0;
            this.CreateSellOrderButton.Location = new System.Drawing.Point(16, 399);
            this.CreateSellOrderButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateSellOrderButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateSellOrderButton.Name = "CreateSellOrderButton";
            this.CreateSellOrderButton.Primary = false;
            this.CreateSellOrderButton.Size = new System.Drawing.Size(144, 36);
            this.CreateSellOrderButton.TabIndex = 5;
            this.CreateSellOrderButton.Text = "Create Sell Order";
            this.CreateSellOrderButton.UseVisualStyleBackColor = true;
            this.CreateSellOrderButton.Click += new System.EventHandler(this.CreateSellOrderButton_Click);
            // 
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateSellOrderButton);
            this.Controls.Add(this.DiginotesTextField);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.CurrentQuoteTextField);
            this.Controls.Add(this.currentQuoteLabel);
            this.Controls.Add(this.signOutButton);
            this.Name = "SystemForm";
            this.Text = "Diginote Exchange System";
            this.Shown += new System.EventHandler(this.SystemForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton signOutButton;
        private MaterialSkin.Controls.MaterialLabel currentQuoteLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField CurrentQuoteTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField DiginotesTextField;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton CreateSellOrderButton;
    }
}