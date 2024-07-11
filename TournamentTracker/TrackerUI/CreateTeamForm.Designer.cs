namespace TrackerUI
{
    partial class CreateTeamForm
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
            teamnametextBox = new TextBox();
            label2 = new Label();
            selectteamcomboBox = new ComboBox();
            label4 = new Label();
            addteambutton = new Button();
            groupBox1 = new GroupBox();
            creatememberbutton = new Button();
            emailtextBox = new TextBox();
            label7 = new Label();
            cellphonetextBox = new TextBox();
            label6 = new Label();
            lastnametextBox = new TextBox();
            label5 = new Label();
            firstnametextBox = new TextBox();
            label3 = new Label();
            teammemberslistBox = new ListBox();
            tournamnetplayerdeletebutton = new Button();
            createTeambutton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(33, 38);
            label1.Name = "label1";
            label1.Size = new Size(118, 28);
            label1.TabIndex = 0;
            label1.Text = "Create Team";
            // 
            // teamnametextBox
            // 
            teamnametextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamnametextBox.Location = new Point(33, 96);
            teamnametextBox.Name = "teamnametextBox";
            teamnametextBox.Size = new Size(195, 26);
            teamnametextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(33, 72);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 3;
            label2.Text = "Team Name";
            // 
            // selectteamcomboBox
            // 
            selectteamcomboBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            selectteamcomboBox.FormattingEnabled = true;
            selectteamcomboBox.Location = new Point(33, 154);
            selectteamcomboBox.Name = "selectteamcomboBox";
            selectteamcomboBox.Size = new Size(195, 28);
            selectteamcomboBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(33, 130);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 8;
            label4.Text = "Select Team";
            // 
            // addteambutton
            // 
            addteambutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            addteambutton.Location = new Point(66, 198);
            addteambutton.Name = "addteambutton";
            addteambutton.Size = new Size(118, 35);
            addteambutton.TabIndex = 10;
            addteambutton.Text = "Add Member";
            addteambutton.UseVisualStyleBackColor = true;
            addteambutton.Click += addteambutton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(creatememberbutton);
            groupBox1.Controls.Add(emailtextBox);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cellphonetextBox);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lastnametextBox);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(firstnametextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(33, 249);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(227, 211);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add New Member";
            // 
            // creatememberbutton
            // 
            creatememberbutton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            creatememberbutton.Location = new Point(45, 169);
            creatememberbutton.Name = "creatememberbutton";
            creatememberbutton.Size = new Size(141, 35);
            creatememberbutton.TabIndex = 12;
            creatememberbutton.Text = "Create Member";
            creatememberbutton.UseVisualStyleBackColor = true;
            creatememberbutton.Click += creatememberbutton_Click;
            // 
            // emailtextBox
            // 
            emailtextBox.Location = new Point(99, 99);
            emailtextBox.Name = "emailtextBox";
            emailtextBox.Size = new Size(123, 26);
            emailtextBox.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(6, 102);
            label7.Name = "label7";
            label7.Size = new Size(48, 21);
            label7.TabIndex = 18;
            label7.Text = "Email";
            // 
            // cellphonetextBox
            // 
            cellphonetextBox.Location = new Point(98, 134);
            cellphonetextBox.Name = "cellphonetextBox";
            cellphonetextBox.Size = new Size(123, 26);
            cellphonetextBox.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(6, 137);
            label6.Name = "label6";
            label6.Size = new Size(84, 21);
            label6.TabIndex = 16;
            label6.Text = "Cell Phone";
            // 
            // lastnametextBox
            // 
            lastnametextBox.Location = new Point(98, 64);
            lastnametextBox.Name = "lastnametextBox";
            lastnametextBox.Size = new Size(123, 26);
            lastnametextBox.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(6, 67);
            label5.Name = "label5";
            label5.Size = new Size(84, 21);
            label5.TabIndex = 14;
            label5.Text = "Last Name";
            // 
            // firstnametextBox
            // 
            firstnametextBox.Location = new Point(98, 31);
            firstnametextBox.Name = "firstnametextBox";
            firstnametextBox.Size = new Size(123, 26);
            firstnametextBox.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 34);
            label3.Name = "label3";
            label3.Size = new Size(86, 21);
            label3.TabIndex = 12;
            label3.Text = "First Name";
            // 
            // teammemberslistBox
            // 
            teammemberslistBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teammemberslistBox.FormattingEnabled = true;
            teammemberslistBox.ItemHeight = 20;
            teammemberslistBox.Location = new Point(279, 96);
            teammemberslistBox.Name = "teammemberslistBox";
            teammemberslistBox.Size = new Size(220, 364);
            teammemberslistBox.TabIndex = 12;
            // 
            // tournamnetplayerdeletebutton
            // 
            tournamnetplayerdeletebutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tournamnetplayerdeletebutton.Location = new Point(543, 249);
            tournamnetplayerdeletebutton.Name = "tournamnetplayerdeletebutton";
            tournamnetplayerdeletebutton.Size = new Size(85, 55);
            tournamnetplayerdeletebutton.TabIndex = 13;
            tournamnetplayerdeletebutton.Text = "Delete\r\nSelected\r\n";
            tournamnetplayerdeletebutton.UseVisualStyleBackColor = true;
            tournamnetplayerdeletebutton.Click += tournamnetplayerdeletebutton_Click;
            // 
            // createTeambutton
            // 
            createTeambutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            createTeambutton.Location = new Point(232, 481);
            createTeambutton.Name = "createTeambutton";
            createTeambutton.Size = new Size(174, 44);
            createTeambutton.TabIndex = 17;
            createTeambutton.Text = "Create Team";
            createTeambutton.UseVisualStyleBackColor = true;
            createTeambutton.Click += createTeambutton_Click;
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 540);
            Controls.Add(createTeambutton);
            Controls.Add(tournamnetplayerdeletebutton);
            Controls.Add(teammemberslistBox);
            Controls.Add(groupBox1);
            Controls.Add(addteambutton);
            Controls.Add(selectteamcomboBox);
            Controls.Add(label4);
            Controls.Add(teamnametextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateTeamForm";
            Text = "CreateTeamForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox teamnametextBox;
        private Label label2;
        private ComboBox selectteamcomboBox;
        private Label label4;
        private Button addteambutton;
        private GroupBox groupBox1;
        private Button creatememberbutton;
        private TextBox emailtextBox;
        private Label label7;
        private TextBox cellphonetextBox;
        private Label label6;
        private TextBox lastnametextBox;
        private Label label5;
        private TextBox firstnametextBox;
        private Label label3;
        private ListBox teammemberslistBox;
        private Button tournamnetplayerdeletebutton;
        private Button createTeambutton;
    }
}