using MySql.Data.MySqlClient;
using sale_courses.img;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sale_courses
{
    public partial class MyOrders : Form
    {
        public MyOrders()
        {
            InitializeComponent();
            load_orders();
        }
        public void load_orders()
        {
            DbWorker db = new DbWorker();
            MySqlConnection connect = db.Connect();

            string selectQuery = "SELECT `заказы`.`ID_заказа`, " +
                "`заказы`.`Пользователь`, " +
                "`заказы`.`Курс`, " +
                "`заказы`.`Дата`," +
                "`заказы`.`Сумма`, " +
                "`заказы`.`Статус`, " +
                "`курсы`.`Название`, " +
                "`курсы`.`Описание`, " +
                "`курсы`.`Длительность` " +
                "FROM `sale_courses`.`заказы` " +
                "left join `курсы` on `заказы`.`Курс`=`курсы`.`ID_курса` " +
                $"WHERE `Пользователь` = {GlobalVariables.UserID};";

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectQuery, connect);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connect.Close();


            dataGridView1.Columns["Пользователь"].Visible = false;
            dataGridView1.Columns["Курс"].Visible = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                name.Text = $"{dataGridView1.SelectedRows[0].Cells["Название"].Value}";
                price.Text = $"Цена: {dataGridView1.SelectedRows[0].Cells["Сумма"].Value}";
                date.Text = $"{dataGridView1.SelectedRows[0].Cells["Дата"].Value}";
                status.Text = $"Статус: {dataGridView1.SelectedRows[0].Cells["Статус"].Value}";
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Catalog catalog = new Catalog();
            catalog.Show();
            this.Hide();
        }
    }
}
