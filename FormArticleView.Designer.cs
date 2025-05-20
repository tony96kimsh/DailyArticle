namespace DailyArticle
{
    partial class FormArticleView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArticleView));
            txtArticle = new RichTextBox();
            lblDate = new Label();
            btnChange = new Button();
            linkLabel1 = new LinkLabel();
            txtTitle = new RichTextBox();
            label1 = new Label();
            btnFavoriteList = new Button();
            btnHistory = new Button();
            btnFavorite = new Button();
            linkLabel2 = new LinkLabel();
            tip = new ToolTip(components);
            SuspendLayout();
            // 
            // txtArticle
            // 
            txtArticle.BackColor = Color.White;
            txtArticle.BorderStyle = BorderStyle.FixedSingle;
            txtArticle.Font = new Font("Merriweather 24pt SemiCondensed", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtArticle.ForeColor = SystemColors.InfoText;
            txtArticle.Location = new Point(21, 201);
            txtArticle.Margin = new Padding(3, 4, 3, 4);
            txtArticle.Name = "txtArticle";
            txtArticle.ReadOnly = true;
            txtArticle.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtArticle.Size = new Size(1400, 667);
            txtArticle.TabIndex = 2;
            txtArticle.Text = "Article context loading...";
            txtArticle.Enter += txtArticle_Enter;
            txtArticle.MouseDown += txtArticle_MouseDown;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Merriweather 24pt SemiCondensed", 10F);
            lblDate.ForeColor = SystemColors.AppWorkspace;
            lblDate.Location = new Point(21, 168);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(110, 24);
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
            linkLabel1.Location = new Point(1313, 164);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(108, 26);
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
            label1.Size = new Size(461, 20);
            label1.TabIndex = 8;
            label1.Text = "본문에 커서를 올린 채로 Ctrl + 마우스 휠 사용 시, 글자 크기 조절 가능합니다.";
            // 
            // btnFavoriteList
            // 
            btnFavoriteList.Font = new Font("Noto Sans KR", 18F);
            btnFavoriteList.ForeColor = Color.Gold;
            btnFavoriteList.Location = new Point(79, 12);
            btnFavoriteList.Margin = new Padding(3, 4, 3, 4);
            btnFavoriteList.Name = "btnFavoriteList";
            btnFavoriteList.Size = new Size(52, 54);
            btnFavoriteList.TabIndex = 10;
            btnFavoriteList.Text = "🔖";
            btnFavoriteList.UseVisualStyleBackColor = true;
            btnFavoriteList.Click += btnFavoriteList_Click;
            // 
            // btnHistory
            // 
            btnHistory.Font = new Font("Noto Sans KR", 18F);
            btnHistory.ForeColor = SystemColors.ActiveCaption;
            btnHistory.Location = new Point(21, 12);
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
            btnFavorite.Click += btnFavorite_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Merriweather 24pt SemiCondensed", 8F);
            linkLabel2.ForeColor = Color.Black;
            linkLabel2.LinkColor = SystemColors.ControlDark;
            linkLabel2.Location = new Point(1279, 880);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(112, 19);
            linkLabel2.TabIndex = 16;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "\U0001f9d1‍💻 Development Info";
            linkLabel2.VisitedLinkColor = Color.Gray;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1442, 933);
            Controls.Add(linkLabel2);
            Controls.Add(btnFavorite);
            Controls.Add(btnHistory);
            Controls.Add(btnFavoriteList);
            Controls.Add(label1);
            Controls.Add(txtTitle);
            Controls.Add(linkLabel1);
            Controls.Add(btnChange);
            Controls.Add(lblDate);
            Controls.Add(txtArticle);
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
        private RichTextBox txtArticle;
        private Label lblDate;
        private Button btnChange;
        private LinkLabel linkLabel1;
        private RichTextBox txtTitle;
        private Label label1;
        private Button btnFavoriteList;
        private Button btnHistory;
        private Button btnFavorite;
        private LinkLabel linkLabel2;
        private ToolTip tip;
    }
}
