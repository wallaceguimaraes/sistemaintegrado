using System.Drawing;

namespace SistemaIntegrado
{
    partial class ViewLogin
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewLogin));
            this.textBox_usuario = new System.Windows.Forms.TextBox();
            this.textBox_senha = new System.Windows.Forms.TextBox();
            this.button_entrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barra = new SistemaIntegrado.Barra();
            this.button_sair = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_usuario
            // 
            this.textBox_usuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBox_usuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_usuario.ForeColor = System.Drawing.Color.White;
            this.textBox_usuario.Location = new System.Drawing.Point(85, 173);
            this.textBox_usuario.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_usuario.Name = "textBox_usuario";
            this.textBox_usuario.Size = new System.Drawing.Size(182, 15);
            this.textBox_usuario.TabIndex = 5;
            // 
            // textBox_senha
            // 
            this.textBox_senha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBox_senha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_senha.ForeColor = System.Drawing.Color.White;
            this.textBox_senha.Location = new System.Drawing.Point(85, 225);
            this.textBox_senha.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_senha.Name = "textBox_senha";
            this.textBox_senha.Size = new System.Drawing.Size(182, 15);
            this.textBox_senha.TabIndex = 7;
            this.textBox_senha.UseSystemPasswordChar = true;
            // 
            // button_entrar
            // 
            this.button_entrar.BackColor = System.Drawing.Color.Transparent;
            this.button_entrar.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.button_entrar.FlatAppearance.BorderSize = 0;
            this.button_entrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_entrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_entrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_entrar.ForeColor = System.Drawing.Color.Transparent;
            this.button_entrar.Location = new System.Drawing.Point(139, 259);
            this.button_entrar.Margin = new System.Windows.Forms.Padding(4);
            this.button_entrar.Name = "button_entrar";
            this.button_entrar.Size = new System.Drawing.Size(75, 16);
            this.button_entrar.TabIndex = 9;
            this.button_entrar.UseVisualStyleBackColor = false;
            this.button_entrar.Click += new System.EventHandler(this.button_entrar_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.barra);
            this.panel1.Controls.Add(this.button_sair);
            this.panel1.Controls.Add(this.textBox_usuario);
            this.panel1.Controls.Add(this.textBox_senha);
            this.panel1.Controls.Add(this.button_entrar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 430);
            this.panel1.TabIndex = 10;
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.barra.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.barra.Location = new System.Drawing.Point(7, 417);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(335, 10);
            this.barra.TabIndex = 12;
            this.barra.Visible = false;
            // 
            // button_sair
            // 
            this.button_sair.BackColor = System.Drawing.Color.Transparent;
            this.button_sair.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.button_sair.FlatAppearance.BorderSize = 0;
            this.button_sair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_sair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sair.ForeColor = System.Drawing.Color.Transparent;
            this.button_sair.Location = new System.Drawing.Point(309, 12);
            this.button_sair.Name = "button_sair";
            this.button_sair.Size = new System.Drawing.Size(25, 20);
            this.button_sair.TabIndex = 10;
            this.button_sair.UseVisualStyleBackColor = false;
            this.button_sair.Click += new System.EventHandler(this.button_sair_Click);
            // 
            // ViewLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(350, 430);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.ViewLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_entrar;
        private System.Windows.Forms.TextBox textBox_senha;
        private System.Windows.Forms.TextBox textBox_usuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_sair;
        private Barra barra;
    }
}

