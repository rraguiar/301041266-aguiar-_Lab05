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

        public MainWindow()
        {
            InitializeComponent();
            progBarLoadFile.Minimum = 1; // set minimum on progress bar.
        }

        private async void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            btnLoadFile.IsEnabled = false;
            dGridStockData.ItemsSource = null;
            //Ensure the List is empty before reading from file.
            stockData.Clear();
            //Count size of file to setup progress bar maximum
            try
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                            fileLines++;
                    }
                }
                progBarLoadFile.Maximum = fileLines;
                fileLines = 0;
                progBarLoadFile.Value = 0;
                //Read the file asynchronously and load into the List of stock objects
                stockData = await readFile();
                //Load into Data Grid
                dGridStockData.ItemsSource = stockData.OrderBy(r=>r.Date);
                progBarLoadFile.Maximum = stockData.Count();
                lblLoadMessages.Content = "File Loaded.";
                lblErrorMessages.Content = stockData.Count() + " entries found.";
                btnLoadFile.IsEnabled = true;
                btnSearch.IsEnabled = true;
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
            while (!sr.EndOfStream)
            {
                string line = await sr.ReadLineAsync();
                if (!String.IsNullOrWhiteSpace(line) && !line.Contains("Symbol") && !line.Contains('('))
                {
                    if (!line.Contains('"'))
                    {
                        //Most of the lines doesn´t need special treatment, so this statement is faster and GUI is more responsive
                        string[] values = line.Split(',');
                        //Load each file line into the List of stockdata objects
                        stockData.Add(new StockData(values[0].ToUpper(), DateTime.Parse(values[1]), values[2], values[3], values[4], values[5]));
                    }
                    else
                    {
                        //For the lines with thousands (so double quotes and commas) this statement performs the treatment - heavier processing
                        var stringParser = new TextFieldParser(new StringReader(line));
                        stringParser.TextFieldType = FieldType.Delimited;
                        stringParser.HasFieldsEnclosedInQuotes = true;
                        stringParser.SetDelimiters(",");
                        string[] values = stringParser.ReadFields();
                        //Load each file line into the List of stockdata objects
                        stockData.Add(new StockData(values[0].ToUpper(), DateTime.Parse(values[1]), values[2], values[3], values[4], values[5]));
                    }                                       
                    progBarLoadFile.Value = stockData.Count();
                }
            }
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
            searchStockData.Clear();
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
            if (searchStockData.Count != 0)
            {
                lblErrorMessages.Content = "";
                dGridStockData.ItemsSource = stockData.OrderBy(r => r.Date);
                tBoxSymbol.Text = "";

            }
        }
    }
}
