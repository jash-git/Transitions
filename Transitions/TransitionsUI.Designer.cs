namespace Transitions
{
    partial class TransitionsUI
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
            labInfor = new Label();
            SuspendLayout();
            // 
            // labInfor
            // 
            labInfor.Dock = DockStyle.Fill;
            labInfor.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labInfor.Location = new Point(0, 0);
            labInfor.Margin = new Padding(5, 0, 5, 0);
            labInfor.Name = "labInfor";
            labInfor.Size = new Size(360, 90);
            labInfor.TabIndex = 1;
            labInfor.Text = "label1";
            labInfor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TransitionsUI
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(360, 90);
            Controls.Add(labInfor);
            Font = new Font("微軟正黑體", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5);
            Name = "TransitionsUI";
            StartPosition = FormStartPosition.Manual;
            Text = "TransitionsUI";
            TopMost = true;
            Load += TransitionsUI_Load;
            ResumeLayout(false);
        }

        #endregion
        private Label labInfor;
    }
}