namespace ProyectoLP_ABA
{
    partial class FormNuevoParalelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevoParalelo));
            this.bEliminar = new System.Windows.Forms.Button();
            this.bIngresar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tParalelo = new System.Windows.Forms.TextBox();
            this.tNivel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tAsignatura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClases = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBuscar = new System.Windows.Forms.TextBox();
            this.lbDocente = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bEliminar
            // 
            this.bEliminar.Location = new System.Drawing.Point(606, 272);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(116, 61);
            this.bEliminar.TabIndex = 29;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bIngresar
            // 
            this.bIngresar.Location = new System.Drawing.Point(606, 209);
            this.bIngresar.Name = "bIngresar";
            this.bIngresar.Size = new System.Drawing.Size(116, 57);
            this.bIngresar.TabIndex = 28;
            this.bIngresar.Text = "Ingresar";
            this.bIngresar.UseVisualStyleBackColor = true;
            this.bIngresar.Click += new System.EventHandler(this.bIngresar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Paralelo";
            // 
            // tParalelo
            // 
            this.tParalelo.Location = new System.Drawing.Point(457, 313);
            this.tParalelo.Name = "tParalelo";
            this.tParalelo.Size = new System.Drawing.Size(118, 20);
            this.tParalelo.TabIndex = 26;
            this.tParalelo.TextChanged += new System.EventHandler(this.tParalelo_TextChanged);
            // 
            // tNivel
            // 
            this.tNivel.Location = new System.Drawing.Point(311, 313);
            this.tNivel.Name = "tNivel";
            this.tNivel.Size = new System.Drawing.Size(118, 20);
            this.tNivel.TabIndex = 25;
            this.tNivel.TextChanged += new System.EventHandler(this.tNivel_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Nivel";
            // 
            // tAsignatura
            // 
            this.tAsignatura.Location = new System.Drawing.Point(311, 269);
            this.tAsignatura.Name = "tAsignatura";
            this.tAsignatura.Size = new System.Drawing.Size(264, 20);
            this.tAsignatura.TabIndex = 23;
            this.tAsignatura.TextChanged += new System.EventHandler(this.tAsignatura_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Asignatura";
            // 
            // cbClases
            // 
            this.cbClases.FormattingEnabled = true;
            this.cbClases.Location = new System.Drawing.Point(311, 225);
            this.cbClases.Name = "cbClases";
            this.cbClases.Size = new System.Drawing.Size(264, 21);
            this.cbClases.TabIndex = 21;
            this.cbClases.SelectedIndexChanged += new System.EventHandler(this.cbClases_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Seleccionar una clase o ingresar nueva";
            // 
            // tBuscar
            // 
            this.tBuscar.Location = new System.Drawing.Point(371, 41);
            this.tBuscar.Name = "tBuscar";
            this.tBuscar.Size = new System.Drawing.Size(276, 20);
            this.tBuscar.TabIndex = 19;
            this.tBuscar.TextChanged += new System.EventHandler(this.tBuscar_TextChanged);
            // 
            // lbDocente
            // 
            this.lbDocente.FormattingEnabled = true;
            this.lbDocente.Location = new System.Drawing.Point(371, 67);
            this.lbDocente.Name = "lbDocente";
            this.lbDocente.Size = new System.Drawing.Size(276, 121);
            this.lbDocente.TabIndex = 18;
            this.lbDocente.SelectedIndexChanged += new System.EventHandler(this.lbDocente_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Buscar docente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(522, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "ATRÁS";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(499, 366);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 77);
            this.button2.TabIndex = 33;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormNuevoParalelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bIngresar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tParalelo);
            this.Controls.Add(this.tNivel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tAsignatura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbClases);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBuscar);
            this.Controls.Add(this.lbDocente);
            this.Controls.Add(this.label1);
            this.Name = "FormNuevoParalelo";
            this.Text = "FormNuevoParalelo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bIngresar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tParalelo;
        private System.Windows.Forms.TextBox tNivel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tAsignatura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClases;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBuscar;
        private System.Windows.Forms.ListBox lbDocente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}