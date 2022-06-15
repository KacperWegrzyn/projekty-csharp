
namespace Projekt
{
    partial class Pozyczki
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pozyczka_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uzytkownik_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kwota_pozyczona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kwota_do_splacenia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splacone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.niesplacone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_pozyczenia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_do_oddania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_oddania = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pozyczka_id,
            this.uzytkownik_id,
            this.kwota_pozyczona,
            this.kwota_do_splacenia,
            this.procent,
            this.splacone,
            this.niesplacone,
            this.data_pozyczenia,
            this.data_do_oddania,
            this.data_oddania,
            this.status});
            this.dataGridView1.Location = new System.Drawing.Point(1, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1144, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // pozyczka_id
            // 
            this.pozyczka_id.HeaderText = "pozyczka_id";
            this.pozyczka_id.Name = "pozyczka_id";
            // 
            // uzytkownik_id
            // 
            this.uzytkownik_id.HeaderText = "uzytkownik_id";
            this.uzytkownik_id.Name = "uzytkownik_id";
            // 
            // kwota_pozyczona
            // 
            this.kwota_pozyczona.HeaderText = "kwota_pozyczona";
            this.kwota_pozyczona.Name = "kwota_pozyczona";
            // 
            // kwota_do_splacenia
            // 
            this.kwota_do_splacenia.HeaderText = "kwota_do_splacenia";
            this.kwota_do_splacenia.Name = "kwota_do_splacenia";
            // 
            // procent
            // 
            this.procent.HeaderText = "procent";
            this.procent.Name = "procent";
            // 
            // splacone
            // 
            this.splacone.HeaderText = "splacone";
            this.splacone.Name = "splacone";
            // 
            // niesplacone
            // 
            this.niesplacone.HeaderText = "niesplacone";
            this.niesplacone.Name = "niesplacone";
            // 
            // data_pozyczenia
            // 
            this.data_pozyczenia.HeaderText = "data_pozyczenia";
            this.data_pozyczenia.Name = "data_pozyczenia";
            // 
            // data_do_oddania
            // 
            this.data_do_oddania.HeaderText = "data_do_oddania";
            this.data_do_oddania.Name = "data_do_oddania";
            // 
            // data_oddania
            // 
            this.data_oddania.HeaderText = "data_oddania";
            this.data_oddania.Name = "data_oddania";
            // 
            // status
            // 
            this.status.HeaderText = "status";
            this.status.Name = "status";
            // 
            // Pozyczki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Pozyczki";
            this.Text = "Pozyczki";
            this.Load += new System.EventHandler(this.Pozyczki_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pozyczka_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn uzytkownik_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn kwota_pozyczona;
        private System.Windows.Forms.DataGridViewTextBoxColumn kwota_do_splacenia;
        private System.Windows.Forms.DataGridViewTextBoxColumn procent;
        private System.Windows.Forms.DataGridViewTextBoxColumn splacone;
        private System.Windows.Forms.DataGridViewTextBoxColumn niesplacone;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_pozyczenia;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_do_oddania;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_oddania;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}