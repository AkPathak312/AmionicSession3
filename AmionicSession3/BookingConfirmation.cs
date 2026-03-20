using AmionicSession3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmionicSession3
{
    public partial class BookingConfirmation : Form
    {
        int outBound = 0;
        int returnFlight = 0;
        int passengers = 0;
        int cabinType = 0;
        Session3Context db;
        BindingList<Passenger> list = new BindingList<Passenger>();
        // BindingList<PassengerView> result = new BindingList<PassengerView>();
        public BookingConfirmation(int outBound, int returnFlight, int passengers, int cabinType)
        {
            InitializeComponent();
            db = new Session3Context();
            this.outBound = outBound;
            this.returnFlight = returnFlight;
            this.passengers = passengers;
            this.cabinType = cabinType;
            
         }

        private void BookingConfirmation_Load(object sender, EventArgs e)
        {
            Schedule outBoundFlight = GetFlightDetails(outBound);
            label1.Text = $"From: {outBoundFlight.Route.DepartureAirport.Iatacode} To: {outBoundFlight.Route.ArrivalAirport.Iatacode} Date: {outBoundFlight.Date} Flight Number: {outBoundFlight.FlightNumber}";
            label2.Visible = false;
            if (returnFlight != 0)
            {
                Schedule returnFlightObj = GetFlightDetails(returnFlight);
                label2.Visible = true;
                label2.Text = $"From: {returnFlightObj.Route.DepartureAirport.Iatacode} To: {returnFlightObj.Route.ArrivalAirport.Iatacode} Date: {returnFlightObj.Date} Flight Number: {returnFlightObj.FlightNumber}";
            }

            PopulateCountries();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
        }

        private void PopulateCountries()
        {
            List<Country> countries = db.Countries.ToList();
            comboBox1.DataSource = countries;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        public Schedule GetFlightDetails(int flightId)
        {
            Schedule flight = db.Schedules.Include(x => x.Route).ThenInclude(x => x.DepartureAirport).Include(x => x.Route).ThenInclude(x => x.ArrivalAirport).Where(x => x.Id == flightId).FirstOrDefault();
            return flight;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Put Validations Here


            Passenger pss = new Passenger();
            pss.FirstName = textBox1.Text;
            pss.LastName = textBox2.Text;
            pss.Mobile = textBox3.Text;
            pss.PassportNumber = textBox4.Text;
            pss.PassportCountry = ((Country)comboBox1.SelectedItem).Name;
            pss.BirthDate = dateTimePicker1.Value.Date.ToString();
            list.Add(pss);
            dataGridView1.DataSource = list;
        }

        public class Passenger
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String BirthDate { get; set; }
            public String PassportNumber { get; set; }
            public String PassportCountry { get; set; }
            public String Mobile { get; set; }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                if (!row.IsNewRow)
                {
                    dataGridView1.Rows.Remove(row);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(passengers != dataGridView1.Rows.Count)
            {
                MessageBox.Show($"You must book tickets for {passengers} Passengers.");
                return;
            }
            try
            {
                List<Ticket> tickets = new List<Ticket>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    Country c = db.Countries.Where(x => x.Name == row.Cells["PassportCountry"].Value).FirstOrDefault();
                    Ticket ticket = new Ticket();
                    ticket.UserId = 1;
                    ticket.ScheduleId = outBound;
                    ticket.CabinTypeId = cabinType;
                    ticket.Firstname = (string)row.Cells["FirstName"].Value;
                    ticket.Lastname = (string)row.Cells["LastName"].Value;
                    ticket.Phone = (string)row.Cells["Mobile"].Value;
                    ticket.PassportNumber = (string)row.Cells["PassportNumber"].Value;
                    ticket.PassportCountryId = c.Id;
                    ticket.BookingReference = CreatePnr();
                    ticket.Confirmed = true;
                    tickets.Add(ticket);

                    if (returnFlight != 0)
                    {
                        Ticket ticket2 = new Ticket();
                        ticket2.UserId = 1;
                        ticket2.ScheduleId = returnFlight;
                        ticket2.CabinTypeId = cabinType;
                        ticket2.Firstname = (string)row.Cells["FirstName"].Value;
                        ticket2.Lastname = (string)row.Cells["LastName"].Value;
                        ticket2.Phone = (string)row.Cells["Mobile"].Value;
                        ticket2.PassportNumber = (string)row.Cells["PassportNumber"].Value;
                        ticket2.PassportCountryId = db.Countries.Where(x => x.Name == (string)row.Cells["PassportCountry"].Value).FirstOrDefault().Id;
                        ticket2.BookingReference = CreatePnr();
                        ticket2.Confirmed = true;
                        tickets.Add(ticket2);
                    }

                }
                db.Tickets.AddRange(tickets);
                db.SaveChanges();
                MessageBox.Show("Tickets Booked Successfully!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public String CreatePnr()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();

            string pnr = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
            return pnr;
        }
    }
}
