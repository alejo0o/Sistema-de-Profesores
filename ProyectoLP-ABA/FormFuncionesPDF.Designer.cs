namespace ProyectoLP_ABA
{
    partial class FormFuncionesPDF
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
            this.bCrear = new System.Windows.Forms.Button();
            this.tArea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudIzq = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDer = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudAbajo = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudArriba = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudInterlineado = new System.Windows.Forms.NumericUpDown();
            this.cbVerTodo = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cerrarRegistro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIzq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAbajo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudArriba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterlineado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCrear
            // 
            this.bCrear.Location = new System.Drawing.Point(410, 323);
            this.bCrear.Name = "bCrear";
            this.bCrear.Size = new System.Drawing.Size(257, 23);
            this.bCrear.TabIndex = 1;
            this.bCrear.Text = "Crear PDF";
            this.bCrear.UseVisualStyleBackColor = true;
            this.bCrear.Click += new System.EventHandler(this.bCrear_Click);
            // 
            // tArea
            // 
            this.tArea.Location = new System.Drawing.Point(269, 109);
            this.tArea.Name = "tArea";
            this.tArea.Size = new System.Drawing.Size(223, 20);
            this.tArea.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(269, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Area Academica";
            // 
            // nudAnio
            // 
            this.nudAnio.Location = new System.Drawing.Point(547, 109);
            this.nudAnio.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(120, 20);
            this.nudAnio.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Semestre";
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Items.AddRange(new object[] {
            "01",
            "02"});
            this.cbPeriodo.Location = new System.Drawing.Point(677, 109);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(121, 21);
            this.cbPeriodo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Margenes";
            // 
            // nudIzq
            // 
            this.nudIzq.Location = new System.Drawing.Point(287, 208);
            this.nudIzq.Name = "nudIzq";
            this.nudIzq.Size = new System.Drawing.Size(67, 20);
            this.nudIzq.TabIndex = 8;
            this.nudIzq.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Izquierdo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Derecho";
            // 
            // nudDer
            // 
            this.nudDer.Location = new System.Drawing.Point(372, 208);
            this.nudDer.Name = "nudDer";
            this.nudDer.Size = new System.Drawing.Size(67, 20);
            this.nudDer.TabIndex = 10;
            this.nudDer.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(542, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Abajo";
            // 
            // nudAbajo
            // 
            this.nudAbajo.Location = new System.Drawing.Point(545, 208);
            this.nudAbajo.Name = "nudAbajo";
            this.nudAbajo.Size = new System.Drawing.Size(67, 20);
            this.nudAbajo.TabIndex = 14;
            this.nudAbajo.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(457, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Arriba";
            // 
            // nudArriba
            // 
            this.nudArriba.Location = new System.Drawing.Point(460, 208);
            this.nudArriba.Name = "nudArriba";
            this.nudArriba.Size = new System.Drawing.Size(67, 20);
            this.nudArriba.TabIndex = 12;
            this.nudArriba.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(677, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Interlineado";
            // 
            // nudInterlineado
            // 
            this.nudInterlineado.Location = new System.Drawing.Point(680, 208);
            this.nudInterlineado.Name = "nudInterlineado";
            this.nudInterlineado.Size = new System.Drawing.Size(120, 20);
            this.nudInterlineado.TabIndex = 17;
            this.nudInterlineado.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // cbVerTodo
            // 
            this.cbVerTodo.AutoSize = true;
            this.cbVerTodo.Location = new System.Drawing.Point(268, 271);
            this.cbVerTodo.Name = "cbVerTodo";
            this.cbVerTodo.Size = new System.Drawing.Size(261, 17);
            this.cbVerTodo.TabIndex = 18;
            this.cbVerTodo.Text = "Incluir docentes que no tienen datos en el informe";
            this.cbVerTodo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cerrarRegistro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 47);
            this.panel1.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(446, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "GENERAR PDF";
            // 
            // cerrarRegistro
            // 
            this.cerrarRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrarRegistro.AutoSize = true;
            this.cerrarRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cerrarRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarRegistro.Location = new System.Drawing.Point(1005, 16);
            this.cerrarRegistro.Name = "cerrarRegistro";
            this.cerrarRegistro.Size = new System.Drawing.Size(17, 17);
            this.cerrarRegistro.TabIndex = 5;
            this.cerrarRegistro.Text = "X";
            this.cerrarRegistro.Click += new System.EventHandler(this.cerrarRegistro_Click);
            // 
            // FormFuncionesPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbVerTodo);
            this.Controls.Add(this.nudInterlineado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudAbajo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudArriba);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudDer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudIzq);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPeriodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudAnio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tArea);
            this.Controls.Add(this.bCrear);
            this.Name = "FormFuncionesPDF";
            this.Text = "FormFuncionesPDF";
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIzq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAbajo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudArriba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterlineado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCrear;
        private System.Windows.Forms.TextBox tArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudIzq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudAbajo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudArriba;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudInterlineado;
        private System.Windows.Forms.CheckBox cbVerTodo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label cerrarRegistro;
    }
}