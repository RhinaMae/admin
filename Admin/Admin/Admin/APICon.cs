using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Data;
using Newtonsoft.Json.Linq;

namespace Admin
{
    class APICon
    {
        public static async Task DgvViewingAsync(DataGridView dgv)
        {
            try
            {
                string apiUrl = "http://192.168.117.70:3000/programming-languages/employees";
                await DgvResultEmployees(dgv, apiUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        public static async Task DgvViewlate(DataGridView dgv,string date)
        {
            try
            {
                string apiUrl = "http://192.168.117.70:3000/programming-languages/records?date='"+ date + "'";
               
                await DgvResultView(dgv, apiUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        public static async Task DgvResultView(DataGridView dgv, string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send the GET request and receive the response
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content as a string
                        string responseData = await response.Content.ReadAsStringAsync();

                        JObject jsonResponse = JObject.Parse(responseData);

                        JArray dataArray = jsonResponse["data"] as JArray;

                        if (dataArray != null)
                        {
                            DataTable dt = new DataTable();

                            // Assume that the first item in the array has all the columns
                            JObject firstItem = dataArray.FirstOrDefault() as JObject;

                            if (firstItem != null)
                            {
                                // Add columns to DataTable based on JSON keys
                                foreach (JProperty property in firstItem.Properties())
                                {
                                    dt.Columns.Add(property.Name, typeof(string));
                                }

                                // Populate the DataTable with data
                                foreach (JObject dataObject in dataArray)
                                {
                                    DataRow row = dt.NewRow();

                                    foreach (JProperty property in dataObject.Properties())
                                    {
                                        row[property.Name] = property.Value.ToString();
                                    }

                                    dt.Rows.Add(row);
                                }

                                dgv.DataSource = dt;

                                // Optionally, set specific column properties or hide columns
                                // For example, hiding the Employee_ID column
                                dgv.Columns["Employee_ID"].Visible = false;

                                dgv.Refresh();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error fetching data. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        public static async Task DgvResultEmployees(DataGridView dgv, string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send the GET request and receive the response
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content as a string
                        string responseData = await response.Content.ReadAsStringAsync();

                        JObject jsonResponse = JObject.Parse(responseData);

                        JArray dataArray = jsonResponse["data"] as JArray;

                        if (dataArray != null)
                        {
                            DataTable dt = new DataTable();

                            // Assuming that the first object in the array has all the columns
                            foreach (JProperty property in dataArray.First.Children<JProperty>())
                            {
                                dt.Columns.Add(property.Name, typeof(string));
                            }

                            // Populate the DataTable with data
                            foreach (JObject dataObject in dataArray)
                            {
                                DataRow row = dt.NewRow();
                                foreach (JProperty property in dataObject.Properties())
                                {
                                    row[property.Name] = property.Value.ToString();
                                }
                                dt.Rows.Add(row);
                            }

                            dgv.DataSource = dt;

                            // Optionally, set specific column properties or hide columns
                            // For example, hiding the Employee_ID column
                            dgv.Columns["Employee_ID"].Visible = false;

                            dgv.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error fetching data. Status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

    }
}
    
