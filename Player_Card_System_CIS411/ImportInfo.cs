using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data;
using System.Drawing;

namespace Player_Card_System_CIS411
{
    class ImportInfo
    {
        string fileName;
        public ImportInfo()
        {
            if(GetPath())
            {
                ReadFile();
            }
            else
            {
                MessageBox.Show("Error With File");
            }
            
        }

        private void ReadFile()
        {
            Database.WipeDatabase();
            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(fileName))
            {
                // Reads through every worksheet in the excel file
                foreach (IXLWorksheet workSheet in workBook.Worksheets)
                {
                    //Create a new DataTable.
                    DataTable dt = new DataTable();
                    //Loop through the Worksheet rows.
                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        //Use the first row to add columns to DataTable.
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            //Add rows to DataTable.
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                if (cell.IsEmpty())
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = "";
                                }
                                else
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                }
                                
                                i++;
                            }
                        }
                    }
                    Database.RestoreDatabase(dt, workSheet.Name);
                  //  dataTables.Add(dt);
                }
                Console.WriteLine("Restore Complete");
            }
        }

        private bool GetPath()
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select File";
            fdlg.FileName = fileName;
            fdlg.Filter = "Excel Sheet (*.xlsx)|*.xlsx|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;

            
            if (fdlg.ShowDialog() == DialogResult.OK)

            {
                string fileExt = System.IO.Path.GetExtension(fdlg.FileName);
                MessageBox.Show(fileExt);
                if (fileExt == ".xlsx")
                {
                    fileName = fdlg.FileName;
                    Console.WriteLine(fileName);
                    return true;
                }


            }
            return false;
        }
    }
}
