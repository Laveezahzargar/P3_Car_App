using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P3_Car_App.Data;
using P3_Car_App.Models;
using Serilog;
using Serilog.Events;

namespace P3_Car_App
{
    public partial class Manufacturer_Form : Form
    {
        int selectedManufacturerId = 0;

        public Manufacturer_Form()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void Manufacturer_form_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            StyleButton(button1);
            ApplyResponsiveLayout();

            // IMPORTANT: grid setup must be here, not constructor
            dataGridViewManufacturer.AutoGenerateColumns = true;
            dataGridViewManufacturer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadManufacturers();
        }
        void ApplyResponsiveLayout()
        {
            // Grid fills remaining space
            dataGridViewManufacturer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Textboxes stretch horizontally
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Button stays top-right
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void StyleButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(0, 120, 215);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.White;
        }

        void LoadManufacturers()
        {
            try
            {
                using var context = new AppDbContext();

                var list = context.Manufacturers
                    .Select(m => new
                    {
                        m.Id,
                        m.Name,
                        m.Description
                    })
                    .ToList();

                dataGridViewManufacturer.DataSource = list;

                HideIdColumn();
                AddButtons();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load manufacturers.");
                MessageBox.Show("Operation failed.");
            }
        }

        void HideIdColumn()
        {
            if (dataGridViewManufacturer.Columns["Id"] != null)
                dataGridViewManufacturer.Columns["Id"].Visible = false;
        }

        void AddButtons()
        {
            // Prevent duplicate buttons
            if (dataGridViewManufacturer.Columns["ViewCars"] != null)
                return;

            dataGridViewManufacturer.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "ViewCars",
                HeaderText = "Cars",
                Text = "View Cars",
                UseColumnTextForButtonValue = true
            });

            dataGridViewManufacturer.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            });

            dataGridViewManufacturer.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });
        }

        private void dataGridViewManufacturer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridViewManufacturer.Rows[e.RowIndex].Cells["Id"].Value);
            string column = dataGridViewManufacturer.Columns[e.ColumnIndex].Name;

            if (column == "ViewCars")
            {
                var form = new Car_Form(id, null);
                form.ShowDialog();
            }
            else if (column == "Edit")
            {
                txtName.Text = dataGridViewManufacturer.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtDescription.Text = dataGridViewManufacturer.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                selectedManufacturerId = id;
                button1.Text = "Update";
            }
            else if (column == "Delete")
            {
                DeleteManufacturer(id);
            }
        }

        void DeleteManufacturer(int id)
        {
            try
            {
                using var context = new AppDbContext();

                bool hasCars = context.Cars.Any(c => c.ManufacturerId == id);

                if (hasCars)
                {
                    MessageBox.Show("Cannot delete. Cars are linked.");
                    return;
                }

                var manu = context.Manufacturers.Find(id);

                if (manu == null) return;

                context.Manufacturers.Remove(manu);
                context.SaveChanges();

                LoadManufacturers();
                Log.Warning("Manufacturer deleted: {Id}", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to delete manufacturers.");
                MessageBox.Show("Operation failed.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please fill all fields");
                    return;
                }

                using var context = new AppDbContext();

                if (selectedManufacturerId == 0)
                {
                    context.Manufacturers.Add(new Manufacturer
                    {
                        Name = txtName.Text,
                        Description = txtDescription.Text
                    });
                    Log.Information("User added new manufacturer: {ManufacturerName}", txtName.Text);
                }
                else
                {
                    var manu = context.Manufacturers.Find(selectedManufacturerId);

                    if (manu == null)
                        return;

                    manu.Name = txtName.Text;
                    manu.Description = txtDescription.Text;
                    Log.Information("User updated manufacturer: {ManufacturerId}, Name: {ManufacturerName}", selectedManufacturerId, txtName.Text);
                }

                context.SaveChanges();

                ResetForm();
                LoadManufacturers();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to add/update manufacturer.");
                MessageBox.Show("Operation failed.");
            }
        }

        void ResetForm()
        {
            selectedManufacturerId = 0;
            button1.Text = "Add";
            txtName.Clear();
            txtDescription.Clear();
        }

    }
}
