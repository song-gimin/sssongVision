namespace sssongVision.Property
{
    partial class BinaryProp
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkUse = new System.Windows.Forms.CheckBox();
            this.grpBinary = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbChannel = new System.Windows.Forms.ComboBox();
            this.binRangeTrackbar = new sssongVision.UIControl.RangeTrackbar();
            this.lbHighlight = new System.Windows.Forms.Label();
            this.cbHighlight = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBinMethod = new System.Windows.Forms.ComboBox();
            this.dataGridViewFilter = new System.Windows.Forms.DataGridView();
            this.chkRotatedRect = new System.Windows.Forms.CheckBox();
            this.grpBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // chkUse
            // 
            this.chkUse.AutoSize = true;
            this.chkUse.Checked = true;
            this.chkUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUse.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkUse.Location = new System.Drawing.Point(14, 18);
            this.chkUse.Name = "chkUse";
            this.chkUse.Size = new System.Drawing.Size(72, 22);
            this.chkUse.TabIndex = 2;
            this.chkUse.Text = "검사";
            this.chkUse.UseVisualStyleBackColor = true;
            this.chkUse.CheckedChanged += new System.EventHandler(this.chkUse_CheckedChanged);
            // 
            // grpBinary
            // 
            this.grpBinary.Controls.Add(this.label2);
            this.grpBinary.Controls.Add(this.cbChannel);
            this.grpBinary.Controls.Add(this.binRangeTrackbar);
            this.grpBinary.Controls.Add(this.lbHighlight);
            this.grpBinary.Controls.Add(this.cbHighlight);
            this.grpBinary.Location = new System.Drawing.Point(14, 66);
            this.grpBinary.Name = "grpBinary";
            this.grpBinary.Size = new System.Drawing.Size(353, 210);
            this.grpBinary.TabIndex = 3;
            this.grpBinary.TabStop = false;
            this.grpBinary.Text = "이진화";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "이미지 채널";
            // 
            // cbChannel
            // 
            this.cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChannel.FormattingEnabled = true;
            this.cbChannel.Location = new System.Drawing.Point(127, 116);
            this.cbChannel.Name = "cbChannel";
            this.cbChannel.Size = new System.Drawing.Size(203, 26);
            this.cbChannel.TabIndex = 11;
            this.cbChannel.SelectedIndexChanged += new System.EventHandler(this.cbChannel_SelectedIndexChanged);
            // 
            // binRangeTrackbar
            // 
            this.binRangeTrackbar.Location = new System.Drawing.Point(24, 33);
            this.binRangeTrackbar.Name = "binRangeTrackbar";
            this.binRangeTrackbar.Size = new System.Drawing.Size(300, 74);
            this.binRangeTrackbar.TabIndex = 9;
            this.binRangeTrackbar.ValueLeft = 0;
            this.binRangeTrackbar.ValueRight = 125;
            // 
            // lbHighlight
            // 
            this.lbHighlight.AutoSize = true;
            this.lbHighlight.Location = new System.Drawing.Point(23, 169);
            this.lbHighlight.Name = "lbHighlight";
            this.lbHighlight.Size = new System.Drawing.Size(98, 18);
            this.lbHighlight.TabIndex = 4;
            this.lbHighlight.Text = "하이라이트";
            // 
            // cbHighlight
            // 
            this.cbHighlight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHighlight.FormattingEnabled = true;
            this.cbHighlight.Location = new System.Drawing.Point(127, 163);
            this.cbHighlight.Name = "cbHighlight";
            this.cbHighlight.Size = new System.Drawing.Size(203, 26);
            this.cbHighlight.TabIndex = 5;
            this.cbHighlight.SelectedIndexChanged += new System.EventHandler(this.cbHighlight_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(39, 293);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "검사 타입";
            // 
            // cbBinMethod
            // 
            this.cbBinMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBinMethod.FormattingEnabled = true;
            this.cbBinMethod.Location = new System.Drawing.Point(139, 291);
            this.cbBinMethod.Name = "cbBinMethod";
            this.cbBinMethod.Size = new System.Drawing.Size(203, 26);
            this.cbBinMethod.TabIndex = 6;
            this.cbBinMethod.SelectedIndexChanged += new System.EventHandler(this.cbBinMethod_SelectedIndexChanged);
            // 
            // dataGridViewFilter
            // 
            this.dataGridViewFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilter.Location = new System.Drawing.Point(14, 336);
            this.dataGridViewFilter.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewFilter.Name = "dataGridViewFilter";
            this.dataGridViewFilter.RowHeadersWidth = 82;
            this.dataGridViewFilter.RowTemplate.Height = 37;
            this.dataGridViewFilter.Size = new System.Drawing.Size(353, 248);
            this.dataGridViewFilter.TabIndex = 7;
            this.dataGridViewFilter.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFilter_CellValueChanged);
            this.dataGridViewFilter.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewFilter_CurrentCellDirtyStateChanged);
            // 
            // chkRotatedRect
            // 
            this.chkRotatedRect.AutoSize = true;
            this.chkRotatedRect.Checked = true;
            this.chkRotatedRect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRotatedRect.Location = new System.Drawing.Point(30, 602);
            this.chkRotatedRect.Margin = new System.Windows.Forms.Padding(2);
            this.chkRotatedRect.Name = "chkRotatedRect";
            this.chkRotatedRect.Size = new System.Drawing.Size(124, 22);
            this.chkRotatedRect.TabIndex = 8;
            this.chkRotatedRect.Text = "회전사각형";
            this.chkRotatedRect.UseVisualStyleBackColor = true;
            this.chkRotatedRect.CheckedChanged += new System.EventHandler(this.chkRotatedRect_CheckedChanged);
            // 
            // BinaryProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkRotatedRect);
            this.Controls.Add(this.dataGridViewFilter);
            this.Controls.Add(this.cbBinMethod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpBinary);
            this.Controls.Add(this.chkUse);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BinaryProp";
            this.Size = new System.Drawing.Size(500, 654);
            this.grpBinary.ResumeLayout(false);
            this.grpBinary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkUse;
        private System.Windows.Forms.GroupBox grpBinary;
        private System.Windows.Forms.Label lbHighlight;
        private System.Windows.Forms.ComboBox cbHighlight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBinMethod;
        private System.Windows.Forms.DataGridView dataGridViewFilter;
        private System.Windows.Forms.CheckBox chkRotatedRect;
        private UIControl.RangeTrackbar binRangeTrackbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbChannel;
    }
}
