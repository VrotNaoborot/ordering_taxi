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
    public partial class Selected_courses : Form
    {
        public Selected_courses()
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

        public object selected_id_category;
        public object selected_name_category;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selected_id_category = dataGridView1.SelectedRows[0].Cells["ID_курса"].Value;
            selected_name_category = dataGridView1.SelectedRows[0].Cells["Название"].Value;
            DialogResult = DialogResult.OK;
        }
    }
}
