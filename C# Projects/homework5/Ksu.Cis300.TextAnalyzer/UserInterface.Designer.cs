namespace Ksu.Cis300.TextAnalyzer
{
    partial class UserInterface
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
            this.uxSelectText1 = new System.Windows.Forms.Button();
            this.uxSelectText2 = new System.Windows.Forms.Button();
            this.uxText1 = new System.Windows.Forms.TextBox();
            this.uxText2 = new System.Windows.Forms.TextBox();
            this.uxNumberOfWords = new System.Windows.Forms.NumericUpDown();
            this.uxAnalyze = new System.Windows.Forms.Button();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxNumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfWords)).BeginInit();
            this.SuspendLayout();
            // 
            // uxSelectText1
            // 
            this.uxSelectText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxSelectText1.Location = new System.Drawing.Point(13, 13);
            this.uxSelectText1.Name = "uxSelectText1";
            this.uxSelectText1.Size = new System.Drawing.Size(143, 43);
            this.uxSelectText1.TabIndex = 0;
            this.uxSelectText1.Text = "Text 1:";
            this.uxSelectText1.UseVisualStyleBackColor = true;
            this.uxSelectText1.Click += new System.EventHandler(this.uxSelectText1_Click);
            // 
            // uxSelectText2
            // 
            this.uxSelectText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxSelectText2.Location = new System.Drawing.Point(14, 75);
            this.uxSelectText2.Name = "uxSelectText2";
            this.uxSelectText2.Size = new System.Drawing.Size(142, 43);
            this.uxSelectText2.TabIndex = 1;
            this.uxSelectText2.Text = "Text 2:";
            this.uxSelectText2.UseVisualStyleBackColor = true;
            this.uxSelectText2.Click += new System.EventHandler(this.uxSelectText2_Click);
            // 
            // uxText1
            // 
            this.uxText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxText1.Location = new System.Drawing.Point(179, 19);
            this.uxText1.Name = "uxText1";
            this.uxText1.ReadOnly = true;
            this.uxText1.Size = new System.Drawing.Size(355, 29);
            this.uxText1.TabIndex = 2;
            // 
            // uxText2
            // 
            this.uxText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxText2.Location = new System.Drawing.Point(179, 81);
            this.uxText2.Name = "uxText2";
            this.uxText2.ReadOnly = true;
            this.uxText2.Size = new System.Drawing.Size(355, 29);
            this.uxText2.TabIndex = 3;
            // 
            // uxNumberOfWords
            // 
            this.uxNumberOfWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxNumberOfWords.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uxNumberOfWords.Location = new System.Drawing.Point(238, 148);
            this.uxNumberOfWords.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.uxNumberOfWords.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumberOfWords.Name = "uxNumberOfWords";
            this.uxNumberOfWords.Size = new System.Drawing.Size(64, 29);
            this.uxNumberOfWords.TabIndex = 5;
            this.uxNumberOfWords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxNumberOfWords.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // uxAnalyze
            // 
            this.uxAnalyze.Enabled = false;
            this.uxAnalyze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxAnalyze.Location = new System.Drawing.Point(326, 141);
            this.uxAnalyze.Name = "uxAnalyze";
            this.uxAnalyze.Size = new System.Drawing.Size(208, 43);
            this.uxAnalyze.TabIndex = 6;
            this.uxAnalyze.Text = "Analyze Texts";
            this.uxAnalyze.UseVisualStyleBackColor = true;
            this.uxAnalyze.Click += new System.EventHandler(this.uxAnalyze_Click);
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            // 
            // uxNumberLabel
            // 
            this.uxNumberLabel.AutoSize = true;
            this.uxNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxNumberLabel.Location = new System.Drawing.Point(10, 150);
            this.uxNumberLabel.Name = "uxNumberLabel";
            this.uxNumberLabel.Size = new System.Drawing.Size(222, 24);
            this.uxNumberLabel.TabIndex = 4;
            this.uxNumberLabel.Text = "Number of Words to Use:";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 200);
            this.Controls.Add(this.uxAnalyze);
            this.Controls.Add(this.uxNumberOfWords);
            this.Controls.Add(this.uxNumberLabel);
            this.Controls.Add(this.uxText2);
            this.Controls.Add(this.uxText1);
            this.Controls.Add(this.uxSelectText2);
            this.Controls.Add(this.uxSelectText1);
            this.Name = "UserInterface";
            this.Text = "Text Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxSelectText1;
        private System.Windows.Forms.Button uxSelectText2;
        private System.Windows.Forms.TextBox uxText1;
        private System.Windows.Forms.TextBox uxText2;
        private System.Windows.Forms.NumericUpDown uxNumberOfWords;
        private System.Windows.Forms.Button uxAnalyze;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.Label uxNumberLabel;
    }
}

