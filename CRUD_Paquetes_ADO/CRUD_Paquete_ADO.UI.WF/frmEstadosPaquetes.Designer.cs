namespace CRUD_Paquete_ADO.UI.WF
{
    partial class frmEstadosPaquetes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadosPaquetes));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dgvEstadosPaquetes = new System.Windows.Forms.DataGridView();
            this.btnBuscarUser = new System.Windows.Forms.Button();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.agregarEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadosPaquetes)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.ContentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripContainer1.ContentPanel.BackgroundImage")));
            this.toolStripContainer1.ContentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(335, 292);
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(48, 174);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(335, 292);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dgvEstadosPaquetes
            // 
            this.dgvEstadosPaquetes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadosPaquetes.Location = new System.Drawing.Point(401, 132);
            this.dgvEstadosPaquetes.Name = "dgvEstadosPaquetes";
            this.dgvEstadosPaquetes.ReadOnly = true;
            this.dgvEstadosPaquetes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstadosPaquetes.Size = new System.Drawing.Size(440, 275);
            this.dgvEstadosPaquetes.TabIndex = 2;
            // 
            // btnBuscarUser
            // 
            this.btnBuscarUser.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarUser.Location = new System.Drawing.Point(708, 78);
            this.btnBuscarUser.Name = "btnBuscarUser";
            this.btnBuscarUser.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarUser.TabIndex = 8;
            this.btnBuscarUser.Text = "BUSCAR";
            this.btnBuscarUser.UseVisualStyleBackColor = false;
            this.btnBuscarUser.Click += new System.EventHandler(this.btnBuscarUser_Click);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(538, 80);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(156, 20);
            this.txtDNI.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(443, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Paquete ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(189)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Humnst777 Blk BT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(404, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 33);
            this.label1.TabIndex = 9;
            this.label1.Text = "ESTADO DE ENTREGAS";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarEstadoToolStripMenuItem,
            this.editarEstadoToolStripMenuItem,
            this.eliminarEstadoToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1062, 24);
            this.menuStrip2.TabIndex = 10;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // agregarEstadoToolStripMenuItem
            // 
            this.agregarEstadoToolStripMenuItem.Name = "agregarEstadoToolStripMenuItem";
            this.agregarEstadoToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.agregarEstadoToolStripMenuItem.Text = "Agregar Estado";
            this.agregarEstadoToolStripMenuItem.Click += new System.EventHandler(this.agregarEstadoToolStripMenuItem_Click);
            // 
            // editarEstadoToolStripMenuItem
            // 
            this.editarEstadoToolStripMenuItem.Name = "editarEstadoToolStripMenuItem";
            this.editarEstadoToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.editarEstadoToolStripMenuItem.Text = "Editar Estado";
            this.editarEstadoToolStripMenuItem.Click += new System.EventHandler(this.editarEstadoToolStripMenuItem_Click);
            // 
            // eliminarEstadoToolStripMenuItem
            // 
            this.eliminarEstadoToolStripMenuItem.Name = "eliminarEstadoToolStripMenuItem";
            this.eliminarEstadoToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.eliminarEstadoToolStripMenuItem.Text = "Eliminar Estado";
            this.eliminarEstadoToolStripMenuItem.Click += new System.EventHandler(this.eliminarEstadoToolStripMenuItem_Click);
            // 
            // frmEstadosPaquetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1062, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarUser);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvEstadosPaquetes);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEstadosPaquetes";
            this.Text = "DETALLES ESTAOOS PAQUETES";
            this.Load += new System.EventHandler(this.frmEstadosPaquetes_Load);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadosPaquetes)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dgvEstadosPaquetes;
        private System.Windows.Forms.Button btnBuscarUser;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem agregarEstadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarEstadoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem eliminarEstadoToolStripMenuItem;
    }
}