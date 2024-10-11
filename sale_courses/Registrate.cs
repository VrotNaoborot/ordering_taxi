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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace sale_courses
{
    public partial class Registrate : Form
    {
        public Registrate()
        {
            InitializeComponent();
            this.password.AutoSize = false;
            this.password.Size = new Size(this.password.Size.Width, 45);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login.Text.Length == 0)
            {
                MessageBox.Show("Необходимо ввести username");
                return;
            }
            if (password.Text.Length == 0)
            {
                MessageBox.Show("Необходимо ввести пароль");
                return;
            }
            if (name.Text.Length == 0)
            {
                MessageBox.Show("Необходимо ввести Имя");
                return;
            }
            if (surname.Text.Length == 0)
            {
                MessageBox.Show("Необходимо ввести Фамилию");
                return;
            }

            var db = new DbWorker();
            MySqlConnection connection = db.Connect();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand check_user_command = new MySqlCommand("SELECT * FROM `пользователи` WHERE `логин` = @login", connection);
            check_user_command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;

            adapter.SelectCommand = check_user_command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Данный логин занят!");
                connection.Close();
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO `пользователи` (`Логин`, `Пароль`, `Имя`, `Фамилия`) VALUES (@Логин, @Пароль, @Имя, @Фамилия)", connection);
            command.Parameters.Add("@Логин", MySqlDbType.VarChar).Value = this.login.Text;
            command.Parameters.Add("@Пароль", MySqlDbType.VarChar).Value = this.password.Text;
            command.Parameters.Add("@Имя", MySqlDbType.VarChar).Value = this.name.Text;
            command.Parameters.Add("@Фамилия", MySqlDbType.VarChar).Value = this.surname.Text;

            if (command.ExecuteNonQuery() == 1)
            {
                connection.Close();
                MessageBox.Show("Аккаунт создан!");
                Auth auth = new Auth();
                auth.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан.");
                connection.Close();
                Registrate registrate = new Registrate();
                registrate.Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }
    }
}
