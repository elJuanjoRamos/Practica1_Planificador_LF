namespace Practica1_Planificador_LF
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Archivo = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripLabel();
            this.Otros = new System.Windows.Forms.ToolStripDropDownButton();
            this.imprimirTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayuda = new System.Windows.Forms.ToolStripDropDownButton();
            this.manualDeAplicacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutaArchivo = new System.Windows.Forms.TextBox();
            this.textAnalizar = new System.Windows.Forms.RichTextBox();
            this.Result = new System.Windows.Forms.RichTextBox();
            this.Analizar = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.detalle = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(520, 178);
            this.calendario.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Archivo,
            this.toolStripDropDownButton1,
            this.Otros,
            this.ayuda});
            this.toolStrip1.Location = new System.Drawing.Point(7, 66);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(176, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Archivo
            // 
            this.Archivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.Archivo.Image = ((System.Drawing.Image)(resources.GetObject("Archivo.Image")));
            this.Archivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Archivo.Name = "Archivo";
            this.Archivo.Size = new System.Drawing.Size(61, 22);
            this.Archivo.Text = "Archivo";
            this.Archivo.ToolTipText = "Archivo";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.newToolStripMenuItem.Text = "Nueva Pestaña";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openToolStripMenuItem.Text = "Abrir Archivo";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.guardarToolStripMenuItem.Text = "Guardar Archivo";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(0, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // Otros
            // 
            this.Otros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Otros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirTokensToolStripMenuItem,
            this.imprimirErroresToolStripMenuItem,
            this.imprimirEventosToolStripMenuItem});
            this.Otros.Image = ((System.Drawing.Image)(resources.GetObject("Otros.Image")));
            this.Otros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Otros.Name = "Otros";
            this.Otros.Size = new System.Drawing.Size(49, 22);
            this.Otros.Text = "Otros";
            this.Otros.ToolTipText = "Otros";
            // 
            // imprimirTokensToolStripMenuItem
            // 
            this.imprimirTokensToolStripMenuItem.Name = "imprimirTokensToolStripMenuItem";
            this.imprimirTokensToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.imprimirTokensToolStripMenuItem.Text = "Imprimir Tokens";
            this.imprimirTokensToolStripMenuItem.Click += new System.EventHandler(this.ImprimirTokensToolStripMenuItem_Click);
            // 
            // imprimirErroresToolStripMenuItem
            // 
            this.imprimirErroresToolStripMenuItem.Name = "imprimirErroresToolStripMenuItem";
            this.imprimirErroresToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.imprimirErroresToolStripMenuItem.Text = "Imprimir Errores";
            this.imprimirErroresToolStripMenuItem.Click += new System.EventHandler(this.ImprimirErroresToolStripMenuItem_Click);
            // 
            // imprimirEventosToolStripMenuItem
            // 
            this.imprimirEventosToolStripMenuItem.Name = "imprimirEventosToolStripMenuItem";
            this.imprimirEventosToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.imprimirEventosToolStripMenuItem.Text = "Imprimir Eventos";
            this.imprimirEventosToolStripMenuItem.Click += new System.EventHandler(this.ImprimirEventosToolStripMenuItem_Click);
            // 
            // ayuda
            // 
            this.ayuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ayuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualDeAplicacionToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.ayuda.Image = ((System.Drawing.Image)(resources.GetObject("ayuda.Image")));
            this.ayuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ayuda.Name = "ayuda";
            this.ayuda.Size = new System.Drawing.Size(54, 22);
            this.ayuda.Text = "Ayuda";
            // 
            // manualDeAplicacionToolStripMenuItem
            // 
            this.manualDeAplicacionToolStripMenuItem.Name = "manualDeAplicacionToolStripMenuItem";
            this.manualDeAplicacionToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.manualDeAplicacionToolStripMenuItem.Text = "Manual de Aplicacion";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca De";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.AcercaDeToolStripMenuItem_Click);
            // 
            // rutaArchivo
            // 
            this.rutaArchivo.Location = new System.Drawing.Point(44, 119);
            this.rutaArchivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rutaArchivo.Name = "rutaArchivo";
            this.rutaArchivo.Size = new System.Drawing.Size(415, 20);
            this.rutaArchivo.TabIndex = 6;
            // 
            // textAnalizar
            // 
            this.textAnalizar.Location = new System.Drawing.Point(0, 0);
            this.textAnalizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textAnalizar.Name = "textAnalizar";
            this.textAnalizar.Size = new System.Drawing.Size(409, 436);
            this.textAnalizar.TabIndex = 7;
            this.textAnalizar.Text = "";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(542, 405);
            this.Result.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(554, 198);
            this.Result.TabIndex = 9;
            this.Result.Text = "";
            this.Result.TextChanged += new System.EventHandler(this.Result_TextChanged);
            // 
            // Analizar
            // 
            this.Analizar.Location = new System.Drawing.Point(520, 119);
            this.Analizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Analizar.Name = "Analizar";
            this.Analizar.Size = new System.Drawing.Size(98, 36);
            this.Analizar.TabIndex = 10;
            this.Analizar.Text = "Analizar";
            this.Analizar.UseVisualStyleBackColor = true;
            this.Analizar.Click += new System.EventHandler(this.Analizar_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(806, 93);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(290, 283);
            this.treeView1.TabIndex = 11;
            // 
            // detalle
            // 
            this.detalle.Location = new System.Drawing.Point(638, 117);
            this.detalle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.detalle.Name = "detalle";
            this.detalle.Size = new System.Drawing.Size(78, 37);
            this.detalle.TabIndex = 12;
            this.detalle.Text = "Ver Actividades";
            this.detalle.UseVisualStyleBackColor = true;
            this.detalle.Click += new System.EventHandler(this.Detalle_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(44, 141);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(414, 461);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textAnalizar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(406, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pestaña 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(406, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pestaña 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 1);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(409, 436);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 644);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.detalle);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.Analizar);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.rutaArchivo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.calendario);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox rutaArchivo;
        private System.Windows.Forms.RichTextBox textAnalizar;
        private System.Windows.Forms.ToolStripDropDownButton Archivo;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Result;
        private System.Windows.Forms.ToolStripLabel toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton Otros;
        private System.Windows.Forms.ToolStripMenuItem imprimirTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirErroresToolStripMenuItem;
        private System.Windows.Forms.Button Analizar;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripDropDownButton ayuda;
        private System.Windows.Forms.ToolStripMenuItem manualDeAplicacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.Button detalle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem imprimirEventosToolStripMenuItem;
    }
}

