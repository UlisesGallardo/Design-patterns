﻿
namespace Store
{
    partial class Pedidos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NTienda = new System.Windows.Forms.Label();
            this.ListaProductos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NTienda
            // 
            this.NTienda.AutoSize = true;
            this.NTienda.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NTienda.Location = new System.Drawing.Point(241, 0);
            this.NTienda.Name = "NTienda";
            this.NTienda.Size = new System.Drawing.Size(70, 28);
            this.NTienda.TabIndex = 0;
            this.NTienda.Text = "Tienda";
            this.NTienda.Click += new System.EventHandler(this.label1_Click);
            // 
            // ListaProductos
            // 
            this.ListaProductos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ListaProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListaProductos.Font = new System.Drawing.Font("Adobe Devanagari", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListaProductos.FormattingEnabled = true;
            this.ListaProductos.ItemHeight = 27;
            this.ListaProductos.Location = new System.Drawing.Point(49, 69);
            this.ListaProductos.Name = "ListaProductos";
            this.ListaProductos.Size = new System.Drawing.Size(245, 135);
            this.ListaProductos.TabIndex = 1;
            this.ListaProductos.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de la Tienda:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Productos:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(487, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 211);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListaProductos);
            this.Controls.Add(this.NTienda);
            this.Name = "Pedidos";
            this.Size = new System.Drawing.Size(780, 239);
            this.Load += new System.EventHandler(this.Pedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NTienda;
        private System.Windows.Forms.ListBox ListaProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
