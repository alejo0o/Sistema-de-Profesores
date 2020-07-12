namespace ProyectoLP_ABA
{
    partial class FormCoordinador_Parte5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCoordinador_Parte5));
            this.dGridDocentes = new System.Windows.Forms.DataGridView();
            this.Asignatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paralelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Docente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingreso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Archivo1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Archivo2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Archivo3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGridDocentes)).BeginInit();
            this.SuspendLayout();
            // 
            // dGridDocentes
            // 
            this.dGridDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridDocentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Asignatura,
            this.Nivel,
            this.Paralelo,
            this.Docente,
            this.Ingreso,
            this.Column1,
            this.Column2,
            this.Archivo1,
            this.Archivo2,
            this.Archivo3});
            this.dGridDocentes.Location = new System.Drawing.Point(17, 32);
            this.dGridDocentes.Name = "dGridDocentes";
            this.dGridDocentes.Size = new System.Drawing.Size(1005, 392);
            this.dGridDocentes.TabIndex = 3;
            this.dGridDocentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridDocentes_CellContentClick);
            // 
            // Asignatura
            // 
            this.Asignatura.HeaderText = "Asignatura";
            this.Asignatura.Name = "Asignatura";
            // 
            // Nivel
            // 
            this.Nivel.HeaderText = "Nivel";
            this.Nivel.Name = "Nivel";
            // 
            // Paralelo
            // 
            this.Paralelo.HeaderText = "Paralelo";
            this.Paralelo.Name = "Paralelo";
            // 
            // Docente
            // 
            this.Docente.HeaderText = "Docente";
            this.Docente.Name = "Docente";
            // 
            // Ingreso
            // 
            this.Ingreso.HeaderText = "Ingreso 1";
            this.Ingreso.Name = "Ingreso";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ingreso 2";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ingreso 3";
            this.Column2.Name = "Column2";
            // 
            // Archivo1
            // 
            this.Archivo1.HeaderText = "Archivo 1 (Bimestre 1)";
            this.Archivo1.Name = "Archivo1";
            this.Archivo1.Text = "";
            // 
            // Archivo2
            // 
            this.Archivo2.HeaderText = "Archivo 2 (Bimestre 2)";
            this.Archivo2.Name = "Archivo2";
            // 
            // Archivo3
            // 
            this.Archivo3.HeaderText = "Archivo 3 (Bimestre 3)";
            this.Archivo3.Name = "Archivo3";
            // 
            // tBuscar
            // 
            this.tBuscar.Location = new System.Drawing.Point(98, 4);
            this.tBuscar.Name = "tBuscar";
            this.tBuscar.Size = new System.Drawing.Size(835, 20);
            this.tBuscar.TabIndex = 2;
            this.tBuscar.TextChanged += new System.EventHandler(this.tBuscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar";
            // 
            // FormCoordinador_Parte5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGridDocentes);
            this.Controls.Add(this.tBuscar);
            this.Name = "FormCoordinador_Parte5";
            this.Text = "FormCoordinador_Parte5";
            ((System.ComponentModel.ISupportInitialize)(this.dGridDocentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGridDocentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paralelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Docente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ingreso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn Archivo1;
        private System.Windows.Forms.DataGridViewLinkColumn Archivo2;
        private System.Windows.Forms.DataGridViewLinkColumn Archivo3;
        private System.Windows.Forms.TextBox tBuscar;
        private System.Windows.Forms.Label label1;
    }
}