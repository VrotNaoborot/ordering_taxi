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
    public partial class Selected_category : Form
    {
        public Selected_category()
        {
            InitializeComponent();
            load_category();
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

        public object selected_id_category;
        public object selected_name_category;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                selected_id_category = dataGridView1.SelectedRows[0].Cells["ID_категории"].Value;
                selected_name_category = dataGridView1.SelectedRows[0].Cells["Название"].Value;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
