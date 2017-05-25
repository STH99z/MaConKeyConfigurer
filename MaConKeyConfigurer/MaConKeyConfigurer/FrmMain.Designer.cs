namespace MaConKeyConfigurer
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbSerial = new System.Windows.Forms.GroupBox();
            this.btnHandshake = new System.Windows.Forms.Button();
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbExact = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbExpect = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbData = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSwap = new System.Windows.Forms.Button();
            this.cbAxis = new System.Windows.Forms.ComboBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbHoldThreshold = new System.Windows.Forms.TextBox();
            this.tbReverseMove = new System.Windows.Forms.TextBox();
            this.tbFrameMove = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMapping = new System.Windows.Forms.TextBox();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSide = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgMid = new System.Windows.Forms.DataGridView();
            this.keyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mappingColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbStat = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbSerial.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMid)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSerial
            // 
            this.gbSerial.Controls.Add(this.btnHandshake);
            this.gbSerial.Controls.Add(this.btnRefreshPorts);
            this.gbSerial.Controls.Add(this.label1);
            this.gbSerial.Controls.Add(this.cbPort);
            this.gbSerial.Location = new System.Drawing.Point(12, 12);
            this.gbSerial.Name = "gbSerial";
            this.gbSerial.Size = new System.Drawing.Size(200, 74);
            this.gbSerial.TabIndex = 0;
            this.gbSerial.TabStop = false;
            this.gbSerial.Text = "串口";
            // 
            // btnHandshake
            // 
            this.btnHandshake.Location = new System.Drawing.Point(38, 43);
            this.btnHandshake.Name = "btnHandshake";
            this.btnHandshake.Size = new System.Drawing.Size(75, 23);
            this.btnHandshake.TabIndex = 1;
            this.btnHandshake.Text = "连接";
            this.btnHandshake.UseVisualStyleBackColor = true;
            this.btnHandshake.Click += new System.EventHandler(this.btnHandshake_Click);
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Location = new System.Drawing.Point(119, 43);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshPorts.TabIndex = 2;
            this.btnRefreshPorts.Text = "刷新Ports";
            this.btnRefreshPorts.UseVisualStyleBackColor = true;
            this.btnRefreshPorts.Click += new System.EventHandler(this.btnRefreshPorts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前：";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(54, 17);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(140, 20);
            this.cbPort.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbExact);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbExpect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbData);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 181);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据";
            // 
            // lbExact
            // 
            this.lbExact.AutoSize = true;
            this.lbExact.Location = new System.Drawing.Point(72, 32);
            this.lbExact.Name = "lbExact";
            this.lbExact.Size = new System.Drawing.Size(11, 12);
            this.lbExact.TabIndex = 4;
            this.lbExact.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "实际大小:";
            // 
            // lbExpect
            // 
            this.lbExpect.AutoSize = true;
            this.lbExpect.Location = new System.Drawing.Point(72, 17);
            this.lbExpect.Name = "lbExpect";
            this.lbExpect.Size = new System.Drawing.Size(11, 12);
            this.lbExpect.TabIndex = 2;
            this.lbExpect.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "预期大小:";
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(9, 47);
            this.tbData.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(185, 123);
            this.tbData.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnSwap);
            this.groupBox2.Controls.Add(this.cbAxis);
            this.groupBox2.Controls.Add(this.pb);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbHoldThreshold);
            this.groupBox2.Controls.Add(this.tbReverseMove);
            this.groupBox2.Controls.Add(this.tbFrameMove);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tbMapping);
            this.groupBox2.Controls.Add(this.cbStyle);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbSide);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dgMid);
            this.groupBox2.Controls.Add(this.lbStat);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(218, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 261);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "按键设置";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(253, 227);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 23);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "保存设置";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSwap
            // 
            this.btnSwap.Enabled = false;
            this.btnSwap.Location = new System.Drawing.Point(354, 227);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(94, 23);
            this.btnSwap.TabIndex = 19;
            this.btnSwap.Text = "侧键左右交换";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // cbAxis
            // 
            this.cbAxis.Enabled = false;
            this.cbAxis.FormattingEnabled = true;
            this.cbAxis.Items.AddRange(new object[] {
            "X",
            "Y"});
            this.cbAxis.Location = new System.Drawing.Point(263, 113);
            this.cbAxis.Name = "cbAxis";
            this.cbAxis.Size = new System.Drawing.Size(185, 20);
            this.cbAxis.TabIndex = 8;
            this.cbAxis.Text = "X";
            this.cbAxis.SelectedIndexChanged += new System.EventHandler(this.cbAxis_SelectedIndexChanged);
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.White;
            this.pb.Location = new System.Drawing.Point(218, 221);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(29, 29);
            this.pb.TabIndex = 18;
            this.pb.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(216, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "长按触发反搓时间(ms)：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(216, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "反搓距离：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(216, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "单帧距离：";
            // 
            // tbHoldThreshold
            // 
            this.tbHoldThreshold.Enabled = false;
            this.tbHoldThreshold.Location = new System.Drawing.Point(354, 194);
            this.tbHoldThreshold.Name = "tbHoldThreshold";
            this.tbHoldThreshold.Size = new System.Drawing.Size(94, 21);
            this.tbHoldThreshold.TabIndex = 11;
            this.tbHoldThreshold.Text = "100";
            this.tbHoldThreshold.TextChanged += new System.EventHandler(this.tbHoldThreshold_TextChanged);
            // 
            // tbReverseMove
            // 
            this.tbReverseMove.Enabled = false;
            this.tbReverseMove.Location = new System.Drawing.Point(284, 167);
            this.tbReverseMove.Name = "tbReverseMove";
            this.tbReverseMove.Size = new System.Drawing.Size(164, 21);
            this.tbReverseMove.TabIndex = 10;
            this.tbReverseMove.Text = "-100";
            this.tbReverseMove.TextChanged += new System.EventHandler(this.tbReverseMove_TextChanged);
            // 
            // tbFrameMove
            // 
            this.tbFrameMove.Enabled = false;
            this.tbFrameMove.Location = new System.Drawing.Point(284, 140);
            this.tbFrameMove.Name = "tbFrameMove";
            this.tbFrameMove.Size = new System.Drawing.Size(164, 21);
            this.tbFrameMove.TabIndex = 9;
            this.tbFrameMove.Text = "1";
            this.tbFrameMove.TextChanged += new System.EventHandler(this.tbFrameMove_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "轴向：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "映射：";
            // 
            // tbMapping
            // 
            this.tbMapping.Enabled = false;
            this.tbMapping.Location = new System.Drawing.Point(263, 86);
            this.tbMapping.Name = "tbMapping";
            this.tbMapping.Size = new System.Drawing.Size(185, 21);
            this.tbMapping.TabIndex = 7;
            this.tbMapping.TextChanged += new System.EventHandler(this.tbMapping_TextChanged);
            // 
            // cbStyle
            // 
            this.cbStyle.Enabled = false;
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Items.AddRange(new object[] {
            "按键（默认）",
            "鼠标移动",
            "鼠标移动，松开时反向"});
            this.cbStyle.Location = new System.Drawing.Point(263, 60);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(185, 20);
            this.cbStyle.TabIndex = 6;
            this.cbStyle.SelectedIndexChanged += new System.EventHandler(this.cbStyle_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "模式：";
            // 
            // cbSide
            // 
            this.cbSide.Enabled = false;
            this.cbSide.FormattingEnabled = true;
            this.cbSide.Items.AddRange(new object[] {
            "侧键1（左）",
            "侧键2（右）"});
            this.cbSide.Location = new System.Drawing.Point(263, 34);
            this.cbSide.Name = "cbSide";
            this.cbSide.Size = new System.Drawing.Size(185, 20);
            this.cbSide.TabIndex = 5;
            this.cbSide.SelectedIndexChanged += new System.EventHandler(this.cbSide_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "侧键：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 37);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "主键：";
            // 
            // dgMid
            // 
            this.dgMid.AllowUserToDeleteRows = false;
            this.dgMid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyColumn,
            this.mappingColumn});
            this.dgMid.Enabled = false;
            this.dgMid.Location = new System.Drawing.Point(6, 57);
            this.dgMid.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.dgMid.Name = "dgMid";
            this.dgMid.RowHeadersVisible = false;
            this.dgMid.RowTemplate.Height = 23;
            this.dgMid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgMid.Size = new System.Drawing.Size(204, 193);
            this.dgMid.TabIndex = 4;
            // 
            // keyColumn
            // 
            this.keyColumn.Frozen = true;
            this.keyColumn.HeaderText = "按键(左到右)";
            this.keyColumn.Name = "keyColumn";
            this.keyColumn.ReadOnly = true;
            // 
            // mappingColumn
            // 
            this.mappingColumn.HeaderText = "映射";
            this.mappingColumn.Name = "mappingColumn";
            // 
            // lbStat
            // 
            this.lbStat.AutoSize = true;
            this.lbStat.Location = new System.Drawing.Point(77, 17);
            this.lbStat.Name = "lbStat";
            this.lbStat.Size = new System.Drawing.Size(29, 12);
            this.lbStat.TabIndex = 1;
            this.lbStat.Text = "NULL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "目前状态：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 282);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSerial);
            this.Name = "FrmMain";
            this.Text = "Malody Controller Key Configurer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.gbSerial.ResumeLayout(false);
            this.gbSerial.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Button btnRefreshPorts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHandshake;
        private System.Windows.Forms.Label lbExact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbExpect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSide;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgMid;
        private System.Windows.Forms.Label lbStat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbHoldThreshold;
        private System.Windows.Forms.TextBox tbReverseMove;
        private System.Windows.Forms.TextBox tbFrameMove;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMapping;
        private System.Windows.Forms.ComboBox cbStyle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mappingColumn;
        private System.Windows.Forms.ComboBox cbAxis;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Timer timer1;
    }
}

