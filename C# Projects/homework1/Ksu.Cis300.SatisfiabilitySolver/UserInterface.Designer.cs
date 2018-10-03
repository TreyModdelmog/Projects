namespace Ksu.Cis300.SatisfiabilitySolver
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
            this.uxRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uxSolutionLabel = new System.Windows.Forms.Label();
            this.uxSolution = new System.Windows.Forms.TextBox();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxRead
            // 
            this.uxRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRead.Location = new System.Drawing.Point(12, 12);
            this.uxRead.Name = "uxRead";
            this.uxRead.Size = new System.Drawing.Size(351, 41);
            this.uxRead.TabIndex = 0;
            this.uxRead.Text = "Read Formula";
            this.uxRead.UseVisualStyleBackColor = true;
            this.uxRead.Click += new System.EventHandler(this.uxRead_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // uxSolutionLabel
            // 
            this.uxSolutionLabel.AutoSize = true;
            this.uxSolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSolutionLabel.Location = new System.Drawing.Point(19, 67);
            this.uxSolutionLabel.Name = "uxSolutionLabel";
            this.uxSolutionLabel.Size = new System.Drawing.Size(92, 24);
            this.uxSolutionLabel.TabIndex = 2;
            this.uxSolutionLabel.Text = "Solution:";
            // 
            // uxSolution
            // 
            this.uxSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSolution.Location = new System.Drawing.Point(117, 64);
            this.uxSolution.Name = "uxSolution";
            this.uxSolution.ReadOnly = true;
            this.uxSolution.Size = new System.Drawing.Size(230, 29);
            this.uxSolution.TabIndex = 3;
            // 
            // uxOpenDialog
            // 
            this.uxOpenDialog.FileName = "openFileDialog1";
            this.uxOpenDialog.Filter = "    Text files|*.txt|All files|*.*  ";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 110);
            this.Controls.Add(this.uxSolution);
            this.Controls.Add(this.uxSolutionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxRead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Satisfiability Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label uxSolutionLabel;
        private System.Windows.Forms.TextBox uxSolution;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
    }
}

