namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            label1 = new Label();
            label2 = new Label();
            loadexistingcomboBox = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 41);
            label1.Name = "label1";
            label1.Size = new Size(295, 37);
            label1.TabIndex = 0;
            label1.Text = "Tournament Dashboard";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(83, 118);
            label2.Name = "label2";
            label2.Size = new Size(236, 28);
            label2.TabIndex = 1;
            label2.Text = "Load Existing Tournament";
            // 
            // loadexistingcomboBox
            // 
            loadexistingcomboBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            loadexistingcomboBox.FormattingEnabled = true;
            loadexistingcomboBox.Location = new Point(53, 161);
            loadexistingcomboBox.Name = "loadexistingcomboBox";
            loadexistingcomboBox.Size = new Size(295, 36);
            loadexistingcomboBox.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(106, 213);
            button1.Name = "button1";
            button1.Size = new Size(184, 39);
            button1.TabIndex = 3;
            button1.Text = "Load Tournament";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(94, 274);
            button2.Name = "button2";
            button2.Size = new Size(213, 64);
            button2.TabIndex = 4;
            button2.Text = "Create Tournament";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // TournamentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 384);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(loadexistingcomboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TournamentDashboardForm";
            Text = "TournamentDashboardForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox loadexistingcomboBox;
        private Button button1;
        private Button button2;
    }
}