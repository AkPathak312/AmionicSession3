using AmionicSession3.Models;

namespace AmionicSession3
{
    public partial class Form1 : Form
    {
        Session3Context db;
        public Form1()
        {
            InitializeComponent();
            db = new Session3Context();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color colorSecondary = ColorTranslator.FromHtml("#f79420");
            Color colorMain = ColorTranslator.FromHtml("#fff");
            this.BackColor = colorMain;
            button1.BackColor = colorSecondary;
            LoadComboboxes();
            radioButton2.Checked = true;
            dateTimePicker2.Enabled = false;

            //dEFAULTING dATE   
            dateTimePicker1.Value = new DateTime(2017, 10, 04);
            dateTimePicker2.Value = new DateTime(2017, 10, 04);

            //Setting row select
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

        }

        private void LoadComboboxes()
        {
            List<Airport> airports = db.Airports.ToList();
            List<Airport> airports2 = db.Airports.ToList();
            comboBox1.DataSource = airports;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "IATACode";
            comboBox2.DataSource = airports2;
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "IATACode";

            List<CabinType> cabinTypes = db.CabinTypes.ToList();
            comboBox3.DataSource = cabinTypes;
            comboBox3.ValueMember = "Id";
            comboBox3.DisplayMember = "Name";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker2.Enabled = true;
                dataGridView2.Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dateTimePicker2.Enabled = false;
                dataGridView2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fromAirport = (int)comboBox1.SelectedValue;
            int toAirport = (int)comboBox2.SelectedValue;
            int cabinType = (int)comboBox3.SelectedValue;

            if (fromAirport == toAirport)
            {
                MessageBox.Show("From and To cannot be same");
                return;
            }

            //Fetch List from DB
            var outboundFlights = db.Schedules.Where(x => x.Route.DepartureAirportId == fromAirport
                && x.Route.ArrivalAirportId == toAirport
                && x.Date == DateOnly.FromDateTime(dateTimePicker1.Value))
                .Select(x => new
                {
                    Id = x.Id,
                    From = x.Route.DepartureAirport.Iatacode,
                    To = x.Route.ArrivalAirport.Iatacode,
                    Date = x.Date,
                    Time = x.Time,
                    FlightNumber = x.FlightNumber,
                    CabinPrice = x.EconomyPrice
                }).ToList();

            if (checkBox1.Checked)
            {
                outboundFlights = db.Schedules.Where(x => x.Route.DepartureAirportId == fromAirport
                && x.Route.ArrivalAirportId == toAirport
                && x.Date > DateOnly.FromDateTime(dateTimePicker1.Value.AddDays(-3))
                && x.Date < DateOnly.FromDateTime(dateTimePicker1.Value.AddDays(3)))
                .Select(x => new
                {
                    Id = x.Id,
                    From = x.Route.DepartureAirport.Iatacode,
                    To = x.Route.ArrivalAirport.Iatacode,
                    Date = x.Date,
                    Time = x.Time,
                    FlightNumber = x.FlightNumber,
                    CabinPrice = x.EconomyPrice
                }).ToList();
            }

            //if(dateTimePicker2.Value < dateTimePicker1.Value.AddDays(1))
            //{
            //    MessageBox.Show("Return should be after outbound");
            //    return;
            //}
            //Data source for Datagrid Outbound
            var flights = outboundFlights.Select(x => new
            {
                Id = x.Id,
                From = x.From,
                To = x.To,
                Date = x.Date,
                Time = x.Time,
                FlightNumber = x.FlightNumber,
                CabinPrice = CalculatePrice((decimal)x.CabinPrice, cabinType)
            }).ToList();
            dataGridView1.DataSource = flights;

            //Data source for return
            if (radioButton1.Checked)
            {
                //Fetch List from DB
                var returnFlights = db.Schedules.Where(x => x.Route.DepartureAirportId == toAirport && x.Route.ArrivalAirportId == fromAirport && x.Date == DateOnly.FromDateTime(dateTimePicker2.Value))
                    .Select(x => new
                    {
                        Id = x.Id,
                        From = x.Route.DepartureAirport.Iatacode,
                        To = x.Route.ArrivalAirport.Iatacode,
                        Date = x.Date,
                        Time = x.Time,
                        FlightNumber = x.FlightNumber,
                        CabinPrice = x.EconomyPrice
                    }).ToList();
                if (checkBox2.Checked)
                {
                    returnFlights = db.Schedules.Where(x => x.Route.DepartureAirportId == toAirport
                    && x.Route.ArrivalAirportId == fromAirport
                    && x.Date > DateOnly.FromDateTime(dateTimePicker2.Value.AddDays(-3))
                    && x.Date < DateOnly.FromDateTime(dateTimePicker2.Value.AddDays(3)))
                    .Select(x => new
                    {
                        Id = x.Id,
                        From = x.Route.DepartureAirport.Iatacode,
                        To = x.Route.ArrivalAirport.Iatacode,
                        Date = x.Date,
                        Time = x.Time,
                        FlightNumber = x.FlightNumber,
                        CabinPrice = x.EconomyPrice
                    }).ToList();
                }
                var flightsReturn = returnFlights.Select(x => new 
                {
                    Id = x.Id,
                    From = x.From,
                    To = x.To,
                    Date = x.Date,
                    Time = x.Time,
                    FlightNumber = x.FlightNumber,
                    CabinPrice = CalculatePrice((decimal)x.CabinPrice, cabinType)
                }).ToList();
                dataGridView2.DataSource = flightsReturn;
            }

        }

        private double CalculatePrice(decimal economyPrice, int cabinType)
        {
            double price = (double)economyPrice;
            if (cabinType == 2)
            {
                price = price + (0.35 * price);
            }
            if (cabinType == 3)
            {
                double busPrice = price + (0.35 * price);
                price = busPrice + (0.30 * busPrice);
            }
            return price;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int returnId = 0;
            int outboundId = 0;
            if (numericUpDown1 == null || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Please enter number of passengers.");
                return;
            }
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please Select a Outbound Flight");
                return;
            }
            if (radioButton1.Checked)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please Select a Return Flight");
                    return;
                }
            }
            DataGridViewRow outboundRow = dataGridView1.SelectedRows[0];
            DataGridViewRow returnRow = null;
            if (radioButton1.Checked)
            {
                returnRow = dataGridView2.SelectedRows[0];
                returnId = (int)returnRow.Cells["Id"].Value;
            }
            outboundId = (int)outboundRow.Cells["Id"].Value;
            BookingConfirmation form = new BookingConfirmation(outboundId, returnId, (int)numericUpDown1.Value, (int) comboBox3.SelectedValue);
            form.Show();
            this.Hide();
           // MessageBox.Show($"This is Return Id {returnId}, Outbond Id {outboundId}");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
