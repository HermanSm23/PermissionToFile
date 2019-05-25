namespace PermissionToFile2._0
{
    partial class LoginMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginMenu));
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.btnLoginJSON = new System.Windows.Forms.Button();
            this.loginPasswordError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogInBinary = new System.Windows.Forms.Button();
            this.btnLogInXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(306, 194);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '●';
            this.passwordBox.Size = new System.Drawing.Size(253, 26);
            this.passwordBox.TabIndex = 0;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(306, 127);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(253, 26);
            this.usernameBox.TabIndex = 1;
            // 
            // btnLoginJSON
            // 
            this.btnLoginJSON.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoginJSON.Location = new System.Drawing.Point(12, 277);
            this.btnLoginJSON.Name = "btnLoginJSON";
            this.btnLoginJSON.Size = new System.Drawing.Size(231, 136);
            this.btnLoginJSON.TabIndex = 2;
            this.btnLoginJSON.Text = "Ввійти в систему завантаживши дані з JSON";
            this.btnLoginJSON.UseVisualStyleBackColor = true;
            this.btnLoginJSON.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // loginPasswordError
            // 
            this.loginPasswordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginPasswordError.Location = new System.Drawing.Point(194, 56);
            this.loginPasswordError.Name = "loginPasswordError";
            this.loginPasswordError.Size = new System.Drawing.Size(451, 49);
            this.loginPasswordError.TabIndex = 3;
            this.loginPasswordError.Text = "Неправильний логін або пароль";
            this.loginPasswordError.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(220, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Логін:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(195, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль:";
            // 
            // btnLogInBinary
            // 
            this.btnLogInBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogInBinary.Location = new System.Drawing.Point(563, 277);
            this.btnLogInBinary.Name = "btnLogInBinary";
            this.btnLogInBinary.Size = new System.Drawing.Size(232, 136);
            this.btnLogInBinary.TabIndex = 7;
            this.btnLogInBinary.Text = "Ввійти в систему завантаживши дані з Binary";
            this.btnLogInBinary.UseVisualStyleBackColor = true;
            this.btnLogInBinary.Click += new System.EventHandler(this.btnLogInBinary_Click);
            // 
            // btnLogInXML
            // 
            this.btnLogInXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogInXML.Location = new System.Drawing.Point(290, 277);
            this.btnLogInXML.Name = "btnLogInXML";
            this.btnLogInXML.Size = new System.Drawing.Size(232, 136);
            this.btnLogInXML.TabIndex = 8;
            this.btnLogInXML.Text = "Ввійти в систему завантаживши дані з XML";
            this.btnLogInXML.UseVisualStyleBackColor = true;
            this.btnLogInXML.Click += new System.EventHandler(this.btnLogInXML_Click);
            // 
            // LoginMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 542);
            this.Controls.Add(this.btnLogInXML);
            this.Controls.Add(this.btnLogInBinary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginPasswordError);
            this.Controls.Add(this.btnLoginJSON);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.passwordBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вхід в систему";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Button btnLoginJSON;
        private System.Windows.Forms.Label loginPasswordError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogInBinary;
        private System.Windows.Forms.Button btnLogInXML;
    }
}

