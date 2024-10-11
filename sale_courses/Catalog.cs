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
    public partial class Catalog : Form
    {
        public Catalog()
        {
            InitializeComponent();
            load_catalog();
            load_category();
        }
        public void load_catalog()
        {

            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `курсы`.`ID_Курса`, " +
                "`курсы`.`Название`, " +
                "`курсы`.`Описание`, " +
                "`курсы`.`Цена`, " +
                "`курсы`.`Длительность`, " +
                "`курсы`.`Дата создания`, " +
                "`курсы`.`Категория` " +
                "FROM `sale_courses`.`курсы` " +
                "left join `категории` on `курсы`.`Категория`=`категории`.`ID_категории`";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_Курса"].Visible = false;
            dataGridView1.Columns["Категория"].Visible = false;

            connection.Close();
        }

        public void load_category()
        {
            try
            {
                DbWorker db = new DbWorker();
                MySqlConnection conn = db.Connect();

                String query = "SELECT `категории`.`ID_Категории`, `категории`.`Название` FROM `sale_courses`.`категории`;";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Добавляем новый столбец для строкового идентификатора
                dt.Columns.Add("StringID", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    row["StringID"] = row["ID_категории"].ToString();
                }

                // Добавляем строку для "Все рестораны"
                DataRow allCategories = dt.NewRow();
                allCategories["ID_категории"] = DBNull.Value;
                allCategories["Название"] = "Без категории";
                allCategories["StringID"] = "All";
                dt.Rows.InsertAt(allCategories, 0);

                comboBox1.DisplayMember = "Название";
                comboBox1.ValueMember = "StringID";
                comboBox1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки категорий: " + ex.Message);
            }

        }
        public void load_catalog_for_category(int categoryId)
        {

            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `курсы`.`ID_Курса`, " +
                "`курсы`.`Название`, " +
                "`курсы`.`Описание`, " +
                "`курсы`.`Цена`, " +
                "`курсы`.`Длительность`, " +
                "`курсы`.`Дата создания`, " +
                "`курсы`.`Категория` " +
                "FROM `sale_courses`.`курсы` " +
                "left join `категории` on `курсы`.`Категория`=`категории`.`ID_категории`" +
                "WHERE `курсы`.`Категория`= " + categoryId + ";";



            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_Курса"].Visible = false;
            dataGridView1.Columns["Категория"].Visible = false;

            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                string selectedValue = comboBox1.SelectedValue.ToString();
                if (selectedValue == "All")
                {
                    load_catalog();
                }
                else
                {
                    int categoryId = Convert.ToInt32(selectedValue);
                    load_catalog_for_category(categoryId);
                }
            }
        }
        private void AddOrder(int courseID, int coursePrice)
        {
            try
            {
                DbWorker db = new DbWorker();
                MySqlConnection conn = db.Connect();

                string query = "INSERT INTO заказы (Пользователь, Курс, Дата, Сумма, Статус) VALUES (@Пользователь, @Курс, NOW(), @Сумма, 'В обработке');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Пользователь", GlobalVariables.UserID);
                cmd.Parameters.AddWithValue("@Курс", courseID);
                cmd.Parameters.AddWithValue("@Сумма", coursePrice);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Курс успешно добавлен в заказы!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении заказа: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedCoursesId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Курса"].Value);
                int selectedCoursesPrice = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Цена"].Value);
                AddOrder(selectedCoursesId, selectedCoursesPrice);
                if (comboBox1.SelectedValue.ToString() == "All")
                {
                    load_catalog();
                }
                else
                {
                    int categoryId = Convert.ToInt32(comboBox1.SelectedValue);
                    load_catalog_for_category(categoryId);
                }
            }
            else
            {
                MessageBox.Show("Выберите курс для добавления в заказ.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyOrders myOrders = new MyOrders();
            myOrders.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Hide();
        }
    }
}
