namespace ProyectoLP_ABA
{
    partial class FormDocente_Parte_7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocente_Parte_7));
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bSubArch = new System.Windows.Forms.Button();
            this.bVerArch = new System.Windows.Forms.Button();
            this.labelEstado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbParalelos = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(561, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Añadir Observación";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(374, 286);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(267, 83);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Observaciones";
            // 
            // bSubArch
            // 
            this.bSubArch.Location = new System.Drawing.Point(447, 397);
            this.bSubArch.Name = "bSubArch";
            this.bSubArch.Size = new System.Drawing.Size(99, 23);
            this.bSubArch.TabIndex = 16;
            this.bSubArch.Text = "Subir Archivo";
            this.bSubArch.UseVisualStyleBackColor = true;
            this.bSubArch.Click += new System.EventHandler(this.bSubArch_Click);
            // 
            // bVerArch
            // 
            this.bVerArch.Location = new System.Drawing.Point(354, 397);
            this.bVerArch.Name = "bVerArch";
            this.bVerArch.Size = new System.Drawing.Size(75, 23);
            this.bVerArch.TabIndex = 15;
            this.bVerArch.Text = "Ver Archivo";
            this.bVerArch.UseVisualStyleBackColor = true;
            this.bVerArch.Click += new System.EventHandler(this.bVerArch_Click);
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(371, 372);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(40, 13);
            this.labelEstado.TabIndex = 14;
            this.labelEstado.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Sleccione el Bimestre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccione una materia";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bimestre 1",
            "Bimestre 2",
            "Bimestre 3"});
            this.comboBox1.Location = new System.Drawing.Point(371, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbParalelos
            // 
            this.lbParalelos.FormattingEnabled = true;
            this.lbParalelos.Location = new System.Drawing.Point(371, 107);
            this.lbParalelos.Name = "lbParalelos";
            this.lbParalelos.Size = new System.Drawing.Size(270, 160);
            this.lbParalelos.TabIndex = 10;
            this.lbParalelos.SelectedIndexChanged += new System.EventHandler(this.lbParalelos_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormDocente_Parte_7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bSubArch);
            this.Controls.Add(this.bVerArch);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbParalelos);
            this.Name = "FormDocente_Parte_7";
            this.Text = "FormDocente_Parte_7";
            this.Load += new System.EventHandler(this.FormDocente_Parte_7_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bSubArch;
        private System.Windows.Forms.Button bVerArch;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox lbParalelos;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}