namespace DebugConsole
{
    partial class MyConsole
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DebugLst = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CleanBtn = new System.Windows.Forms.Button();
            this.CombineCb = new System.Windows.Forms.CheckBox();
            this.ErrorCb = new System.Windows.Forms.CheckBox();
            this.WarringCb = new System.Windows.Forms.CheckBox();
            this.NormalCb = new System.Windows.Forms.CheckBox();
            this.DetailTb = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DebugLst);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DetailTb);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // DebugLst
            // 
            this.DebugLst.BackColor = System.Drawing.Color.DimGray;
            this.DebugLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugLst.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DebugLst.ForeColor = System.Drawing.Color.White;
            this.DebugLst.FormattingEnabled = true;
            this.DebugLst.ItemHeight = 12;
            this.DebugLst.Location = new System.Drawing.Point(0, 33);
            this.DebugLst.Name = "DebugLst";
            this.DebugLst.Size = new System.Drawing.Size(800, 233);
            this.DebugLst.TabIndex = 0;
            this.DebugLst.SelectedIndexChanged += new System.EventHandler(this.DebugLst_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.CleanBtn);
            this.flowLayoutPanel1.Controls.Add(this.CombineCb);
            this.flowLayoutPanel1.Controls.Add(this.ErrorCb);
            this.flowLayoutPanel1.Controls.Add(this.WarringCb);
            this.flowLayoutPanel1.Controls.Add(this.NormalCb);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 33);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // CleanBtn
            // 
            this.CleanBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CleanBtn.Location = new System.Drawing.Point(3, 3);
            this.CleanBtn.Name = "CleanBtn";
            this.CleanBtn.Size = new System.Drawing.Size(75, 26);
            this.CleanBtn.TabIndex = 0;
            this.CleanBtn.Text = "清空";
            this.CleanBtn.UseVisualStyleBackColor = true;
            this.CleanBtn.Click += new System.EventHandler(this.CleanBtn_Click);
            // 
            // CombineCb
            // 
            this.CombineCb.AutoSize = true;
            this.CombineCb.Location = new System.Drawing.Point(89, 8);
            this.CombineCb.Margin = new System.Windows.Forms.Padding(8);
            this.CombineCb.Name = "CombineCb";
            this.CombineCb.Size = new System.Drawing.Size(84, 16);
            this.CombineCb.TabIndex = 1;
            this.CombineCb.Text = "合并重复项";
            this.CombineCb.UseVisualStyleBackColor = true;
            this.CombineCb.CheckedChanged += new System.EventHandler(this.CombineCb_CheckedChanged);
            // 
            // ErrorCb
            // 
            this.ErrorCb.AutoSize = true;
            this.ErrorCb.Checked = true;
            this.ErrorCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ErrorCb.Location = new System.Drawing.Point(189, 8);
            this.ErrorCb.Margin = new System.Windows.Forms.Padding(8);
            this.ErrorCb.Name = "ErrorCb";
            this.ErrorCb.Size = new System.Drawing.Size(48, 16);
            this.ErrorCb.TabIndex = 2;
            this.ErrorCb.Text = "错误";
            this.ErrorCb.UseVisualStyleBackColor = true;
            this.ErrorCb.CheckedChanged += new System.EventHandler(this.ErrorCb_CheckedChanged);
            // 
            // WarringCb
            // 
            this.WarringCb.AutoSize = true;
            this.WarringCb.Checked = true;
            this.WarringCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WarringCb.Location = new System.Drawing.Point(253, 8);
            this.WarringCb.Margin = new System.Windows.Forms.Padding(8);
            this.WarringCb.Name = "WarringCb";
            this.WarringCb.Size = new System.Drawing.Size(48, 16);
            this.WarringCb.TabIndex = 3;
            this.WarringCb.Text = "警告";
            this.WarringCb.UseVisualStyleBackColor = true;
            this.WarringCb.CheckedChanged += new System.EventHandler(this.WarringCb_CheckedChanged);
            // 
            // NormalCb
            // 
            this.NormalCb.AutoSize = true;
            this.NormalCb.Checked = true;
            this.NormalCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NormalCb.Location = new System.Drawing.Point(317, 8);
            this.NormalCb.Margin = new System.Windows.Forms.Padding(8);
            this.NormalCb.Name = "NormalCb";
            this.NormalCb.Size = new System.Drawing.Size(48, 16);
            this.NormalCb.TabIndex = 4;
            this.NormalCb.Text = "普通";
            this.NormalCb.UseVisualStyleBackColor = true;
            this.NormalCb.CheckedChanged += new System.EventHandler(this.NormalCb_CheckedChanged);
            // 
            // DetailTb
            // 
            this.DetailTb.BackColor = System.Drawing.Color.DimGray;
            this.DetailTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailTb.ForeColor = System.Drawing.Color.White;
            this.DetailTb.Location = new System.Drawing.Point(0, 0);
            this.DetailTb.Multiline = true;
            this.DetailTb.Name = "DetailTb";
            this.DetailTb.ReadOnly = true;
            this.DetailTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DetailTb.Size = new System.Drawing.Size(800, 180);
            this.DetailTb.TabIndex = 0;
            // 
            // MyConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MyConsole";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox DebugLst;
        private System.Windows.Forms.TextBox DetailTb;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button CleanBtn;
        private System.Windows.Forms.CheckBox CombineCb;
        private System.Windows.Forms.CheckBox ErrorCb;
        private System.Windows.Forms.CheckBox WarringCb;
        private System.Windows.Forms.CheckBox NormalCb;
    }
}

