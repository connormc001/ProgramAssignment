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
    public partial class frmparts : Form
    {

        SqlDataAdapter daParts;
        DataSet dsCOCOFitness = new DataSet();
        SqlCommandBuilder cmdBParts;
        DataRow drParts;
        String connStr, sqlParts;
        int selectedTab = 0;
        bool partSelected = false;
        int partNoSelected = 0;

        public frmparts()
        {
            InitializeComponent();
        }



        private void frmparts_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = .; Initial Catalog = COCOFitness; Integrated Security = true";

            sqlParts = @"select * from Parts";
            daParts = new SqlDataAdapter(sqlParts, connStr);
            cmdBParts = new SqlCommandBuilder(daParts);
            daParts.FillSchema(dsCOCOFitness, SchemaType.Source, "Parts");
            daParts.Fill(dsCOCOFitness, "Parts");

            dgvParts.DataSource = dsCOCOFitness.Tables["Parts"];

            //Resize the DataGridView columns to fit the newly loaded content.

            dgvParts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            tabParts.SelectedIndex = 1;
            tabParts.SelectedIndex = 0;
        }

        

        private void btnAddAdd_Click(object sender, EventArgs e)
        {
            MyParts myParts = new MyParts();
            bool ok = true;
            errP.Clear();

            try
            {
                myParts.PartNo = Convert.ToInt32(lblAddPartNo.Text.Trim());
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(lblAddPartNo, MyEx.toString());
            }

         

            try
            {
                myParts.MachineType = cmbAddMachineType.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddMachineType, MyEx.toString());
            }

           

            try
            {
                myParts.Quantity = cmbAddQuantity.Text.Trim();
            }
            catch (MyException MyEx)
            {
                ok = false;
                errP.SetError(cmbAddQuantity, MyEx.toString());
            }

            try
            {
                myParts.Price = Convert.ToInt32(txtAddPrice.Text.Trim());
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
                    drParts = dsCOCOFitness.Tables["Part"].NewRow();
                    drParts["PartNo"] = myParts.PartNo;
                    drParts["MachineType"] = myParts.MachineType;
                    drParts["PartDesc"] = myParts.PartDesc;
                    drParts["Quantity"] = myParts.Quantity;
                    drParts["Price"] = myParts.Price;


                    dsCOCOFitness.Tables["Parts"].Rows.Add(drParts);
                    daParts.Update(dsCOCOFitness, "Parts");

                    MessageBox.Show("Part Added");

                    if (MessageBox.Show("Do you wish to add another Part?", "Add Part"
                        , MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        clearAddForm();
                        getNumber(dsCOCOFitness.Tables["Parts"].Rows.Count);
                    }
                    else
                        tabParts.SelectedIndex = 0;
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
                txtAddPartDesc.Clear();
                cmbAddQuantity.SelectedIndex = -1;
                txtAddPrice.Clear();

            }

        private void tabParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTab = tabParts.SelectedIndex;

            tabParts.TabPages[tabParts.SelectedIndex].Focus();
            tabParts.TabPages[tabParts.SelectedIndex].CausesValidation = true;

            if (dgvParts.SelectedRows.Count == 0 && tabParts.SelectedIndex == 2)
                tabParts.TabPages[tabParts.SelectedIndex].CausesValidation = true;

            //else
            //{
            switch (tabParts.SelectedIndex)
            {
                case 0: // Display Tab Selected
                    {
                        dsCOCOFitness.Tables["Parts"].Clear();
                        daParts.Fill(dsCOCOFitness, "Parts");

                        break;
                    }
                case 1: //Add tab Selected
                    {
                        int noRows = dsCOCOFitness.Tables["Parts"].Rows.Count;
                        if (noRows == 0)
                            lblAddPartNo.Text = "10000";
                        else
                        {
                            getNumber(noRows);
                        }
                        errP.Clear();
                        clearAddForm();
                        break;
                    }

                case 2: //Edit tab selected
                    {
                        if (partNoSelected == 0)
                        {
                            //tabParts.SelectedIndex = 0;
                            
                        }
                       else
                        {

                            lblEditPartNo.Text = partNoSelected.ToString();

                            drParts =
                                dsCOCOFitness.Tables["Parts"].Rows.Find(lblEditPartNo.Text);

                            if (drParts["MachineType"].ToString() == "Bike")
                                cmbEditMachineType.SelectedIndex = 0;
                            if (drParts["MachineType"].ToString() == "Tredmill")
                                cmbEditMachineType.SelectedIndex = 1;
                            if (drParts["MachineType"].ToString() == "MultiRack")
                                cmbEditMachineType.SelectedIndex = 2;
                            if (drParts["MachineType"].ToString() == "Stairs")
                                cmbEditMachineType.SelectedIndex = 3;
                            if (drParts["MachineType"].ToString() == "Wondercore")
                                cmbEditMachineType.SelectedIndex = 4;
                            if (drParts["MachineType"].ToString() == "Other")
                                cmbEditMachineType.SelectedIndex = 5;

                            if (drParts["Quantity"].ToString() == "One")
                                cmbEditQuantity.SelectedIndex = 0;
                            if (drParts["Quantity"].ToString() == "Two")
                                cmbEditQuantity.SelectedIndex = 1;
                            if (drParts["Quantity"].ToString() == "Three")
                                cmbEditQuantity.SelectedIndex = 2;
                            if (drParts["Quantity"].ToString() == "Four")
                                cmbEditQuantity.SelectedIndex = 3;
                            if (drParts["Quantity"].ToString() == "Five")
                                cmbEditQuantity.SelectedIndex = 4;

                            txtEditPartDesc.Text = drParts["Part Description"].ToString();
                            txtEditPrice.Text = drParts["Price"].ToString();
                        }
                        break;
                    }
            }
        }


        private void getNumber(int noRows)
        {
            drParts = dsCOCOFitness.Tables["Parts"].Rows[noRows - 1];
            lblAddPartNo.Text = (int.Parse(drParts["PartNo"].ToString()) + 1).ToString();
            
        }

        void AddTabValidation(object sender, CancelEventArgs e)
        {
            if (dgvParts.SelectedRows.Count == 0)
            {
                partSelected = false;
                partNoSelected = 0;
            }
            else if (dgvParts.SelectedRows.Count == 1)
            {
                partSelected = true;
                partNoSelected = Convert.ToInt32(dgvParts.SelectedRows[0].Cells[0].Value);

            }
        }


        private void frmparts_Shown(object sender, EventArgs e)
        {
            tabParts.TabPages[0].CausesValidation = true;
            tabParts.TabPages[0].Validating += new CancelEventHandler(AddTabValidate);

            tabParts.TabPages[2].CausesValidation = true;
            tabParts.TabPages[2].Validating += new CancelEventHandler(EditTabValidate);
        }

        private void btnEDEdit_Click(object sender, EventArgs e)
        {
            if (btnEDEdit.Text == "Edit")
            {
                cmbEditMachineType.Enabled = true;
                txtEditPartDesc.Enabled = true;
                cmbEditQuantity.Enabled = true;
                txtEditPrice.Enabled = true;


                btnEDEdit.Text = "Save";

            }
            else
            {
                MyParts myParts = new MyParts();
                bool ok = true;
                errP.Clear();

                try
                {
                    myParts.PartNo = Convert.ToInt32(lblEditPartNo.Text.Trim());

                }
                catch (MyException MyEx)

                {
                    ok = false;
                    errP.SetError(lblEditPartNo, MyEx.toString());
                }

                

                try
                {
                    myParts.MachineType = cmbEditMachineType.Text.Trim();
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditMachineType, MyEx.toString());
                }

                
                try
                {
                    myParts.Quantity = cmbEditQuantity.Text.Trim();
                }
                catch (MyException MyEx)
                {
                    ok = false;
                    errP.SetError(cmbEditQuantity, MyEx.toString());
                }

                try
                {
                    myParts.Price = Convert.ToInt32(txtEditPrice.Text.Trim());

                }
                catch (MyException MyEx)

                {
                    ok = false;
                    errP.SetError(txtEditPrice, MyEx.toString());
                }



                try
                {
                    if (ok)
                    {
                        drParts.BeginEdit();

                        drParts["PartsNo"] = myParts.PartNo;
                        
                        drParts["MachineType"] = myParts.MachineType;
                        drParts["PartDescription"] = myParts.PartDesc;
                        drParts["Quantity"] = myParts.Quantity;
                        drParts["Price"] = myParts.Price;


                        drParts.EndEdit();
                        daParts.Update(dsCOCOFitness, "Parts");

                        MessageBox.Show("Part Details Updated", "Parts");

                        cmbEditMachineType.Enabled = false;
                        
                        cmbEditQuantity.Enabled = false;
                        txtEditPrice.Enabled = false;


                        btnEDEdit.Text = "Edit";
                        tabParts.SelectedIndex = 0;
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
            // if(lstParts.SelectedIndices.Count == 0)
            if (dgvParts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Part from the list.", "Select Part");

            }
            else
            {
                drParts = dsCOCOFitness.Tables["Parts"].Rows.Find(dgvParts.SelectedRows[0].Cells[0].Value);
                string tempName = drParts["MachineType"].ToString() + "" + drParts["Part Description"].ToString() + "\'s";

                if (MessageBox.Show("Are you sure you want to delete" + tempName + "Details?", "Add Part", MessageBoxButtons.YesNo) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    drParts.Delete();
                    daParts.Update(dsCOCOFitness, "Parts");
                }
            }
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the addition of Part No:  " +
             lblAddPartNo.Text + "?", "Add Part", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabParts.SelectedIndex = 0;
        }

        private void btnDisplayEdit_Click(object sender, EventArgs e)
        {
            tabParts.SelectedIndex = 2;
        }

        private void txtAddPartDesc_TextChanged(object sender, EventArgs e)
        {
            if (txtAddPartDesc.Text.Length >= 2 &&
                    txtAddPartDesc.Text.Length <= 15)
                txtAddPartDesc.BackColor = Color.White;
            else
                txtAddPartDesc.BackColor = Color.LightCoral;
        }

        private void btnEditCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel the edit of Part No:   " + lblEditPartNo.Text +
                  "?", "Edit Part", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                tabParts.SelectedIndex = 0;
        }

        private void btnDisplayExit_Click(object sender, EventArgs e)
        {
            btnEDEdit.ForeColor = Color.Blue;
        }

        private void btnDisplayAdd_Click(object sender, EventArgs e)
        {
            tabParts.SelectedIndex = 1;
        }

        void EditTabValidate(object sender, CancelEventArgs e)
        {
            if (partSelected == false && partNoSelected == 0)
            //have to do this here
            // reset tab to display and put out message to select a part
            {
                partSelected = false;
                partNoSelected = 0;
            }
            else if (dgvParts.SelectedRows.Count == 1)
            {
                partSelected = true;
                partNoSelected = Convert.ToInt32(dgvParts.SelectedRows[0].Cells[0].Value);
            }
        }

        void AddTabValidate(object sender, CancelEventArgs e)
        {
            if (partSelected == false && partNoSelected == 0)
            //have to do this here
            // reset tab to display and put out message to select a part
            {
                partSelected = false;
                partNoSelected = 0;
            }
            else if (dgvParts.SelectedRows.Count == 1)
            {
                partSelected = true;
                partNoSelected = Convert.ToInt32(dgvParts.SelectedRows[0].Cells[0].Value);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
   
}
