namespace ProyectoLP_ABA
{
    partial class FormEditarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarUsuario));
            this.tBuscar = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.bEliUsuario = new System.Windows.Forms.Button();
            this.bModUsuario = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAdmin = new System.Windows.Forms.RadioButton();
            this.rbDocCor = new System.Windows.Forms.RadioButton();
            this.rbCoordinador = new System.Windows.Forms.RadioButton();
            this.rbDocente = new System.Windows.Forms.RadioButton();
            this.tContrasenia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tNomUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tNomCompleto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBuscar
            // 
            this.tBuscar.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBuscar.Location = new System.Drawing.Point(25, 101);
            this.tBuscar.Name = "tBuscar";
            this.tBuscar.Size = new System.Drawing.Size(276, 20);
            this.tBuscar.TabIndex = 5;
            this.tBuscar.TextChanged += new System.EventHandler(this.tBuscar_TextChanged);
            // 
            // lbUsuario
            // 
            this.lbUsuario.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.FormattingEnabled = true;
            this.lbUsuario.ItemHeight = 14;
            this.lbUsuario.Location = new System.Drawing.Point(25, 168);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(276, 158);
            this.lbUsuario.TabIndex = 4;
            this.lbUsuario.SelectedIndexChanged += new System.EventHandler(this.lbUsuario_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "BUSCAR USUARIO";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.labelInfo.Location = new System.Drawing.Point(562, 69);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 15);
            this.labelInfo.TabIndex = 27;
            // 
            // bEliUsuario
            // 
            this.bEliUsuario.Location = new System.Drawing.Point(656, 368);
            this.bEliUsuario.Name = "bEliUsuario";
            this.bEliUsuario.Size = new System.Drawing.Size(179, 61);
            this.bEliUsuario.TabIndex = 26;
            this.bEliUsuario.Text = "Eliminar Usuario";
            this.bEliUsuario.UseVisualStyleBackColor = true;
            this.bEliUsuario.Click += new System.EventHandler(this.bEliUsuario_Click);
            // 
            // bModUsuario
            // 
            this.bModUsuario.Location = new System.Drawing.Point(439, 368);
            this.bModUsuario.Name = "bModUsuario";
            this.bModUsuario.Size = new System.Drawing.Size(179, 61);
            this.bModUsuario.TabIndex = 25;
            this.bModUsuario.Text = "Guardar cambios";
            this.bModUsuario.UseVisualStyleBackColor = true;
            this.bModUsuario.Click += new System.EventHandler(this.bModUsuario_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAdmin);
            this.groupBox1.Controls.Add(this.rbDocCor);
            this.groupBox1.Controls.Add(this.rbCoordinador);
            this.groupBox1.Controls.Add(this.rbDocente);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(666, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 132);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione un tipo de usuario";
            // 
            // rbAdmin
            // 
            this.rbAdmin.AutoSize = true;
            this.rbAdmin.Location = new System.Drawing.Point(7, 92);
            this.rbAdmin.Name = "rbAdmin";
            this.rbAdmin.Size = new System.Drawing.Size(88, 17);
            this.rbAdmin.TabIndex = 3;
            this.rbAdmin.Text = "Administrador";
            this.rbAdmin.UseVisualStyleBackColor = true;
            this.rbAdmin.CheckedChanged += new System.EventHandler(this.rbAdmin_CheckedChanged);
            // 
            // rbDocCor
            // 
            this.rbDocCor.AutoSize = true;
            this.rbDocCor.Location = new System.Drawing.Point(7, 68);
            this.rbDocCor.Name = "rbDocCor";
            this.rbDocCor.Size = new System.Drawing.Size(126, 17);
            this.rbDocCor.TabIndex = 2;
            this.rbDocCor.Text = "Docente Coordinador";
            this.rbDocCor.UseVisualStyleBackColor = true;
            this.rbDocCor.CheckedChanged += new System.EventHandler(this.rbDocCor_CheckedChanged);
            // 
            // rbCoordinador
            // 
            this.rbCoordinador.AutoSize = true;
            this.rbCoordinador.Location = new System.Drawing.Point(7, 44);
            this.rbCoordinador.Name = "rbCoordinador";
            this.rbCoordinador.Size = new System.Drawing.Size(82, 17);
            this.rbCoordinador.TabIndex = 1;
            this.rbCoordinador.Text = "Coordinador";
            this.rbCoordinador.UseVisualStyleBackColor = true;
            this.rbCoordinador.CheckedChanged += new System.EventHandler(this.rbCoordinador_CheckedChanged);
            // 
            // rbDocente
            // 
            this.rbDocente.AutoSize = true;
            this.rbDocente.Location = new System.Drawing.Point(7, 20);
            this.rbDocente.Name = "rbDocente";
            this.rbDocente.Size = new System.Drawing.Size(66, 17);
            this.rbDocente.TabIndex = 0;
            this.rbDocente.Text = "Docente";
            this.rbDocente.UseVisualStyleBackColor = true;
            this.rbDocente.CheckedChanged += new System.EventHandler(this.rbDocente_CheckedChanged);
            // 
            // tContrasenia
            // 
            this.tContrasenia.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tContrasenia.Location = new System.Drawing.Point(554, 154);
            this.tContrasenia.Name = "tContrasenia";
            this.tContrasenia.Size = new System.Drawing.Size(345, 20);
            this.tContrasenia.TabIndex = 23;
            this.tContrasenia.UseSystemPasswordChar = true;
            this.tContrasenia.TextChanged += new System.EventHandler(this.tContrasenia_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(405, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "CONTRASEÑA";
            // 
            // tNomUsuario
            // 
            this.tNomUsuario.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNomUsuario.Location = new System.Drawing.Point(554, 98);
            this.tNomUsuario.Name = "tNomUsuario";
            this.tNomUsuario.Size = new System.Drawing.Size(397, 20);
            this.tNomUsuario.TabIndex = 21;
            this.tNomUsuario.TextChanged += new System.EventHandler(this.tNomUsuario_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(405, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "NOMBRE DE USUARIO";
            // 
            // tNomCompleto
            // 
            this.tNomCompleto.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNomCompleto.Location = new System.Drawing.Point(554, 39);
            this.tNomCompleto.Name = "tNomCompleto";
            this.tNomCompleto.Size = new System.Drawing.Size(397, 22);
            this.tNomCompleto.TabIndex = 19;
            this.tNomCompleto.TextChanged += new System.EventHandler(this.tNomCompleto_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(405, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "NOMBRE COMPLETO";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(925, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 22);
            this.button3.TabIndex = 28;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1034, 471);
            this.shapeContainer1.TabIndex = 29;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 376;
            this.lineShape1.X2 = 376;
            this.lineShape1.Y1 = -2;
            this.lineShape1.Y2 = 476;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "DIGITE USUARIO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(908, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "ATRÁS";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(885, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 77);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormEditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.bEliUsuario);
            this.Controls.Add(this.bModUsuario);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tContrasenia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tNomUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tNomCompleto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBuscar);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "FormEditarUsuario";
            this.Text = "FormEditarUsuario";
            this.Load += new System.EventHandler(this.FormEditarUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBuscar;
        private System.Windows.Forms.ListBox lbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button bEliUsuario;
        private System.Windows.Forms.Button bModUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAdmin;
        private System.Windows.Forms.RadioButton rbDocCor;
        private System.Windows.Forms.RadioButton rbCoordinador;
        private System.Windows.Forms.RadioButton rbDocente;
        private System.Windows.Forms.TextBox tContrasenia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tNomUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tNomCompleto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}