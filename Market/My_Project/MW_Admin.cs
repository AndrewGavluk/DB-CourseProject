using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

namespace My_Project
{
    
    public partial class MW_Admin : Form
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        MySqlDataAdapter MSDA;
        MySqlCommand cmd;


        static string server = "localhost";
        static string database = "trade_platform";
        static string uid = "root";
        static string password = "";
        static string connectionString = ("SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";");
        private string[] MESSAGES;
        int MESSAGES_Q;
        public MW_Admin()
        {
            InitializeComponent();
            MESSAGES_Q = 6;
            MESSAGES = new string[MESSAGES_Q];
            MESSAGES[0] = "Ошибочный запрос";
            MESSAGES[1] = "Ошибка полей ввода";
            MESSAGES[2] = "Ошибка чтения БД";
            MESSAGES[3] = "Элемент был удачно добавлен";
            MESSAGES[4] = "Элемент был удачно изменён";
            MESSAGES[5] = "Элемент был удачно удалён";

            //dataGridView1
            #region
                dataGridView1.ColumnCount = 12;
                dataGridView1.Columns[0].Name = "Ид. Пользователя";
                dataGridView1.Columns[1].Name = "Пароль";
                dataGridView1.Columns[2].Name = "Ид. Брокера";
                dataGridView1.Columns[3].Name = "Фамилия";
                dataGridView1.Columns[4].Name = "Имя";
                dataGridView1.Columns[5].Name = "Отчество";
                dataGridView1.Columns[6].Name = "Дата рождения";
                dataGridView1.Columns[7].Name = "Серия паспорт";
                dataGridView1.Columns[8].Name = "Номер Паспорта";
                dataGridView1.Columns[9].Name = "Код подразделения";
                dataGridView1.Columns[10].Name = "Название банка";
                dataGridView1.Columns[11].Name = "Код счета в банке";
                Update_dataGridView1();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;

            #endregion

            //dataGridView2
            #region
                dataGridView2.ColumnCount = 11;
                dataGridView2.Columns[0].Name = "Ид. брокера";
                dataGridView2.Columns[1].Name = "Пароль";
                dataGridView2.Columns[2].Name = "Ид. aдмин";
                dataGridView2.Columns[3].Name = "Лицензия брокера (ЛБ)";
                dataGridView2.Columns[4].Name = "Серия ЛБ";
                dataGridView2.Columns[5].Name = "Номер ЛБ";
                dataGridView2.Columns[6].Name = "Дата  ЛБ";
                dataGridView2.Columns[7].Name = "Фамилия брокера";
                dataGridView2.Columns[8].Name = "Имя брокера";
                dataGridView2.Columns[9].Name = "Отчество брокера";
                dataGridView2.Columns[10].Name = "Дата рождения брокера";
                Update_dataGridView2();

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
            #endregion

            //dataGridView3
            #region
                dataGridView3.ColumnCount = 9;
                dataGridView3.Columns[0].Name = "Ид. счёта";
                dataGridView3.Columns[1].Name = "Пароль";
                dataGridView3.Columns[2].Name = "Ид. трейдера";
                dataGridView3.Columns[3].Name = "Фамилия трейдера";
                dataGridView3.Columns[4].Name = "Имя трейдера";
                dataGridView3.Columns[5].Name = "Отчество трейдера";
                dataGridView3.Columns[6].Name = "Тип Продукта";
                dataGridView3.Columns[7].Name = "Название Продукта";
                dataGridView3.Columns[8].Name = "Количество";
                Update_dataGridView3();

                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView3.MultiSelect = false;
            #endregion
            
            //dataGridView4
            #region
                dataGridView4.ColumnCount = 7;
                dataGridView4.Columns[0].Name = "Ид. Администратора";
                dataGridView4.Columns[1].Name = "Пароль";
                dataGridView4.Columns[2].Name = "Фамилия";
                dataGridView4.Columns[3].Name = "Имя";
                dataGridView4.Columns[4].Name = "Отчество";
                dataGridView4.Columns[5].Name = "Дата рождения";
                dataGridView4.Columns[6].Name = "Лицензия";

                Update_dataGridView4();

                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView4.MultiSelect = false;
            #endregion

            //dataGridView5
            #region
                dataGridView5.ColumnCount = 3;
                dataGridView5.Columns[0].Name = "Ид. товара";
                dataGridView5.Columns[1].Name = "Короткое название";
                dataGridView5.Columns[2].Name = "Описание";
                
                Update_dataGridView5();

                dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView5.MultiSelect = false;
            #endregion 
        }

        private void UpdateDGV (DataGridView DGV,  string str)
        {
            DataTable DT = new DataTable();
            DGV.Rows.Clear();
            connection.Open();
            MSDA = new MySqlDataAdapter(str, connection);
            MySqlCommandBuilder MSCB = new MySqlCommandBuilder(MSDA);
            try
            {
                MSDA.Fill(DT);
            }
            catch (Exception )
            {
                MessageBox.Show(MESSAGES[0]);
            }
            foreach (DataRow row in DT.Rows)
            {
                try
                {
                    switch (DGV.ColumnCount)
                    {
                        case 2:  DGV.Rows.Add(row[0].ToString(), row[1].ToString()); break;
                        case 3:  DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString()); break;
                        case 4:  DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString()); break;
                        case 5:  DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString()); break;
                        case 6:  DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString()); break;
                        case 7:  DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString()); break;
                        case 8:  DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString()); break;
                        case 9:  DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString()); break;
                        case 10: DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString()); break;
                        case 11: DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString()); break;
                        case 12: DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString());  break;
                        case 13: DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString()); break;
                        case 14: DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString()); break;
                        case 15: DGV.Rows.Add(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString()); break;
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show(MESSAGES[2]);
                }
                
            }
            connection.Close();
            DT.Rows.Clear();
            DT.Dispose();
        }
        private void InsertRowToDGV(MethodInvoker UpdaterFunction , MySqlCommand MSC)
        {
            try
            {
                connection.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //clearTxts();
                    MessageBox.Show(MESSAGES[3]);
                }
                connection.Close();
                UpdaterFunction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        private void UpdateRowToDGV(MethodInvoker UpdaterFunction, string sql)
        {
            MySqlCommand MSC = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();

                MSDA = new MySqlDataAdapter();
                MSDA.UpdateCommand = connection.CreateCommand();
                MSDA.UpdateCommand.CommandText = sql;

                if (MSDA.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(MESSAGES[4]);
                }
                connection.Close();
                UpdaterFunction();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                connection.Close();
            }
            MSC.Dispose();
        }
        private void DeleteRowFromDGV(MethodInvoker UpdaterFunction, string sql)
        {
            cmd = new MySqlCommand(sql, connection);
            try
            {
                connection.Open();

                MSDA = new MySqlDataAdapter(cmd);
                MSDA.DeleteCommand = connection.CreateCommand();
                MSDA.DeleteCommand.CommandText = sql;

                //PROMPT FOR CONFIRMATION
                if (MessageBox.Show("Sure ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show(MESSAGES[5]);
                }
                connection.Close();
                UpdaterFunction();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
                connection.Close();
            }
        }

        //dataGridView1 - Трейдер
        #region
        private void Update_dataGridView1()
        {
            string cmd = "Select * From info_trader";
            UpdateDGV(dataGridView1, cmd);
        }
        private void InsertToTraderInfo (Int64 id, string PWD, Int64 id_brock, string family, string name, string fname, string date, int Pasp_Serial, int Pasp_Number, int Pasp_Code,  string Bank_name, int Banck_account)      
        {
            string sql = "CALL ins_trader (@IDU, @PWD, @IDB, @FAM, @NAM, @FNM, @DAT, @PSR, @PNM, @PCD, @BNM, @BAC)";
            cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("IDU", id);
            cmd.Parameters.AddWithValue("PWD", PWD);
            cmd.Parameters.AddWithValue("IDB", id_brock);
            cmd.Parameters.AddWithValue("FAM", family);
            cmd.Parameters.AddWithValue("NAM", name);
            cmd.Parameters.AddWithValue("FNM", fname);
            cmd.Parameters.AddWithValue("DAT", date);
            cmd.Parameters.AddWithValue("PSR", Pasp_Serial);
            cmd.Parameters.AddWithValue("PNM", Pasp_Number);
            cmd.Parameters.AddWithValue("PCD", Pasp_Code);
            cmd.Parameters.AddWithValue("BNM", Bank_name);
            cmd.Parameters.AddWithValue("BAC", Banck_account);

            InsertRowToDGV(Update_dataGridView1, cmd);
        }
        private void UpdateTraderInfo   (Int64 id,string PWD,Int64 id_brock,string family, string name,string fname,string date,int Pasp_Serial,int Pasp_Number,int Pasp_Code,string Bank_name, int Banck_account)
        {
            string sql = "Call upd_traider(" + id.ToString() + ",'" + PWD + "'," + id_brock + ",'" + family + "','" + name + "','" + fname + "','" + date + "'," + Pasp_Serial + "," + Pasp_Number + "," + Pasp_Code + ",'" + Bank_name +"',"+ Banck_account+ ");";
            UpdateRowToDGV(Update_dataGridView1, sql);
        }
        private void DeleteFromTraderInfo(int num)
        {
            //SQLSTMT
            string sql = "call del_trader(" + num.ToString() + ");";
            DeleteRowFromDGV(Update_dataGridView1, sql);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox10.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox9.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                textBox14.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                textBox13.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            }
            catch (Exception)
            { 
            
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                InsertToTraderInfo(Convert.ToInt64(textBox2.Text, CultureInfo.CurrentCulture), textBox10.Text, Convert.ToInt64(textBox9.Text, CultureInfo.CurrentCulture),textBox3.Text,textBox4.Text, textBox5.Text, dateTimePicker1.Text, Convert.ToInt32(textBox8.Text, CultureInfo.CurrentCulture),Convert.ToInt32(textBox7.Text, CultureInfo.CurrentCulture), Convert.ToInt32(textBox6.Text, CultureInfo.CurrentCulture), textBox14.Text,Convert.ToInt16(textBox13.Text, CultureInfo.CurrentCulture));
            }
            catch (Exception )
            {
                MessageBox.Show(MESSAGES[1]);
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateTraderInfo(Convert.ToInt64(textBox2.Text, CultureInfo.CurrentCulture), textBox10.Text, Convert.ToInt64(textBox9.Text, CultureInfo.CurrentCulture),textBox3.Text, textBox4.Text, textBox5.Text,dateTimePicker1.Text,Convert.ToInt32(textBox8.Text, CultureInfo.CurrentCulture), Convert.ToInt32(textBox7.Text, CultureInfo.CurrentCulture), Convert.ToInt32(textBox6.Text, CultureInfo.CurrentCulture),textBox14.Text, Convert.ToInt16(textBox13.Text, CultureInfo.CurrentCulture));
             }
            catch (Exception)
            {
                MessageBox.Show(MESSAGES[1]);
            }
        }
        private void button18_Click(object sender, EventArgs e)
        {
             try
            {
                DeleteFromTraderInfo(Convert.ToInt16(textBox2.Text, CultureInfo.CurrentCulture));
            }
             catch (Exception )
             {
                 MessageBox.Show(MESSAGES[1]);
             }
        }
#endregion

        //dataGridView2 - Брокер
        #region
        private void Update_dataGridView2()                  // - Конструирование таблицы (Обновление)
        {
            string cmd = "Select * From info_broker";
            UpdateDGV(dataGridView2, cmd);
        }
        private void InsertToBrockerInfo(Int64 id, string PWD, Int64 id_admin, Int64 id_brock_lic, Int64 id_brock_lic_ser, Int64 id_brock_lic_num, string id_brock_lic_date, string brock_fam, string brock_nam, string brock_fnam, string brock_DB)                     
       {
            string sql = "CALL ins_broker(@IDU, @PWD, @IDA, @LIC, @LIC_S, @LIC_N, @LIC_D, @BFM, @BNM, @BFN, @BDB)";
            cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("IDU", id);
            cmd.Parameters.AddWithValue("PWD", PWD);
            cmd.Parameters.AddWithValue("IDA", id_admin);
            cmd.Parameters.AddWithValue("LIC", id_brock_lic);
            cmd.Parameters.AddWithValue("LIC_S", id_brock_lic_ser);
            cmd.Parameters.AddWithValue("LIC_N", id_brock_lic_num);
            cmd.Parameters.AddWithValue("LIC_D", id_brock_lic_date);
            cmd.Parameters.AddWithValue("BFM", brock_fam);
            cmd.Parameters.AddWithValue("BNM", brock_nam);
            cmd.Parameters.AddWithValue("BFN", brock_fnam);
            cmd.Parameters.AddWithValue("BDB", brock_DB);
            InsertRowToDGV(Update_dataGridView2, cmd);
        }
        private void UpdateBrockerInfo(Int64 id, string PWD, Int64 id_admin,  Int64 id_brock_lic,  Int64 id_brock_lic_ser,  Int64 id_brock_lic_num,  string id_brock_lic_date, string brock_fam, string brock_nam,  string brock_fnam, string brock_DB )
        {
            string sql = "CALL upd_broker(" + id.ToString() + ",'" + PWD + "'," + id_admin + "," + id_brock_lic + "," + id_brock_lic_ser + ", " + id_brock_lic_num + ", '" + id_brock_lic_date + "','" + brock_fam + "', '" + brock_nam + "', '" + brock_fnam + "','" + brock_DB + "')";
            UpdateRowToDGV(Update_dataGridView2, sql);
        }
        private void DeleteFromBrockerInfo (Int64 num)
        {
            string sql = "call del_broker(" + num.ToString() + ");";
            DeleteRowFromDGV(Update_dataGridView2, sql);
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox36.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox35.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox33.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox34.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                textBox11.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                textBox12.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
                dateTimePicker2.Value = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[6].Value.ToString());
                textBox21.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();
                textBox20.Text = dataGridView2.SelectedRows[0].Cells[8].Value.ToString();
                textBox19.Text = dataGridView2.SelectedRows[0].Cells[9].Value.ToString();
                dateTimePicker6.Value = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells[10].Value.ToString());
            }
            catch (Exception)
            { 
                
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
             try
            {
                InsertToBrockerInfo(Convert.ToInt64(textBox36.Text, CultureInfo.CurrentCulture), textBox35.Text, Convert.ToInt64(textBox33.Text, CultureInfo.CurrentCulture), Convert.ToInt64(textBox34.Text), Convert.ToInt64(textBox11.Text, CultureInfo.CurrentCulture), Convert.ToInt64(textBox12.Text, CultureInfo.CurrentCulture), dateTimePicker2.Text, textBox21.Text, textBox20.Text, textBox19.Text, dateTimePicker6.Text);
            }
            catch (Exception )
            {
                MessageBox.Show(MESSAGES[1]);
            }
      }
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBrockerInfo(Convert.ToInt64(textBox36.Text, CultureInfo.CurrentCulture), textBox35.Text, Convert.ToInt64(textBox33.Text, CultureInfo.CurrentCulture), Convert.ToInt64(textBox34.Text, CultureInfo.CurrentCulture), Convert.ToInt64(textBox11.Text, CultureInfo.CurrentCulture), Convert.ToInt64(textBox12.Text, CultureInfo.CurrentCulture), dateTimePicker2.Text, textBox21.Text, textBox20.Text, textBox19.Text, dateTimePicker6.Text);
            }
            catch (Exception )
            {
                MessageBox.Show(MESSAGES[1]);
            }
      }
        private void button19_Click(object sender, EventArgs e)
        {
            DeleteFromBrockerInfo(Convert.ToInt64(textBox36.Text, CultureInfo.CurrentCulture));
        }

        #endregion

        //dataGridView3 - Счёт
        #region

        public void Update_dataGridView3()
        {
            string cmd = "Select * From info_account";
            UpdateDGV(dataGridView3, cmd);
        }
        private void InsertToAccInfo(Int64 id,string PWD,Int64 id_admin,string prod,double Q)
        {
            string sql = "CALL ins_acc(@IDU, @PWD, @IDA, @PRO, @QUA)";
            cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("IDU", id);
            cmd.Parameters.AddWithValue("PWD", PWD);
            cmd.Parameters.AddWithValue("IDA", id_admin);
            cmd.Parameters.AddWithValue("PRO", prod);
            cmd.Parameters.AddWithValue("QUA", Q);
            InsertRowToDGV(Update_dataGridView3, cmd);
        }
        private void UpdateAccInfo(Int64 id,string PWD,Int64 id_admin,string prod, double Q)
        {
            string sql = "CALL upd_acc(" + id.ToString() + ",'" + PWD + "'," + id_admin.ToString() + ",'" + prod + "'," + Q.ToString().Replace(',', '.') + ") ";
            UpdateRowToDGV(Update_dataGridView3, sql);
        }
        private void DeleteFromAccInfo(Int64 num)
        {
            string sql = "call del_acc(" + num.ToString() + ");";
            DeleteRowFromDGV(Update_dataGridView3, sql);
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox24.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox23.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            textBox16.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            textBox30.Text = dataGridView3.SelectedRows[0].Cells[7].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dataGridView3.SelectedRows[0].Cells[8].Value.ToString());
        }
        private void button24_Click(object sender, EventArgs e)
        {InsertToAccInfo(Convert.ToInt64(textBox24.Text, CultureInfo.CurrentCulture), textBox23.Text, Convert.ToInt64(textBox16.Text, CultureInfo.CurrentCulture), textBox30.Text, Convert.ToDouble(numericUpDown1.Value, CultureInfo.CurrentCulture));}
        private void button23_Click(object sender, EventArgs e)
        {UpdateAccInfo(Convert.ToInt64(textBox24.Text, CultureInfo.CurrentCulture), textBox23.Text, Convert.ToInt64(textBox16.Text, CultureInfo.CurrentCulture), textBox30.Text, Convert.ToDouble(numericUpDown1.Value, CultureInfo.CurrentCulture));}
        private void button22_Click(object sender, EventArgs e)
        {DeleteFromAccInfo(Convert.ToInt64(textBox24.Text, CultureInfo.CurrentCulture)); }
        #endregion

        //dataGridView4 - Админ
        #region
        public void Update_dataGridView4()
        {
            string cmd = "Select * From admin_info";
            UpdateDGV(dataGridView4, cmd);
        }
        private void InsertToAdminInfo(Int64 id,string PWD,string Lic,string Adm_fam,string Adm_nam,string Adm_fnam, string Adm_DB)
        {
            string sql = "CALL ins_ADM(@IDU, @PWD,  @LIC, @AFM, @ANM, @AFN, @ADB)";
            cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("IDU", id);
            cmd.Parameters.AddWithValue("PWD", PWD);
            cmd.Parameters.AddWithValue("LIC", Lic);
            cmd.Parameters.AddWithValue("AFM", Adm_fam);
            cmd.Parameters.AddWithValue("ANM", Adm_nam);
            cmd.Parameters.AddWithValue("AFN", Adm_fnam);
            cmd.Parameters.AddWithValue("ADB", Adm_DB);
            InsertRowToDGV(Update_dataGridView4, cmd);
        }
        private void UpdateAdminInfo(Int64 id,string PWD,string Lic,string Adm_fam,string Adm_nam,string Adm_fnam,string Adm_DB)
        {
            string sql = "CALL upd_adm(" + id.ToString() + ",'" + PWD + "','" + Lic + "','" + Adm_fam + "','" + Adm_nam + "', '" + Adm_fnam + "', '" + Adm_DB +  "')";
            UpdateRowToDGV(Update_dataGridView4, sql);
        }
        private void DeleteFromAdminInfo(Int64 num)
        {
            string sql = "call del_ADM(" + num.ToString() + ");";
            DeleteRowFromDGV(Update_dataGridView4, sql);
        }     

        private void dataGridView4_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox29.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
                textBox15.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
                textBox28.Text = dataGridView4.SelectedRows[0].Cells[2].Value.ToString();
                textBox27.Text = dataGridView4.SelectedRows[0].Cells[3].Value.ToString();
                textBox26.Text = dataGridView4.SelectedRows[0].Cells[4].Value.ToString();
                dateTimePicker4.Value = Convert.ToDateTime(dataGridView4.SelectedRows[0].Cells[5].Value.ToString());
                textBox25.Text = dataGridView4.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch (Exception)
            { 
            
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {InsertToAdminInfo(Convert.ToInt64(textBox29.Text, CultureInfo.CurrentCulture), textBox15.Text, textBox25.Text, textBox28.Text, textBox27.Text, textBox26.Text, dateTimePicker4.Text);}
        private void button26_Click(object sender, EventArgs e)
        {UpdateAdminInfo(Convert.ToInt64(textBox29.Text, CultureInfo.CurrentCulture), textBox15.Text, textBox25.Text, textBox28.Text, textBox27.Text, textBox26.Text, dateTimePicker4.Text); }
        private void button25_Click(object sender, EventArgs e)
        {DeleteFromAdminInfo(Convert.ToInt64(textBox29.Text, CultureInfo.CurrentCulture)); }
        #endregion

        //dataGridView5 - Товар
        #region
        public void Update_dataGridView5()
        {
            string cmd = "Select * From info_product";
            UpdateDGV(dataGridView5, cmd);
        }
        private void dataGridView5_MouseClick(object sender, MouseEventArgs e)  // обработчик события выделения строки
        {
            textBox57.Text = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            textBox56.Text = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();
            textBox55.Text = dataGridView5.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void InsertToProduct(int Num, string ShortName, string LongName)
        {
            string sql = "CALL ins_prod(@NUM, @SNM,  @LNM)";
            cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("NUM", Num);
            cmd.Parameters.AddWithValue("SNM", ShortName);
            cmd.Parameters.AddWithValue("LNM", LongName);
            InsertRowToDGV(Update_dataGridView5, cmd);
        }
        private void UpdateProductInfo(int Num, string ShortName, string LongName)
        {
            string sql = "CALL upd_prod(" + Num.ToString() + ",'" + ShortName + "','" + LongName + "')";
            UpdateRowToDGV(Update_dataGridView5, sql);
        }
        private void DeleteFromProduct(int Num)
        {
            string sql = "call del_prod(" + Num.ToString() + ");";
            DeleteRowFromDGV(Update_dataGridView5, sql);
        }

        private void button30_Click(object sender, EventArgs e)             // - Обработчик нажатия "Добавить"       
        {
            InsertToProduct(Convert.ToInt16(textBox57.Text, CultureInfo.CurrentCulture), textBox56.Text, textBox55.Text);
        }
        private void button29_Click(object sender, EventArgs e)             // - Обработчик нажатия "Редактор"   
        {
            UpdateProductInfo(Convert.ToInt16(textBox57.Text, CultureInfo.CurrentCulture), textBox56.Text, textBox55.Text);
        }
        private void button28_Click(object sender, EventArgs e)             // - Обработчик нажатия "Удалить"   
        {
            DeleteFromProduct(Convert.ToInt16(textBox57.Text, CultureInfo.CurrentCulture));
        }

        #endregion

        private void MW_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
