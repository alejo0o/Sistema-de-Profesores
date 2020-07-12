namespace ProyectoLP_ABA
{
    partial class FormDocente_Parte6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocente_Parte6));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtInfo = new System.Windows.Forms.RichTextBox();
            this.cbUsarPlantilla = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbParalelos = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tNomPla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bEliminar = new System.Windows.Forms.Button();
            this.bIngresar = new System.Windows.Forms.Button();
            this.rtPlantilla = new System.Windows.Forms.RichTextBox();
            this.cbSelecPlantilla = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(278, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(546, 415);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtInfo);
            this.tabPage1.Controls.Add(this.cbUsarPlantilla);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lbParalelos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(538, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Editar información";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtInfo
            // 
            this.rtInfo.Location = new System.Drawing.Point(9, 173);
            this.rtInfo.Name = "rtInfo";
            this.rtInfo.Size = new System.Drawing.Size(382, 129);
            this.rtInfo.TabIndex = 11;
            this.rtInfo.Text = "";
            this.rtInfo.TextChanged += new System.EventHandler(this.rtInfo_TextChanged);
            // 
            // cbUsarPlantilla
            // 
            this.cbUsarPlantilla.FormattingEnabled = true;
            this.cbUsarPlantilla.Location = new System.Drawing.Point(9, 146);
            this.cbUsarPlantilla.Name = "cbUsarPlantilla";
            this.cbUsarPlantilla.Size = new System.Drawing.Size(264, 21);
            this.cbUsarPlantilla.TabIndex = 10;
            this.cbUsarPlantilla.SelectedIndexChanged += new System.EventHandler(this.cbUsarPlantilla_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seleccionar una plantilla";
            // 
            // lbParalelos
            // 
            this.lbParalelos.FormattingEnabled = true;
            this.lbParalelos.Location = new System.Drawing.Point(59, 6);
            this.lbParalelos.Name = "lbParalelos";
            this.lbParalelos.Size = new System.Drawing.Size(276, 121);
            this.lbParalelos.TabIndex = 8;
            this.lbParalelos.SelectedIndexChanged += new System.EventHandler(this.lbParalelos_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tNomPla);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.bEliminar);
            this.tabPage2.Controls.Add(this.bIngresar);
            this.tabPage2.Controls.Add(this.rtPlantilla);
            this.tabPage2.Controls.Add(this.cbSelecPlantilla);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(538, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plantillas de evaluación";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tNomPla
            // 
            this.tNomPla.Location = new System.Drawing.Point(9, 73);
            this.tNomPla.Name = "tNomPla";
            this.tNomPla.Size = new System.Drawing.Size(222, 20);
            this.tNomPla.TabIndex = 14;
            this.tNomPla.TextAlignChanged += new System.EventHandler(this.tNomPla_TextAlignChanged);
            this.tNomPla.TextChanged += new System.EventHandler(this.tNomPla_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre de plantilla";
            // 
            // bEliminar
            // 
            this.bEliminar.Location = new System.Drawing.Point(213, 279);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(178, 23);
            this.bEliminar.TabIndex = 12;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bIngresar
            // 
            this.bIngresar.Location = new System.Drawing.Point(9, 279);
            this.bIngresar.Name = "bIngresar";
            this.bIngresar.Size = new System.Drawing.Size(178, 23);
            this.bIngresar.TabIndex = 11;
            this.bIngresar.Text = "Ingresar";
            this.bIngresar.UseVisualStyleBackColor = true;
            this.bIngresar.Click += new System.EventHandler(this.bIngresar_Click);
            // 
            // rtPlantilla
            // 
            this.rtPlantilla.Location = new System.Drawing.Point(9, 99);
            this.rtPlantilla.Name = "rtPlantilla";
            this.rtPlantilla.Size = new System.Drawing.Size(382, 174);
            this.rtPlantilla.TabIndex = 10;
            this.rtPlantilla.Text = "";
            this.rtPlantilla.TextChanged += new System.EventHandler(this.rtPlantilla_TextChanged);
            // 
            // cbSelecPlantilla
            // 
            this.cbSelecPlantilla.FormattingEnabled = true;
            this.cbSelecPlantilla.Location = new System.Drawing.Point(9, 32);
            this.cbSelecPlantilla.Name = "cbSelecPlantilla";
            this.cbSelecPlantilla.Size = new System.Drawing.Size(222, 21);
            this.cbSelecPlantilla.TabIndex = 9;
            this.cbSelecPlantilla.SelectedIndexChanged += new System.EventHandler(this.cbSelecPlantilla_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Seleccionar una plantilla o ingresar una nueva";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(914, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "ATRÁS";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(917, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 49);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormDocente_Parte6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormDocente_Parte6";
            this.Text = "DocenteParte_6";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtInfo;
        private System.Windows.Forms.ComboBox cbUsarPlantilla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbParalelos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tNomPla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bIngresar;
        private System.Windows.Forms.RichTextBox rtPlantilla;
        private System.Windows.Forms.ComboBox cbSelecPlantilla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}