namespace YSLDotNetCore.WinFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancel = new Button();
            labTitle = new Label();
            labAuthor = new Label();
            labContent = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(104, 118, 138);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(291, 349);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 32);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // labTitle
            // 
            labTitle.AutoSize = true;
            labTitle.Location = new Point(291, 118);
            labTitle.Margin = new Padding(4, 0, 4, 0);
            labTitle.Name = "labTitle";
            labTitle.Size = new Size(46, 21);
            labTitle.TabIndex = 1;
            labTitle.Text = "Title :";
            // 
            // labAuthor
            // 
            labAuthor.AutoSize = true;
            labAuthor.Location = new Point(291, 174);
            labAuthor.Margin = new Padding(4, 0, 4, 0);
            labAuthor.Name = "labAuthor";
            labAuthor.Size = new Size(65, 21);
            labAuthor.TabIndex = 2;
            labAuthor.Text = "Author :";
            // 
            // labContent
            // 
            labContent.AutoSize = true;
            labContent.Location = new Point(291, 230);
            labContent.Margin = new Padding(4, 0, 4, 0);
            labContent.Name = "labContent";
            labContent.Size = new Size(72, 21);
            labContent.TabIndex = 3;
            labContent.Text = "Content :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(291, 142);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(453, 29);
            txtTitle.TabIndex = 4;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(291, 198);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(453, 29);
            txtAuthor.TabIndex = 5;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(291, 254);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(453, 88);
            txtContent.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(107, 105, 214);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(393, 349);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 32);
            btnSave.TabIndex = 7;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SaddleBrown;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(393, 348);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(95, 32);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 630);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(labContent);
            Controls.Add(labAuthor);
            Controls.Add(labTitle);
            Controls.Add(btnCancel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Label labTitle;
        private Label labAuthor;
        private Label labContent;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnSave;
        private Button btnUpdate;
    }
}
