namespace L7
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(223, 302);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.RowHeaderMouseClick += dataGridView1_RowHeaderMouseClick;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridView2.Location = new Point(273, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(515, 302);
            dataGridView2.TabIndex = 1;
            dataGridView2.CellEndEdit += dataGridView2_CellEndEdit;
            // 
            // button1
            // 
            button1.Location = new Point(12, 320);
            button1.Name = "button1";
            button1.Size = new Size(223, 23);
            button1.TabIndex = 2;
            button1.Text = "Delete Group";
            button1.UseVisualStyleBackColor = true;
            button1.Click += deleteGroupBtn_Click;
            // 
            // button2
            // 
            button2.Location = new Point(273, 320);
            button2.Name = "button2";
            button2.Size = new Size(515, 23);
            button2.TabIndex = 3;
            button2.Text = "Delete Student";
            button2.UseVisualStyleBackColor = true;
            button2.Click += deleteStudentBtn_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 349);
            button3.Name = "button3";
            button3.Size = new Size(223, 23);
            button3.TabIndex = 4;
            button3.Text = "Add Group";
            button3.UseVisualStyleBackColor = true;
            button3.Click += addGroupBtn_Click;
            // 
            // button4
            // 
            button4.Location = new Point(273, 349);
            button4.Name = "button4";
            button4.Size = new Size(515, 23);
            button4.TabIndex = 5;
            button4.Text = "Add Student";
            button4.UseVisualStyleBackColor = true;
            button4.Click += addStudentBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 389);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}