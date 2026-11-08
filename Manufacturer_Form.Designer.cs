namespace P3_Car_App
{
    partial class Manufacturer_Form
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
            txtName = new TextBox();
            txtDescription = new TextBox();
            button1 = new Button();
            dataGridViewManufacturer = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewManufacturer).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(460, 105);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(460, 147);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 1;
            label2.Text = "Description";
            // 
            // txtName
            // 
            txtName.Location = new Point(652, 98);
            txtName.Name = "txtName";
            txtName.Size = new Size(886, 27);
            txtName.TabIndex = 2;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(652, 140);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(886, 27);
            txtDescription.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(1387, 185);
            button1.Name = "button1";
            button1.Size = new Size(107, 43);
            button1.TabIndex = 4;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAdd_Click;
            // 
            // dataGridViewManufacturer
            // 
            dataGridViewManufacturer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewManufacturer.Location = new Point(87, 250);
            dataGridViewManufacturer.Name = "dataGridViewManufacturer";
            dataGridViewManufacturer.RowHeadersWidth = 51;
            dataGridViewManufacturer.Size = new Size(1582, 435);
            dataGridViewManufacturer.TabIndex = 5;
            dataGridViewManufacturer.CellContentClick += dataGridViewManufacturer_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(248, 105);
            label3.Name = "label3";
            label3.Size = new Size(24, 20);
            label3.TabIndex = 6;
            label3.Text = "1 .";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(248, 147);
            label4.Name = "label4";
            label4.Size = new Size(24, 20);
            label4.TabIndex = 7;
            label4.Text = "2 .";
            // 
            // Manufacturer_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1761, 697);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridViewManufacturer);
            Controls.Add(button1);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Manufacturer_Form";
            Text = "ManufacturerForm";
            Load += Manufacturer_form_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewManufacturer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private TextBox txtDescription;
        private Button button1;
        private DataGridView dataGridViewManufacturer;
        private Label label3;
        private Label label4;
    }
}