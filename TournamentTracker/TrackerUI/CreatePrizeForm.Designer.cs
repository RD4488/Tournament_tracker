namespace TrackerUI
{
    partial class CreatePrizeForm
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
            label3 = new Label();
            placenumbertextBox = new TextBox();
            label2 = new Label();
            prizepercantagetextBox = new TextBox();
            label4 = new Label();
            placeamounttextBox = new TextBox();
            label5 = new Label();
            placenametextBox = new TextBox();
            label6 = new Label();
            createPrizebutton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(35, 41);
            label1.Name = "label1";
            label1.Size = new Size(115, 28);
            label1.TabIndex = 1;
            label1.Text = "Create Prize";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(46, 92);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 10;
            label3.Text = "Place Number";
            // 
            // placenumbertextBox
            // 
            placenumbertextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            placenumbertextBox.Location = new Point(160, 89);
            placenumbertextBox.Name = "placenumbertextBox";
            placenumbertextBox.Size = new Size(128, 29);
            placenumbertextBox.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(46, 275);
            label2.Name = "label2";
            label2.Size = new Size(124, 21);
            label2.TabIndex = 12;
            label2.Text = "Prize Percantage";
            // 
            // prizepercantagetextBox
            // 
            prizepercantagetextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            prizepercantagetextBox.Location = new Point(176, 272);
            prizepercantagetextBox.Name = "prizepercantagetextBox";
            prizepercantagetextBox.Size = new Size(112, 29);
            prizepercantagetextBox.TabIndex = 11;
            prizepercantagetextBox.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(46, 182);
            label4.Name = "label4";
            label4.Size = new Size(106, 21);
            label4.TabIndex = 14;
            label4.Text = "Place Amount";
            // 
            // placeamounttextBox
            // 
            placeamounttextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            placeamounttextBox.Location = new Point(160, 179);
            placeamounttextBox.Name = "placeamounttextBox";
            placeamounttextBox.Size = new Size(128, 29);
            placeamounttextBox.TabIndex = 13;
            placeamounttextBox.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(46, 136);
            label5.Name = "label5";
            label5.Size = new Size(92, 21);
            label5.TabIndex = 16;
            label5.Text = "Place Name";
            // 
            // placenametextBox
            // 
            placenametextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            placenametextBox.Location = new Point(160, 133);
            placenametextBox.Name = "placenametextBox";
            placenametextBox.Size = new Size(128, 29);
            placenametextBox.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(149, 225);
            label6.Name = "label6";
            label6.Size = new Size(32, 21);
            label6.TabIndex = 17;
            label6.Text = "OR";
            // 
            // createPrizebutton
            // 
            createPrizebutton.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            createPrizebutton.Location = new Point(89, 342);
            createPrizebutton.Name = "createPrizebutton";
            createPrizebutton.Size = new Size(174, 44);
            createPrizebutton.TabIndex = 18;
            createPrizebutton.Text = "Create Prize";
            createPrizebutton.UseVisualStyleBackColor = true;
            createPrizebutton.Click += createPrizebutton_Click;
            // 
            // CreatePrizeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 437);
            Controls.Add(createPrizebutton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(placenametextBox);
            Controls.Add(label4);
            Controls.Add(placeamounttextBox);
            Controls.Add(label2);
            Controls.Add(prizepercantagetextBox);
            Controls.Add(label3);
            Controls.Add(placenumbertextBox);
            Controls.Add(label1);
            Name = "CreatePrizeForm";
            Text = "CreatePrizeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private TextBox placenumbertextBox;
        private Label label2;
        private TextBox prizepercantagetextBox;
        private Label label4;
        private TextBox placeamounttextBox;
        private Label label5;
        private TextBox placenametextBox;
        private Label label6;
        private Button createPrizebutton;
    }
}