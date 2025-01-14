namespace Json_Practice_Winform
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageFetchButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cubePictureBox = new System.Windows.Forms.PictureBox();
            this.cardNameLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cardAmountTextBox = new System.Windows.Forms.TextBox();
            this.fetchCardButton = new System.Windows.Forms.Button();
            this.cardListBox = new System.Windows.Forms.ListBox();
            this.deckFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.jsonLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cubePictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageFetchButton
            // 
            this.imageFetchButton.Location = new System.Drawing.Point(479, 373);
            this.imageFetchButton.Name = "imageFetchButton";
            this.imageFetchButton.Size = new System.Drawing.Size(75, 23);
            this.imageFetchButton.TabIndex = 1;
            this.imageFetchButton.Text = "button1";
            this.imageFetchButton.UseVisualStyleBackColor = true;
            this.imageFetchButton.Click += new System.EventHandler(this.imageFetchButton_Click);
            // 
            // cubePictureBox
            // 
            this.cubePictureBox.Location = new System.Drawing.Point(3, 3);
            this.cubePictureBox.Name = "cubePictureBox";
            this.cubePictureBox.Size = new System.Drawing.Size(231, 291);
            this.cubePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cubePictureBox.TabIndex = 0;
            this.cubePictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.cubePictureBox, "text");
            this.cubePictureBox.DoubleClick += new System.EventHandler(this.cubePictureBox_DoubleClick);
            this.cubePictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cubePictureBox_MouseDown);
            // 
            // cardNameLabel
            // 
            this.cardNameLabel.AutoSize = true;
            this.cardNameLabel.Location = new System.Drawing.Point(240, 0);
            this.cardNameLabel.Name = "cardNameLabel";
            this.cardNameLabel.Size = new System.Drawing.Size(63, 13);
            this.cardNameLabel.TabIndex = 2;
            this.cardNameLabel.Text = "Palceholder";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cubePictureBox);
            this.flowLayoutPanel1.Controls.Add(this.cardNameLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(479, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(309, 313);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // cardAmountTextBox
            // 
            this.cardAmountTextBox.Location = new System.Drawing.Point(119, 376);
            this.cardAmountTextBox.Name = "cardAmountTextBox";
            this.cardAmountTextBox.Size = new System.Drawing.Size(100, 20);
            this.cardAmountTextBox.TabIndex = 4;
            // 
            // fetchCardButton
            // 
            this.fetchCardButton.Location = new System.Drawing.Point(242, 374);
            this.fetchCardButton.Name = "fetchCardButton";
            this.fetchCardButton.Size = new System.Drawing.Size(75, 23);
            this.fetchCardButton.TabIndex = 5;
            this.fetchCardButton.Text = "button1";
            this.fetchCardButton.UseVisualStyleBackColor = true;
            this.fetchCardButton.Click += new System.EventHandler(this.fetchCardButton_Click);
            // 
            // cardListBox
            // 
            this.cardListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardListBox.FormattingEnabled = true;
            this.cardListBox.ItemHeight = 25;
            this.cardListBox.Location = new System.Drawing.Point(12, 15);
            this.cardListBox.Name = "cardListBox";
            this.cardListBox.Size = new System.Drawing.Size(339, 329);
            this.cardListBox.TabIndex = 6;
            this.cardListBox.SelectedIndexChanged += new System.EventHandler(this.cardListBox_SelectedIndexChanged);
            // 
            // deckFlowLayoutPanel
            // 
            this.deckFlowLayoutPanel.AllowDrop = true;
            this.deckFlowLayoutPanel.AutoScroll = true;
            this.deckFlowLayoutPanel.Location = new System.Drawing.Point(19, 411);
            this.deckFlowLayoutPanel.Name = "deckFlowLayoutPanel";
            this.deckFlowLayoutPanel.Size = new System.Drawing.Size(1417, 306);
            this.deckFlowLayoutPanel.TabIndex = 7;
            this.deckFlowLayoutPanel.WrapContents = false;
            this.deckFlowLayoutPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.deckFlowLayoutPanel_DragDrop);
            this.deckFlowLayoutPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.deckFlowLayoutPanel_DragEnter);
            // 
            // jsonLabel
            // 
            this.jsonLabel.AutoSize = true;
            this.jsonLabel.Location = new System.Drawing.Point(810, 105);
            this.jsonLabel.Name = "jsonLabel";
            this.jsonLabel.Size = new System.Drawing.Size(35, 13);
            this.jsonLabel.TabIndex = 8;
            this.jsonLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 729);
            this.Controls.Add(this.jsonLabel);
            this.Controls.Add(this.deckFlowLayoutPanel);
            this.Controls.Add(this.cardListBox);
            this.Controls.Add(this.fetchCardButton);
            this.Controls.Add(this.cardAmountTextBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.imageFetchButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cubePictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button imageFetchButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label cardNameLabel;
        private System.Windows.Forms.PictureBox cubePictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox cardAmountTextBox;
        private System.Windows.Forms.Button fetchCardButton;
        private System.Windows.Forms.ListBox cardListBox;
        private System.Windows.Forms.FlowLayoutPanel deckFlowLayoutPanel;
        private System.Windows.Forms.Label jsonLabel;
    }
}

