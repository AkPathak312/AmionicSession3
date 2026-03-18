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
            Color colorMain = ColorTranslator.FromHtml("#196AA6");
            this.BackColor = colorMain;
            button1.BackColor = colorSecondary;
            LoadComboboxes();
            radioButton2.Checked = true;
            dateTimePicker2.Enabled = false;
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
            if(cabinType == 2)
            {
                price = price + (0.35*price);
            }
            if(cabinType == 3)
            {
                double busPrice = price + (0.35 * price);
                price = busPrice + (0.30 * busPrice);
            }
            return price;
        }
    }
}
