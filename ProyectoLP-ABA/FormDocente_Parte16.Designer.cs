namespace ProyectoLP_ABA
{
    partial class FormDocente_Parte16
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocente_Parte16));
            this.bEliminar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colAsignatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bEliminar
            // 
            this.bEliminar.Location = new System.Drawing.Point(493, 405);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(436, 23);
            this.bEliminar.TabIndex = 5;
            this.bEliminar.Text = "Eliminar fuente bibliográfica seleccionada";
            this.bEliminar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAsignatura,
            this.colNombre,
            this.colAutores,
            this.colEditorial,
            this.colEdicion,
            this.colAño,
            this.colISBN});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1010, 378);
            this.dataGridView1.TabIndex = 4;
            // 
            // colAsignatura
            // 
            this.colAsignatura.HeaderText = "Asignatura";
            this.colAsignatura.Name = "colAsignatura";
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.HeaderText = "Nombre del libro";
            this.colNombre.Name = "colNombre";
            // 
            // colAutores
            // 
            this.colAutores.HeaderText = "Autor/es";
            this.colAutores.Name = "colAutores";
            // 
            // colEditorial
            // 
            this.colEditorial.HeaderText = "Editorial";
            this.colEditorial.Name = "colEditorial";
            // 
            // colEdicion
            // 
            this.colEdicion.HeaderText = "Edición";
            this.colEdicion.Name = "colEdicion";
            // 
            // colAño
            // 
            this.colAño.HeaderText = "Año";
            this.colAño.Name = "colAño";
            // 
            // colISBN
            // 
            this.colISBN.HeaderText = "ISBN";
            this.colISBN.Name = "colISBN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(979, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "ATRÁS";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(935, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 37);
            this.button2.TabIndex = 27;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(455, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormDocente_Parte16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDocente_Parte16";
            this.Text = "FormDocente_Parte16";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsignatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEditorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEdicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn colISBN;
    }
}