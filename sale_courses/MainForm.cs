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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            load_orders();
        }
        public string currentTable = "Заказы";
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
        public void load_category()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connection = db.Connect();

            String sqlQuery = "SELECT `категории`.`ID_категории`, " +
                "`категории`.`Название`, " +
                "`категории`.`Описание` " +
                "FROM `sale_courses`.`категории`";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, connection);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns["ID_категории"].Visible = false;


            connection.Close();
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
            dataGridView1.Columns["Пароль"].Visible = false;


            connection.Close();
        }


        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_orders();
            currentTable = "Заказы";
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_category();
            currentTable = "Категории";
        }

        private void курсыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_courses();
            currentTable = "Курсы";
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_users();
            currentTable = "Пользователи";
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentTable == "Заказы")
            {
                load_orders();
            }
            else if (currentTable == "Категории")
            {
                load_category();
            }
            else if(currentTable == "Курсы")
            {
                load_courses();
            }
            else if(currentTable == "Пользователи")
            {
                load_users();
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentTable == "Заказы")
            {
                Add_orders add_Orders = new Add_orders();
                add_Orders.ShowDialog();
            }
            else if(currentTable == "Категории")
            {
                Add_category add_Category = new Add_category();
                add_Category.ShowDialog();
            }
            else if(currentTable == "Курсы")
            {
                Add_courses add_Courses = new Add_courses();
                add_Courses.ShowDialog();
            }
            else if(currentTable == "Пользователи")
            {
                Add_users add_Users = new Add_users();
                add_Users.ShowDialog();
            }
        }
    }

}
