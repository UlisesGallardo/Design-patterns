
namespace Store
{
    partial class SurtirPedido
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.NombreTienda = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ImagenInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(373, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(965, 491);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // NombreTienda
            // 
            this.NombreTienda.AutoSize = true;
            this.NombreTienda.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NombreTienda.Location = new System.Drawing.Point(713, 9);
            this.NombreTienda.Name = "NombreTienda";
            this.NombreTienda.Size = new System.Drawing.Size(109, 46);
            this.NombreTienda.TabIndex = 1;
            this.NombreTienda.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1226, 589);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Siguiente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 574);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Anterior";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ImagenInfo
            // 
            this.ImagenInfo.Location = new System.Drawing.Point(36, 167);
            this.ImagenInfo.Name = "ImagenInfo";
            this.ImagenInfo.Size = new System.Drawing.Size(313, 304);
            this.ImagenInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagenInfo.TabIndex = 4;
            this.ImagenInfo.TabStop = false;
            // 
            // SurtirPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 622);
            this.Controls.Add(this.ImagenInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NombreTienda);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "SurtirPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SurtirPedido";
            this.Load += new System.EventHandler(this.SurtirPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label NombreTienda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox ImagenInfo;
    }
}