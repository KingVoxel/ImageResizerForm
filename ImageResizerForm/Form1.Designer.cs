namespace ImageResizer
{
    partial class ImageResizerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageResizerForm));

            txtInputPath = new TextBox();
            txtOutputPath = new TextBox();
            btnBrowseInput = new Button();
            btnBrowseOutput = new Button();
            label1 = new Label();
            label2 = new Label();
            chkOverwrite = new CheckBox();
            cboVerticalResolution = new ComboBox();
            label3 = new Label();
            progressBar = new ProgressBar();
            btnProcess = new Button();
            btnCancel = new Button();
            labelVersion = new Label();
            SuspendLayout();
            // 
            // txtInputPath
            // 
            txtInputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInputPath.Location = new Point(12, 27);
            txtInputPath.Name = "txtInputPath";
            txtInputPath.Size = new Size(459, 23);
            txtInputPath.TabIndex = 0;
            txtInputPath.TextChanged += txtInputPath_TextChanged;
            // 
            // txtOutputPath
            // 
            txtOutputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtOutputPath.Location = new Point(12, 71);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(459, 23);
            txtOutputPath.TabIndex = 1;
            // 
            // btnBrowseInput
            // 
            btnBrowseInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseInput.Location = new Point(477, 27);
            btnBrowseInput.Name = "btnBrowseInput";
            btnBrowseInput.Size = new Size(75, 23);
            btnBrowseInput.TabIndex = 2;
            btnBrowseInput.Text = "Browse...";
            btnBrowseInput.UseVisualStyleBackColor = true;
            btnBrowseInput.Click += btnBrowseInput_Click;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseOutput.Location = new Point(477, 71);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(75, 23);
            btnBrowseOutput.TabIndex = 3;
            btnBrowseOutput.Text = "Browse...";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 4;
            label1.Text = "Input Path:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 5;
            label2.Text = "Output Path:";
            // 
            // chkOverwrite
            // 
            chkOverwrite.AutoSize = true;
            chkOverwrite.Location = new Point(12, 100);
            chkOverwrite.Name = "chkOverwrite";
            chkOverwrite.Size = new Size(147, 19);
            chkOverwrite.TabIndex = 6;
            chkOverwrite.Text = "Overwrite existing files";
            chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // cboVerticalResolution
            // 
            cboVerticalResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVerticalResolution.FormattingEnabled = true;
            cboVerticalResolution.Location = new Point(12, 140);
            cboVerticalResolution.Name = "cboVerticalResolution";
            cboVerticalResolution.Size = new Size(121, 23);
            cboVerticalResolution.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 143);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 8;
            label3.Text = "Vertical Resolution";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(12, 177);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(540, 23);
            progressBar.TabIndex = 9;
            // 
            // btnProcess
            // 
            btnProcess.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnProcess.Location = new Point(396, 206);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(75, 23);
            btnProcess.TabIndex = 10;
            btnProcess.Text = "Process";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(477, 206);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(12, 211);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(40, 15);
            labelVersion.TabIndex = 12;
            labelVersion.Text = "v1.0.0";
            // 
            // ImageResizerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 241);
            Controls.Add(labelVersion);
            Controls.Add(btnCancel);
            Controls.Add(btnProcess);
            Controls.Add(progressBar);
            Controls.Add(label3);
            Controls.Add(cboVerticalResolution);
            Controls.Add(chkOverwrite);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBrowseOutput);
            Controls.Add(btnBrowseInput);
            Controls.Add(txtOutputPath);
            Controls.Add(txtInputPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("ImageSizer.ico")));
            MinimumSize = new Size(580, 280);
            Name = "ImageResizerForm";
            Text = "Image Resizer";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtInputPath;
        private TextBox txtOutputPath;
        private Button btnBrowseInput;
        private Button btnBrowseOutput;
        private Label label1;
        private Label label2;
        private CheckBox chkOverwrite;
        private ComboBox cboVerticalResolution;
        private Label label3;
        private ProgressBar progressBar;
        private Button btnProcess;
        private Button btnCancel;
        private Label labelVersion;
    }
}