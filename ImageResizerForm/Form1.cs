using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageResizer
{
    public partial class ImageResizerForm : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private bool _isProcessing = false;

        public ImageResizerForm()
        {
            InitializeComponent();
            SetupInitialState();
        }

        private void SetupInitialState()
        {
            // Setup resolution combo box
            cboVerticalResolution.Items.AddRange(new object[] { 640, 1080, 2160 });
            cboVerticalResolution.SelectedItem = 1080;

            // Setup checkbox
            chkOverwrite.Checked = true;

            // Disable process button until we have a valid input path
            btnProcess.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtInputPath.Text = dialog.SelectedPath;
                // Auto-set output path
                txtOutputPath.Text = Path.Combine(dialog.SelectedPath, "shrunk");
                btnProcess.Enabled = true;
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = dialog.SelectedPath;
            }
        }

        private void txtInputPath_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtInputPath.Text))
            {
                txtOutputPath.Text = Path.Combine(txtInputPath.Text, "shrunk");
                btnProcess.Enabled = true;
            }
            else
            {
                btnProcess.Enabled = false;
            }
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (_isProcessing)
                return;

            if (!Directory.Exists(txtInputPath.Text))
            {
                MessageBox.Show("Please select a valid input folder.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create output directory if it doesn't exist
            Directory.CreateDirectory(txtOutputPath.Text);

            // Get all jpg files
            var files = Directory.GetFiles(txtInputPath.Text, "*.jpg", SearchOption.TopDirectoryOnly)
                               .Concat(Directory.GetFiles(txtInputPath.Text, "*.jpeg", SearchOption.TopDirectoryOnly))
                               .ToArray();

            if (files.Length == 0)
            {
                MessageBox.Show("No JPG files found in the input folder.", "No Files", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isProcessing = true;
            btnProcess.Enabled = false;
            btnCancel.Enabled = true;
            progressBar.Value = 0;
            progressBar.Maximum = files.Length;

            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                var targetHeight = (int)cboVerticalResolution.SelectedItem;
                var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount,
                    CancellationToken = _cancellationTokenSource.Token
                };

                var processedCount = 0;

                await Task.Run(() =>
                {
                    Parallel.ForEach(files, options, (file) =>
                    {
                        if (_cancellationTokenSource.Token.IsCancellationRequested)
                            return;

                        var outputPath = Path.Combine(txtOutputPath.Text, Path.GetFileName(file));

                        if (!chkOverwrite.Checked && File.Exists(outputPath))
                            return;

                        try
                        {
                            ResizeImage(file, outputPath, targetHeight);
                            Interlocked.Increment(ref processedCount);
                            this.Invoke(() => progressBar.Value = processedCount);
                        }
                        catch (Exception ex)
                        {
                            // Log error but continue processing
                            Debug.WriteLine($"Error processing {file}: {ex.Message}");
                        }
                    });
                }, _cancellationTokenSource.Token);

                MessageBox.Show($"Processing complete! {processedCount} images resized.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Operation cancelled by user.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isProcessing = false;
                btnProcess.Enabled = true;
                btnCancel.Enabled = false;
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private void ResizeImage(string inputPath, string outputPath, int targetHeight)
        {
            using var image = Image.FromFile(inputPath);
            // Calculate new width maintaining aspect ratio
            int targetWidth = (int)((double)image.Width * targetHeight / image.Height);

            using var resized = new Bitmap(targetWidth, targetHeight);
            using var graphics = Graphics.FromImage(resized);

            // High quality rendering settings
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Draw the resized image
            graphics.DrawImage(image, 0, 0, targetWidth, targetHeight);

            // Save with high quality JPEG settings
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 90L);
            var jpegCodec = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
            resized.Save(outputPath, jpegCodec, encoderParameters);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            btnCancel.Enabled = false;
        }
    }
}