namespace ProyectoLP_ABA
{
    partial class NuevoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoUsuario));
            this.bIngUsuario = new System.Windows.Forms.Button();
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bIngUsuario
            // 
            this.bIngUsuario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bIngUsuario.BackgroundImage")));
            this.bIngUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bIngUsuario.Location = new System.Drawing.Point(516, 324);
            this.bIngUsuario.Name = "bIngUsuario";
            this.bIngUsuario.Size = new System.Drawing.Size(85, 77);
            this.bIngUsuario.TabIndex = 15;
            this.bIngUsuario.UseVisualStyleBackColor = true;
            this.bIngUsuario.Click += new System.EventHandler(this.bIngUsuario_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbAdmin);
            this.groupBox1.Controls.Add(this.rbDocCor);
            this.groupBox1.Controls.Add(this.rbCoordinador);
            this.groupBox1.Controls.Add(this.rbDocente);
            this.groupBox1.Location = new System.Drawing.Point(461, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 153);
            this.groupBox1.TabIndex = 14;
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
            this.rbAdmin.TabStop = true;
            this.rbAdmin.Text = "Administrador";
            this.rbAdmin.UseVisualStyleBackColor = true;
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
            // 
            // rbDocente
            // 
            this.rbDocente.AutoSize = true;
            this.rbDocente.Checked = true;
            this.rbDocente.Location = new System.Drawing.Point(7, 20);
            this.rbDocente.Name = "rbDocente";
            this.rbDocente.Size = new System.Drawing.Size(66, 17);
            this.rbDocente.TabIndex = 0;
            this.rbDocente.TabStop = true;
            this.rbDocente.Text = "Docente";
            this.rbDocente.UseVisualStyleBackColor = true;
            this.rbDocente.CheckedChanged += new System.EventHandler(this.rbDocente_CheckedChanged);
            // 
            // tContrasenia
            // 
            this.tContrasenia.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tContrasenia.Location = new System.Drawing.Point(667, 103);
            this.tContrasenia.Name = "tContrasenia";
            this.tContrasenia.Size = new System.Drawing.Size(316, 19);
            this.tContrasenia.TabIndex = 13;
            this.tContrasenia.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Linen;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(553, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "CONTRASEÑA";
            // 
            // tNomUsuario
            // 
            this.tNomUsuario.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNomUsuario.Location = new System.Drawing.Point(208, 104);
            this.tNomUsuario.Name = "tNomUsuario";
            this.tNomUsuario.Size = new System.Drawing.Size(316, 19);
            this.tNomUsuario.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Linen;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "NOMBRE DE USUARIO";
            // 
            // tNomCompleto
            // 
            this.tNomCompleto.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNomCompleto.Location = new System.Drawing.Point(291, 38);
            this.tNomCompleto.Name = "tNomCompleto";
            this.tNomCompleto.Size = new System.Drawing.Size(639, 19);
            this.tNomCompleto.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "NOMBRE COMPLETO";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(395, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 77);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(625, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 77);
            this.button2.TabIndex = 17;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(531, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "GUARDAR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(408, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "LIMPIAR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(639, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "ATRÁS";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(999, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 22);
            this.button3.TabIndex = 21;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NuevoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1037, 471);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bIngUsuario);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tContrasenia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tNomUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tNomCompleto);
            this.Controls.Add(this.label1);
            this.Name = "NuevoUsuario";
            this.Text = " ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bIngUsuario;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
    }
}