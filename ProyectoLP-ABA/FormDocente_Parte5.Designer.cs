namespace ProyectoLP_ABA
{
    partial class FormDocente_Parte5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocente_Parte5));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbParalelos = new System.Windows.Forms.ListBox();
            this.bSubArch = new System.Windows.Forms.Button();
            this.bVerArch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Seleccione el Bimestre";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bimestre 1",
            "Bimestre 2",
            "Bimestre 3"});
            this.comboBox1.Location = new System.Drawing.Point(386, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbParalelos
            // 
            this.lbParalelos.FormattingEnabled = true;
            this.lbParalelos.Location = new System.Drawing.Point(386, 119);
            this.lbParalelos.Name = "lbParalelos";
            this.lbParalelos.Size = new System.Drawing.Size(258, 186);
            this.lbParalelos.TabIndex = 17;
            this.lbParalelos.SelectedIndexChanged += new System.EventHandler(this.lbParalelos_SelectedIndexChanged);
            // 
            // bSubArch
            // 
            this.bSubArch.Location = new System.Drawing.Point(519, 325);
            this.bSubArch.Name = "bSubArch";
            this.bSubArch.Size = new System.Drawing.Size(125, 23);
            this.bSubArch.TabIndex = 16;
            this.bSubArch.Text = "Subir Archivo";
            this.bSubArch.UseVisualStyleBackColor = true;
            this.bSubArch.Click += new System.EventHandler(this.bSubArch_Click);
            // 
            // bVerArch
            // 
            this.bVerArch.Location = new System.Drawing.Point(386, 325);
            this.bVerArch.Name = "bVerArch";
            this.bVerArch.Size = new System.Drawing.Size(127, 23);
            this.bVerArch.TabIndex = 15;
            this.bVerArch.Text = "Ver Archivo";
            this.bVerArch.UseVisualStyleBackColor = true;
            this.bVerArch.Click += new System.EventHandler(this.bVerArch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Seleccione una materia";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(383, 308);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 13);
            this.labelEstado.TabIndex = 13;
            this.labelEstado.Text = "Estado:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormDocente_Parte5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbParalelos);
            this.Controls.Add(this.bSubArch);
            this.Controls.Add(this.bVerArch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelEstado);
            this.Name = "FormDocente_Parte5";
            this.Text = "FormDocente_Parte5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox lbParalelos;
        private System.Windows.Forms.Button bSubArch;
        private System.Windows.Forms.Button bVerArch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}