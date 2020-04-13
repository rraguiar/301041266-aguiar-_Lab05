// Fig. 23.4: FickrViewerForm.cs
// Invoking a web service asynchronously with class HttpClient
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FlickrViewer
{
    public partial class FickrViewerForm : Form
    {
        // Use your Flickr API key here--you can get one at:
        // https://www.flickr.com/services/apps/create/apply
        private const string KEY = "2e77003f5a5ab4e50baf9fcedfc5ee0c";
        // object used to invoke Flickr web service      
        private static HttpClient flickrClient = new HttpClient();
        Task<string> flickrTask = null; // Task<string> that queries Flickr
        //Make FlickrPhotos a global variable
        //var FlickrPhotos;
        IEnumerable<FlickrResult> flickrPhotos;
        byte[] imageToSave;
        int imageNumber = 0;
        public FickrViewerForm()
        {
            InitializeComponent();
            //Initialize ComboBox options
            cBoxSizes.Items.AddRange(new object[] { "Half Size", "Full Size" });
            cBoxSizes.SelectedIndex = 0;
        }

        // initiate asynchronous Flickr search query; 
        // display results when query completes
        private async void searchButton_Click(object sender, EventArgs e)
        {
            // if flickrTask already running, prompt user 
            if (flickrTask?.Status != TaskStatus.RanToCompletion)
            {
                var result = MessageBox.Show(
                   "Cancel the current Flickr search?",
                   "Are you sure?", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
                // determine whether user wants to cancel prior search
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    flickrClient.CancelPendingRequests(); // cancel search
                }
            }
            // Flickr's web service URL for searches                         
            var flickrURL = "https://api.flickr.com/services/rest/?method=" +
               $"flickr.photos.search&api_key={KEY}&" +
               $"tags={inputTextBox.Text.Replace(" ", ",")}" +
               "&tag_mode=all&per_page=500&privacy_filter=1";
            imagesListBox.DataSource = null; // remove prior data source
            imagesListBox.Items.Clear(); // clear imagesListBox
            pictureBox.Image = null; // clear pictureBox
            imagesListBox.Items.Add("Loading..."); // display Loading...
            // invoke Flickr web service to search Flick with user's tags
            flickrTask = flickrClient.GetStringAsync(flickrURL);
            // await flickrTask then parse results with XDocument and LINQ
            XDocument flickrXML = XDocument.Parse(await flickrTask);
            // gather information on all photos
            flickrPhotos =
               from photo in flickrXML.Descendants("photo")
               let id = photo.Attribute("id").Value
               let title = photo.Attribute("title").Value
               let secret = photo.Attribute("secret").Value
               let server = photo.Attribute("server").Value
               let farm = photo.Attribute("farm").Value
               select new FlickrResult
               {
                   Title = title,
                   URL = $"https://farm{farm}.staticflickr.com/" +
                     $"{server}/{id}_{secret}.jpg"
               };
            imagesListBox.Items.Clear(); // clear imagesListBox
            // set ListBox properties only if results were found
            if (flickrPhotos.Any())
            {
                imagesListBox.DataSource = flickrPhotos.ToList();
                imagesListBox.DisplayMember = "Title";
            }
            else // no matches were found
            {
                imagesListBox.Items.Add("No matches");
            }
        }

        // display selected image
        private async void imagesListBox_SelectedIndexChanged(
           object sender, EventArgs e)
        {
            if (imagesListBox.SelectedItem != null)
            {
                string selectedURL = ((FlickrResult)imagesListBox.SelectedItem).URL;
                try
                {
                    // use HttpClient to get selected image's bytes asynchronously
                    byte[] imageBytes = await flickrClient.GetByteArrayAsync(selectedURL);
                    // display downloaded image in pictureBox                  
                    using (var memoryStream = new MemoryStream(imageBytes))
                    {
                        pictureBox.Image = Image.FromStream(memoryStream);
                    }
                }
                //I don´t want to do anything at this point, just avoid from the app breaking.
                catch { }
            }
        }
        /// <summary>
        /// Method to handle the resize and save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResizeSave_Click(object sender, EventArgs e)
        {
            int comboBoxSelection = cBoxSizes.SelectedIndex;
            try
            {
                if (flickrPhotos.Any())
                {
                    string imageName = "picture";
                    Parallel.ForEach(flickrPhotos, (image) => saveImage(comboBoxSelection, imageName, image));
                }
                else
                {
                    MessageBox.Show("No image found to Save.");
                }
            }
            catch { }
        }
        /// <summary>
        /// Method that resize the picture accordingly to the option selected on the Combo Box
        /// and save it as a ".png" file.
        /// </summary>
        /// <param name="comboBoxIndex"></param>
        /// <param name="imageName"></param>
        /// <param name="image"></param>
        private void saveImage(int comboBoxIndex, string imageName, FlickrResult image)
        {
            try
            {
                imageToSave = (Task.Run(() => flickrClient.GetByteArrayAsync(image.URL)).Result);
                MemoryStream memoryStream = new MemoryStream(imageToSave);
                Image img = Image.FromStream(memoryStream);
                imageNumber++;
                //if comboBox is at index position 0, Half Size images, otherwise it saves on the original size
                if (comboBoxIndex == 0)
                {
                    img = img.GetThumbnailImage((int)(img.Width / 2), (int)(img.Height / 2), null, IntPtr.Zero);
                }
                //Uses the SAVE method from Image class and save the files into the \bin\Debug
                img.Save((imageName + imageNumber + ".png"), System.Drawing.Imaging.ImageFormat.Png);
            }
            catch { }
        }
    }
}
/**************************************************************************
 * (C) Copyright 1992-2017 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************/
