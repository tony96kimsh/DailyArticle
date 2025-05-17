namespace DailyArticle
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtAriticle = new RichTextBox();
            lblDate = new Label();
            btnChange = new Button();
            linkLabel1 = new LinkLabel();
            txtTitle = new RichTextBox();
            label1 = new Label();
            btnFavoriteList = new Button();
            btnCalendar = new Button();
            btnHistory = new Button();
            btnFavorite = new Button();
            button1 = new Button();
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // txtAriticle
            // 
            txtAriticle.BackColor = Color.White;
            txtAriticle.BorderStyle = BorderStyle.FixedSingle;
            txtAriticle.Font = new Font("Merriweather 24pt SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAriticle.ForeColor = SystemColors.InfoText;
            txtAriticle.Location = new Point(21, 201);
            txtAriticle.Margin = new Padding(3, 4, 3, 4);
            txtAriticle.Name = "txtAriticle";
            txtAriticle.ReadOnly = true;
            txtAriticle.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtAriticle.Size = new Size(1400, 667);
            txtAriticle.TabIndex = 2;
            txtAriticle.Text = "Article context loading...";
            txtAriticle.Enter += txtAriticle_Enter;
            txtAriticle.MouseDown += txtAriticle_MouseDown;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Merriweather 24pt SemiCondensed", 10F);
            lblDate.ForeColor = SystemColors.AppWorkspace;
            lblDate.Location = new Point(21, 168);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(137, 29);
            lblDate.TabIndex = 4;
            lblDate.Text = "Publication date: ";
            // 
            // btnChange
            // 
            btnChange.Font = new Font("Noto Sans KR", 18F);
            btnChange.ForeColor = SystemColors.MenuHighlight;
            btnChange.Location = new Point(1373, 12);
            btnChange.Margin = new Padding(3, 4, 3, 4);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(52, 54);
            btnChange.TabIndex = 5;
            btnChange.Text = "🔃";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Merriweather 24pt SemiCondensed", 11F);
            linkLabel1.ForeColor = Color.Black;
            linkLabel1.LinkColor = Color.Gray;
            linkLabel1.Location = new Point(1286, 164);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(135, 33);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "visit article link";
            linkLabel1.VisitedLinkColor = Color.Gray;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.White;
            txtTitle.Font = new Font("Merriweather 24pt SemiCondensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(21, 73);
            txtTitle.Margin = new Padding(3, 4, 3, 4);
            txtTitle.Name = "txtTitle";
            txtTitle.ReadOnly = true;
            txtTitle.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtTitle.Size = new Size(1400, 91);
            txtTitle.TabIndex = 7;
            txtTitle.Text = "title loading...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Sans KR", 10F);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(21, 876);
            label1.Name = "label1";
            label1.Size = new Size(570, 25);
            label1.TabIndex = 8;
            label1.Text = "본문에 커서를 올린 채로 Ctrl + 마우스 휠 사용 시, 글자 크기 조절 가능합니다.";
            // 
            // btnFavoriteList
            // 
            btnFavoriteList.Font = new Font("Noto Sans KR", 18F);
            btnFavoriteList.ForeColor = Color.Gold;
            btnFavoriteList.Location = new Point(137, 11);
            btnFavoriteList.Margin = new Padding(3, 4, 3, 4);
            btnFavoriteList.Name = "btnFavoriteList";
            btnFavoriteList.Size = new Size(52, 54);
            btnFavoriteList.TabIndex = 10;
            btnFavoriteList.Text = "🔖";
            btnFavoriteList.UseVisualStyleBackColor = true;
            btnFavoriteList.Click += btnFavoriteList_Click;
            // 
            // btnCalendar
            // 
            btnCalendar.Font = new Font("Noto Sans KR", 18F);
            btnCalendar.ForeColor = Color.Crimson;
            btnCalendar.Location = new Point(21, 13);
            btnCalendar.Margin = new Padding(3, 4, 3, 4);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Size = new Size(52, 54);
            btnCalendar.TabIndex = 11;
            btnCalendar.Text = "📅";
            btnCalendar.UseVisualStyleBackColor = true;
            btnCalendar.Click += btnCalendar_Click;
            // 
            // btnHistory
            // 
            btnHistory.Font = new Font("Noto Sans KR", 18F);
            btnHistory.ForeColor = SystemColors.ActiveCaption;
            btnHistory.Location = new Point(79, 12);
            btnHistory.Margin = new Padding(3, 4, 3, 4);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(52, 54);
            btnHistory.TabIndex = 12;
            btnHistory.Text = "🕒";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // btnFavorite
            // 
            btnFavorite.Font = new Font("Noto Sans KR", 18F);
            btnFavorite.ForeColor = SystemColors.ControlLight;
            btnFavorite.Location = new Point(1315, 11);
            btnFavorite.Margin = new Padding(3, 4, 3, 4);
            btnFavorite.Name = "btnFavorite";
            btnFavorite.Size = new Size(52, 54);
            btnFavorite.TabIndex = 13;
            btnFavorite.Text = "🌟";
            btnFavorite.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Merriweather 24pt SemiCondensed", 12F);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(1267, 876);
            button1.Name = "button1";
            button1.Size = new Size(154, 41);
            button1.TabIndex = 14;
            button1.Text = "Read complete";
            button1.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Merriweather 24pt SemiCondensed", 8F);
            linkLabel2.ForeColor = Color.Black;
            linkLabel2.LinkColor = SystemColors.ControlDark;
            linkLabel2.Location = new Point(21, 954);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(142, 24);
            linkLabel2.TabIndex = 16;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "\U0001f9d1‍💻 Development Info";
            linkLabel2.VisitedLinkColor = Color.Gray;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 39F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1442, 996);
            Controls.Add(linkLabel2);
            Controls.Add(button1);
            Controls.Add(btnFavorite);
            Controls.Add(btnHistory);
            Controls.Add(btnCalendar);
            Controls.Add(btnFavoriteList);
            Controls.Add(label1);
            Controls.Add(txtTitle);
            Controls.Add(linkLabel1);
            Controls.Add(btnChange);
            Controls.Add(lblDate);
            Controls.Add(txtAriticle);
            Font = new Font("Merriweather 24pt SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Daily Article by The Guardian";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox txtAriticle;
        private Label lblDate;
        private Button btnChange;
        private LinkLabel linkLabel1;
        private RichTextBox txtTitle;
        private Label label1;
        private Button btnFavoriteList;
        private Button btnCalendar;
        private Button btnHistory;
        private Button btnFavorite;
        private Button button1;
        private LinkLabel linkLabel2;
    }
}
