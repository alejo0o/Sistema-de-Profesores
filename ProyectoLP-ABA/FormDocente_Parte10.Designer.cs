namespace ProyectoLP_ABA
{
    partial class FormDocente_Parte10
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocente_Parte10));
            this.bEliminar = new System.Windows.Forms.Button();
            this.bNuevo = new System.Windows.Forms.Button();
            this.cbFondos = new System.Windows.Forms.CheckBox();
            this.tFondos = new System.Windows.Forms.TextBox();
            this.rbPuceNo = new System.Windows.Forms.RadioButton();
            this.rbPuceSi = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbInvestigador = new System.Windows.Forms.RadioButton();
            this.rbDirector = new System.Windows.Forms.RadioButton();
            this.tInstitucion = new System.Windows.Forms.TextBox();
            this.tTitulo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRegistros = new System.Windows.Forms.ListBox();
            this.bSubArch = new System.Windows.Forms.Button();
            this.bVerArch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bEliminar
            // 
            this.bEliminar.Location = new System.Drawing.Point(167, 226);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(111, 23);
            this.bEliminar.TabIndex = 65;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // bNuevo
            // 
            this.bNuevo.Location = new System.Drawing.Point(38, 226);
            this.bNuevo.Name = "bNuevo";
            this.bNuevo.Size = new System.Drawing.Size(111, 23);
            this.bNuevo.TabIndex = 64;
            this.bNuevo.Text = "Crear nuevo";
            this.bNuevo.UseVisualStyleBackColor = true;
            this.bNuevo.Click += new System.EventHandler(this.bNuevo_Click);
            // 
            // cbFondos
            // 
            this.cbFondos.AutoSize = true;
            this.cbFondos.Location = new System.Drawing.Point(601, 167);
            this.cbFondos.Name = "cbFondos";
            this.cbFondos.Size = new System.Drawing.Size(54, 17);
            this.cbFondos.TabIndex = 63;
            this.cbFondos.Text = "Otros:";
            this.cbFondos.UseVisualStyleBackColor = true;
            this.cbFondos.CheckedChanged += new System.EventHandler(this.cbFondos_CheckedChanged);
            // 
            // tFondos
            // 
            this.tFondos.Location = new System.Drawing.Point(673, 167);
            this.tFondos.Name = "tFondos";
            this.tFondos.Size = new System.Drawing.Size(188, 20);
            this.tFondos.TabIndex = 62;
            this.tFondos.TextChanged += new System.EventHandler(this.tFondos_TextChanged);
            // 
            // rbPuceNo
            // 
            this.rbPuceNo.AutoSize = true;
            this.rbPuceNo.Location = new System.Drawing.Point(507, 167);
            this.rbPuceNo.Name = "rbPuceNo";
            this.rbPuceNo.Size = new System.Drawing.Size(39, 17);
            this.rbPuceNo.TabIndex = 61;
            this.rbPuceNo.Text = "No";
            this.rbPuceNo.UseVisualStyleBackColor = true;
            // 
            // rbPuceSi
            // 
            this.rbPuceSi.AutoSize = true;
            this.rbPuceSi.Checked = true;
            this.rbPuceSi.Location = new System.Drawing.Point(412, 167);
            this.rbPuceSi.Name = "rbPuceSi";
            this.rbPuceSi.Size = new System.Drawing.Size(34, 17);
            this.rbPuceSi.TabIndex = 60;
            this.rbPuceSi.TabStop = true;
            this.rbPuceSi.Text = "Si";
            this.rbPuceSi.UseVisualStyleBackColor = true;
            this.rbPuceSi.CheckedChanged += new System.EventHandler(this.rbPuceSi_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Fondos PUCE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbInvestigador);
            this.groupBox1.Controls.Add(this.rbDirector);
            this.groupBox1.Location = new System.Drawing.Point(744, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 89);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Participación como; ";
            // 
            // rbInvestigador
            // 
            this.rbInvestigador.AutoSize = true;
            this.rbInvestigador.Location = new System.Drawing.Point(7, 43);
            this.rbInvestigador.Name = "rbInvestigador";
            this.rbInvestigador.Size = new System.Drawing.Size(83, 17);
            this.rbInvestigador.TabIndex = 1;
            this.rbInvestigador.TabStop = true;
            this.rbInvestigador.Text = "Investigador";
            this.rbInvestigador.UseVisualStyleBackColor = true;
            // 
            // rbDirector
            // 
            this.rbDirector.AutoSize = true;
            this.rbDirector.Checked = true;
            this.rbDirector.Location = new System.Drawing.Point(7, 19);
            this.rbDirector.Name = "rbDirector";
            this.rbDirector.Size = new System.Drawing.Size(62, 17);
            this.rbDirector.TabIndex = 0;
            this.rbDirector.TabStop = true;
            this.rbDirector.Text = "Director";
            this.rbDirector.UseVisualStyleBackColor = true;
            this.rbDirector.CheckedChanged += new System.EventHandler(this.rbDirector_CheckedChanged);
            // 
            // tInstitucion
            // 
            this.tInstitucion.Location = new System.Drawing.Point(412, 113);
            this.tInstitucion.Name = "tInstitucion";
            this.tInstitucion.Size = new System.Drawing.Size(303, 20);
            this.tInstitucion.TabIndex = 57;
            this.tInstitucion.TextChanged += new System.EventHandler(this.tInstitucion_TextChanged);
            // 
            // tTitulo
            // 
            this.tTitulo.Location = new System.Drawing.Point(412, 61);
            this.tTitulo.Name = "tTitulo";
            this.tTitulo.Size = new System.Drawing.Size(303, 20);
            this.tTitulo.TabIndex = 56;
            this.tTitulo.TextChanged += new System.EventHandler(this.tTitulo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Institución auspiciante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Titulo del proyecto de investigación";
            // 
            // lbRegistros
            // 
            this.lbRegistros.FormattingEnabled = true;
            this.lbRegistros.Location = new System.Drawing.Point(38, 25);
            this.lbRegistros.Name = "lbRegistros";
            this.lbRegistros.Size = new System.Drawing.Size(240, 186);
            this.lbRegistros.TabIndex = 53;
            this.lbRegistros.SelectedIndexChanged += new System.EventHandler(this.lbRegistros_SelectedIndexChanged);
            // 
            // bSubArch
            // 
            this.bSubArch.Location = new System.Drawing.Point(647, 219);
            this.bSubArch.Name = "bSubArch";
            this.bSubArch.Size = new System.Drawing.Size(137, 23);
            this.bSubArch.TabIndex = 52;
            this.bSubArch.Text = "Subir Archivo";
            this.bSubArch.UseVisualStyleBackColor = true;
            this.bSubArch.Click += new System.EventHandler(this.bSubArch_Click);
            // 
            // bVerArch
            // 
            this.bVerArch.Location = new System.Drawing.Point(481, 219);
            this.bVerArch.Name = "bVerArch";
            this.bVerArch.Size = new System.Drawing.Size(139, 23);
            this.bVerArch.TabIndex = 51;
            this.bVerArch.Text = "Ver Archivo";
            this.bVerArch.UseVisualStyleBackColor = true;
            this.bVerArch.Click += new System.EventHandler(this.bVerArch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(35, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Seleccione una materia";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(478, 202);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 13);
            this.labelEstado.TabIndex = 49;
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
            this.label6.Location = new System.Drawing.Point(511, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "ATRÁS";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(507, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 49);
            this.button2.TabIndex = 66;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormDocente_Parte10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.bNuevo);
            this.Controls.Add(this.cbFondos);
            this.Controls.Add(this.tFondos);
            this.Controls.Add(this.rbPuceNo);
            this.Controls.Add(this.rbPuceSi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tInstitucion);
            this.Controls.Add(this.tTitulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRegistros);
            this.Controls.Add(this.bSubArch);
            this.Controls.Add(this.bVerArch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelEstado);
            this.Name = "FormDocente_Parte10";
            this.Text = "FormDocente_Parte10";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bEliminar;
        private System.Windows.Forms.Button bNuevo;
        private System.Windows.Forms.CheckBox cbFondos;
        private System.Windows.Forms.TextBox tFondos;
        private System.Windows.Forms.RadioButton rbPuceNo;
        private System.Windows.Forms.RadioButton rbPuceSi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbInvestigador;
        private System.Windows.Forms.RadioButton rbDirector;
        private System.Windows.Forms.TextBox tInstitucion;
        private System.Windows.Forms.TextBox tTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbRegistros;
        private System.Windows.Forms.Button bSubArch;
        private System.Windows.Forms.Button bVerArch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}