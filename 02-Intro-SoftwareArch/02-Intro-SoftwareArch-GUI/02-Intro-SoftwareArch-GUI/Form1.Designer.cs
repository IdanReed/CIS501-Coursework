namespace Intro_SoftwareArch_GUI
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
            this.uxTextBox1 = new System.Windows.Forms.TextBox();
            this.uxButton1 = new System.Windows.Forms.Button();
            this.uxLabel1 = new System.Windows.Forms.Label();
            this.outLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxTextBox2 = new System.Windows.Forms.TextBox();
            this.uxButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxTextBox1
            // 
            this.uxTextBox1.Location = new System.Drawing.Point(197, 9);
            this.uxTextBox1.Name = "uxTextBox1";
            this.uxTextBox1.Size = new System.Drawing.Size(175, 20);
            this.uxTextBox1.TabIndex = 0;
            // 
            // uxButton1
            // 
            this.uxButton1.Location = new System.Drawing.Point(378, 9);
            this.uxButton1.Name = "uxButton1";
            this.uxButton1.Size = new System.Drawing.Size(68, 26);
            this.uxButton1.TabIndex = 1;
            this.uxButton1.Text = "Enter";
            this.uxButton1.UseVisualStyleBackColor = true;
            this.uxButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uxLabel1
            // 
            this.uxLabel1.AutoSize = true;
            this.uxLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabel1.Location = new System.Drawing.Point(12, 9);
            this.uxLabel1.Name = "uxLabel1";
            this.uxLabel1.Size = new System.Drawing.Size(179, 13);
            this.uxLabel1.TabIndex = 2;
            this.uxLabel1.Text = "Guess an int, M, in range 0..10:  M =";
            // 
            // outLabel
            // 
            this.outLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outLabel.Location = new System.Drawing.Point(15, 34);
            this.outLabel.Name = "outLabel";
            this.outLabel.Size = new System.Drawing.Size(338, 43);
            this.outLabel.TabIndex = 3;
            this.outLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type an int, P, such that M + N + P = 10:  P =";
            // 
            // uxTextBox2
            // 
            this.uxTextBox2.Enabled = false;
            this.uxTextBox2.Location = new System.Drawing.Point(241, 47);
            this.uxTextBox2.Name = "uxTextBox2";
            this.uxTextBox2.Size = new System.Drawing.Size(175, 20);
            this.uxTextBox2.TabIndex = 5;
            // 
            // uxButton2
            // 
            this.uxButton2.Enabled = false;
            this.uxButton2.Location = new System.Drawing.Point(422, 47);
            this.uxButton2.Name = "uxButton2";
            this.uxButton2.Size = new System.Drawing.Size(68, 26);
            this.uxButton2.TabIndex = 6;
            this.uxButton2.Text = "Enter";
            this.uxButton2.UseVisualStyleBackColor = true;
            this.uxButton2.Click += new System.EventHandler(this.uxButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 278);
            this.Controls.Add(this.uxButton2);
            this.Controls.Add(this.uxTextBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outLabel);
            this.Controls.Add(this.uxLabel1);
            this.Controls.Add(this.uxButton1);
            this.Controls.Add(this.uxTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxTextBox1;
        private System.Windows.Forms.Button uxButton1;
        private System.Windows.Forms.Label uxLabel1;
        private System.Windows.Forms.Label outLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxTextBox2;
        private System.Windows.Forms.Button uxButton2;
    }
}

