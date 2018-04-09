namespace diginote_exchange_system.Views
{
    partial class SellOrderNotSatisfiedForm
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.CurrentQuoteTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.DiginotesLeftTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ConfirmButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.BackButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(49, 107);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(106, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Current Quote:";
            // 
            // CurrentQuoteTextField
            // 
            this.CurrentQuoteTextField.Depth = 0;
            this.CurrentQuoteTextField.Enabled = false;
            this.CurrentQuoteTextField.Hint = "";
            this.CurrentQuoteTextField.Location = new System.Drawing.Point(161, 107);
            this.CurrentQuoteTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.CurrentQuoteTextField.Name = "CurrentQuoteTextField";
            this.CurrentQuoteTextField.PasswordChar = '\0';
            this.CurrentQuoteTextField.SelectedText = "";
            this.CurrentQuoteTextField.SelectionLength = 0;
            this.CurrentQuoteTextField.SelectionStart = 0;
            this.CurrentQuoteTextField.Size = new System.Drawing.Size(75, 23);
            this.CurrentQuoteTextField.TabIndex = 2;
            this.CurrentQuoteTextField.TabStop = false;
            this.CurrentQuoteTextField.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(48, 153);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(107, 19);
            this.materialLabel3.TabIndex = 3;
            this.materialLabel3.Text = "Diginotes Left:";
            // 
            // DiginotesLeftTextField
            // 
            this.DiginotesLeftTextField.Depth = 0;
            this.DiginotesLeftTextField.Enabled = false;
            this.DiginotesLeftTextField.Hint = "";
            this.DiginotesLeftTextField.Location = new System.Drawing.Point(161, 153);
            this.DiginotesLeftTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.DiginotesLeftTextField.Name = "DiginotesLeftTextField";
            this.DiginotesLeftTextField.PasswordChar = '\0';
            this.DiginotesLeftTextField.SelectedText = "";
            this.DiginotesLeftTextField.SelectionLength = 0;
            this.DiginotesLeftTextField.SelectionStart = 0;
            this.DiginotesLeftTextField.Size = new System.Drawing.Size(75, 23);
            this.DiginotesLeftTextField.TabIndex = 1;
            this.DiginotesLeftTextField.UseSystemPasswordChar = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.AutoSize = true;
            this.ConfirmButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConfirmButton.Depth = 0;
            this.ConfirmButton.Location = new System.Drawing.Point(64, 206);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ConfirmButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Primary = false;
            this.ConfirmButton.Size = new System.Drawing.Size(72, 36);
            this.ConfirmButton.TabIndex = 4;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.AutoSize = true;
            this.BackButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackButton.Depth = 0;
            this.BackButton.Location = new System.Drawing.Point(152, 206);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackButton.Name = "BackButton";
            this.BackButton.Primary = false;
            this.BackButton.Size = new System.Drawing.Size(64, 36);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Cancel";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SellOrderNotSatisfiedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 287);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.DiginotesLeftTextField);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.CurrentQuoteTextField);
            this.Controls.Add(this.materialLabel1);
            this.Name = "SellOrderNotSatisfiedForm";
            this.Text = "Sell Order Not Satisfied";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField CurrentQuoteTextField;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField DiginotesLeftTextField;
        private MaterialSkin.Controls.MaterialFlatButton ConfirmButton;
        private MaterialSkin.Controls.MaterialFlatButton BackButton;
    }
}