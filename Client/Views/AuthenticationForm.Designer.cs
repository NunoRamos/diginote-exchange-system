namespace diginote_exchange_system
{
    partial class AuthenticationForm
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
            this.signInButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.signUpButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.nicknameTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.nicknameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.passwordLabel = new MaterialSkin.Controls.MaterialLabel();
            this.passwordTextField = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(228, 95);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(73, 57);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Diginote\r\nExchange\r\nSystem";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signInButton
            // 
            this.signInButton.AutoSize = true;
            this.signInButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.signInButton.Depth = 0;
            this.signInButton.Location = new System.Drawing.Point(170, 277);
            this.signInButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.signInButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.signInButton.Name = "signInButton";
            this.signInButton.Primary = false;
            this.signInButton.Size = new System.Drawing.Size(60, 36);
            this.signInButton.TabIndex = 3;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // signUpButton
            // 
            this.signUpButton.AutoSize = true;
            this.signUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.signUpButton.Depth = 0;
            this.signUpButton.Location = new System.Drawing.Point(297, 277);
            this.signUpButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.signUpButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Primary = false;
            this.signUpButton.Size = new System.Drawing.Size(64, 36);
            this.signUpButton.TabIndex = 4;
            this.signUpButton.Text = "Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // nicknameTextField
            // 
            this.nicknameTextField.Depth = 0;
            this.nicknameTextField.Hint = "";
            this.nicknameTextField.Location = new System.Drawing.Point(277, 199);
            this.nicknameTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.nicknameTextField.Name = "nicknameTextField";
            this.nicknameTextField.PasswordChar = '\0';
            this.nicknameTextField.SelectedText = "";
            this.nicknameTextField.SelectionLength = 0;
            this.nicknameTextField.SelectionStart = 0;
            this.nicknameTextField.Size = new System.Drawing.Size(112, 23);
            this.nicknameTextField.TabIndex = 1;
            this.nicknameTextField.UseSystemPasswordChar = false;
            // 
            // nicknameLabel
            // 
            this.nicknameLabel.AutoSize = true;
            this.nicknameLabel.Depth = 0;
            this.nicknameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.nicknameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nicknameLabel.Location = new System.Drawing.Point(166, 199);
            this.nicknameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.nicknameLabel.Name = "nicknameLabel";
            this.nicknameLabel.Size = new System.Drawing.Size(81, 19);
            this.nicknameLabel.TabIndex = 7;
            this.nicknameLabel.Text = "Nickname:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Depth = 0;
            this.passwordLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.passwordLabel.Location = new System.Drawing.Point(166, 228);
            this.passwordLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(79, 19);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password:";
            // 
            // passwordTextField
            // 
            this.passwordTextField.Depth = 0;
            this.passwordTextField.Hint = "";
            this.passwordTextField.Location = new System.Drawing.Point(277, 228);
            this.passwordTextField.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordTextField.Name = "passwordTextField";
            this.passwordTextField.PasswordChar = '\0';
            this.passwordTextField.SelectedText = "";
            this.passwordTextField.SelectionLength = 0;
            this.passwordTextField.SelectionStart = 0;
            this.passwordTextField.Size = new System.Drawing.Size(112, 23);
            this.passwordTextField.TabIndex = 2;
            this.passwordTextField.UseSystemPasswordChar = true;
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 443);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextField);
            this.Controls.Add(this.nicknameLabel);
            this.Controls.Add(this.nicknameTextField);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.signInButton);
            this.Name = "AuthenticationForm";
            this.Text = "Diginote Exchange System";
            this.Load += new System.EventHandler(this.AuthenticationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton signInButton;
        private MaterialSkin.Controls.MaterialFlatButton signUpButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField nicknameTextField;
        private MaterialSkin.Controls.MaterialLabel nicknameLabel;
        private MaterialSkin.Controls.MaterialLabel passwordLabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField passwordTextField;
    }
}

