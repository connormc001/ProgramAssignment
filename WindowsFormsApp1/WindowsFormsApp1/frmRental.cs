using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class frmRental : Form
    {
        Button[] btns = new Button[26];
        SqlDataAdapter daNames, daCustomers, daMachine, daBooking, daBookingDet, daBookedMachines, daOrder, daOrderDet;
        DataSet dsCOCOFitness = new DataSet();
        SqlConnection conn;
        SqlCommand cmdCustomerDetails, cmdMachineDetails;



        private void lblHome_Click(object sender, EventArgs e)
        {

        }



        SqlCommandBuilder cmdOrder, cmdOrderDet, cmdBBookedMachines;



        DataRow drCustomer;

        

        String sqlNames, sqlCustomerDetails, sqlMachineDetails, sqlOrder,

        sqlOrderDet, sqlBookedMachines;

        

        String connStr;


        public frmRental()
        {
            InitializeComponent();
        }

        private void frmRental_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                btns[i] = (Button)pnlButtons.Controls[i];
                btns[i].Text = "" + (char)(65 + i);
                btns[i].Enabled = false;
                btns[i].Click += new EventHandler(button1_Click);


            }

            int no;
            lblOrderDate.Text = DateTime.Now.ToShortDateString();
            dtpStartDate.MinDate = DateTime.Now;


            connStr = @"Data Source = .,• Initial Catalog = lnTheDogHouse; Integrated Security = true";
            // connStr = Properties. Resources.connectionStr;



            //get surnames for alphabet butttons 
            sqlNames = @"Select surname from customer order by surname";
            daNames = new SqlDataAdapter(sqlNames, connStr);
            daNames.Fill(dsCOCOFitness, "Names");

            // enable relevant alpha buttons 
            foreach (DataRow dr in dsCOCOFitness.Tables["Names"].Rows)
            {
                no = (int)dr["Surname"].ToString()[0] - 65;
                btns[no].Enabled = true;
                btns[no].BackColor = Color.Black;
                btns[no].ForeColor = Color.White;
            }

            // set up dataAdapter for customer details for the listbox 

            sqlCustomerDetails = @"Select customerNo, title, surname, forename, surname +', ' + 
            Forename as name, street, town, county, postcode, telno from customer where surname LIKE
            @Letter order by surname, forename";
            conn = new SqlConnection(connStr);
            cmdCustomerDetails = new SqlCommand(sqlCustomerDetails, conn);
            cmdCustomerDetails.Parameters.Add("@Letter", SqlDbType.VarChar);
            daCustomers = new SqlDataAdapter(cmdCustomerDetails);
            daCustomers.FillSchema(dsCOCOFitness, SchemaType.Source, "Customer");


            // setup dataAdapter for Machine details for the listbox 

            sqlMachineDetails = @"Select machineNumber, machineName, machineType, dob, gender, colour, custormerNo from dog 
            where customerNo LIKE @CustNo order dogNo";
            cmdMachineDetails = new SqlCommand(sqlMachineDetails, conn);
            cmdMachineDetails.Parameters.Add("@CustNo", SqlDbType.Int);
            daMachine = new SqlDataAdapter(cmdMachineDetails);
            daMachine.FillSchema(dsCOCOFitness, SchemaType.Source, "Machine");

            // set up dataAdapter for kennels already booked details for the validation 
            sqlBookedMachines = @"SELECT Order.orderNo, orderDate, Delivered dateStart, noDays. machineNo 
            FROM order JOIN bookingDetail ON booking.bookingNo = bookingDetail.bookingND order by 
            bookingNo";


            daBookedMachines = new SqlDataAdapter(sqlBookedMachines, conn);

            cmdBBookedMachines = new SqlCommandBuilder(daBookedMachines);
            daBookedMachines.FillSchema(dsCOCOFitness, SchemaType.Source, "BookedKennels");
            daBookedMachines.Fill(dsCOCOFitness, "BookedMachines");

            sqlOrder = @"SELECT * from Order";
            daOrder = new SqlDataAdapter(sqlOrder, conn);
            cmdOrder = new SqlCommandBuilder(daOrder);
            daBooking.FillSchema(dsCOCOFitness, SchemaType.Source, "Booking");
            daBooking.Fill(dsCOCOFitness, "Booking");

            sqlOrderDet = @"select * from bookingDetail";
            daBookingDet = new SqlDataAdapter(sqlOrderDet, conn);
            cmdOrderDet = new SqlCommandBuilder(daOrderDet); daBookingDet.FillSchema(dsCOCOFitness, SchemaType.Source, "orderDetail");
            daBookingDet.Fill(dsCOCOFitness, "orderDetai!");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            // get customer details for listbox - use selected button letter for parameter
            String str = b.Text;
            //empty dataset table customer 
            dsCOCOFitness.Tables["Customer"].Clear(); fillListboxCustomers(str);
            //clear any previously selected dogs/kennels by emptying the dataset tables 
            dsCOCOFitness.Tables["Dog"].Clear();
            dsCOCOFitness.Tables["Kennel"].Clear();
            ClearCustomer();
            pnlBooking.Enabled = false;

        }
        private void fillListboxCustomers(String str)
        {
            // get all customer details for listbox - use wildcard for parameter
            cmdCustomerDetails.Parameters["@Letter"].Value = str + "%";
            daCustomers.Fill(dsCOCOFitness, "Customer");

            // fill listbox 
            lstCustomer.DataSource = dsCOCOFitness.Tables["Customer"];

            lstCustomer.DisplayMember = "name";

            lstCustomer.ValueMember = "CustomerNo";

        }

        //lstMachine to be done///////////////////////////
        private void lstCustomer_Click(object sender, EventArgs e)
        {
            String title = "";
            dsCOCOFitness.Tables["Machine"].Clear();
            // get all dog details for listbox 
            cmdMachineDetails.Parameters["@CustNo"].Value = lstCustomer.SelectedValue;

            daMachine.Fill(dsCOCOFitness, "Machine");

            // fill listbox  
            lstMachine.DataSource = dsCOCOFitness.Tables["Machine"];
            lstMachine.DisplayMember = "machineName";
            lstMachine.ValueMember = "machineType";

            lstMachine.SelectedIndex = -1;

            drCustomer = dsCOCOFitness.Tables["Customer"].Rows.Find(lstCustomer.SelectedValue);

            if (drCustomer["Title"].ToString() == "Mr")
                title = "Mr";
            if (drCustomer["Title"].ToString() == "Mrs")
                title = "Mrs";
            if (drCustomer["Title"].ToString() == "Miss")
                title = "Miss";
            if (drCustomer["Title"].ToString() == "Ms")
                title = "Ms";

            lblCust0.Text = drCustomer["CustomerNo"].ToString();
            lblCust1.Text = title + " " + drCustomer["Forename"].ToString() + " ";
            drCustomer["Surname"].ToString();
            lblCust2.Text = drCustomer["Street"].ToString();
            lblCust3.Text = drCustomer["Town"].ToString();
            lblCust4.Text = drCustomer["County"].ToString();

            lblCust5.Text = drCustomer["Postcode"].ToString();
        }

        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            DataRow drOrder, drOrderDets;
            int orderNo;

            int noRows = dsCOCOFitness.Tables["Order"].Rows.Count;

            drOrder = dsCOCOFitness.Tables["Booking"].Rows[noRows - 1];
            orderNo = (int.Parse(drOrder["OrderNo"].ToString()) + 1);

            if (lstCustomer.SelectedIndex == -1)
                MessageBox.Show("Please select a Customer", "Customer");
            else if (lstMachine.SelectedIndex == -1)
                MessageBox.Show("Please select a Machine", "Machine");
            else if (cmbNoOfDays.SelectedIndex == -1)
            {
                MessageBox.Show("Please input number of days required", "No Of Days");
                cmbNoOfDays.Focus();
            }
            else if (lvwOrder.Items.Count == 0)
                MessageBox.Show("Please add a Machine to the Order", "Order Detaiis");
            else
            {
                drOrder = dsCOCOFitness.Tables["Order"].NewRow();

                drOrder["customerNo"] = int.Parse(lblCust0.Text);
                drOrder["dateBooked"] = DateTime.Parse(lblOrderDate.Text.Trim());
                drOrder["dateBooked"] = DateTime.Parse(dtpStartDate.Text.Trim());
                drOrder["noDays"] = int.Parse(cmbNoOfDays.Text);

                dsCOCOFitness.Tables["Order"].Rows.Add(drOrder);
                daBooking.Update(dsCOCOFitness, "Order");

                foreach (ListViewItem item in lvwOrder.Items)
                {
                    drOrderDets = dsCOCOFitness.Tables["OrderDetail"].NewRow();
                    drOrderDets["orderNo"] = drOrder["orderNo"];
                    drOrderDets["machineNo"] = int.Parse(item.SubItems[0].Text);
                    dsCOCOFitness.Tables["OrderDetail"].Rows.Add(drOrderDets);
                    daBookingDet.Update(dsCOCOFitness, "OrderDetail");
                }
                MessageBox.Show("Order No: " + drOrder["orderNo"].ToString() + " added to system");

                pnlBooking.Enabled = false;
            }
        }
        
        private void btnAddItem_Click(object sender, EventArgs e)
        {

            bool ok = true;
            bool exits = false;

            if (lstCustomer.SelectedIndex == -1)
                MessageBox.Show("Please selett a Customer", "Customer");
            else if (lstMachine.SelectedIndex == -1)
                MessageBox.Show("Please select a Machine", "Machine");
            else if (cmbNoOfDays.SelectedIndex == -1)
            {
                MessageBox.Show("Please input number of days required", "No Of Days");
                cmbNoOfDays.Focus();

            }

            else
            {
                //if (lvwBooking.ltems.Count > 0) 
                //{ 
                foreach (ListViewItem item in lvwOrder.Items)
                {
                    if (item.SubItems[1].Text == lstMachine.Text)
                    {
                        MessageBox.Show("Machine has already been selected for this order.", "Order");
                        exits = true;
                        break;
                    }

                }

                if (!exits)
                {
                    DateTime start = DateTime.Parse(dtpStartDate.Text.Trim());

                    foreach (DataRow dr in dsCOCOFitness.Tables["BookedMachines"].Rows)
                    {
                        DateTime bookedDate = DateTime.Parse(dr["dateStart"].ToString());
                        if (start >= bookedDate && start <=
                        bookedDate.AddDays(int.Parse(cmbNoOfDays.Text)))
                        {
                            if ((dr["dogNo"] == lstMachine.SelectedValue))
                            {
                                MessageBox.Show("It seems the selected machine is already included in a order for this date range. Please re-select.", "Order");
                                ok = false;
                            }
                            if (!ok) break;

                        }

                    }

                    if (ok)
                    {
                        foreach (DataRow dr in dsCOCOFitness.Tables["machine"].Rows)
                        {
                            if (dr["name"].ToString() == lstMachine.Text)
                            {
                                ListViewItem item = new ListViewItem(dr["machineno"].ToString());
                                item.SubItems.Add(dr["name"].ToString());
                                
                                lvwOrder.Items.Add(item);
                                break;

                            }
                        }
                    }
                }
            }
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lvwOrder.SelectedItems.Count != 0)
            {
                var item = lvwOrder.SelectedItems[0];
                lvwOrder.Items.Remove(item);
            }
        }

        private void ClearCustomer()
        {
            lstCustomer.SelectedIndex = -1;

            lblCust0.Text = "";
            lblCust1.Text = "";
            lblCust2.Text = "";
            lblCust3.Text = "";
            lblCust4.Text = "";
            lblCust5.Text = "";
        }




    }







    
}
