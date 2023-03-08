using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WikiDataStructure
{
    public partial class FormWiki : Form
    {

        // Initial
        public FormWiki()
        {
            InitializeComponent();
        }

        // Global Variables
        static int row = 12;
        static int col = 4;
        //static string[,] DataTable = new string[row, col];

        // Initialise array
        static string[,] DataTable = new string[12, 4]{
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""},
            {"~", "", "", ""}
        };

        //static int index = 0;
        static int selectedIndex = 0;
        static bool sorted = false;

        // global file name
        string fileName = "definitions.dat";


        #region FUNCTIONS
        // Fill listview with array.
        private void UpdataListView()
        {
            ListViewData.Items.Clear();
            for (int x = 0; x < row; x++)
            {
                if (DataTable[x, 0] != "~") // filter out any "~" records.
                {
                    ListViewItem item = new ListViewItem(DataTable[x, 0]);
                    item.SubItems.Add(DataTable[x, 1]);
                    item.SubItems.Add(DataTable[x, 2]);
                    item.SubItems.Add(DataTable[x, 3]);
                    ListViewData.Items.Add(item);
                }
            }
        }
        private void ResetTable()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    DataTable[i, j] = "";
                }
            }

        }

        // Clear textboxes.
        private void ClearTextboxes()
        {
            txtName.Text = "";
            cboCategory.Text = "";
            rdoLinear.Checked = false;
            rdoNonLinear.Checked = false;
            txtDefinition.Text = "";
        }
        #endregion

        #region Modify data (add/edit/delete)
        // Add record from textboxes to array.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < row; x++)
            {
                if (txtName.Text != "")  // Check emtpy input.
                {
                    if (DataTable[x, 0] == "~")
                    {
                        toolStripStatusLabel1.Text = "";

                        DataTable[x, 0] = txtName.Text;
                        DataTable[x, 1] = cboCategory.Text;
                        DataTable[x, 2] = structure;
                        DataTable[x, 3] = txtDefinition.Text;

                        // Clear textboxes, focus cursor to txtName.
                        ClearTextboxes();
                        txtName.Focus();
                        break;  // after adding one record, ending loop.
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Cannot add, no space left";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Please enter new record";
                }
            }
            UpdataListView();
        }
        // Edit the selected record.
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                selectedIndex = ListViewData.SelectedIndices[0];
                toolStripStatusLabel1.Text = "";

                DataTable[selectedIndex, 0] = txtName.Text;
                DataTable[selectedIndex, 1] = cboCategory.Text;
                DataTable[selectedIndex, 2] = structure;
                DataTable[selectedIndex, 3] = txtDefinition.Text;
            }
            catch
            {
                toolStripStatusLabel1.Text = "No selected record to be edited";
            }
            ClearTextboxes();
            UpdataListView();
        }
        // Delete the selected record.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                selectedIndex = ListViewData.SelectedIndices[0];
                toolStripStatusLabel1.Text = "";
                DialogResult result = MessageBox.Show("Do you want to delete the record?", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DataTable[selectedIndex, 0] = "~";
                    DataTable[selectedIndex, 1] = "";
                    DataTable[selectedIndex, 2] = "";
                    DataTable[selectedIndex, 3] = "";
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "No selected record to be deleted.";
            }

            ClearTextboxes();
            UpdataListView();
        }
        #endregion

        #region Sort & Search
        private void btnBinarySearch_Click(object sender, EventArgs e)
        {
            /*// Check if textbox is filled
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                // Sort the data and refresh it
                SortTable();
                UpdataListView();
                // Create the target to search
                string target = txtSearch.Text;
                int first = 0;
                int last = row - 1;
                int position = -1;
                // Entry and exit condition for loop
                while (first <= last)
                {
                    int middle = (first + last) / 2;
                    // If target is found
                    if (DataTable[middle, 0] == target)
                    {
                        // Change position and highlight the entry
                        toolStripStatusLabel1.Text = "Fond";
                        position = middle;
                        ListViewData.SelectedItems.Clear();
                        ListViewData.Items[position].Selected = true;
                        ListViewData.Items[position].Focused = true;
                        ListViewData.Select();
                        // Exit out of loop
                        break;
                    }
                    // Change the middle if entry is higher or lower than the current position
                    else if (String.CompareOrdinal(DataTable[middle, 0], target) < 0)
                    {
                        first = middle + 1;
                    }
                    else if (String.CompareOrdinal(DataTable[middle, 0], target) > 0)
                    {
                        last = middle - 1;
                    }
                }
                // If position has not changed then it does not exist
                if (position == -1)
                {
                    toolStripStatusLabel1.Text = "The record does not exist";
                }
            }*/



            toolStripStatusLabel1.Text = "";
            // Declare variables. 
            string target = txtSearch.Text;
            int min = 0;
            int max = row - 1;

            // Check user empty input.
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                toolStripStatusLabel1.Text = "Please enter a data structure name";
                return;
            }

            // Check if the array has been sorted. 
            if (!sorted)
            {
                MessageBox.Show("Please click Sort first");
                return;
            }
            else
            {
                
                UpdataListView();

                // Using while loop to find the target element. 
                while (min <= max) // "<" to check the last one index[0]
                {
                    int mid = (min + max) / 2;
                    if (DataTable[mid, 0] == target)
                    {
                        ListViewData.Items[mid].Selected = true;
                        toolStripStatusLabel1.Text = "Fond";
                        break;
                    }

                    // Focus on the half top rows. 
                    else if (String.CompareOrdinal(DataTable[mid, 0], target) < 0)
                    {
                        min = mid + 1;
                    }

                    // Focus on the half bottom rows. 
                    else if (String.CompareOrdinal(DataTable[mid, 0], target) > 0)
                    {
                        max = mid - 1;
                    }
                    
                }
                if (min > max)
                {
                    toolStripStatusLabel1.Text = "The record does not exist!";
                }
                
                
            }

            txtSearch.Clear();

        }

        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            SortTable();
            sorted = true;
            UpdataListView();
        }
        // Sort method -- only sort the 1st column (Name).
        private void SortTable()
        {
            for (int x = 0; x < row; x++)
            {
                for (int i = 0; i < row - 1; i++)
                {
                    if (string.CompareOrdinal(DataTable[i, 0], DataTable[i + 1, 0]) > 0)
                    {
                        Swap(i);
                    }
                }
            }
            UpdataListView();
        }
        // Swap method -- swap whole row.
        private void Swap(int indx)
        {
            string temp;
            for (int z = 0; z < col; z++)
            {
                temp = DataTable[indx, z];
                DataTable[indx, z] = DataTable[indx + 1, z];
                DataTable[indx + 1, z] = temp;
            }
        }
        #endregion

        #region SAVE/LOAD

        // 9.10 Create a SAVE button so the information from the 2D array
        // can be written into a binary file called definitions.dat
        // which is sorted by Name, ensure the user has the option to
        // select an alternative file.
        // Use a file stream and BinaryWriter to create the file. 
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = @"C:\\temp\\";
            savefile.Filter = "Binary File (*.dat)|*.dat";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string fileName = savefile.FileName;
                using (BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Append)))
                {
                    // Writing the dimensions of the array to the file
                    //bw.Write(WikiTable.GetLength(0));
                    //bw.Write(WikiTable.GetLength(1));

                    // Writing the data of the array to the file
                    for (int i = 0; i < row; i++)
                    {

                        for (int j = 0; j < col; j++)
                        {

                            if (string.IsNullOrEmpty(DataTable[i, j]))
                            {
                                bw.Write("");
                            }
                            else
                            {
                                bw.Write(DataTable[i, j]);
                            }
                        }

                    }
                }
            }
            /*SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Binary file|*.dat";
            //saveFile.FileName = "definitions.dat"; // Default.
            saveFile.Title = "Save file";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryWriter bw = new BinaryWriter(new FileStream(fileName, FileMode.Create));
                    // Use nested loop to access each elements
                    for (int x = 0; x < row; x++)
                    {
                        for (int y = 0; y < col; y++)
                        {
                            try
                            {
                                // Write each data to the file
                                bw.Write(DataTable[x, y]);
                            }
                            catch (Exception fe)
                            {
                                MessageBox.Show(fe.Message + "\nInvalid data.");
                                return;
                            }
                        }
                    }
                    bw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }*/

        }

        // 9.11 Create a LOAD button that will read the information from a binary file
        // called definitions.dat into the 2D array, ensure the user has the option
        // to select an alternative file.
        // Use a file stream and BinaryReader to complete this task.
        private void btnLoad_Click(object sender, EventArgs e)
        {
            int rowRef = 0;

            ResetTable();

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Binary File (*.dat)|*.dat";
                openFile.InitialDirectory = @"C:\\temp\\";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string openFileName = openFile.FileName;
                    BinaryReader br = new BinaryReader(new FileStream(openFileName, FileMode.Open));
                    for (int i = 0; i < row; i++)
                    {
                        try
                        {
                            for (int j = 0; j < col; j++)
                            {
                                DataTable[i, j] = br.ReadString();
                            }
                            rowRef++;
                        }
                        catch (Exception)
                        {
                            toolStripStatusLabel1.Text = "Cannot load file";
                            break;
                        }

                    }
                    br.Close();
                    UpdataListView();
                }
            }
            /*// Using OpenFileDialog to select file to be opened.
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Binary file|*.dat";
            //openFile.FileName = "definitions.dat"; // Default.
            openFile.Title = "Load file";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ListViewData.Items.Clear(); // Clear listbox

                // Reading from the file
                try
                {
                    BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open));
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        for (int x = 0; x < row; x++)
                        {
                            for (int y = 0; y < col; y++)
                            {
                                try
                                {
                                    DataTable[x, y] = br.ReadString();
                                    
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message + "\nCannot read data from file");
                                    return;
                                }
                            }
                        }
                        br.Close();
                    }

                }
                catch (Exception)
                {
                    toolStripStatusLabel1.Text = "Cannot open file for reading";
                    return;
                }
                // read data from file until the end of the file                    

                // Close the file
                
            }
            UpdataListView();*/
        }
        #endregion

        #region EVENTS

        // Radio buttons (Structure: Linear/Non-Linear).
        string structure = "";
        private void rdoLinear_CheckedChanged(object sender, EventArgs e)
        {
            structure = "Linear";
        }
        private void rdoNonLinear_CheckedChanged(object sender, EventArgs e)
        {
            structure = "Non-Linear";
        }

        // 9.5 A double mouse click in the name text box will clear all four text boxes
        // and focus the cursor into the name text box.
        // Double click event
        private void txtName_DoubleClick_1(object sender, EventArgs e)
        {
            txtName.Clear();
            cboCategory.Text = null;
            rdoLinear.Checked = false;
            rdoNonLinear.Checked = false;
            txtDefinition.Clear();

            txtName.Focus();
        }

        // Double click listView to delete record.
        private void ListViewData_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = ListViewData.SelectedIndices[0];
            DialogResult result = MessageBox.Show("Do you want to delete the record?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataTable[selectedIndex, 0] = "~";
                DataTable[selectedIndex, 1] = "";
                DataTable[selectedIndex, 2] = "";
                DataTable[selectedIndex, 3] = "";
            }
            SortTable();
            ClearTextboxes();
            UpdataListView();
        }

        // 9.9 Create a method so the user can select a definition (Name) from the ListView
        // and all the information is displayed in the appropriate Textboxes.
        // Single click event
        private void ListViewData_MouseClick_1(object sender, MouseEventArgs e)
        {
            // Get each col. data.
            string name = ListViewData.SelectedItems[0].SubItems[0].Text;
            string category = ListViewData.SelectedItems[0].SubItems[1].Text;
            string structureData = ListViewData.SelectedItems[0].SubItems[2].Text;
            string definition = ListViewData.SelectedItems[0].SubItems[3].Text;

            // Pass the data to textboxes.
            txtName.Text = name;
            cboCategory.Text = category;
            txtDefinition.Text = definition;

            if (structureData == "Linear")
            {
                rdoLinear.Checked = true;
            }
            else if (structureData == "Non-Linear")
            {
                rdoNonLinear.Checked = true;
            }
        }

        #endregion        
    }
}



