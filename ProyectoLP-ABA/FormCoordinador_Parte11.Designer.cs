namespace ProyectoLP_ABA
{
    partial class FormCoordinador_Parte11
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCoordinador_Parte11));
            this.dGridDocentes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGridDocentes)).BeginInit();
            this.SuspendLayout();
            // 
            // dGridDocentes
            // 
            this.dGridDocentes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dGridDocentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGridDocentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridDocentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dGridDocentes.Location = new System.Drawing.Point(179, 68);
            this.dGridDocentes.Name = "dGridDocentes";
            this.dGridDocentes.Size = new System.Drawing.Size(656, 310);
            this.dGridDocentes.TabIndex = 1;
            this.dGridDocentes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridDocentes_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Docente";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Asignatura";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "¿Ha participado en eventos de capacitación afín al área? (Si/No)";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tipo de Evento";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Participación";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Certificados";
            this.Column6.Name = "Column6";
            // 
            // tBuscar
            // 
            this.tBuscar.Location = new System.Drawing.Point(179, 31);
            this.tBuscar.Name = "tBuscar";
            this.tBuscar.Size = new System.Drawing.Size(642, 20);
            this.tBuscar.TabIndex = 2;
            this.tBuscar.TextChanged += new System.EventHandler(this.tBuscar_TextChanged);
            // 
            // FormCoordinador_Parte11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.tBuscar);
            this.Controls.Add(this.dGridDocentes);
            this.Name = "FormCoordinador_Parte11";
            this.Text = "FormCoordinador_Parte11";
            ((System.ComponentModel.ISupportInitialize)(this.dGridDocentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGridDocentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewLinkColumn Column6;
        private System.Windows.Forms.TextBox tBuscar;
    }
}