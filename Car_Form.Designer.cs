namespace P3_Car_App
{
    partial class Car_Form
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtYear = new TextBox();
            cmbManufacturer = new ComboBox();
            cmbEngine = new ComboBox();
            cmbFueltype = new ComboBox();
            cmbTransmission = new ComboBox();
            button1 = new Button();
            dataGridViewCar = new DataGridView();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(438, 39);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(438, 76);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 1;
            label2.Text = "Manufacturer_Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(438, 110);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 2;
            label3.Text = "EngineCapacity_Id";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(438, 144);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 3;
            label4.Text = "Fuel_Type";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(438, 182);
            label5.Name = "label5";
            label5.Size = new Size(93, 20);
            label5.TabIndex = 4;
            label5.Text = "Transmission";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(438, 219);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 5;
            label6.Text = "Price";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(438, 252);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 6;
            label7.Text = "Year";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtName
            // 
            txtName.Location = new Point(680, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(954, 27);
            txtName.TabIndex = 8;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(680, 212);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(954, 27);
            txtPrice.TabIndex = 9;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(680, 245);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(954, 27);
            txtYear.TabIndex = 10;
            // 
            // cmbManufacturer
            // 
            cmbManufacturer.FormattingEnabled = true;
            cmbManufacturer.Location = new Point(680, 68);
            cmbManufacturer.Name = "cmbManufacturer";
            cmbManufacturer.Size = new Size(954, 28);
            cmbManufacturer.TabIndex = 11;
            // 
            // cmbEngine
            // 
            cmbEngine.FormattingEnabled = true;
            cmbEngine.Location = new Point(680, 102);
            cmbEngine.Name = "cmbEngine";
            cmbEngine.Size = new Size(954, 28);
            cmbEngine.TabIndex = 12;
            // 
            // cmbFueltype
            // 
            cmbFueltype.FormattingEnabled = true;
            cmbFueltype.Location = new Point(680, 136);
            cmbFueltype.Name = "cmbFueltype";
            cmbFueltype.Size = new Size(954, 28);
            cmbFueltype.TabIndex = 13;
            // 
            // cmbTransmission
            // 
            cmbTransmission.FormattingEnabled = true;
            cmbTransmission.Location = new Point(680, 174);
            cmbTransmission.Name = "cmbTransmission";
            cmbTransmission.Size = new Size(954, 28);
            cmbTransmission.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new Point(1466, 293);
            button1.Name = "button1";
            button1.Size = new Size(114, 44);
            button1.TabIndex = 15;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAdd_Click;
            // 
            // dataGridViewCar
            // 
            dataGridViewCar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCar.Location = new Point(95, 356);
            dataGridViewCar.Name = "dataGridViewCar";
            dataGridViewCar.RowHeadersWidth = 51;
            dataGridViewCar.Size = new Size(1603, 282);
            dataGridViewCar.TabIndex = 16;
            dataGridViewCar.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(215, 39);
            label8.Name = "label8";
            label8.Size = new Size(24, 20);
            label8.TabIndex = 17;
            label8.Text = "1 .";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(215, 76);
            label9.Name = "label9";
            label9.Size = new Size(24, 20);
            label9.TabIndex = 18;
            label9.Text = "2 .";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(215, 110);
            label10.Name = "label10";
            label10.Size = new Size(24, 20);
            label10.TabIndex = 19;
            label10.Text = "3 .";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(215, 144);
            label11.Name = "label11";
            label11.Size = new Size(24, 20);
            label11.TabIndex = 20;
            label11.Text = "4 .";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(215, 182);
            label12.Name = "label12";
            label12.Size = new Size(24, 20);
            label12.TabIndex = 21;
            label12.Text = "5 .";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(215, 219);
            label13.Name = "label13";
            label13.Size = new Size(24, 20);
            label13.TabIndex = 22;
            label13.Text = "6 .";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(215, 252);
            label14.Name = "label14";
            label14.Size = new Size(24, 20);
            label14.TabIndex = 23;
            label14.Text = "7 .";
            // 
            // Car_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1767, 662);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(dataGridViewCar);
            Controls.Add(button1);
            Controls.Add(cmbTransmission);
            Controls.Add(cmbFueltype);
            Controls.Add(cmbEngine);
            Controls.Add(cmbManufacturer);
            Controls.Add(txtYear);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Car_Form";
            Text = "Car_Form";
            Load += Car_form_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtYear;
        private ComboBox cmbManufacturer;
        private ComboBox cmbEngine;
        private ComboBox cmbFueltype;
        private ComboBox cmbTransmission;
        private Button button1;
        private DataGridView dataGridViewCar;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
    }
}