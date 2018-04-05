﻿namespace diginote_exchange_system.Views
{
    partial class CreateSellOrderForm
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
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.QuantityTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ValueTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
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
            this.materialLabel1.Location = new System.Drawing.Point(78, 157);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Quantity:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(95, 193);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(51, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Value:";
            // 
            // QuantityTextField
            // 
            this.QuantityTextField.Depth = 0;
            this.QuantityTextField.Hint = "";
            this.QuantityTextField.Location = new System.Drawing.Point(152, 157);
            this.QuantityTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.QuantityTextField.Name = "QuantityTextField";
            this.QuantityTextField.PasswordChar = '\0';
            this.QuantityTextField.SelectedText = "";
            this.QuantityTextField.SelectionLength = 0;
            this.QuantityTextField.SelectionStart = 0;
            this.QuantityTextField.Size = new System.Drawing.Size(102, 23);
            this.QuantityTextField.TabIndex = 2;
            this.QuantityTextField.UseSystemPasswordChar = false;
            // 
            // ValueTextField
            // 
            this.ValueTextField.Depth = 0;
            this.ValueTextField.Hint = "";
            this.ValueTextField.Location = new System.Drawing.Point(153, 188);
            this.ValueTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.ValueTextField.Name = "ValueTextField";
            this.ValueTextField.PasswordChar = '\0';
            this.ValueTextField.SelectedText = "";
            this.ValueTextField.SelectionLength = 0;
            this.ValueTextField.SelectionStart = 0;
            this.ValueTextField.Size = new System.Drawing.Size(101, 23);
            this.ValueTextField.TabIndex = 3;
            this.ValueTextField.UseSystemPasswordChar = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.AutoSize = true;
            this.ConfirmButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConfirmButton.Depth = 0;
            this.ConfirmButton.Location = new System.Drawing.Point(99, 263);
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
            this.BackButton.Location = new System.Drawing.Point(187, 263);
            this.BackButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BackButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.BackButton.Name = "BackButton";
            this.BackButton.Primary = false;
            this.BackButton.Size = new System.Drawing.Size(47, 36);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CreateSellOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ValueTextField);
            this.Controls.Add(this.QuantityTextField);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Name = "CreateSellOrderForm";
            this.Text = "Create Sell Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField QuantityTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField ValueTextField;
        private MaterialSkin.Controls.MaterialFlatButton ConfirmButton;
        private MaterialSkin.Controls.MaterialFlatButton BackButton;
    }
}