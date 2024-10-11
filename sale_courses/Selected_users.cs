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
    public partial class Selected_users : Form
    {
        public Selected_users()
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


            connection.Close();
        }
        public object selected_id_user;
        public object selected_login_user;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                selected_id_user = dataGridView1.SelectedRows[0].Cells["ID_пользователя"].Value;
                selected_login_user = dataGridView1.SelectedRows[0].Cells["Логин"].Value;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
