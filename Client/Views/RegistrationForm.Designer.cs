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
            this.errorBoxLabel = new System.Windows.Forms.Label();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.nameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.nicknameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.passwordTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.repeatPasswordTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.createAccountButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // errorBoxLabel
            // 
            this.errorBoxLabel.AutoSize = true;
            this.errorBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorBoxLabel.Location = new System.Drawing.Point(233, 305);
            this.errorBoxLabel.Name = "errorBoxLabel";
            this.errorBoxLabel.Size = new System.Drawing.Size(0, 18);
            this.errorBoxLabel.TabIndex = 10;
            this.errorBoxLabel.Visible = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(162, 115);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(53, 19);
            this.materialLabel1.TabIndex = 11;
            this.materialLabel1.Text = "Name:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(136, 163);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(81, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Nickname:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(136, 211);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(79, 19);
            this.materialLabel3.TabIndex = 13;
            this.materialLabel3.Text = "Password:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(87, 262);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(129, 19);
            this.materialLabel4.TabIndex = 14;
            this.materialLabel4.Text = "Repeat Password:";
            // 
            // nameTextField
            // 
            this.nameTextField.Depth = 0;
            this.nameTextField.Hint = "";
            this.nameTextField.Location = new System.Drawing.Point(233, 111);
            this.nameTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.nameTextField.Name = "nameTextField";
            this.nameTextField.PasswordChar = '\0';
            this.nameTextField.SelectedText = "";
            this.nameTextField.SelectionLength = 0;
            this.nameTextField.SelectionStart = 0;
            this.nameTextField.Size = new System.Drawing.Size(231, 23);
            this.nameTextField.TabIndex = 15;
            this.nameTextField.UseSystemPasswordChar = false;
            // 
            // nicknameTextField
            // 
            this.nicknameTextField.Depth = 0;
            this.nicknameTextField.Hint = "";
            this.nicknameTextField.Location = new System.Drawing.Point(233, 163);
            this.nicknameTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.nicknameTextField.Name = "nicknameTextField";
            this.nicknameTextField.PasswordChar = '\0';
            this.nicknameTextField.SelectedText = "";
            this.nicknameTextField.SelectionLength = 0;
            this.nicknameTextField.SelectionStart = 0;
            this.nicknameTextField.Size = new System.Drawing.Size(231, 23);
            this.nicknameTextField.TabIndex = 16;
            this.nicknameTextField.UseSystemPasswordChar = false;
            // 
            // passwordTextField
            // 
            this.passwordTextField.Depth = 0;
            this.passwordTextField.Hint = "";
            this.passwordTextField.Location = new System.Drawing.Point(233, 211);
            this.passwordTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordTextField.Name = "passwordTextField";
            this.passwordTextField.PasswordChar = '\0';
            this.passwordTextField.SelectedText = "";
            this.passwordTextField.SelectionLength = 0;
            this.passwordTextField.SelectionStart = 0;
            this.passwordTextField.Size = new System.Drawing.Size(231, 23);
            this.passwordTextField.TabIndex = 17;
            this.passwordTextField.UseSystemPasswordChar = true;
            // 
            // repeatPasswordTextField
            // 
            this.repeatPasswordTextField.Depth = 0;
            this.repeatPasswordTextField.Hint = "";
            this.repeatPasswordTextField.Location = new System.Drawing.Point(233, 262);
            this.repeatPasswordTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.repeatPasswordTextField.Name = "repeatPasswordTextField";
            this.repeatPasswordTextField.PasswordChar = '\0';
            this.repeatPasswordTextField.SelectedText = "";
            this.repeatPasswordTextField.SelectionLength = 0;
            this.repeatPasswordTextField.SelectionStart = 0;
            this.repeatPasswordTextField.Size = new System.Drawing.Size(231, 23);
            this.repeatPasswordTextField.TabIndex = 18;
            this.repeatPasswordTextField.UseSystemPasswordChar = true;
            // 
            // createAccountButton
            // 
            this.createAccountButton.AutoSize = true;
            this.createAccountButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createAccountButton.Depth = 0;
            this.createAccountButton.Location = new System.Drawing.Point(263, 343);
            this.createAccountButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.createAccountButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Primary = false;
            this.createAccountButton.Size = new System.Drawing.Size(64, 36);
            this.createAccountButton.TabIndex = 19;
            this.createAccountButton.Text = "Sign Up";
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
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
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.errorBoxLabel);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label errorBoxLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField nameTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField nicknameTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField passwordTextField;
        private MaterialSkin.Controls.MaterialSingleLineTextField repeatPasswordTextField;
        private MaterialSkin.Controls.MaterialFlatButton createAccountButton;
    }
}