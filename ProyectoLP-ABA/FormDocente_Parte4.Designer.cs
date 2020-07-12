namespace ProyectoLP_ABA
{
    partial class SubirSy_D
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubirSy_D));
            this.lbParalelos = new System.Windows.Forms.ListBox();
            this.bSubArch = new System.Windows.Forms.Button();
            this.bVerArch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbParalelos
            // 
            this.lbParalelos.FormattingEnabled = true;
            this.lbParalelos.Location = new System.Drawing.Point(351, 35);
            this.lbParalelos.Name = "lbParalelos";
            this.lbParalelos.Size = new System.Drawing.Size(258, 225);
            this.lbParalelos.TabIndex = 10;
            this.lbParalelos.SelectedIndexChanged += new System.EventHandler(this.lbParalelos_SelectedIndexChanged);
            // 
            // bSubArch
            // 
            this.bSubArch.Location = new System.Drawing.Point(484, 298);
            this.bSubArch.Name = "bSubArch";
            this.bSubArch.Size = new System.Drawing.Size(125, 23);
            this.bSubArch.TabIndex = 9;
            this.bSubArch.Text = "Subir Archivo";
            this.bSubArch.UseVisualStyleBackColor = true;
            this.bSubArch.Click += new System.EventHandler(this.bSubArch_Click);
            // 
            // bVerArch
            // 
            this.bVerArch.Location = new System.Drawing.Point(351, 298);
            this.bVerArch.Name = "bVerArch";
            this.bVerArch.Size = new System.Drawing.Size(127, 23);
            this.bVerArch.TabIndex = 8;
            this.bVerArch.Text = "Ver Archivo";
            this.bVerArch.UseVisualStyleBackColor = true;
            this.bVerArch.Click += new System.EventHandler(this.bVerArch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(383, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Seleccione una materia";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelEstado.Location = new System.Drawing.Point(348, 281);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 13);
            this.labelEstado.TabIndex = 6;
            this.labelEstado.Text = "Estado:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(467, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "ATRÁS";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(465, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 44);
            this.button2.TabIndex = 21;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SubirSy_D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(920, 404);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbParalelos);
            this.Controls.Add(this.bSubArch);
            this.Controls.Add(this.bVerArch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelEstado);
            this.Name = "SubirSy_D";
            this.Text = "SubirSy_D";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbParalelos;
        private System.Windows.Forms.Button bSubArch;
        private System.Windows.Forms.Button bVerArch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}