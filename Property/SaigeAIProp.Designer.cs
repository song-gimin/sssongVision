namespace sssongVision.Property
{
    partial class SaigeAIProp
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
            this.cbModelType = new System.Windows.Forms.ComboBox();
            this.txtModelPath = new System.Windows.Forms.MaskedTextBox();
            this.btnSelectModel = new System.Windows.Forms.Button();
            this.btnInspModel = new System.Windows.Forms.Button();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.labelArea = new System.Windows.Forms.Label();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).BeginInit();
            this.SuspendLayout();
            // 
            // cbModelType
            // 
            this.cbModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModelType.FormattingEnabled = true;
            this.cbModelType.Items.AddRange(new object[] {
            "CLS",
            "DET",
            "SEG"});
            this.cbModelType.Location = new System.Drawing.Point(13, 59);
            this.cbModelType.Margin = new System.Windows.Forms.Padding(2);
            this.cbModelType.Name = "cbModelType";
            this.cbModelType.Size = new System.Drawing.Size(166, 26);
            this.cbModelType.TabIndex = 1;
            this.cbModelType.SelectedIndexChanged += new System.EventHandler(this.cbModelType_SelectedIndexChanged);
            // 
            // txtModelPath
            // 
            this.txtModelPath.Location = new System.Drawing.Point(13, 158);
            this.txtModelPath.Name = "txtModelPath";
            this.txtModelPath.Size = new System.Drawing.Size(276, 28);
            this.txtModelPath.TabIndex = 5;
            // 
            // btnSelectModel
            // 
            this.btnSelectModel.Location = new System.Drawing.Point(13, 101);
            this.btnSelectModel.Name = "btnSelectModel";
            this.btnSelectModel.Size = new System.Drawing.Size(85, 45);
            this.btnSelectModel.TabIndex = 6;
            this.btnSelectModel.Text = "선택";
            this.btnSelectModel.UseVisualStyleBackColor = true;
            this.btnSelectModel.Click += new System.EventHandler(this.btnSelectModel_Click);
            // 
            // btnInspModel
            // 
            this.btnInspModel.Location = new System.Drawing.Point(206, 101);
            this.btnInspModel.Name = "btnInspModel";
            this.btnInspModel.Size = new System.Drawing.Size(85, 45);
            this.btnInspModel.TabIndex = 7;
            this.btnInspModel.Text = "적용";
            this.btnInspModel.UseVisualStyleBackColor = true;
            this.btnInspModel.Click += new System.EventHandler(this.btnInspModel_Click);
            // 
            // numArea
            // 
            this.numArea.Location = new System.Drawing.Point(77, 208);
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(120, 28);
            this.numArea.TabIndex = 9;
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelArea.Location = new System.Drawing.Point(16, 212);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(50, 18);
            this.labelArea.TabIndex = 10;
            this.labelArea.Text = "Area";
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Location = new System.Drawing.Point(110, 101);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(85, 45);
            this.btnLoadModel.TabIndex = 11;
            this.btnLoadModel.Text = "로딩";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Model";
            // 
            // SaigeAIProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadModel);
            this.Controls.Add(this.labelArea);
            this.Controls.Add(this.numArea);
            this.Controls.Add(this.btnInspModel);
            this.Controls.Add(this.btnSelectModel);
            this.Controls.Add(this.txtModelPath);
            this.Controls.Add(this.cbModelType);
            this.Name = "SaigeAIProp";
            this.Size = new System.Drawing.Size(462, 450);
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbModelType;
        private System.Windows.Forms.MaskedTextBox txtModelPath;
        private System.Windows.Forms.Button btnSelectModel;
        private System.Windows.Forms.Button btnInspModel;
        private System.Windows.Forms.NumericUpDown numArea;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Label label1;
    }
}
