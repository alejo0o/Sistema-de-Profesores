namespace ProyectoLP_ABA
{
    partial class IngresoPM_D
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
            this.tBuscar = new System.Windows.Forms.TextBox();
            this.dGridDocentes = new System.Windows.Forms.DataGridView();
            this.Asignatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paralelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Docente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingreso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Archivo = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGridDocentes)).BeginInit();
            this.SuspendLayout();
            // 
            // tBuscar
            // 
            this.tBuscar.Location = new System.Drawing.Point(13, 10);
            this.tBuscar.Name = "tBuscar";
            this.tBuscar.Size = new System.Drawing.Size(953, 20);
            this.tBuscar.TabIndex = 3;
            this.tBuscar.TextChanged += new System.EventHandler(this.tBuscar_TextChanged);
            // 
            // dGridDocentes
            // 
            this.dGridDocentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridDocentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Asignatura,
            this.Nivel,
            this.Paralelo,
            this.Docente,
            this.Ingreso,
            this.Archivo});
            this.dGridDocentes.Location = new System.Drawing.Point(12, 36);
            this.dGridDocentes.Name = "dGridDocentes";
            this.dGridDocentes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dGridDocentes.Size = new System.Drawing.Size(954, 391);
            this.dGridDocentes.TabIndex = 2;
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
            this.Ingreso.HeaderText = "Ingreso(Si/No)";
            this.Ingreso.Name = "Ingreso";
            // 
            // Archivo
            // 
            this.Archivo.HeaderText = "Archivo";
            this.Archivo.Name = "Archivo";
            // 
            // IngresoPM_D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 459);
            this.Controls.Add(this.tBuscar);
            this.Controls.Add(this.dGridDocentes);
            this.Name = "IngresoPM_D";
            this.Text = "IngresoPM_D";
            ((System.ComponentModel.ISupportInitialize)(this.dGridDocentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBuscar;
        private System.Windows.Forms.DataGridView dGridDocentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paralelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Docente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ingreso;
        private System.Windows.Forms.DataGridViewLinkColumn Archivo;
    }
}