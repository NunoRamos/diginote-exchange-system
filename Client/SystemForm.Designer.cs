﻿namespace diginote_exchange_system
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
            this.currentQuoteTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
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
            // currentQuoteTextField
            // 
            this.currentQuoteTextField.Depth = 0;
            this.currentQuoteTextField.Enabled = false;
            this.currentQuoteTextField.Hint = "";
            this.currentQuoteTextField.Location = new System.Drawing.Point(124, 122);
            this.currentQuoteTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.currentQuoteTextField.Name = "currentQuoteTextField";
            this.currentQuoteTextField.PasswordChar = '\0';
            this.currentQuoteTextField.SelectedText = "";
            this.currentQuoteTextField.SelectionLength = 0;
            this.currentQuoteTextField.SelectionStart = 0;
            this.currentQuoteTextField.Size = new System.Drawing.Size(53, 23);
            this.currentQuoteTextField.TabIndex = 2;
            this.currentQuoteTextField.Text = "1.00";
            this.currentQuoteTextField.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Enabled = false;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(124, 90);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(53, 23);
            this.materialSingleLineTextField1.TabIndex = 4;
            this.materialSingleLineTextField1.Text = "12";
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
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
            // SystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialSingleLineTextField1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.currentQuoteTextField);
            this.Controls.Add(this.currentQuoteLabel);
            this.Controls.Add(this.signOutButton);
            this.Name = "SystemForm";
            this.Text = "Diginote Exchange System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton signOutButton;
        private MaterialSkin.Controls.MaterialLabel currentQuoteLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField currentQuoteTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}