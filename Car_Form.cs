using Microsoft.Data.Sqlite;
using P3_Car_App.Data;
using P3_Car_App.Models;
using P3_Car_App.Types;
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
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

namespace P3_Car_App
{
    public partial class Car_Form : Form
    {
        private readonly AppDbContext _context = new AppDbContext();

        int selectedCarId = 0;
        int filterManufacturerId = 0;
        int filterEngineId = 0;
        int _manuId;
        int _engineId;
        public Car_Form(int? manuId = null, int? engineId = null)
        {
            InitializeComponent();

            this.AutoScroll = true;

            Color bg = Color.White;
            Color panel = Color.FromArgb(245, 245, 245);
            Color accent = Color.FromArgb(0, 120, 215);
            Color text = Color.Black;

            StyleButton(button1);

            _manuId = manuId ?? 0;
            _engineId = engineId ?? 0;

            if (manuId != null)
                filterManufacturerId = manuId.Value;

            if (engineId != null)
                filterEngineId = engineId.Value;
        }
        private void Car_form_Load(object sender, EventArgs e)
        {
            dataGridViewCar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbTransmission.DataSource = null;
            cmbFueltype.DataSource = null;

            cmbTransmission.Items.Clear();
            cmbFueltype.Items.Clear();

            cmbTransmission.Items.Add("Manual");
            cmbTransmission.Items.Add("Automatic");

            cmbFueltype.Items.Add("Petrol");
            cmbFueltype.Items.Add("Diesel");
            cmbFueltype.Items.Add("Electric");

            ApplyResponsiveLayout();

            ApplyTheme();

            LoadCars();
            LoadManufacturers();
            LoadEngineCapacity();

            if (_manuId != 0)
            {
                cmbManufacturer.SelectedValue = _manuId;
                cmbManufacturer.Enabled = false;
            }
            if (_engineId != 0)
            {
                cmbEngine.SelectedValue = _engineId;
                cmbEngine.Enabled = false;
            }

            ClearForm();

            cmbTransmission.SelectedIndex = 0;
            cmbFueltype.SelectedIndex = 0;
        }
        void ApplyResponsiveLayout()
        {
            // DataGridView fills bottom area
            dataGridViewCar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Textboxes stretch horizontally
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtYear.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // ComboBoxes stretch horizontally
            cmbManufacturer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbEngine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTransmission.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbFueltype.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Buttons stay aligned properly
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            //btnShowAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
        public void SetManufacturerFilter(int id)
        {
            filterManufacturerId = id;
            filterEngineId = 0;
        }

        public void SetEngineFilter(int id)
        {
            filterEngineId = id;
            filterManufacturerId = 0;
        }
        void LoadCars()
        {
            try
            {
                var query = _context.Cars
                    .Include(c => c.Manufacturer)
                    .Include(c => c.EngineCapacity)
                    .AsQueryable();

                if (filterManufacturerId != 0)
                    query = query.Where(c => c.ManufacturerId == filterManufacturerId);

                if (filterEngineId != 0)
                    query = query.Where(c => c.EngineCapacityId == filterEngineId);

                var list = query.Select(c => new
                {
                    c.Id,
                    c.Name,
                    Manufacturer = c.Manufacturer.Name,
                    Capacity = c.EngineCapacity.Capacity,
                    c.Transmission,
                    c.FuelType,
                    c.Price,
                    c.Year,
                    c.ManufacturerId,      // IMPORTANT FIX
                    c.EngineCapacityId     // IMPORTANT FIX
                }).ToList();

                dataGridViewCar.DataSource = list;

                AddButtonsToGrid();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load cars");
                MessageBox.Show("Operation failed.");
            }
        }
        void LoadCarToForm(int rowIndex)
        {
            var row = dataGridViewCar.Rows[rowIndex];

            selectedCarId = Convert.ToInt32(row.Cells["Id"].Value);

            txtName.Text = row.Cells["Name"].Value.ToString();
            txtPrice.Text = row.Cells["Price"].Value.ToString();
            txtYear.Text = row.Cells["Year"].Value.ToString();

            cmbManufacturer.SelectedValue = row.Cells["ManufacturerId"].Value;
            cmbEngine.SelectedValue = row.Cells["EngineCapacityId"].Value;

            cmbTransmission.DataSource = Enum.GetValues(typeof(Transmission));
            cmbFueltype.DataSource = Enum.GetValues(typeof(FuelType));

            button1.Text = "Update";
        }
        void DeleteCar(int id)
        {
            try
            {
                var car = _context.Cars.Find(id);

                if (car == null) return;

                _context.Cars.Remove(car);
                _context.SaveChanges();

                LoadCars();
                Log.Warning("Car deleted: {Id}", id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to delete car.");
                MessageBox.Show("Operation failed.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int carId = Convert.ToInt32(dataGridViewCar.Rows[e.RowIndex].Cells["Id"].Value);

            if (dataGridViewCar.Columns[e.ColumnIndex].Name == "Edit")
            {
                LoadCarToForm(e.RowIndex);
            }

            if (dataGridViewCar.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteCar(carId);
            }
        }
        void LoadManufacturers()
        {
            try
            {
                var list = _context.Manufacturers
                    .Select(m => new
                    {
                        m.Id,
                        m.Name
                    })
                    .ToList();

                cmbManufacturer.DisplayMember = "Name";
                cmbManufacturer.ValueMember = "Id";
                cmbManufacturer.DataSource = list;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load manufacturers.");
                MessageBox.Show("Operation failed.");
            }
        }
        void LoadEngineCapacity()
        {
            try
            {
                var list = _context.EngineCapacities
                    .Select(e => new
                    {
                        e.Id,
                        e.Capacity
                    })
                    .ToList();

                cmbEngine.DisplayMember = "Capacity";
                cmbEngine.ValueMember = "Id";
                cmbEngine.DataSource = list;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load engine capacities.");
                MessageBox.Show("Operation failed.");
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            filterManufacturerId = 0;
            filterEngineId = 0;

            LoadCars();
        }
        void ClearForm()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtYear.Clear();

            cmbTransmission.SelectedIndex = 0;
            cmbFueltype.SelectedIndex = 0;

            if (_manuId != 0)
                cmbManufacturer.SelectedValue = _manuId;
            else if (cmbManufacturer.Items.Count > 0)
                cmbManufacturer.SelectedIndex = 0;

            if (_engineId != 0)
                cmbEngine.SelectedValue = _engineId;
            else if (cmbEngine.Items.Count > 0)
                cmbEngine.SelectedIndex = 0;

            selectedCarId = 0;
            button1.Text = "Add";
        }
        void AddButtonsToGrid()
        {
            if (dataGridViewCar.Columns["Edit"] != null)
                return;

            dataGridViewCar.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            });

            dataGridViewCar.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            });
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please fill all fields");
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out var price) ||
                    !int.TryParse(txtYear.Text, out var year))
                {
                    MessageBox.Show("Invalid price or year");
                    return;
                }

                if (selectedCarId == 0)
                {
                    var car = new Car
                    {
                        Name = txtName.Text,
                        ManufacturerId = (int)cmbManufacturer.SelectedValue,
                        EngineCapacityId = (int)cmbEngine.SelectedValue,
                        Transmission = Enum.Parse<Transmission>(cmbTransmission.Text),
                        FuelType = Enum.Parse<FuelType>(cmbFueltype.Text),
                        Price = price,
                        Year = year
                    };

                    _context.Cars.Add(car);
                    Log.Information("User added new car: {CarName}", txtName.Text);
                }
                else
                {
                    var car = _context.Cars.Find(selectedCarId);

                    if (car == null)
                    {
                        MessageBox.Show("Car not found");
                        return;
                    }

                    car.Name = txtName.Text;
                    car.ManufacturerId = (int)cmbManufacturer.SelectedValue;
                    car.EngineCapacityId = (int)cmbEngine.SelectedValue;
                    car.Transmission = Enum.Parse<Transmission>(cmbTransmission.Text);
                    car.FuelType = Enum.Parse<FuelType>(cmbFueltype.Text);
                    car.Price = price;
                    car.Year = year;
                    Log.Information("User updated car: {CarId}, Name: {CarName}", selectedCarId, txtName.Text);
                }

                _context.SaveChanges();

                selectedCarId = 0;
                button1.Text = "Add";

                LoadCars();
                ClearForm();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to add/update car.");
                MessageBox.Show("Operation failed.");
            }

        }
    }
}
