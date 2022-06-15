
namespace pilka2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rakietka = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pilka1 = new System.Windows.Forms.PictureBox();
            this.pilka2 = new System.Windows.Forms.PictureBox();
            this.pilka3 = new System.Windows.Forms.PictureBox();
            this.pilka4 = new System.Windows.Forms.PictureBox();
            this.pilka = new System.Windows.Forms.Panel();
            this.pilkaZDJ = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.punkty = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kolorRakietkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bialyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czerwonyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niebieskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button4 = new System.Windows.Forms.Button();
            this.panel0 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pilka1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pilka2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pilka3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pilka4)).BeginInit();
            this.pilka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pilkaZDJ)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel0.SuspendLayout();
            this.SuspendLayout();
            // 
            // rakietka
            // 
            this.rakietka.BackColor = System.Drawing.Color.White;
            this.rakietka.Location = new System.Drawing.Point(350, 525);
            this.rakietka.Name = "rakietka";
            this.rakietka.Size = new System.Drawing.Size(200, 25);
            this.rakietka.TabIndex = 48;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pilka1
            // 
            this.pilka1.BackColor = System.Drawing.Color.Transparent;
            this.pilka1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pilka1.Image = ((System.Drawing.Image)(resources.GetObject("pilka1.Image")));
            this.pilka1.InitialImage = null;
            this.pilka1.Location = new System.Drawing.Point(847, 493);
            this.pilka1.Name = "pilka1";
            this.pilka1.Size = new System.Drawing.Size(25, 25);
            this.pilka1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pilka1.TabIndex = 50;
            this.pilka1.TabStop = false;
            // 
            // pilka2
            // 
            this.pilka2.BackColor = System.Drawing.Color.Transparent;
            this.pilka2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pilka2.Image = ((System.Drawing.Image)(resources.GetObject("pilka2.Image")));
            this.pilka2.InitialImage = null;
            this.pilka2.Location = new System.Drawing.Point(847, 462);
            this.pilka2.Name = "pilka2";
            this.pilka2.Size = new System.Drawing.Size(25, 25);
            this.pilka2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pilka2.TabIndex = 51;
            this.pilka2.TabStop = false;
            // 
            // pilka3
            // 
            this.pilka3.BackColor = System.Drawing.Color.Transparent;
            this.pilka3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pilka3.Image = ((System.Drawing.Image)(resources.GetObject("pilka3.Image")));
            this.pilka3.InitialImage = null;
            this.pilka3.Location = new System.Drawing.Point(847, 431);
            this.pilka3.Name = "pilka3";
            this.pilka3.Size = new System.Drawing.Size(25, 25);
            this.pilka3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pilka3.TabIndex = 52;
            this.pilka3.TabStop = false;
            // 
            // pilka4
            // 
            this.pilka4.BackColor = System.Drawing.Color.Transparent;
            this.pilka4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pilka4.Image = ((System.Drawing.Image)(resources.GetObject("pilka4.Image")));
            this.pilka4.InitialImage = null;
            this.pilka4.Location = new System.Drawing.Point(847, 400);
            this.pilka4.Name = "pilka4";
            this.pilka4.Size = new System.Drawing.Size(25, 25);
            this.pilka4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pilka4.TabIndex = 53;
            this.pilka4.TabStop = false;
            // 
            // pilka
            // 
            this.pilka.Controls.Add(this.pilkaZDJ);
            this.pilka.Location = new System.Drawing.Point(400, 400);
            this.pilka.Name = "pilka";
            this.pilka.Padding = new System.Windows.Forms.Padding(5);
            this.pilka.Size = new System.Drawing.Size(50, 50);
            this.pilka.TabIndex = 54;
            // 
            // pilkaZDJ
            // 
            this.pilkaZDJ.BackColor = System.Drawing.Color.Transparent;
            this.pilkaZDJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pilkaZDJ.Image = ((System.Drawing.Image)(resources.GetObject("pilkaZDJ.Image")));
            this.pilkaZDJ.Location = new System.Drawing.Point(5, 5);
            this.pilkaZDJ.Name = "pilkaZDJ";
            this.pilkaZDJ.Size = new System.Drawing.Size(40, 40);
            this.pilkaZDJ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pilkaZDJ.TabIndex = 55;
            this.pilkaZDJ.TabStop = false;
            this.pilkaZDJ.Click += new System.EventHandler(this.pictureBox49_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(364, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 130);
            this.panel1.TabIndex = 55;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Zatwierdź";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 72);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(54, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "trudny";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "średni";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "łatwy";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz poziom trudności:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(315, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 120);
            this.panel2.TabIndex = 56;
            this.panel2.Visible = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(58, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 30);
            this.button2.TabIndex = 56;
            this.button2.Text = "Spróbuj ponownie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(41, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 31);
            this.label2.TabIndex = 57;
            this.label2.Text = "Game Over!";
            this.label2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(315, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 120);
            this.panel3.TabIndex = 58;
            this.panel3.Visible = false;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(63, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 30);
            this.button3.TabIndex = 58;
            this.button3.Text = "Spróbuj ponownie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(41, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 31);
            this.label3.TabIndex = 57;
            this.label3.Text = "Zwycięstwo!";
            this.label3.Visible = false;
            // 
            // punkty
            // 
            this.punkty.AutoSize = true;
            this.punkty.BackColor = System.Drawing.Color.Transparent;
            this.punkty.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.punkty.Location = new System.Drawing.Point(3, 493);
            this.punkty.Name = "punkty";
            this.punkty.Size = new System.Drawing.Size(128, 31);
            this.punkty.TabIndex = 58;
            this.punkty.Text = "Punkty: 0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kolorRakietkiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 59;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kolorRakietkiToolStripMenuItem
            // 
            this.kolorRakietkiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bialyToolStripMenuItem,
            this.czerwonyToolStripMenuItem,
            this.niebieskiToolStripMenuItem});
            this.kolorRakietkiToolStripMenuItem.Name = "kolorRakietkiToolStripMenuItem";
            this.kolorRakietkiToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.kolorRakietkiToolStripMenuItem.Text = "Kolor rakietki";
            this.kolorRakietkiToolStripMenuItem.Click += new System.EventHandler(this.kolorRakietkiToolStripMenuItem_Click);
            // 
            // bialyToolStripMenuItem
            // 
            this.bialyToolStripMenuItem.Name = "bialyToolStripMenuItem";
            this.bialyToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.bialyToolStripMenuItem.Text = "Bialy";
            this.bialyToolStripMenuItem.Click += new System.EventHandler(this.bialyToolStripMenuItem_Click);
            // 
            // czerwonyToolStripMenuItem
            // 
            this.czerwonyToolStripMenuItem.Name = "czerwonyToolStripMenuItem";
            this.czerwonyToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.czerwonyToolStripMenuItem.Text = "Czerwony";
            this.czerwonyToolStripMenuItem.Click += new System.EventHandler(this.czerwonyToolStripMenuItem_Click);
            // 
            // niebieskiToolStripMenuItem
            // 
            this.niebieskiToolStripMenuItem.Name = "niebieskiToolStripMenuItem";
            this.niebieskiToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.niebieskiToolStripMenuItem.Text = "Niebieski";
            this.niebieskiToolStripMenuItem.Click += new System.EventHandler(this.niebieskiToolStripMenuItem_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(232, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 60;
            this.button4.Text = "restart";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel0
            // 
            this.panel0.Controls.Add(this.panel2);
            this.panel0.Controls.Add(this.panel3);
            this.panel0.Controls.Add(this.panel1);
            this.panel0.Location = new System.Drawing.Point(0, 0);
            this.panel0.Name = "panel0";
            this.panel0.Size = new System.Drawing.Size(884, 563);
            this.panel0.TabIndex = 61;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pilka);
            this.Controls.Add(this.pilka4);
            this.Controls.Add(this.pilka3);
            this.Controls.Add(this.pilka2);
            this.Controls.Add(this.pilka1);
            this.Controls.Add(this.rakietka);
            this.Controls.Add(this.punkty);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel0);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyup);
            ((System.ComponentModel.ISupportInitialize)(this.pilka1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pilka2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pilka3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pilka4)).EndInit();
            this.pilka.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pilkaZDJ)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel0.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel rakietka;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pilka1;
        private System.Windows.Forms.PictureBox pilka2;
        private System.Windows.Forms.PictureBox pilka3;
        private System.Windows.Forms.PictureBox pilka4;
        private System.Windows.Forms.Panel pilka;
        private System.Windows.Forms.PictureBox pilkaZDJ;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label punkty;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kolorRakietkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bialyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czerwonyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem niebieskiToolStripMenuItem;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel0;
    }
}

