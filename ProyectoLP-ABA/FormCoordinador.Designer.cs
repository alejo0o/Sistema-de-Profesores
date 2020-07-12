namespace ProyectoLP_ABA
{
    partial class FormCoordinador
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cerrarDocente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContenedorC = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.asistenciaReunionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAsistenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAsistenciasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.seguimientoProgramaMicrocurricularesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revisiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revisiónCuestionariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDesarroloSílaboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.otrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizaciónCientíficaDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panelContenedorC.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.cerrarDocente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 51);
            this.panel1.TabIndex = 0;
            // 
            // cerrarDocente
            // 
            this.cerrarDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cerrarDocente.AutoSize = true;
            this.cerrarDocente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cerrarDocente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarDocente.Location = new System.Drawing.Point(1005, 17);
            this.cerrarDocente.Name = "cerrarDocente";
            this.cerrarDocente.Size = new System.Drawing.Size(17, 17);
            this.cerrarDocente.TabIndex = 6;
            this.cerrarDocente.Text = "X";
            this.cerrarDocente.Click += new System.EventHandler(this.cerrarDocente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(430, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "COORDINADOR";
            // 
            // panelContenedorC
            // 
            this.panelContenedorC.Controls.Add(this.menuStrip1);
            this.panelContenedorC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedorC.Location = new System.Drawing.Point(0, 51);
            this.panelContenedorC.Name = "panelContenedorC";
            this.panelContenedorC.Size = new System.Drawing.Size(1034, 420);
            this.panelContenedorC.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asistenciaReunionesToolStripMenuItem,
            this.seguimientoProgramaMicrocurricularesToolStripMenuItem,
            this.revisiónToolStripMenuItem,
            this.revisiónCuestionariosToolStripMenuItem,
            this.dDesarroloSílaboToolStripMenuItem,
            this.otrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1034, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // asistenciaReunionesToolStripMenuItem
            // 
            this.asistenciaReunionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verAsistenciasToolStripMenuItem,
            this.verAsistenciasToolStripMenuItem1});
            this.asistenciaReunionesToolStripMenuItem.Name = "asistenciaReunionesToolStripMenuItem";
            this.asistenciaReunionesToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.asistenciaReunionesToolStripMenuItem.Text = "Asistencia-Reuniones";
            this.asistenciaReunionesToolStripMenuItem.Click += new System.EventHandler(this.asistenciaReunionesToolStripMenuItem_Click);
            // 
            // verAsistenciasToolStripMenuItem
            // 
            this.verAsistenciasToolStripMenuItem.Name = "verAsistenciasToolStripMenuItem";
            this.verAsistenciasToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.verAsistenciasToolStripMenuItem.Text = "Registrar";
            this.verAsistenciasToolStripMenuItem.Click += new System.EventHandler(this.verAsistenciasToolStripMenuItem_Click);
            // 
            // verAsistenciasToolStripMenuItem1
            // 
            this.verAsistenciasToolStripMenuItem1.Name = "verAsistenciasToolStripMenuItem1";
            this.verAsistenciasToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.verAsistenciasToolStripMenuItem1.Text = "Ver Asistencias";
            this.verAsistenciasToolStripMenuItem1.Click += new System.EventHandler(this.verAsistenciasToolStripMenuItem1_Click);
            // 
            // seguimientoProgramaMicrocurricularesToolStripMenuItem
            // 
            this.seguimientoProgramaMicrocurricularesToolStripMenuItem.Name = "seguimientoProgramaMicrocurricularesToolStripMenuItem";
            this.seguimientoProgramaMicrocurricularesToolStripMenuItem.Size = new System.Drawing.Size(238, 20);
            this.seguimientoProgramaMicrocurricularesToolStripMenuItem.Text = "Seguimiento-Programa Microcurriculares";
            this.seguimientoProgramaMicrocurricularesToolStripMenuItem.Click += new System.EventHandler(this.seguimientoProgramaMicrocurricularesToolStripMenuItem_Click);
            // 
            // revisiónToolStripMenuItem
            // 
            this.revisiónToolStripMenuItem.Name = "revisiónToolStripMenuItem";
            this.revisiónToolStripMenuItem.Size = new System.Drawing.Size(179, 20);
            this.revisiónToolStripMenuItem.Text = "Revisión seguimiento al Sílabo";
            this.revisiónToolStripMenuItem.Click += new System.EventHandler(this.revisiónToolStripMenuItem_Click);
            // 
            // revisiónCuestionariosToolStripMenuItem
            // 
            this.revisiónCuestionariosToolStripMenuItem.Name = "revisiónCuestionariosToolStripMenuItem";
            this.revisiónCuestionariosToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.revisiónCuestionariosToolStripMenuItem.Text = "Revisión Cuestionarios";
            this.revisiónCuestionariosToolStripMenuItem.Click += new System.EventHandler(this.revisiónCuestionariosToolStripMenuItem_Click);
            // 
            // dDesarroloSílaboToolStripMenuItem
            // 
            this.dDesarroloSílaboToolStripMenuItem.Name = "dDesarroloSílaboToolStripMenuItem";
            this.dDesarroloSílaboToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.dDesarroloSílaboToolStripMenuItem.Text = "Desarrolo Sílabo";
            this.dDesarroloSílaboToolStripMenuItem.Click += new System.EventHandler(this.dDesarroloSílaboToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // otrosToolStripMenuItem
            // 
            this.otrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizaciónCientíficaDToolStripMenuItem});
            this.otrosToolStripMenuItem.Name = "otrosToolStripMenuItem";
            this.otrosToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.otrosToolStripMenuItem.Text = "Otros";
            // 
            // actualizaciónCientíficaDToolStripMenuItem
            // 
            this.actualizaciónCientíficaDToolStripMenuItem.Name = "actualizaciónCientíficaDToolStripMenuItem";
            this.actualizaciónCientíficaDToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.actualizaciónCientíficaDToolStripMenuItem.Text = "Actualización Científica-D";
            this.actualizaciónCientíficaDToolStripMenuItem.Click += new System.EventHandler(this.actualizaciónCientíficaDToolStripMenuItem_Click);
            // 
            // FormCoordinador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 471);
            this.Controls.Add(this.panelContenedorC);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormCoordinador";
            this.Text = "FormCoordinador";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelContenedorC.ResumeLayout(false);
            this.panelContenedorC.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelContenedorC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cerrarDocente;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asistenciaReunionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seguimientoProgramaMicrocurricularesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verAsistenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verAsistenciasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem revisiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revisiónCuestionariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDesarroloSílaboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizaciónCientíficaDToolStripMenuItem;
    }
}