namespace Ksu.Cis300.BTrees
{
    partial class NameLookUp
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
            this.uxMinLabel = new System.Windows.Forms.Label();
            this.uxNumItemsLabel = new System.Windows.Forms.Label();
            this.uxMakeTree = new System.Windows.Forms.Button();
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxName = new System.Windows.Forms.TextBox();
            this.uxLookUp = new System.Windows.Forms.Button();
            this.uxFrequencyLabel = new System.Windows.Forms.Label();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxFrequency = new System.Windows.Forms.TextBox();
            this.uxRank = new System.Windows.Forms.TextBox();
            this.uxMinDegree = new System.Windows.Forms.NumericUpDown();
            this.uxCount = new System.Windows.Forms.NumericUpDown();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxCount)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMinLabel
            // 
            this.uxMinLabel.AutoSize = true;
            this.uxMinLabel.Location = new System.Drawing.Point(13, 13);
            this.uxMinLabel.Name = "uxMinLabel";
            this.uxMinLabel.Size = new System.Drawing.Size(86, 13);
            this.uxMinLabel.TabIndex = 0;
            this.uxMinLabel.Text = "Minimum Degree";
            // 
            // uxNumItemsLabel
            // 
            this.uxNumItemsLabel.AutoSize = true;
            this.uxNumItemsLabel.Location = new System.Drawing.Point(12, 38);
            this.uxNumItemsLabel.Name = "uxNumItemsLabel";
            this.uxNumItemsLabel.Size = new System.Drawing.Size(84, 13);
            this.uxNumItemsLabel.TabIndex = 1;
            this.uxNumItemsLabel.Text = "Number of Items";
            // 
            // uxMakeTree
            // 
            this.uxMakeTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxMakeTree.Location = new System.Drawing.Point(161, 9);
            this.uxMakeTree.Name = "uxMakeTree";
            this.uxMakeTree.Size = new System.Drawing.Size(134, 54);
            this.uxMakeTree.TabIndex = 4;
            this.uxMakeTree.Text = "Make Tree";
            this.uxMakeTree.UseVisualStyleBackColor = true;
            this.uxMakeTree.Click += new System.EventHandler(this.uxMakeTree_Click);
            // 
            // uxOpen
            // 
            this.uxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxOpen.Location = new System.Drawing.Point(13, 69);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(282, 43);
            this.uxOpen.TabIndex = 5;
            this.uxOpen.Text = "Open Data File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.AutoSize = true;
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxNameLabel.Location = new System.Drawing.Point(12, 124);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(66, 24);
            this.uxNameLabel.TabIndex = 6;
            this.uxNameLabel.Text = "Name:";
            // 
            // uxName
            // 
            this.uxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxName.Location = new System.Drawing.Point(79, 121);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(216, 29);
            this.uxName.TabIndex = 7;
            // 
            // uxLookUp
            // 
            this.uxLookUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxLookUp.Location = new System.Drawing.Point(15, 163);
            this.uxLookUp.Name = "uxLookUp";
            this.uxLookUp.Size = new System.Drawing.Size(280, 47);
            this.uxLookUp.TabIndex = 8;
            this.uxLookUp.Text = "Get Statistics";
            this.uxLookUp.UseVisualStyleBackColor = true;
            this.uxLookUp.Click += new System.EventHandler(this.uxLookUp_Click);
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.AutoSize = true;
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxFrequencyLabel.Location = new System.Drawing.Point(12, 216);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(107, 24);
            this.uxFrequencyLabel.TabIndex = 9;
            this.uxFrequencyLabel.Text = "Frequency:";
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxRankLabel.Location = new System.Drawing.Point(12, 251);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(58, 24);
            this.uxRankLabel.TabIndex = 10;
            this.uxRankLabel.Text = "Rank:";
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxFrequency.Location = new System.Drawing.Point(128, 216);
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.ReadOnly = true;
            this.uxFrequency.Size = new System.Drawing.Size(167, 29);
            this.uxFrequency.TabIndex = 11;
            // 
            // uxRank
            // 
            this.uxRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxRank.Location = new System.Drawing.Point(79, 251);
            this.uxRank.Name = "uxRank";
            this.uxRank.ReadOnly = true;
            this.uxRank.Size = new System.Drawing.Size(216, 29);
            this.uxRank.TabIndex = 12;
            // 
            // uxMinDegree
            // 
            this.uxMinDegree.Location = new System.Drawing.Point(106, 13);
            this.uxMinDegree.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.uxMinDegree.Name = "uxMinDegree";
            this.uxMinDegree.Size = new System.Drawing.Size(49, 20);
            this.uxMinDegree.TabIndex = 13;
            this.uxMinDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxMinDegree.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // uxCount
            // 
            this.uxCount.Location = new System.Drawing.Point(106, 39);
            this.uxCount.Name = "uxCount";
            this.uxCount.Size = new System.Drawing.Size(49, 20);
            this.uxCount.TabIndex = 14;
            this.uxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NameLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 297);
            this.Controls.Add(this.uxCount);
            this.Controls.Add(this.uxMinDegree);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxLookUp);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.uxNameLabel);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxMakeTree);
            this.Controls.Add(this.uxNumItemsLabel);
            this.Controls.Add(this.uxMinLabel);
            this.Name = "NameLookUp";
            this.Text = "B Trees";
            ((System.ComponentModel.ISupportInitialize)(this.uxMinDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxMinLabel;
        private System.Windows.Forms.Label uxNumItemsLabel;
        private System.Windows.Forms.Button uxMakeTree;
        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.Button uxLookUp;
        private System.Windows.Forms.Label uxFrequencyLabel;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.TextBox uxFrequency;
        private System.Windows.Forms.TextBox uxRank;
        private System.Windows.Forms.NumericUpDown uxMinDegree;
        private System.Windows.Forms.NumericUpDown uxCount;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

