namespace DailyArticle
{
    class Loading
    {
        private Form overlay;
        private Form parentForm;

        public Loading(Form parent)
        {
            this.parentForm = parent;
        }

        public void InitOverlay()
        {
            // 로딩 폼 생성
            overlay = new Form();
            overlay.FormBorderStyle = FormBorderStyle.None;
            overlay.BackColor = Color.Black;
            overlay.Opacity = 0.7;
            overlay.ShowInTaskbar = false;
            overlay.StartPosition = FormStartPosition.Manual;
            // 작업 표시줄 제외한 화면 영역 기준으로 덮기
            overlay.Size = parentForm.ClientSize;
            overlay.Location = parentForm.PointToScreen(Point.Empty);
            overlay.TopMost = true;

            // Alt + F4 시 앱 종료
            overlay.FormClosing += (s, e) =>
            {
                Application.Exit();
            };

            // 라벨 생성
            Label lbl = new Label();
            lbl.Text = "Loading...";
            lbl.Font = new Font("Merriweather 24pt SemiCondensed", 16, FontStyle.Bold);
            lbl.ForeColor = Color.White; // 검정 배경 위에 흰 글자            
            lbl.BackColor = Color.Black;
            lbl.AutoSize = true;

            // 라벨은 위치 계산이 되기 전이므로 Load 이벤트에서 위치 설정
            overlay.Load += (s, args) =>
            {
                lbl.Location = new Point(
                    (overlay.ClientSize.Width - lbl.Width) / 2,
                    (overlay.ClientSize.Height - lbl.Height) / 2
                );
            };

            overlay.Controls.Add(lbl);
        }

        public void showLoading()
        {
            if (overlay == null || overlay.IsDisposed)
            {
                InitOverlay();
            }

            if (overlay.Visible)
            {
                overlay.Hide();
                Cursor.Current = Cursors.Default;
            }
            else
            {
                overlay.Show();
                Cursor.Current = Cursors.WaitCursor;
            }
        }
    }
}
