namespace SistemaIntegrado.Util
{
    partial class Informa
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
            this.gradientPanelMuda1 = new SistemaIntegrado.Util.GradientPanelMuda();
            this.btnOk = new SistemaIntegrado.Botao();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.gradientPanelMuda1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanelMuda1
            // 
            this.gradientPanelMuda1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.gradientPanelMuda1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(101)))), ((int)(((byte)(145)))));
            this.gradientPanelMuda1.Controls.Add(this.btnOk);
            this.gradientPanelMuda1.Controls.Add(this.lblMensagem);
            this.gradientPanelMuda1.Location = new System.Drawing.Point(-8, -20);
            this.gradientPanelMuda1.Name = "gradientPanelMuda1";
            this.gradientPanelMuda1.Size = new System.Drawing.Size(384, 198);
            this.gradientPanelMuda1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(156, 130);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 36);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnNao_Click);
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.BackColor = System.Drawing.Color.Transparent;
            this.lblMensagem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.White;
            this.lblMensagem.Location = new System.Drawing.Point(82, 64);
            this.lblMensagem.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(57, 21);
            this.lblMensagem.TabIndex = 0;
            this.lblMensagem.Text = "label1";
            // 
            // Informa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 159);
            this.Controls.Add(this.gradientPanelMuda1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Informa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informa";
            this.gradientPanelMuda1.ResumeLayout(false);
            this.gradientPanelMuda1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanelMuda gradientPanelMuda1;
        private Botao btnOk;
        private System.Windows.Forms.Label lblMensagem;
    }
}