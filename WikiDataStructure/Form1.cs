/*
 * Dongyun Huang 30042104
 * 12/3/2023 week_6
 * 
 * Describe: This program is used to perform as a wiki, by using a 
 *           2D string array to operate data structure definitions.
 */

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
using System.Security.Policy;
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

        // Initialise form
        public FormWiki()
        {
            InitializeComponent();
            ResetTable();
        }

        // Global Variables
        static int row = 12;
        static int col = 4;
        static int selectedIndex = 0;
        static bool sorted = false;

        // 9.1 Create a global 2D string array, use static variables for the dimensions (row = 12, column = 4)
        static string[,] DataTable = new string[row, col]; // Initialise array
/*        static string[,] DataTable = new string[12, 4]{ // Initialise array
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
        };*/

        #region FUNCTIONS
        // 9.8 Create a display method that will show the following information in a ListView: Name and Category
        private void UpdateListView()
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
        // Initialise array
        private void ResetTable()
        {
            for (int i = 0; i < row; i++)
            {                
                DataTable[i, 0] = "~"; // The 1st column set "~".
                for (int j = 1; j < col; j++)  // The rest set "".
                {
                    DataTable[i, j] = "";
                }
            }
            UpdateListView();
        }

        // Clear textboxes.
        private void ClearTextboxes()
        {
            txtName.Text = "";
            txtCategory.Text = "";
            txtStructure.Text = "";
            txtDefinition.Text = "";
        }
        #endregion

        #region EVENTS
        // 9.5 A double mouse click in the name text box will clear all four text boxes
        //     and focus the cursor into the name text box.
        // Double click event
        private void txtName_DoubleClick_1(object sender, EventArgs e)
        {
            txtName.Clear();
            txtCategory.Clear();
            txtStructure.Clear();
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
            UpdateListView();
        }
        // 9.9 Create a method so the user can select a definition (Name) from the ListView
        //     and all the information is displayed in the appropriate Textboxes.
        // Single click event
        private void ListViewData_MouseClick_1(object sender, MouseEventArgs e)
        {
            // Get each col. data.
            string name = ListViewData.SelectedItems[0].SubItems[0].Text;
            string category = ListViewData.SelectedItems[0].SubItems[1].Text;
            string structure = ListViewData.SelectedItems[0].SubItems[2].Text;
            string definition = ListViewData.SelectedItems[0].SubItems[3].Text;

            // Pass the data to textboxes.
            txtName.Text = name;
            txtCategory.Text = category;
            txtStructure.Text = structure;
            txtDefinition.Text = definition;
        }
        #endregion        

        #region Modify data (add/edit/delete)
        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void btnAdd_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = ""; // Clear user feedback; avoid confusing.
            for (int x = 0; x < row; x++)
            {
                if (txtName.Text != "")  // Check emtpy input.
                {
                    if (DataTable[x, 0] == "~")
                    {                    
                        DataTable[x, 0] = txtName.Text;
                        DataTable[x, 1] = txtCategory.Text;
                        DataTable[x, 2] = txtStructure.Text;
                        DataTable[x, 3] = txtDefinition.Text;
                        toolStripStatusLabel1.Text = "Successfully added.";
                        ClearTextboxes(); // Clear all textboxes.
                        txtName.Focus(); // Focus cursor to txtName.
                        break;  // after adding one record, ending loop.
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Cannot add, no space left";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Please enter a new record";
                }
            }            
            UpdateListView();
        }
        // 9.3 Create an EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        private void btnEdit_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            try
            {
                selectedIndex = ListViewData.SelectedIndices[0]; // Get the index of which has been selected.              
                DataTable[selectedIndex, 0] = txtName.Text;
                DataTable[selectedIndex, 1] = txtCategory.Text;
                DataTable[selectedIndex, 2] = txtStructure.Text;
                DataTable[selectedIndex, 3] = txtDefinition.Text;
                toolStripStatusLabel1.Text = "Successfully edited.";
            }
            catch
            {
                toolStripStatusLabel1.Text = "No selected record to be edited";
            }
            ClearTextboxes();
            UpdateListView();
        }
        // 9.4 Create a DELETE button that removes all the information from a single entry of the array;
        //     the user must be prompted before the final deletion occurs
        private void btnDelete_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
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
                    toolStripStatusLabel1.Text = "Successfully deleted";
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "No selected record to be deleted.";
            }
            ClearTextboxes();
            UpdateListView();
        }
        #endregion

        #region Sort & Search
       
        // 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending, ensure you use
        //     a separate swap method that passes the array element to be swapped (do not use any built-in array methods)
        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Data sorted";
            SortTable();            
            UpdateListView();
        }
        // Sort method -- only sort the 1st column (Name).
        private void SortTable()
        {
            for (int x = 0; x < row; x++)
            {
                for (int i = 0; i < row - 1; i++) // NB: "row - 1" -> next line "i + 1" will not out of bound.
                {
                    if (string.CompareOrdinal(DataTable[i, 0], DataTable[i + 1, 0]) > 0)
                    {
                        Swap(i);
                    }
                }
            }
            sorted = true;
        }
        // Swap method -- swap whole row.
        private void Swap(int indx)
        {
            string temp;
            for (int i = 0; i < col; i++)
            {
                temp = DataTable[indx, i];
                DataTable[indx, i] = DataTable[indx + 1, i];
                DataTable[indx + 1, i] = temp;
            }
        }
        // 9.7 Write the code for a Binary Search for the Name in the 2D array and
        //     display the information in the other textboxes when found, add suitable feedback if the search
        //     in not successful and clear the search textbox(do not use any built-in array methods)
        private void btnBinarySearch_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            // Declare variables. 
            string target = txtSearch.Text;
            int min = 0;
            int max = row - 1;

            if (string.IsNullOrEmpty(txtSearch.Text)) // Check user empty input.
            {
                toolStripStatusLabel1.Text = "Please enter a data structure name";
                return;
            }

            if (!sorted) // Check if the array has been sorted. 
            {
                toolStripStatusLabel1.Text = "Please click Sort first";
                return;
            }

            while (min <= max) //// Using while loop to find the target element. "<" to check the last one index[0]
            {
                int mid = (min + max) / 2;
                if (string.CompareOrdinal(DataTable[mid, 0], target) == 0) // If the mid of array equals target, giving feedback to user, exiting loop.
                {
                    toolStripStatusLabel1.Text = "Fond in row " + (mid + 1);
                    ListViewData.SelectedItems.Clear();
                    ListViewData.Items[mid].Selected = true;
                    ListViewData.Focus(); // Highlight the target.
                    txtName.Text = DataTable[mid, 0];
                    txtCategory.Text = DataTable[mid, 1];
                    txtStructure.Text = DataTable[mid, 2];
                    txtDefinition.Text = DataTable[mid, 3];
                    break; // End loop.
                }
                else if (string.CompareOrdinal(DataTable[mid, 0], target) < 0) // If the mid of array less than target, focus on the half bottom records.
                {
                    min = mid + 1;
                }
                else if (string.CompareOrdinal(DataTable[mid, 0], target) > 0) // If the mid of array greater than target, focus on the half top records.
                {
                    max = mid - 1;
                }
            }
            if (min > max) // Not found case.
            {
                toolStripStatusLabel1.Text = "The record does not exist!";
            }
            txtSearch.Clear(); // Empty search textbox, be read for next use.
        }
        #endregion

        #region SAVE/LOAD
        // 9.10 Create a SAVE button so the information from the 2D array
        //      can be written into a binary file called definitions.dat
        //      which is sorted by Name, ensure the user has the option to
        //      select an alternative file.
        //      Use a file stream and BinaryWriter to create the file. 
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.InitialDirectory = @"C:\\temp\\";
            savefile.Filter = "definitions (*.dat)|*.dat";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                string definitions = savefile.FileName;
                using (BinaryWriter bw = new BinaryWriter(new FileStream(definitions, FileMode.Create))) // NB: BinaryFormatter serialization methods are obsolete.
                {
                    // Using nested loop to access each element of array, then using BinaryWriter.Write() save the data to the file
                    for (int i = 0; i < row; i++)
                    {
                        for (int j = 0; j < col; j++)
                        {                            
                            bw.Write(DataTable[i, j]);                            
                        }
                    }
                    toolStripStatusLabel1.Text = "File saved";
                    bw.Close(); // Close always.
                }
            }           
        }
        // 9.11 Create a LOAD button that will read the information from a binary file
        //      called definitions.dat into the 2D array, ensure the user has the option
        //      to select an alternative file.
        //      Use a file stream and BinaryReader to complete this task.
        private void btnLoad_Click(object sender, EventArgs e)
        {     
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                ResetTable(); // Clear the previous data opened file
                openFile.Filter = "definitions (*.dat)|*.dat";
                openFile.InitialDirectory = @"C:\\temp\\";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string definitions = openFile.FileName;
                    BinaryReader br = new BinaryReader(new FileStream(definitions, FileMode.Open));
                    for (int i = 0; i < row; i++)
                    {
                        try
                        {
                            for (int j = 0; j < col; j++)
                            {
                                DataTable[i, j] = br.ReadString();
                            }
                        }
                        catch (Exception)
                        {
                            toolStripStatusLabel1.Text = "Cannot load file";
                            break;
                        }
                    }
                    toolStripStatusLabel1.Text = "New file loaded";
                    br.Close();
                    UpdateListView();
                }
            }            
        }
        #endregion                
    }
}



