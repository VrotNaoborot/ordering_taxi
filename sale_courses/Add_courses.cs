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
    public partial class Add_courses : Form
    {
        public Add_courses()
        {
            InitializeComponent();
            load_courses();
        }
        public void load_courses()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `курсы`.`ID_курса`, " +
                "`курсы`.`Название`, " +
                "`курсы`.`Описание`, " +
                "`курсы`.`Цена`, " +
                "`курсы`.`Длительность`, " +
                "`курсы`.`Дата создания`, " +
                "`курсы`.`Категория`," +
                "`категории`.`Название` AS `Категория курса` " +
                "FROM `sale_courses`.`курсы` " +
                "left join `категории` on `курсы`.`Категория`=`категории`.`ID_Категории`;";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_курса"].Visible = false;
            dataGridView1.Columns["Категория"].Visible = false;


            connection.Close();
        }

        public object detected_id_category;
        private void textBox2_Click(object sender, EventArgs e)
        {
            Selected_category selected_Category = new Selected_category();
            selected_Category.ShowDialog();
            detected_id_category = selected_Category.selected_id_category;
            textBox2.Text = Convert.ToString(selected_Category.selected_name_category);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "INSERT INTO курсы (Название, Описание, Цена, Длительность, `Дата создания`, Категория) " +
                "VALUES (@Название, @Описание, @Цена, @Длительность, @Дата, @Категория);";

            MySqlCommand insertOrderCommand = new MySqlCommand(sqlQuery, connection);
            insertOrderCommand.Parameters.AddWithValue("@Название", user.Text);
            insertOrderCommand.Parameters.AddWithValue("@Описание", courses.Text);
            insertOrderCommand.Parameters.AddWithValue("@Цена", name.Text);
            insertOrderCommand.Parameters.AddWithValue("@Длительность", summ.Text);
            insertOrderCommand.Parameters.AddWithValue("@Дата", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            insertOrderCommand.Parameters.AddWithValue("@Категория", detected_id_category);

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
                load_courses();
            }
        }
    }
}
