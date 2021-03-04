using AcessoControle.Controller;
using AcessoControle.Model.Entity;
using SistemaIntegrado.Util;
using SistemaIntegrado.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIntegrado
{
    public partial class ViewLogin : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
     (
         int nLeftRect,     // x-coordinate of upper-left corner
         int nTopRect,      // y-coordinate of upper-left corner
         int nRightRect,    // x-coordinate of lower-right corner
         int nBottomRect,   // y-coordinate of lower-right corner
         int nWidthEllipse, // height of ellipse
         int nHeightEllipse // width of ellipse
     );


        public ViewLogin()
        {



            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));



        }

        int progresso = 0;

        private void button_entrar_Click(object sender, EventArgs e)
        {
            barra.Visible = true;


          /*  
            Thread timerThread;
            timerThread = new Thread(new ThreadStart(ThreadProc));
            timerThread.IsBackground = true;
            timerThread.Start();
        */    

            MoverProgressBar();

            LoginController loginController = new LoginController();

            Usuario usuario;

            usuario = loginController.ValidaUsuario(textBox_usuario.Text, textBox_senha.Text);

            if (usuario != null)
            {

                // MessageBox.Show("Usuário logado!");

                Sessao sess = Sessao.getInstance();
                sess.setUsuario(usuario);

                Informa.Mostrar("Usuário logado com sucesso!", "Ok");


                if (barra.Value == 100)
                {
                    ViewIndex index = new ViewIndex();
                    index.Show();
                    this.Hide();         //fecha a janela após completar os 100%
                }
                

            }
            else
            {
                Informa.Mostrar("Usuário ou senha incorretos!", "Ok");
                barra.Visible = false;
                barra.Value = 0;
            }


        }

     
        /*
        public void ThreadProc()
        {
            try
            {
                MethodInvoker mi = new MethodInvoker(this.MoverProgressBar);
                while (true)
                {
                    this.BeginInvoke(mi);
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {

            }
         
            
            }
        
        
        private void UpdateProgress()
        {
            if (barra.Value == barra.Maximum)
            {
                barra.Value = barra.Minimum;
            }
            barra.PerformStep();
        }
        */

        

        private void MoverProgressBar()
        {          
         

            for (int i = 0; i <= barra.Maximum; i++)
            {
                barra.Value = i;
                Thread.Sleep(40);
            }

        }
    

        private void Abrir()
        {
            ViewIndex index = new ViewIndex();
            index.Show();
            //this.Hide();
        }


        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gradientPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button_sair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ViewLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
