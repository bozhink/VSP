using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace GreekTagger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (this.textToSend.Text.Length > 0)
            {
                ////displayResultText.Text = Examples.System.Net.WebRequestPostExample.Mainnn(this.textToSend.Text);

                using (HttpClient client = new HttpClient())
                {
                    Dictionary<string, string> values = new Dictionary<string, string>();

                    values.Add("document", this.textToSend.Text);
                    values.Add("entity_types", "-2 -25 -26 -27");
                    values.Add("format", "xml");

                    HttpContent content = new FormUrlEncodedContent(values);

                    // Task<HttpResponseMessage> response = client.PostAsync("http://tagger.jensenlab.org/GetHTML", content);
                    Task<HttpResponseMessage> response = client.PostAsync("http://tagger.jensenlab.org/GetEntities", content);

                    Task<string> responseString = response.Result.Content.ReadAsStringAsync();
                    displayResultText.Text = responseString.Result;
                }
            }
            else
            {
                MessageBox.Show("No text to send.");
            }
        }
    }
}
