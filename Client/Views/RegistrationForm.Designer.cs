namespace diginote_exchange_system.Views
{
    partial class RegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextField = new System.Windows.Forms.TextBox();
            this.nicknameTextField = new System.Windows.Forms.TextBox();
            this.passwordTextField = new System.Windows.Forms.TextBox();
            this.repeatPasswordTextField = new System.Windows.Forms.TextBox();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nickname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Repeat Passoword:";
            // 
            // nameTextField
            // 
            this.nameTextField.Location = new System.Drawing.Point(233, 116);
            this.nameTextField.Name = "nameTextField";
            this.nameTextField.Size = new System.Drawing.Size(231, 20);
            this.nameTextField.TabIndex = 4;
            // 
            // nicknameTextField
            // 
            this.nicknameTextField.Location = new System.Drawing.Point(233, 163);
            this.nicknameTextField.Name = "nicknameTextField";
            this.nicknameTextField.Size = new System.Drawing.Size(231, 20);
            this.nicknameTextField.TabIndex = 5;
            // 
            // passwordTextField
            // 
            this.passwordTextField.Location = new System.Drawing.Point(233, 210);
            this.passwordTextField.Name = "passwordTextField";
            this.passwordTextField.Size = new System.Drawing.Size(231, 20);
            this.passwordTextField.TabIndex = 6;
            // 
            // repeatPasswordTextField
            // 
            this.repeatPasswordTextField.Location = new System.Drawing.Point(233, 262);
            this.repeatPasswordTextField.Name = "repeatPasswordTextField";
            this.repeatPasswordTextField.Size = new System.Drawing.Size(231, 20);
            this.repeatPasswordTextField.TabIndex = 7;
            // 
            // createAccountButton
            // 
            this.createAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createAccountButton.Location = new System.Drawing.Point(233, 321);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(151, 29);
            this.createAccountButton.TabIndex = 8;
            this.createAccountButton.Text = "Create Account";
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 443);
            this.Controls.Add(this.createAccountButton);
            this.Controls.Add(this.repeatPasswordTextField);
            this.Controls.Add(this.passwordTextField);
            this.Controls.Add(this.nicknameTextField);
            this.Controls.Add(this.nameTextField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTextField;
        private System.Windows.Forms.TextBox nicknameTextField;
        private System.Windows.Forms.TextBox passwordTextField;
        private System.Windows.Forms.TextBox repeatPasswordTextField;
        private System.Windows.Forms.Button createAccountButton;
    }
}