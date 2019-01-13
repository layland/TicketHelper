namespace TicketHelper
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_showtime = new System.Windows.Forms.Label();
            this.btn_time = new System.Windows.Forms.Button();
            this.tb_address = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnGetColor = new System.Windows.Forms.Button();
            this.mouse_x = new System.Windows.Forms.Label();
            this.mouse_y = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveCmpl = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_compX = new System.Windows.Forms.Label();
            this.label_compY = new System.Windows.Forms.Label();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.btnAutoSelect = new System.Windows.Forms.Button();
            this.btnEndSearch = new System.Windows.Forms.Button();
            this.GrapeNumSelect = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrapeNumSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_showtime
            // 
            this.lb_showtime.AutoSize = true;
            this.lb_showtime.Location = new System.Drawing.Point(13, 29);
            this.lb_showtime.Name = "lb_showtime";
            this.lb_showtime.Size = new System.Drawing.Size(0, 12);
            this.lb_showtime.TabIndex = 0;
            this.lb_showtime.Click += new System.EventHandler(this.lb_showtime_Click);
            // 
            // btn_time
            // 
            this.btn_time.Location = new System.Drawing.Point(19, 20);
            this.btn_time.Name = "btn_time";
            this.btn_time.Size = new System.Drawing.Size(75, 23);
            this.btn_time.TabIndex = 1;
            this.btn_time.Text = "서버시간";
            this.btn_time.UseVisualStyleBackColor = true;
            this.btn_time.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_address
            // 
            this.tb_address.Location = new System.Drawing.Point(104, 20);
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(72, 21);
            this.tb_address.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnGetColor
            // 
            this.btnGetColor.Location = new System.Drawing.Point(19, 68);
            this.btnGetColor.Name = "btnGetColor";
            this.btnGetColor.Size = new System.Drawing.Size(114, 27);
            this.btnGetColor.TabIndex = 3;
            this.btnGetColor.Text = "1. 포도알색깔저장";
            this.btnGetColor.UseVisualStyleBackColor = true;
            this.btnGetColor.Click += new System.EventHandler(this.btnGetColor_click);
            // 
            // mouse_x
            // 
            this.mouse_x.AutoSize = true;
            this.mouse_x.Location = new System.Drawing.Point(248, 298);
            this.mouse_x.Name = "mouse_x";
            this.mouse_x.Size = new System.Drawing.Size(0, 12);
            this.mouse_x.TabIndex = 4;
            // 
            // mouse_y
            // 
            this.mouse_y.AutoSize = true;
            this.mouse_y.Location = new System.Drawing.Point(248, 313);
            this.mouse_y.Name = "mouse_y";
            this.mouse_y.Size = new System.Drawing.Size(0, 12);
            this.mouse_y.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y : ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(240, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(29, 26);
            this.panel1.TabIndex = 7;
            // 
            // btnSaveCmpl
            // 
            this.btnSaveCmpl.Location = new System.Drawing.Point(19, 110);
            this.btnSaveCmpl.Name = "btnSaveCmpl";
            this.btnSaveCmpl.Size = new System.Drawing.Size(114, 24);
            this.btnSaveCmpl.TabIndex = 9;
            this.btnSaveCmpl.Text = "2. 확인위치저장";
            this.btnSaveCmpl.UseVisualStyleBackColor = true;
            this.btnSaveCmpl.Click += new System.EventHandler(this.btnSaveCmplBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "포도알색깔";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "확인버튼";
            // 
            // label_compX
            // 
            this.label_compX.AutoSize = true;
            this.label_compX.Location = new System.Drawing.Point(265, 110);
            this.label_compX.Name = "label_compX";
            this.label_compX.Size = new System.Drawing.Size(0, 12);
            this.label_compX.TabIndex = 12;
            // 
            // label_compY
            // 
            this.label_compY.AutoSize = true;
            this.label_compY.Location = new System.Drawing.Point(265, 130);
            this.label_compY.Name = "label_compY";
            this.label_compY.Size = new System.Drawing.Size(0, 12);
            this.label_compY.TabIndex = 12;
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(19, 149);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(114, 27);
            this.btnStartSearch.TabIndex = 8;
            this.btnStartSearch.Text = "3. 검색시작위치";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // btnAutoSelect
            // 
            this.btnAutoSelect.Location = new System.Drawing.Point(19, 232);
            this.btnAutoSelect.Name = "btnAutoSelect";
            this.btnAutoSelect.Size = new System.Drawing.Size(114, 27);
            this.btnAutoSelect.TabIndex = 8;
            this.btnAutoSelect.Text = "5. 좌석자동선택";
            this.btnAutoSelect.UseVisualStyleBackColor = true;
            this.btnAutoSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnEndSearch
            // 
            this.btnEndSearch.Location = new System.Drawing.Point(19, 193);
            this.btnEndSearch.Name = "btnEndSearch";
            this.btnEndSearch.Size = new System.Drawing.Size(114, 27);
            this.btnEndSearch.TabIndex = 8;
            this.btnEndSearch.Text = "4. 검색끝위치";
            this.btnEndSearch.UseVisualStyleBackColor = true;
            this.btnEndSearch.Click += new System.EventHandler(this.btnEndSearch_Click);
            // 
            // GrapeNumSelect
            // 
            this.GrapeNumSelect.Location = new System.Drawing.Point(197, 20);
            this.GrapeNumSelect.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.GrapeNumSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GrapeNumSelect.Name = "GrapeNumSelect";
            this.GrapeNumSelect.Size = new System.Drawing.Size(32, 21);
            this.GrapeNumSelect.TabIndex = 13;
            this.GrapeNumSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GrapeNumSelect.ValueChanged += new System.EventHandler(this.GrapeNumSelect_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "X :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "Y :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 330);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GrapeNumSelect);
            this.Controls.Add(this.label_compY);
            this.Controls.Add(this.label_compX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveCmpl);
            this.Controls.Add(this.btnEndSearch);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.btnAutoSelect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mouse_y);
            this.Controls.Add(this.mouse_x);
            this.Controls.Add(this.btnGetColor);
            this.Controls.Add(this.tb_address);
            this.Controls.Add(this.btn_time);
            this.Controls.Add(this.lb_showtime);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrapeNumSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_showtime;
        private System.Windows.Forms.Button btn_time;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnGetColor;
        private System.Windows.Forms.Label mouse_x;
        private System.Windows.Forms.Label mouse_y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveCmpl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_compX;
        private System.Windows.Forms.Label label_compY;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Button btnAutoSelect;
        private System.Windows.Forms.Button btnEndSearch;
        private System.Windows.Forms.NumericUpDown GrapeNumSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

