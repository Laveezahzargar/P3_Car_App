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
    public partial class EngineCapacity_Form : Form
    {
        int selectedEngineId = 0;
        public EngineCapacity_Form()
        {
            InitializeComponent();

            this.AutoScroll = true;

            Color bg = Color.White;
            Color panel = Color.FromArgb(245, 245, 245);
            Color accent = Color.FromArgb(0, 120, 215);
            Color text = Color.Black;
        }
        private void EngineCapacity_form_Load(object sender, EventArgs e)
        {
            StyleButton(button1);
            ApplyTheme();
            ApplyResponsiveLayout();
            LoadEngineCapacity();
            dataGridViewEngine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void ApplyResponsiveLayout()
        {
            // Grid expands fully
            dataGridViewEngine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Inputs stretch horizontally
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCapacity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Button stays aligned right
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
        void LoadEngineCapacity()
        {
            try
            {
                using var context = new AppDbContext();

                var list = context.EngineCapacities
                    .Select(e => new
                    {
                        e.Id,
                        e.Name,
                        e.Description,
                        e.Capacity
                    })
                    .ToList();

                dataGridViewEngine.DataSource = list;

                dataGridViewEngine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                HideIdColumn();
                AddButtons();
            }

            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load engine capacities.");
                MessageBox.Show("Operation failed.");
            }
        }
        void HideIdColumn()
        {
            if (dataGridViewEngine.Columns["Id"] != null)
                dataGridViewEngine.Columns["Id"].Visible = false;
        }
        void AddButtons()
        {
            if (dataGridViewEngine.Columns["ViewCars"] != null)
                return;

            dataGridViewEngine.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "ViewCars",
                Text = "View Cars",
                UseColumnTextForButtonValue = true
            });

            dataGridViewEngine.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            });

            dataGridViewEngine.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });
        }
        private void dataGridViewEngine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridViewEngine.Rows[e.RowIndex].Cells["Id"].Value);

            string col = dataGridViewEngine.Columns[e.ColumnIndex].Name;

            if (col == "ViewCars")
            {
                var carForm = new Car_Form(null, id);
                carForm.ShowDialog();
            }
            else if (col == "Edit")
            {
                txtName.Text = dataGridViewEngine.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtDescription.Text = dataGridViewEngine.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                txtCapacity.Text = dataGridViewEngine.Rows[e.RowIndex].Cells["Capacity"].Value.ToString();

                selectedEngineId = id;
                button1.Text = "Update";
            }
            else if (col == "Delete")
            {
                DeleteEngine(id);
            }
        }
        void DeleteEngine(int id)
        {
            try
            {
                using var context = new AppDbContext();

                bool hasCars = context.Cars.Any(c => c.EngineCapacityId == id);

                if (hasCars)
                {
                    MessageBox.Show("Cannot delete. Cars are linked to this engine.");
                    return;
                }

                var engine = context.EngineCapacities.Find(id);

                if (engine == null) return;

                context.EngineCapacities.Remove(engine);
                context.SaveChanges();

                LoadEngineCapacity();
                Log.Warning("Engine Capacity deleted: {Id}", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to delete engine capacity.");
                MessageBox.Show("Operation failed.");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text) ||
                    string.IsNullOrWhiteSpace(txtCapacity.Text))
                {
                    MessageBox.Show("Please fill all fields");
                    return;
                }
                using var context = new AppDbContext();

                if (selectedEngineId == 0)
                {
                    var engine = new EngineCapacity
                    {
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        Capacity = txtCapacity.Text
                    };

                    context.EngineCapacities.Add(engine);
                    Log.Information("User added new engine capacity: {EngineCapacityName}", txtName.Text);
                }
                else
                {
                    var engine = context.EngineCapacities.Find(selectedEngineId);

                    if (engine == null)
                    {
                        MessageBox.Show("Not found");
                        return;
                    }

                    engine.Name = txtName.Text;
                    engine.Description = txtDescription.Text;
                    engine.Capacity = txtCapacity.Text;
                    Log.Information("User updated engine capacity: {EngineCapacityId}, Name: {EngineCapacityName}", selectedEngineId, txtName.Text);
                }

                context.SaveChanges();

                selectedEngineId = 0;
                button1.Text = "Add";

                txtName.Clear();
                txtDescription.Clear();
                txtCapacity.Clear();

                LoadEngineCapacity();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to add/update engine capacity.");
                MessageBox.Show("Operation failed.");
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
