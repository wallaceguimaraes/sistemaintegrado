using System.Drawing;

namespace SistemaIntegrado
{
    partial class Mensagem
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
            this.btnNao = new SistemaIntegrado.Botao();
            this.btnSim = new SistemaIntegrado.Botao();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.gradientPanelMuda1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanelMuda1
            // 
            this.gradientPanelMuda1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.gradientPanelMuda1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(101)))), ((int)(((byte)(145)))));
            this.gradientPanelMuda1.Controls.Add(this.btnNao);
            this.gradientPanelMuda1.Controls.Add(this.btnSim);
            this.gradientPanelMuda1.Controls.Add(this.lblMensagem);
            this.gradientPanelMuda1.Location = new System.Drawing.Point(-5, 0);
            this.gradientPanelMuda1.Name = "gradientPanelMuda1";
            this.gradientPanelMuda1.Size = new System.Drawing.Size(384, 198);
            this.gradientPanelMuda1.TabIndex = 0;
            // 
            // btnNao
            // 
            this.btnNao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnNao.FlatAppearance.BorderSize = 0;
            this.btnNao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnNao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNao.ForeColor = System.Drawing.Color.White;
            this.btnNao.Location = new System.Drawing.Point(206, 135);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(75, 36);
            this.btnNao.TabIndex = 2;
            this.btnNao.Text = "Não";
            this.btnNao.UseVisualStyleBackColor = false;
            this.btnNao.Click += new System.EventHandler(this.btnNao_Click);
            // 
            // btnSim
            // 
            this.btnSim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.btnSim.FlatAppearance.BorderSize = 0;
            this.btnSim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.btnSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSim.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSim.ForeColor = System.Drawing.Color.White;
            this.btnSim.Location = new System.Drawing.Point(106, 135);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(75, 36);
            this.btnSim.TabIndex = 1;
            this.btnSim.Text = "Sim";
            this.btnSim.UseVisualStyleBackColor = false;
            this.btnSim.Click += new System.EventHandler(this.btnSim_Click);
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.BackColor = System.Drawing.Color.Transparent;
            this.lblMensagem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.ForeColor = System.Drawing.Color.White;
            this.lblMensagem.Location = new System.Drawing.Point(80, 64);
            this.lblMensagem.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(57, 21);
            this.lblMensagem.TabIndex = 0;
            this.lblMensagem.Text = "label1";
            // 
            // Mensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 198);
            this.Controls.Add(this.gradientPanelMuda1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mensagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensagem";
            this.Load += new System.EventHandler(this.Mensagem_Load);
            this.gradientPanelMuda1.ResumeLayout(false);
            this.gradientPanelMuda1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Util.GradientPanelMuda gradientPanelMuda1;
        private System.Windows.Forms.Label lblMensagem;
        private Botao btnNao;
        private Botao btnSim;
    }
}