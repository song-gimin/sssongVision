namespace sssongVision.Setting
{
    partial class CommunicatorSetting
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
            this.lbMachine = new System.Windows.Forms.Label();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.lbCommType = new System.Windows.Forms.Label();
            this.cbCommType = new System.Windows.Forms.ComboBox();
            this.laIpAddr = new System.Windows.Forms.Label();
            this.txtIpAddr = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMachine
            // 
            this.lbMachine.AutoSize = true;
            this.lbMachine.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbMachine.Location = new System.Drawing.Point(23, 25);
            this.lbMachine.Name = "lbMachine";
            this.lbMachine.Size = new System.Drawing.Size(65, 18);
            this.lbMachine.TabIndex = 0;
            this.lbMachine.Text = "설비명";
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(109, 20);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(222, 28);
            this.txtMachine.TabIndex = 1;
            // 
            // lbCommType
            // 
            this.lbCommType.AutoSize = true;
            this.lbCommType.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbCommType.Location = new System.Drawing.Point(13, 65);
            this.lbCommType.Name = "lbCommType";
            this.lbCommType.Size = new System.Drawing.Size(84, 18);
            this.lbCommType.TabIndex = 2;
            this.lbCommType.Text = "통신타입";
            // 
            // cbCommType
            // 
            this.cbCommType.FormattingEnabled = true;
            this.cbCommType.Location = new System.Drawing.Point(109, 63);
            this.cbCommType.Name = "cbCommType";
            this.cbCommType.Size = new System.Drawing.Size(222, 26);
            this.cbCommType.TabIndex = 3;
            // 
            // laIpAddr
            // 
            this.laIpAddr.AutoSize = true;
            this.laIpAddr.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.laIpAddr.Location = new System.Drawing.Point(21, 106);
            this.laIpAddr.Name = "laIpAddr";
            this.laIpAddr.Size = new System.Drawing.Size(69, 18);
            this.laIpAddr.TabIndex = 4;
            this.laIpAddr.Text = "IP 주소";
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.Location = new System.Drawing.Point(109, 104);
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Size = new System.Drawing.Size(222, 28);
            this.txtIpAddr.TabIndex = 5;
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.Location = new System.Drawing.Point(233, 153);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(98, 33);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // CommunicatorSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtIpAddr);
            this.Controls.Add(this.laIpAddr);
            this.Controls.Add(this.cbCommType);
            this.Controls.Add(this.lbCommType);
            this.Controls.Add(this.txtMachine);
            this.Controls.Add(this.lbMachine);
            this.Name = "CommunicatorSetting";
            this.Size = new System.Drawing.Size(350, 204);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMachine;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.Label lbCommType;
        private System.Windows.Forms.ComboBox cbCommType;
        private System.Windows.Forms.Label laIpAddr;
        private System.Windows.Forms.TextBox txtIpAddr;
        private System.Windows.Forms.Button btnApply;
    }
}
