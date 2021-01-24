using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Project
{
    public partial class LogIn : Form
    {
        MW_Admin MW_A;
        private int Pre_Status =1 ; 
        private DBConnect Connect;

        public LogIn()
        {
            InitializeComponent();
            Connect = new DBConnect();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Pre_Status = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Pre_Status = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Pre_Status = 1;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string UID, PWD;
            if (Pre_Status!=0)
            {
                UID = textBox1.Text;
                PWD = textBox2.Text;
                if ((UID.Length == 0) || (PWD.Length == 0)) 
                    MessageBox.Show("Имеются пустые поля");
                else if (Connect.TryConnect(UID, PWD, Pre_Status))
                {
                    MW_A = new MW_Admin();
                    MW_A.Show();
                    this.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Выберите тип пользователя");
            }

            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }


    }
}
