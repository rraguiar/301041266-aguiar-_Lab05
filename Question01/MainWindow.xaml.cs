using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Question01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List of StockData objects to load into the DataGrid
        List<StockData> stockData = new List<StockData>();
        //List of StockData after searched for specific stock.
        List<StockData> searchStockData = new List<StockData>();
        //counter to file lines
        long fileLines = 1;
        //Path of the file
        string filePath = @"../../Model/stockData.csv";
        //string[] values;

        //Regex regex = new Regex("^[$]?([0 - 9]{1, 2})?,?([0 - 9]{3})?,?([0 - 9]{3})?(.[0-9]{2})");

        public MainWindow()
        {
            InitializeComponent();
            progBarLoadFile.Minimum = 1; // set minimum on progress bar.
        }

        private async void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            btnLoadFile.IsEnabled = false;
            dGridStockData.ItemsSource = null;
            //Count size of file to set progress bar maximum
            //Ensure the List is empty before reading from file.
            stockData.Clear();
            //Count size of file to setup progress bar maximum
            try
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string line;
                    //string[] items;
                    while ((line = r.ReadLine()) != null)
                    {
                        //items= line.Split(',');
                        //if (regex.IsMatch(items[2])&& regex.IsMatch(items[3])&& regex.IsMatch(items[4]) && regex.IsMatch(items[5]))
                            fileLines++;
                    }
                }
                progBarLoadFile.Maximum = fileLines;
                fileLines = 0;
                progBarLoadFile.Value = 0;
                //Read the file asynchronously and load into the List of stock objects
                stockData = await readFile();
                //Load into Data Grid
                dGridStockData.ItemsSource = stockData;
            }
            catch
            {
                lblErrorMessages.Content = "File \"" + filePath + "\" not found.";
                btnLoadFile.IsEnabled = true;
            }

        }
        private async Task<List<StockData>> readFile()
        {
            //StreamReader object to read from the .csv file
            StreamReader sr = new StreamReader(File.OpenRead(filePath));
            lblLoadMessages.Content = "Loading file...";
            //while (!sr.EndOfStream)
            //{
                //string line = await sr.ReadLineAsync();
                
                //if (!String.IsNullOrWhiteSpace(line))
                //{
                    //string[] values = line.Split(',');

                    var test = new TextFieldParser (sr);
                    test.TextFieldType = FieldType.Delimited;
                    test.HasFieldsEnclosedInQuotes = true;
                    test.SetDelimiters(",");

                    string[] values = test.ReadFields();

                    if (!values[0].Contains("Symbol"))
                    {
                    //try
                    //{
                    //Load each file line into the List of stockdata objects
                    //stockData.Add(new StockData(values[0].ToUpper(), DateTime.Parse(values[1]), values[2], values[3], values[4], values[5]));
                    lblLoadMessages.Content = "Size: " + values.Length;
                            progBarLoadFile.Value++;
                            //await Task.Delay(1);
                        //}
                        //catch
                        //{
                        //    continue;
                        //}
                    }
                //}
            //}

            lblLoadMessages.Content = "File Loaded.";
            lblErrorMessages.Content = stockData.Count() + " entries found.";
            btnLoadFile.IsEnabled = true;
            btnSearch.IsEnabled = true;

            return stockData;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnSearch.IsEnabled = false;
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int number = 0;
            try
            {
                number = int.Parse(tBoxNumber.Text);
                for (int i=number-1; i>=2;i--)
                {
                    number = number * i;
                }
                tBoxResult.Text = number.ToString();
            }
            catch
            {
                lblErrorMessages.Content = "Must be a number to Calculate Factorial.";
            }
            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchKey = tBoxSymbol.Text.ToUpper();
            searchStockData.AddRange(from stock in stockData
                                     where stock.Symbol == searchKey
                                     orderby stock.Date
                                     select stock);
            if (searchStockData.Count==0)
            {
                lblErrorMessages.Content = "Not found.";
            }
            else
            {
                dGridStockData.ItemsSource = searchStockData;
                lblErrorMessages.Content = searchStockData.Count.ToString()+" entries found.";
            }
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            lblErrorMessages.Content = "";
            dGridStockData.ItemsSource = stockData;
            tBoxSymbol.Text = "";
        }
    }
}
