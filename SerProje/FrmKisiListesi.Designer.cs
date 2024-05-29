
namespace SerProje
{
    partial class FrmKisiListesi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.yeniKişiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eğitimBilgisiEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridKisiListesi = new System.Windows.Forms.DataGridView();
            this.dataGridEgitimBilgileri = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKisiListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgitimBilgileri)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 28);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniKişiEkleToolStripMenuItem,
            this.eğitimBilgisiEkleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // yeniKişiEkleToolStripMenuItem
            // 
            this.yeniKişiEkleToolStripMenuItem.Name = "yeniKişiEkleToolStripMenuItem";
            this.yeniKişiEkleToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.yeniKişiEkleToolStripMenuItem.Text = "Yeni Kişi Ekle";
            this.yeniKişiEkleToolStripMenuItem.Click += new System.EventHandler(this.yeniKişiEkleToolStripMenuItem_Click);
            // 
            // eğitimBilgisiEkleToolStripMenuItem
            // 
            this.eğitimBilgisiEkleToolStripMenuItem.Name = "eğitimBilgisiEkleToolStripMenuItem";
            this.eğitimBilgisiEkleToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.eğitimBilgisiEkleToolStripMenuItem.Text = "Eğitim Bilgisi Ekle";
            this.eğitimBilgisiEkleToolStripMenuItem.Click += new System.EventHandler(this.eğitimBilgisiEkleToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridKisiListesi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 247);
            this.panel2.TabIndex = 1;
            // 
            // dataGridKisiListesi
            // 
            this.dataGridKisiListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridKisiListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridKisiListesi.Location = new System.Drawing.Point(0, 0);
            this.dataGridKisiListesi.Name = "dataGridKisiListesi";
            this.dataGridKisiListesi.Size = new System.Drawing.Size(800, 247);
            this.dataGridKisiListesi.TabIndex = 0;
            // 
            // dataGridEgitimBilgileri
            // 
            this.dataGridEgitimBilgileri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEgitimBilgileri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEgitimBilgileri.Location = new System.Drawing.Point(0, 0);
            this.dataGridEgitimBilgileri.Name = "dataGridEgitimBilgileri";
            this.dataGridEgitimBilgileri.Size = new System.Drawing.Size(800, 175);
            this.dataGridEgitimBilgileri.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridEgitimBilgileri);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 275);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 175);
            this.panel3.TabIndex = 3;
            // 
            // FrmKisiListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmKisiListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kişi Listesi";
            this.Load += new System.EventHandler(this.FrmKisiListesi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKisiListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEgitimBilgileri)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem yeniKişiEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eğitimBilgisiEkleToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridKisiListesi;
        private System.Windows.Forms.DataGridView dataGridEgitimBilgileri;
        private System.Windows.Forms.Panel panel3;
    }
}