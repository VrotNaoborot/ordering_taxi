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

namespace sale_courses
{
    public partial class Add_orders : Form
    {
        public Add_orders()
        {
            InitializeComponent();
            load_orders();
            status.SelectedItem = "Ожидает";
        }
        public void load_orders()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `заказы`.`ID_Заказа`, " +
                "`заказы`.`Пользователь`, " +
                "`заказы`.`Курс`, " +
                "`заказы`.`Дата`, " +
                "`заказы`.`Сумма`, " +
                "`заказы`.`Статус`," +
                "`пользователи`.`Логин`, " +
                "`курсы`.`Название` " +
                "FROM `sale_courses`.`заказы` " +
                "left join `пользователи` on `заказы`.`Пользователь`=`пользователи`.`ID_пользователя` " +
                "left join `курсы` on `заказы`.`Курс`=`Курсы`.`ID_курса`";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["Пользователь"].Visible = false;
            dataGridView1.Columns["Курс"].Visible = false;
            dataGridView1.Columns["ID_Заказа"].Visible = false;


            connection.Close();
        }

        public object detected_id_user;
        private void user_Click(object sender, EventArgs e)
        {
            Selected_users selected_Users = new Selected_users();
            selected_Users.ShowDialog();
            detected_id_user = selected_Users.selected_id_user;
            user.Text = Convert.ToString(selected_Users.selected_login_user);
        }

        public object detected_id_course;
        private void courses_Click(object sender, EventArgs e)
        {
            Selected_courses selected_Courses = new Selected_courses();
            selected_Courses.ShowDialog();
            detected_id_course = selected_Courses.selected_id_category;
            courses.Text = Convert.ToString(selected_Courses.selected_name_category);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "INSERT INTO заказы (Пользователь, Курс, Дата, Сумма, Статус) " +
                "VALUES (@Пользователь, @Курс, @Дата, @Сумма, @Статус);";

            MySqlCommand insertOrderCommand = new MySqlCommand(sqlQuery, connection);
            insertOrderCommand.Parameters.AddWithValue("@Пользователь", detected_id_user);
            insertOrderCommand.Parameters.AddWithValue("@Курс", detected_id_course);
            insertOrderCommand.Parameters.AddWithValue("@Дата", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            insertOrderCommand.Parameters.AddWithValue("@Сумма", summ.Text);
            insertOrderCommand.Parameters.AddWithValue("@Статус", status.Text);

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
                load_orders();
            }
        }
    }
}
