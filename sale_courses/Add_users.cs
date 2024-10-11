using MySql.Data.MySqlClient;
using sale_courses.img;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sale_courses
{
    public partial class Add_users : Form
    {
        public Add_users()
        {
            InitializeComponent();
            load_users();
        }
        public void load_users()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `пользователи`.`ID_пользователя`, " +
                "`пользователи`.`Имя`, " +
                "`пользователи`.`Фамилия`, " +
                "`пользователи`.`Логин`, " +
                "`пользователи`.`Пароль`, " +
                "`пользователи`.`isAdmin` " +
                "FROM `sale_courses`.`пользователи`;";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_пользователя"].Visible = false;
            dataGridView1.Columns["isAdmin"].Visible = false;
            dataGridView1.Columns["Логин"].Visible = false;


            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new DbWorker();
            MySqlConnection connection = db.Connect();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand check_user_command = new MySqlCommand("SELECT * FROM `пользователи` WHERE `логин` = @login", connection);
            check_user_command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = check_user_command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Данный логин занят!");
                connection.Close();
                return;
            }

            String sqlQuery = "INSERT INTO пользователи (Имя, Фамилия, Логин, Пароль) " +
                "VALUES (@Имя, @Фамилия, @Логин, @Пароль);";

            MySqlCommand insertOrderCommand = new MySqlCommand(sqlQuery, connection);
            insertOrderCommand.Parameters.AddWithValue("@Имя", user.Text);
            insertOrderCommand.Parameters.AddWithValue("@Фамилия", courses.Text);
            insertOrderCommand.Parameters.AddWithValue("@Логин", textBox1.Text);
            insertOrderCommand.Parameters.AddWithValue("@Пароль", summ.Text);

            try
            {
                insertOrderCommand.ExecuteNonQuery();
                MessageBox.Show("Новые данные успешно добавлены в базу",
                "Успешное завершение действия", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить данные в базу. Произошла ошибка: " + ex.Message,
                "Неуспешное завершение действия", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                connection.Close();
                load_users();
            }
        }
    }
}
