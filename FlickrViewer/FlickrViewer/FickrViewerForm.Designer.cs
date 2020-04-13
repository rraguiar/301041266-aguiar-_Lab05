namespace FlickrViewer
{
   partial class FickrViewerForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.label1 = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.imagesListBox = new System.Windows.Forms.ListBox();
            this.btnResizeSave = new System.Windows.Forms.Button();
            this.cBoxSizes = new System.Windows.Forms.ComboBox();
            this.lblComboBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Flickr search tags here:";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.Location = new System.Drawing.Point(217, 16);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(570, 22);
            this.inputTextBox.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(217, 49);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(671, 644);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(795, 13);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(93, 28);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // imagesListBox
            // 
            this.imagesListBox.FormattingEnabled = true;
            this.imagesListBox.ItemHeight = 16;
            this.imagesListBox.Location = new System.Drawing.Point(20, 49);
            this.imagesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.imagesListBox.Name = "imagesListBox";
            this.imagesListBox.Size = new System.Drawing.Size(188, 644);
            this.imagesListBox.TabIndex = 5;
            this.imagesListBox.SelectedIndexChanged += new System.EventHandler(this.imagesListBox_SelectedIndexChanged);
            // 
            // btnResizeSave
            // 
            this.btnResizeSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResizeSave.Location = new System.Drawing.Point(895, 13);
            this.btnResizeSave.Name = "btnResizeSave";
            this.btnResizeSave.Size = new System.Drawing.Size(164, 60);
            this.btnResizeSave.TabIndex = 6;
            this.btnResizeSave.Text = "Resize and Save";
            this.btnResizeSave.UseVisualStyleBackColor = true;
            this.btnResizeSave.Click += new System.EventHandler(this.btnResizeSave_Click);
            // 
            // cBoxSizes
            // 
            this.cBoxSizes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cBoxSizes.FormattingEnabled = true;
            this.cBoxSizes.Location = new System.Drawing.Point(895, 117);
            this.cBoxSizes.Name = "cBoxSizes";
            this.cBoxSizes.Size = new System.Drawing.Size(164, 24);
            this.cBoxSizes.TabIndex = 7;
            // 
            // lblComboBox
            // 
            this.lblComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComboBox.Location = new System.Drawing.Point(895, 85);
            this.lblComboBox.Name = "lblComboBox";
            this.lblComboBox.Size = new System.Drawing.Size(167, 29);
            this.lblComboBox.TabIndex = 8;
            this.lblComboBox.Text = "Choose Size to Save";
            this.lblComboBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FickrViewerForm
            // 
            this.AcceptButton = this.searchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 715);
            this.Controls.Add(this.imagesListBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResizeSave);
            this.Controls.Add(this.lblComboBox);
            this.Controls.Add(this.cBoxSizes);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FickrViewerForm";
            this.Text = "Flickr Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox inputTextBox;
      private System.Windows.Forms.PictureBox pictureBox;
      private System.Windows.Forms.Button searchButton;
      private System.Windows.Forms.ListBox imagesListBox;
        private System.Windows.Forms.Button btnResizeSave;
        private System.Windows.Forms.ComboBox cBoxSizes;
        private System.Windows.Forms.Label lblComboBox;
    }
}

