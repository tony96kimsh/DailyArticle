namespace DailyArticle
{
    partial class FromReadList
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

        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "test", "yy-mn-dd" }, -1);
            ListViewItem listViewItem2 = new ListViewItem("test");
            ListViewItem listViewItem3 = new ListViewItem("test");
            listView1 = new ListView();
            colTitle = new ColumnHeader();
            colDate = new ColumnHeader();
            label1 = new Label();
            btnShowFavorite = new Button();
            btnShowHistory = new Button();
            BtnBack = new Button();
            btnDelete = new Button();
            btnViewArticle = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { colTitle, colDate });
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            listView1.Location = new Point(12, 142);
            listView1.Name = "listView1";
            listView1.Size = new Size(852, 447);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // colTitle
            // 
            colTitle.Text = "기사 제목";
            colTitle.Width = 500;
            // 
            // colDate
            // 
            colDate.Text = "읽은 시간";
            colDate.TextAlign = HorizontalAlignment.Center;
            colDate.Width = 140;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans KR", 16F, FontStyle.Bold);
            label1.Location = new Point(416, 21);
            label1.Name = "label1";
            label1.Size = new Size(95, 32);
            label1.TabIndex = 1;
            label1.Text = "History";
            // 
            // btnShowFavorite
            // 
            btnShowFavorite.Font = new Font("Noto Sans KR", 14F);
            btnShowFavorite.ForeColor = SystemColors.ControlLight;
            btnShowFavorite.Location = new Point(444, 85);
            btnShowFavorite.Name = "btnShowFavorite";
            btnShowFavorite.Size = new Size(420, 50);
            btnShowFavorite.TabIndex = 13;
            btnShowFavorite.Text = "즐겨찾기";
            btnShowFavorite.UseVisualStyleBackColor = true;
            btnShowFavorite.Click += btnShowFavorite_Click;
            // 
            // btnShowHistory
            // 
            btnShowHistory.Font = new Font("Noto Sans KR", 14F);
            btnShowHistory.Location = new Point(12, 85);
            btnShowHistory.Name = "btnShowHistory";
            btnShowHistory.Size = new Size(420, 50);
            btnShowHistory.TabIndex = 14;
            btnShowHistory.Text = "최근 본 기사";
            btnShowHistory.UseVisualStyleBackColor = true;
            btnShowHistory.Click += btnShowHistory_Click;
            // 
            // BtnBack
            // 
            BtnBack.Font = new Font("Noto Sans KR", 18F);
            BtnBack.ForeColor = SystemColors.ActiveCaption;
            BtnBack.Location = new Point(12, 8);
            BtnBack.Margin = new Padding(3, 4, 3, 4);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(52, 53);
            BtnBack.TabIndex = 15;
            BtnBack.Text = "🔙";
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Noto Sans KR", 14F);
            btnDelete.ForeColor = SystemColors.ControlDarkDark;
            btnDelete.Location = new Point(870, 252);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(40, 100);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "🗑️";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnViewArticle
            // 
            btnViewArticle.Font = new Font("Noto Sans KR", 14F);
            btnViewArticle.ForeColor = SystemColors.Highlight;
            btnViewArticle.Location = new Point(870, 142);
            btnViewArticle.Name = "btnViewArticle";
            btnViewArticle.Size = new Size(40, 100);
            btnViewArticle.TabIndex = 17;
            btnViewArticle.Text = "🔍";
            btnViewArticle.UseVisualStyleBackColor = true;
            btnViewArticle.Click += btnViewArticle_Click;
            // 
            // FromReadList
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(926, 644);
            Controls.Add(btnViewArticle);
            Controls.Add(btnDelete);
            Controls.Add(BtnBack);
            Controls.Add(btnShowHistory);
            Controls.Add(btnShowFavorite);
            Controls.Add(label1);
            Controls.Add(listView1);
            Font = new Font("Noto Sans KR", 9F);
            Name = "FromReadList";
            Text = "Daily Article by The Guardian";
            FormClosing += FromReadList_FormClosing;
            Load += FromReadList_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader colTitle;
        private ColumnHeader colDate;
        private Label label1;
        private Button btnShowHistory;
        private Button BtnBack;
        private Button btnShowFavorite;
        private Button btnDelete;
        private Button btnViewArticle;
    }
}
