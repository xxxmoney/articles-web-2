namespace Multithreading.Example
{
    public partial class MainForm : Form
    {
        private readonly ImageResolver resolver;

        public MainForm()
        {
            InitializeComponent();

            // Initialzie image resolver.
            this.resolver = new ImageResolver();
        }

        private async void buttonGet_Click(object sender, EventArgs e)
        {
            // Disable button.
            this.buttonGet.Enabled = false;

            try
            {
                // Dispose of previous image if present.
                if (this.pictureBox.Image != null)
                {
                    this.pictureBox.Image.Dispose();
                }

                // Get image with resolver.
                var bytes = await this.resolver.GetImageAsync();

                // Timeout for test.
                await Task.Delay(2000);

                // Set image into picture box.
                this.pictureBox.Image = Image.FromStream(new MemoryStream(bytes));
                this.pictureBox.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Error.");
            }

            // Enable button.
            this.buttonGet.Enabled = true;
        }
    }
}
