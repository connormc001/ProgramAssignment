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
    public partial class frmStock : Form
    {

        SqlDataAdapter daStock;
        DataSet dsCOCOFitness = new DataSet();
        SqlCommandBuilder cmdBStock;
        DataRow drStock;
        String connStr, sqlStock;
        int selectedTab = 0;
        bool stockSelected = false;
        int stockNoSelected = 0;

        

        public frmStock()
        {
            InitializeComponent();
        }

        

        private void frmStock_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .; Initial Catalog = COCOFitness; Integrated Security = true";

            sqlStock = @"select * from Stock";
            daStock = new SqlDataAdapter(sqlStock, connStr);
            cmdBStock = new SqlCommandBuilder(daStock);
            daStock.FillSchema(dsCOCOFitness, SchemaType.Source, "Customer");
            daStock.Fill(dsCOCOFitness, "Stock");

            dgvStock.DataSource = dsCOCOFitness.Tables["Stock"];

            //Resize the DataGridView columns to fit the newly loaded content.

            dgvStock.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            tabStock.SelectedIndex = 1;
            tabStock.SelectedIndex = 0;

        }

       

        private void btnAddAdd_Click(object sender, EventArgs e)
        {
            MyStock myStock = new MyStock();
            bool ok = true;
            errP.Clear();

            try
            {
                myStock.StockNo = Convert.ToInt32(lblAddStockNo.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblAddStockNo, MyEx.toString());
            }

            try
            {
                myStock.StockNo = Convert.ToInt32(lblAddMachineNo.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblAddMachineNo, MyEx.toString());
            }

            try
            {
                myStock.MachineType = cmbAddMachineType.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddMachineType, MyEx.toString());
            }

            try
            {
                myStock.MachineName = txtAddMachineName.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddMachineName, MyEx.toString());
            }

            try
            {
                myStock.Quantity = cmbAddQuantity.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddQuantity, MyEx.toString());
            }

            try
            {
                myStock.Price = Convert.ToInt32(txtAddPrice.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(txtAddPrice, MyEx.toString());
            }

            try
            {
                if (ok)
                {
                    drStock = dsCOCOFitness.Tables["Stock"].NewRow();
                    drStock["StockNo"] = myStock.StockNo;
                    drStock["MachineNo"] = myStock.MachineNo;
                    drStock["MachineType"] = myStock.MachineType;
                    drStock["MachineName"] = myStock.MachineName;
                    drStock["Quantity"] = myStock.Quantity;
                    drStock["Price"] = myStock.Price;
                    

                    dsCOCOFitness.Tables["Stock"].Rows.Add(drStock);
                    daStock.Update(dsCOCOFitness, "Stock");

                    MessageBox.Show("Stock Added");

                    if (MessageBox.Show("Do you wish to add another Product?", "Add Stock"
                        , MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        clearAddForm();
                        getNumber(dsCOCOFitness.Tables["Stock"].Rows.Count);
                    }
                    else
                        tabStock.SelectedIndex = 0;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }

           
        } 
        void clearAddForm()
            {
                
                cmbAddMachineType.SelectedIndex = -1;
                txtAddMachineName.Clear();
                cmbAddQuantity.SelectedIndex = -1;
                txtAddPrice.Clear();
               
            }
        private void tabStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTab = tabStock.SelectedIndex;

            tabStock.TabPages[tabStock.SelectedIndex].Focus();
            tabStock.TabPages[tabStock.SelectedIndex].CausesValidation = true;

            if (dgvStock.SelectedRows.Count == 0 && tabStock.SelectedIndex == 2)
                tabStock.TabPages[tabStock.SelectedIndex].CausesValidation = true;

            //else
            //{
            switch (tabStock.SelectedIndex)
            {
                case 0: // Display Tab Selected
                    
                        dsCOCOFitness.Tables["Stock"].Clear();
                        daStock.Fill(dsCOCOFitness, "Stock");

                        break;
                    
                case 1: //Add tab Selected
                    
                        int noRows = dsCOCOFitness.Tables["Stock"].Rows.Count;
                        if (noRows == 0)
                            lblAddStockNo.Text = "10000";
                        else
                        {
                            getNumber(noRows);
                        }
                        errP.Clear();
                        clearAddForm();
                        break;
                    

                case 2: //Edit tab selected
                   if (stockNoSelected == 0)
                   {
                        tabStock.SelectedIndex = 0;
                        //break;
                   }
                    else
                    {
                        lblEditStockNo.Text = stockNoSelected.ToString();
                        drStock = dsCOCOFitness.Tables["Stock"].Rows.Find(lblEditStockNo.Text);
                        if (drStock["MachineType"].ToString() == "Bike")
                            cmbEditMachineType.SelectedIndex = 0;
                        if (drStock["MachineType"].ToString() == "Tredmill")
                            cmbEditMachineType.SelectedIndex = 1;
                        if (drStock["MachineType"].ToString() == "MultiRack")
                            cmbEditMachineType.SelectedIndex = 2;
                        if (drStock["MachineType"].ToString() == "Stairs")
                            cmbEditMachineType.SelectedIndex = 3;
                        if (drStock["MachineType"].ToString() == "Wondercore")
                            cmbEditMachineType.SelectedIndex = 4;
                        if (drStock["MachineType"].ToString() == "Other")
                            cmbEditMachineType.SelectedIndex = 5;
                        
                        if (drStock["Quantity"].ToString() == "One")
                                cmbEditQuantity.SelectedIndex = 0;
                        if (drStock["Quantity"].ToString() == "Two")
                                cmbEditQuantity.SelectedIndex = 1;
                        if (drStock["Quantity"].ToString() == "Three")
                                cmbEditQuantity.SelectedIndex = 2; 
                        if (drStock["Quantity"].ToString() == "Four")
                                cmbEditQuantity.SelectedIndex = 3; 
                        if (drStock["Quantity"].ToString() == "Four")
                                cmbEditQuantity.SelectedIndex = 3;
                        if (drStock["Quantity"].ToString() == "Five")
                                cmbEditQuantity.SelectedIndex = 4;
                            txtEditMachineName.Text = drStock["Forename"].ToString();
                            txtEditPrice.Text = drStock["Price"].ToString();



                    }
                    break;
                    
                       
   
                    
            }
        }

                    private void getNumber(int noRows)
                    {
                        drStock = dsCOCOFitness.Tables["Stock"].Rows[noRows - 1];
                        lblAddStockNo.Text = (int.Parse(drStock["StockNo"].ToString()) + 1).ToString();
                        lblAddMachineNo.Text = (int.Parse(drStock["MachineNo"].ToString()) + 1).ToString();
                    }

                    void AddTabValidation(object sender, CancelEventArgs e)
                    {
                        if (dgvStock.SelectedRows.Count == 0)
                        {
                            stockSelected = false;
                            stockNoSelected = 0;
                        }
                        else if (dgvStock.SelectedRows.Count == 1)
                        {
                            stockSelected = true;
                            stockNoSelected = Convert.ToInt32(dgvStock.SelectedRows[0].Cells[0].Value);

                        }
                    }

        

        private void frmStock_Shown(object sender, EventArgs e)
        {
            tabStock.TabPages[0].CausesValidation = true;
            tabStock.TabPages[0].Validating += new CancelEventHandler(AddTabValidate);

            tabStock.TabPages[2].CausesValidation = true;
            tabStock.TabPages[2].Validating += new CancelEventHandler(EditTabValidate);

        }

        

        private void btnEDEdit_Click(object sender, EventArgs e)
        {
            if (btnEDEdit.Text == "Edit")
            {
                cmbEditMachineType.Enabled = true;
                txtEditMachineName.Enabled = true;
                cmbEditQuantity.Enabled = true;
                txtEditPrice.Enabled = true;


                btnEDEdit.Text = "Save";

            }
            else
            {
                MyStock myStock = new MyStock();
                bool ok = true;
                errP.Clear();

                try
                {
                    myStock.StockNo = Convert.ToInt32(lblEditStockNo.Text.Trim());

                }
                catch (MyException MyEx)

                {
                    ok = false;
                    errP.SetError(lblEditStockNo, MyEx.toString());
                }

                try
                {
                    myStock.StockNo = Convert.ToInt32(lblEditMachineNo.Text.Trim());

                }
                catch (MyException MyEx)

                {
                    ok = false;
                    errP.SetError(lblEditMachineNo, MyEx.toString());
                }

                try
                {
                    myStock.MachineType = cmbEditMachineType.Text.Trim();
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditMachineType, MyEx.toString());
                }

                try
                {
                    myStock.MachineName = txtEditMachineName.Text.Trim();
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtEditMachineName, MyEx.toString());
                }

                try
                {
                    myStock.Quantity = cmbEditQuantity.Text.Trim();
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditQuantity, MyEx.toString());
                }

                try
                {
                    myStock.Price = Convert.ToInt32(txtAddPrice.Text.Trim());
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(txtAddPrice, MyEx.toString());
                }



                try
                {
                    if (ok)
                    {
                        drStock.BeginEdit();

                        drStock["StockNo"] = myStock.StockNo;
                        drStock["MachineNo"] = myStock.MachineNo;
                        drStock["MachineType"] = myStock.MachineType;
                        drStock["MachineName"] = myStock.MachineName;
                        drStock["Quantity"] = myStock.Quantity;
                        drStock["Price"] = myStock.Price;
                      

                        drStock.EndEdit();
                        daStock.Update(dsCOCOFitness, "Stock");

                        MessageBox.Show("Stock Details Updated", "Stock");

                        cmbEditMachineType.Enabled = false;
                        txtEditMachineName.Enabled = false;
                        cmbEditQuantity.Enabled = false;
                        txtEditPrice.Enabled = false;
                       

                        
                        tabStock.SelectedIndex = 0;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.TargetSite + "" + ex.Message, "Error!",
                        MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                }
            }
        }

        

        private void btnDisplayDelete_Click(object sender, EventArgs e)
        {
            // if(lstCustomers.SelectedIndices.Count == 0)
            if (dgvStock.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Stock from the list.", "Select Stock");

            }
            else
            {
                drStock = dsCOCOFitness.Tables["Stock"].Rows.Find(dgvStock.SelectedRows[0].Cells[0].Value);
                string tempName = drStock["MachineType"].ToString() + "" + drStock["MachineName"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete" + tempName + "Details?", "Add Stock", MessageBoxButtons.YesNo) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    drStock.Delete();
                    daStock.Update(dsCOCOFitness, "Stock");
                }
            }
        }

        

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition of Stock No:  " +
                lblAddStockNo.Text + "?", "Add Stock", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabStock.SelectedIndex = 0;
        }

        

        private void btnDisplayEdit_Click(object sender, EventArgs e)
        {
            tabStock.SelectedIndex = 2;
        }

        

        private void txtAddMachineName_TextChanged(object sender, EventArgs e)
        {
            if (txtAddMachineName.Text.Length >= 2 &&
                    txtAddMachineName.Text.Length <= 15)
                txtAddMachineName.BackColor = Color.White;
            else
                txtAddMachineName.BackColor = Color.LightCoral;
        }

       

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the edit of Stock No:   " + lblEditStockNo.Text +
                  "?", "Edit Stock", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabStock.SelectedIndex = 0;
        }

        private void btnDisplayExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDisplayEdit_MouseEnter(object sender, EventArgs e)
        {
            btnDisplayEdit.ForeColor = Color.Blue;
        }

        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tabStock.SelectedIndex = 1;
        }

        void EditTabValidate(object sender, CancelEventArgs e)
        {
            if (stockSelected == false && stockNoSelected == 0)
            //have to do this here
            // reset tab to display and put out message to select a customer 
            {
                stockSelected = false;
                stockNoSelected = 0;
            }
            else if (dgvStock.SelectedRows.Count == 1)
            {
                stockSelected = true;
                stockNoSelected = Convert.ToInt32(dgvStock.SelectedRows[0].Cells[0].Value);
            }
        }

        void AddTabValidate(object sender, CancelEventArgs e) //Needs coded
        {
            if (stockSelected == false && stockNoSelected == 0)
            //have to do this here
            // reset tab to display and put out message to select a customer 
            {
                stockSelected = false;
                stockNoSelected = 0;
            }
            else if (dgvStock.SelectedRows.Count == 1)
            {
                stockSelected = true;
                stockNoSelected = Convert.ToInt32(dgvStock.SelectedRows[0].Cells[0].Value);
            }
        }




    }















    
}
