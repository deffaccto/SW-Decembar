namespace Domaci_za_decembar
{
    partial class SpisakFaxForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.nazivTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dodajBtt = new System.Windows.Forms.Button();
            this.promeniBtt = new System.Windows.Forms.Button();
            this.obrisiBtt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(142, 199);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // nazivTxt
            // 
            this.nazivTxt.Location = new System.Drawing.Point(184, 28);
            this.nazivTxt.Name = "nazivTxt";
            this.nazivTxt.Size = new System.Drawing.Size(100, 20);
            this.nazivTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Naziv";
            // 
            // dodajBtt
            // 
            this.dodajBtt.Location = new System.Drawing.Point(184, 75);
            this.dodajBtt.Name = "dodajBtt";
            this.dodajBtt.Size = new System.Drawing.Size(100, 48);
            this.dodajBtt.TabIndex = 3;
            this.dodajBtt.Text = "Dodaj novi fakultet";
            this.dodajBtt.UseVisualStyleBackColor = true;
            this.dodajBtt.Click += new System.EventHandler(this.dodajBtt_Click);
            // 
            // promeniBtt
            // 
            this.promeniBtt.Location = new System.Drawing.Point(184, 129);
            this.promeniBtt.Name = "promeniBtt";
            this.promeniBtt.Size = new System.Drawing.Size(100, 48);
            this.promeniBtt.TabIndex = 4;
            this.promeniBtt.Text = "Promeni podatke";
            this.promeniBtt.UseVisualStyleBackColor = true;
            this.promeniBtt.Click += new System.EventHandler(this.promeniBtt_Click);
            // 
            // obrisiBtt
            // 
            this.obrisiBtt.Location = new System.Drawing.Point(184, 183);
            this.obrisiBtt.Name = "obrisiBtt";
            this.obrisiBtt.Size = new System.Drawing.Size(100, 48);
            this.obrisiBtt.TabIndex = 5;
            this.obrisiBtt.Text = "Obiris fakultet";
            this.obrisiBtt.UseVisualStyleBackColor = true;
            this.obrisiBtt.Click += new System.EventHandler(this.obrisiBtt_Click);
            // 
            // SpisakFaxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 263);
            this.Controls.Add(this.obrisiBtt);
            this.Controls.Add(this.promeniBtt);
            this.Controls.Add(this.dodajBtt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nazivTxt);
            this.Controls.Add(this.listBox1);
            this.Name = "SpisakFaxForm";
            this.Text = "SpisakFaxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox nazivTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dodajBtt;
        private System.Windows.Forms.Button promeniBtt;
        private System.Windows.Forms.Button obrisiBtt;
    }
}