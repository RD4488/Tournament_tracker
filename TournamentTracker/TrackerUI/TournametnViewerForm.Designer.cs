namespace TrackerUI
{
    partial class TournametnViewerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            unplayedonlycheckBox = new CheckBox();
            matchuplistBox = new ListBox();
            tournamentlabel = new Label();
            roundcomboBox = new ComboBox();
            teamonescoretextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            teamonelabel = new Label();
            label3 = new Label();
            label4 = new Label();
            teamtwolabel = new Label();
            teamtwoscoretextBox = new TextBox();
            label5 = new Label();
            scorebutton = new Button();
            SuspendLayout();
            // 
            // unplayedonlycheckBox
            // 
            unplayedonlycheckBox.AutoSize = true;
            unplayedonlycheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            unplayedonlycheckBox.Location = new Point(119, 115);
            unplayedonlycheckBox.Name = "unplayedonlycheckBox";
            unplayedonlycheckBox.Size = new Size(132, 25);
            unplayedonlycheckBox.TabIndex = 0;
            unplayedonlycheckBox.Text = "Unplayed Only";
            unplayedonlycheckBox.UseVisualStyleBackColor = true;
            unplayedonlycheckBox.CheckedChanged += unplayedonlycheckBox_CheckedChanged;
            // 
            // matchuplistBox
            // 
            matchuplistBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            matchuplistBox.FormattingEnabled = true;
            matchuplistBox.ItemHeight = 21;
            matchuplistBox.Location = new Point(25, 155);
            matchuplistBox.Name = "matchuplistBox";
            matchuplistBox.Size = new Size(215, 130);
            matchuplistBox.TabIndex = 1;
            matchuplistBox.SelectedIndexChanged += matchuplistBox_SelectedIndexChanged;
            // 
            // tournamentlabel
            // 
            tournamentlabel.AutoSize = true;
            tournamentlabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentlabel.Location = new Point(119, 23);
            tournamentlabel.Name = "tournamentlabel";
            tournamentlabel.Size = new Size(67, 21);
            tournamentlabel.TabIndex = 2;
            tournamentlabel.Text = "<none>";
            // 
            // roundcomboBox
            // 
            roundcomboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            roundcomboBox.FormattingEnabled = true;
            roundcomboBox.Location = new Point(119, 61);
            roundcomboBox.Name = "roundcomboBox";
            roundcomboBox.Size = new Size(121, 29);
            roundcomboBox.TabIndex = 3;
            roundcomboBox.SelectedIndexChanged += roundcomboBox_SelectedIndexChanged;
            // 
            // teamonescoretextBox
            // 
            teamonescoretextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamonescoretextBox.Location = new Point(348, 155);
            teamonescoretextBox.Name = "teamonescoretextBox";
            teamonescoretextBox.Size = new Size(100, 29);
            teamonescoretextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(25, 23);
            label2.Name = "label2";
            label2.Size = new Size(96, 21);
            label2.TabIndex = 5;
            label2.Text = "Tournament:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(57, 64);
            label1.Name = "label1";
            label1.Size = new Size(56, 21);
            label1.TabIndex = 6;
            label1.Text = "Round";
            // 
            // teamonelabel
            // 
            teamonelabel.AutoSize = true;
            teamonelabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamonelabel.Location = new Point(293, 119);
            teamonelabel.Name = "teamonelabel";
            teamonelabel.Size = new Size(97, 21);
            teamonelabel.TabIndex = 7;
            teamonelabel.Text = "<team one>";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(293, 158);
            label3.Name = "label3";
            label3.Size = new Size(49, 21);
            label3.TabIndex = 8;
            label3.Text = "Score";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(293, 259);
            label4.Name = "label4";
            label4.Size = new Size(49, 21);
            label4.TabIndex = 11;
            label4.Text = "Score";
            // 
            // teamtwolabel
            // 
            teamtwolabel.AutoSize = true;
            teamtwolabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamtwolabel.Location = new Point(293, 220);
            teamtwolabel.Name = "teamtwolabel";
            teamtwolabel.Size = new Size(97, 21);
            teamtwolabel.TabIndex = 10;
            teamtwolabel.Text = "<team two>";
            // 
            // teamtwoscoretextBox
            // 
            teamtwoscoretextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamtwoscoretextBox.Location = new Point(348, 256);
            teamtwoscoretextBox.Name = "teamtwoscoretextBox";
            teamtwoscoretextBox.Size = new Size(100, 29);
            teamtwoscoretextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(335, 192);
            label5.Name = "label5";
            label5.Size = new Size(41, 21);
            label5.TabIndex = 12;
            label5.Text = "-VS-";
            // 
            // scorebutton
            // 
            scorebutton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            scorebutton.Location = new Point(471, 181);
            scorebutton.Name = "scorebutton";
            scorebutton.Size = new Size(83, 37);
            scorebutton.TabIndex = 13;
            scorebutton.Text = "Score";
            scorebutton.UseVisualStyleBackColor = true;
            scorebutton.Click += scorebutton_Click;
            // 
            // TournametnViewerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 339);
            Controls.Add(scorebutton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(teamtwolabel);
            Controls.Add(teamtwoscoretextBox);
            Controls.Add(label3);
            Controls.Add(teamonelabel);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(teamonescoretextBox);
            Controls.Add(roundcomboBox);
            Controls.Add(tournamentlabel);
            Controls.Add(matchuplistBox);
            Controls.Add(unplayedonlycheckBox);
            Name = "TournametnViewerForm";
            Text = "Tournament Viewers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox unplayedonlycheckBox;
        private ListBox matchuplistBox;
        private Label tournamentlabel;
        private ComboBox roundcomboBox;
        private TextBox teamonescoretextBox;
        private Label label2;
        private Label label1;
        private Label teamonelabel;
        private Label label3;
        private Label label4;
        private Label teamtwolabel;
        private TextBox teamtwoscoretextBox;
        private Label label5;
        private Button scorebutton;
    }
}