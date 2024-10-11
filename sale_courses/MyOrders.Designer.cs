namespace sale_courses
{
    partial class MyOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameLabel = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(527, 317);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(533, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(116, 28);
            this.nameLabel.TabIndex = 34;
            this.nameLabel.Text = "Название:";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.price.ForeColor = System.Drawing.Color.White;
            this.price.Location = new System.Drawing.Point(533, 80);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(70, 28);
            this.price.TabIndex = 35;
            this.price.Text = "Цена:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.dateLabel.ForeColor = System.Drawing.Color.White;
            this.dateLabel.Location = new System.Drawing.Point(533, 128);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(138, 28);
            this.dateLabel.TabIndex = 36;
            this.dateLabel.Text = "Дата заказа:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.status.ForeColor = System.Drawing.Color.White;
            this.status.Location = new System.Drawing.Point(533, 206);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(86, 28);
            this.status.TabIndex = 37;
            this.status.Text = "Статус:";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.name.ForeColor = System.Drawing.Color.White;
            this.name.Location = new System.Drawing.Point(533, 37);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(0, 28);
            this.name.TabIndex = 38;
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Sitka Small", 14.25F);
            this.date.ForeColor = System.Drawing.Color.White;
            this.date.Location = new System.Drawing.Point(533, 156);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(0, 28);
            this.date.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(538, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 38);
            this.button1.TabIndex = 40;
            this.button1.Text = "Каталог";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MyOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(198)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(800, 317);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.date);
            this.Controls.Add(this.name);
            this.Controls.Add(this.status);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.price);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MyOrders";
            this.Text = "Мои заказы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Button button1;
    }
}