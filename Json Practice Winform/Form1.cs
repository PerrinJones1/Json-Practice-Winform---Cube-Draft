using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Json_Practice_Winform
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
        }

        private async void imageFetchButton_Click(object sender, EventArgs e)
        {
            // establishes the random variable

            Random random = new Random();

            // grabs Httpclient class

            HttpClient httpClient = new HttpClient();

            // pulls names from the MTGO vintage cube .txt file to then search in the API

            List<string> cardNames = File.ReadAllLines("MTGOVintageCube.txt").ToList();

            // selects a card from random out of the .txt file

            string randomCardNames = cardNames[random.Next(cardNames.Count)];


            // scryfall API database
            
            string apiUrl = $"https://api.scryfall.com/cards/named?exact={Uri.EscapeDataString(randomCardNames)}";
            try
            {
                
                using (HttpClient client = httpClient)
                {
                    // scryfall needs header for requests

                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Perrin/1.0");
                    client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON into a JsonDocument
                        using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                        {
                            // Access the image URL using JsonElement
                            JsonElement root = doc.RootElement;

                            // Get the image URL from the JSON response
                            string imageUrl = root.GetProperty("image_uris").GetProperty("normal").GetString();

                            // Fetch the image
                            byte[] imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                            // Display the image in the PictureBox
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                cubePictureBox.Image = Image.FromStream(ms);
                                cardNameLabel.Text = randomCardNames.ToString();
                                
                            }
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show($"api failed code: {response.StatusCode}");
                    }
                }
                
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void fetchCardButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(cardAmountTextBox.Text, out int numberOfLines))
                {
                    return;
                }
                string filePath = "MTGOVintageCube.txt";

                List<string> lines = File.ReadAllLines(filePath).ToList();

                if (lines.Count < numberOfLines)
                {
                    MessageBox.Show("not enough lines");
                    return;
                }

                Shuffle(lines);
                List<string> selectedLines = lines.Take(numberOfLines).ToList();
                cardListBox.Items.Clear();

                foreach (string kablamo in selectedLines)
                {
                    cardListBox.Items.Add(kablamo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void Shuffle(List<string> list)
        {   

            // yates shuffle 
            Random rng = new Random();
            int n = list.Count;

            while (n > 0)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        private async void cardListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cardListBox.SelectedIndex;

            // Ensure a valid selection
            if (selectedIndex != -1)
            {
                // Get the selected card name from the ListBox (instead of using the index)

                string selectedCard = cardListBox.Items[selectedIndex].ToString();
                string apiUrl = $"https://api.scryfall.com/cards/named?exact={Uri.EscapeDataString(selectedCard)}";

                try
                {
                    // Creates HttpClient that can be reused
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.UserAgent.ParseAdd("Perrin/2.0");
                        client.DefaultRequestHeaders.Accept.ParseAdd("application/json");

                        // Make the GET request to the API
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        // Check if the response is successful
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();


                            // lets me see the Json text, this is for finding out the mana costs of the card.

                            var jsonDocumentText = JsonDocument.Parse(jsonResponse);
                            /*string formattedJson = JsonSerializer.Serialize(jsonDocumentText, new JsonSerializerOptions
                            {
                                WriteIndented = true,
                            });
                            jsonLabel.Text = formattedJson;
                            */
                            // Deserialize the JSON into a JsonDocument
                            using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                            {
                                JsonElement root = doc.RootElement;

                                // Ensure the 'image_uris' property exists in the response
                                if (root.TryGetProperty("image_uris", out JsonElement imageUris))
                                {
                                    // Get the 'normal' image URL from the response
                                    string imageUrl = imageUris.GetProperty("normal").GetString();

                                    // Fetch the image
                                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

                                    // Display the image in the PictureBox on the UI thread
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        cubePictureBox.Image = Image.FromStream(ms);
                                        cardNameLabel.Text = selectedCard; // Display the card name
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Image URL not found for the card.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show($"API request failed with status code: {response.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"error: {ex.Message}");
                }
            }
        }

        public void cubePictureBox_DoubleClick(object sender, EventArgs e)
        {
            AddImagesToFlowLayoutPanel(cubePictureBox.Image);
        }

        public void AddImagesToFlowLayoutPanel(Image image)
        {
            PictureBox pictureBox = new PictureBox()
            {
                Image = image,
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom,
                Margin = new Padding(2)
            };
            deckFlowLayoutPanel.Padding = new Padding(2);
            pictureBox.MouseDown += PictureBox_MouseDown;
            deckFlowLayoutPanel.Controls.Add(pictureBox);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (e.Button == MouseButtons.Right)
            {
                pictureBox.DoDragDrop(pictureBox, DragDropEffects.Move);
            }
        }

        private void cubePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (e.Button == MouseButtons.Right)
            {
                pictureBox.DoDragDrop(pictureBox, DragDropEffects.Move);
            }
        }

        private void deckFlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void deckFlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)e.Data.GetData(typeof(PictureBox));

            Point dropLocation = deckFlowLayoutPanel.PointToClient(new Point(e.X, e.Y));

            pictureBox.Location = dropLocation;

            deckFlowLayoutPanel.Controls.Add(pictureBox);
        }
    }
}
