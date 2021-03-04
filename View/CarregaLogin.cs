using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIntegrado.View
{
    public partial class CarregaLogin : Form
    {
        public CarregaLogin()
        {
            InitializeComponent();
            //backgroundWorkerSplash.RunWorkerAsync();
           // label1.Text = "";

        }



        private void backgroundWorkerSplash_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                Thread.Sleep(2000);
            }
            catch (Exception errsplash)
            {
                MessageBox.Show("Erro\n" + errsplash.ToString());
                this.Close();
            }
        }

        /*
        private void backgroundWorkerSplash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                this.Visible = false;
                login.ShowDialog();

            }
            catch (Exception errsplash)
            {
                MessageBox.Show("Erro\n" + errsplash.ToString());
                this.Close();
            }

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Aguarde. . .\nPowered by Wallace Guimarães And Emanuel Teles®";
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        */
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
