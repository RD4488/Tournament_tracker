namespace TrackerUI
{
    partial class CreateTournamentForm
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
            tournamentnametextBox = new TextBox();
            label3 = new Label();
            entryfeetextBox = new TextBox();
            label4 = new Label();
            selectteamcomboBox = new ComboBox();
            createnewlinkLabel = new LinkLabel();
            addteambutton = new Button();
            createprizebutton = new Button();
            tournamentplayerslistBox = new ListBox();
            label5 = new Label();
            tournamnetplayerdeletebutton = new Button();
            prizelistdeletebutton = new Button();
            label6 = new Label();
            createTournamentbutton = new Button();
            prizeslistBox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(35, 33);
            label1.Name = "label1";
            label1.Size = new Size(177, 28);
            label1.TabIndex = 0;
            label1.Text = "Create Tournament";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(35, 91);
            label2.Name = "label2";
            label2.Size = new Size(141, 20);
            label2.TabIndex = 1;
            label2.Text = "Tournament Name";
            // 
            // tournamentnametextBox
            // 
            tournamentnametextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentnametextBox.Location = new Point(35, 115);
            tournamentnametextBox.Name = "tournamentnametextBox";
            tournamentnametextBox.Size = new Size(195, 26);
            tournamentnametextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(35, 155);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 3;
            label3.Text = "Entry Fee";
            // 
            // entryfeetextBox
            // 
            entryfeetextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            entryfeetextBox.Location = new Point(115, 157);
            entryfeetextBox.Name = "entryfeetextBox";
            entryfeetextBox.Size = new Size(115, 26);
            entryfeetextBox.TabIndex = 4;
            entryfeetextBox.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(35, 195);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 5;
            label4.Text = "Select Team";
            // 
            // selectteamcomboBox
            // 
            selectteamcomboBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            selectteamcomboBox.FormattingEnabled = true;
            selectteamcomboBox.Location = new Point(35, 219);
            selectteamcomboBox.Name = "selectteamcomboBox";
            selectteamcomboBox.Size = new Size(195, 28);
            selectteamcomboBox.TabIndex = 6;
            // 
            // createnewlinkLabel
            // 
            createnewlinkLabel.AutoSize = true;
            createnewlinkLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            createnewlinkLabel.Location = new Point(139, 195);
            createnewlinkLabel.Name = "createnewlinkLabel";
            createnewlinkLabel.Size = new Size(92, 20);
            createnewlinkLabel.TabIndex = 7;
            createnewlinkLabel.TabStop = true;
            createnewlinkLabel.Text = "Create New";
            createnewlinkLabel.LinkClicked += createnewlinkLabel_LinkClicked;
            // 
            // addteambutton
            // 
            addteambutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addteambutton.Location = new Point(80, 265);
            addteambutton.Name = "addteambutton";
            addteambutton.Size = new Size(113, 28);
            addteambutton.TabIndex = 8;
            addteambutton.Text = "Add Team";
            addteambutton.UseVisualStyleBackColor = true;
            addteambutton.Click += addteambutton_Click;
            // 
            // createprizebutton
            // 
            createprizebutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            createprizebutton.Location = new Point(70, 311);
            createprizebutton.Name = "createprizebutton";
            createprizebutton.Size = new Size(134, 38);
            createprizebutton.TabIndex = 9;
            createprizebutton.Text = "Create Prize";
            createprizebutton.UseVisualStyleBackColor = true;
            createprizebutton.Click += createprizebutton_Click;
            // 
            // tournamentplayerslistBox
            // 
            tournamentplayerslistBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentplayerslistBox.FormattingEnabled = true;
            tournamentplayerslistBox.ItemHeight = 20;
            tournamentplayerslistBox.Location = new Point(297, 105);
            tournamentplayerslistBox.Name = "tournamentplayerslistBox";
            tournamentplayerslistBox.Size = new Size(197, 104);
            tournamentplayerslistBox.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(297, 81);
            label5.Name = "label5";
            label5.Size = new Size(115, 20);
            label5.TabIndex = 11;
            label5.Text = "Teams / Playes";
            // 
            // tournamnetplayerdeletebutton
            // 
            tournamnetplayerdeletebutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tournamnetplayerdeletebutton.Location = new Point(523, 116);
            tournamnetplayerdeletebutton.Name = "tournamnetplayerdeletebutton";
            tournamnetplayerdeletebutton.Size = new Size(85, 59);
            tournamnetplayerdeletebutton.TabIndex = 12;
            tournamnetplayerdeletebutton.Text = "Delete\r\nSelected\r\n";
            tournamnetplayerdeletebutton.UseVisualStyleBackColor = true;
            tournamnetplayerdeletebutton.Click += tournamnetplayerdeletebutton_Click;
            // 
            // prizelistdeletebutton
            // 
            prizelistdeletebutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            prizelistdeletebutton.Location = new Point(523, 265);
            prizelistdeletebutton.Name = "prizelistdeletebutton";
            prizelistdeletebutton.Size = new Size(85, 64);
            prizelistdeletebutton.TabIndex = 15;
            prizelistdeletebutton.Text = "Delete\r\nSelected\r\n";
            prizelistdeletebutton.UseVisualStyleBackColor = true;
            prizelistdeletebutton.Click += prizelistdeletebutton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(297, 221);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 14;
            label6.Text = "Prizes";
            // 
            // createTournamentbutton
            // 
            createTournamentbutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            createTournamentbutton.Location = new Point(238, 378);
            createTournamentbutton.Name = "createTournamentbutton";
            createTournamentbutton.Size = new Size(174, 44);
            createTournamentbutton.TabIndex = 16;
            createTournamentbutton.Text = "Create Tournament";
            createTournamentbutton.UseVisualStyleBackColor = true;
            createTournamentbutton.Click += createTournamentbutton_Click;
            // 
            // prizeslistBox
            // 
            prizeslistBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            prizeslistBox.FormattingEnabled = true;
            prizeslistBox.ItemHeight = 20;
            prizeslistBox.Location = new Point(297, 245);
            prizeslistBox.Name = "prizeslistBox";
            prizeslistBox.Size = new Size(197, 104);
            prizeslistBox.TabIndex = 17;
            // 
            // CreateTournamentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 463);
            Controls.Add(prizeslistBox);
            Controls.Add(createTournamentbutton);
            Controls.Add(prizelistdeletebutton);
            Controls.Add(label6);
            Controls.Add(tournamnetplayerdeletebutton);
            Controls.Add(label5);
            Controls.Add(tournamentplayerslistBox);
            Controls.Add(createprizebutton);
            Controls.Add(addteambutton);
            Controls.Add(createnewlinkLabel);
            Controls.Add(selectteamcomboBox);
            Controls.Add(label4);
            Controls.Add(entryfeetextBox);
            Controls.Add(label3);
            Controls.Add(tournamentnametextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateTournamentForm";
            Text = "CreateTournamentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tournamentnametextBox;
        private Label label3;
        private TextBox entryfeetextBox;
        private Label label4;
        private ComboBox selectteamcomboBox;
        private LinkLabel createnewlinkLabel;
        private Button addteambutton;
        private Button createprizebutton;
        private ListBox tournamentplayerslistBox;
        private Label label5;
        private Button tournamnetplayerdeletebutton;
        private Button prizelistdeletebutton;
        private Label label6;
        private Button createTournamentbutton;
        private ListBox prizeslistBox;
    }
}