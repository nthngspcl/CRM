namespace CRM
{
    partial class Form1
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnStart = new Button();
            btnStop = new Button();
            btnGenerateReport = new Button();
            btnViewReport = new Button();
            txtTaskName = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 45;
            dataGridView1.RowTemplate.Height = 27;
            dataGridView1.Size = new Size(728, 311);
            dataGridView1.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(12, 338);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(124, 34);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnStop.Location = new Point(142, 338);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(128, 34);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerateReport.Location = new Point(289, 338);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(83, 34);
            btnGenerateReport.TabIndex = 3;
            btnGenerateReport.Text = "Отчет";
            btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // btnViewReport
            // 
            btnViewReport.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnViewReport.Location = new Point(390, 338);
            btnViewReport.Name = "btnViewReport";
            btnViewReport.Size = new Size(104, 34);
            btnViewReport.TabIndex = 4;
            btnViewReport.Text = "Отчет";
            btnViewReport.UseVisualStyleBackColor = true;
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(12, 381);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(247, 25);
            txtTaskName.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(275, 384);
            label1.Name = "label1";
            label1.Size = new Size(155, 23);
            label1.TabIndex = 6;
            label1.Text = "Название задания";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 429);
            Controls.Add(label1);
            Controls.Add(txtTaskName);
            Controls.Add(btnViewReport);
            Controls.Add(btnGenerateReport);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnStart;
        private Button btnStop;
        private Button btnGenerateReport;
        private Button btnViewReport;
        private TextBox txtTaskName;
        private Label label1;
    }
}