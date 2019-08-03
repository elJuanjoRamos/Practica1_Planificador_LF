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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutaArchivo = new System.Windows.Forms.TextBox();
            this.textAnalizar = new System.Windows.Forms.RichTextBox();
            this.Analizar = new MaterialSkin.Controls.MaterialFlatButton();
            this.Result = new System.Windows.Forms.RichTextBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripLabel();
            this.Otros = new System.Windows.Forms.ToolStripDropDownButton();
            this.imprimirTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(693, 219);
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
            this.Otros});
            this.toolStrip1.Location = new System.Drawing.Point(9, 81);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(184, 27);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Archivo
            // 
            this.Archivo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.Archivo.Image = ((System.Drawing.Image)(resources.GetObject("Archivo.Image")));
            this.Archivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Archivo.Name = "Archivo";
            this.Archivo.Size = new System.Drawing.Size(73, 24);
            this.Archivo.Text = "Archivo";
            this.Archivo.ToolTipText = "Archivo";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newToolStripMenuItem.Text = "Nueva Pestaña";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Abrir Archivo";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Guardar Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // rutaArchivo
            // 
            this.rutaArchivo.Location = new System.Drawing.Point(59, 146);
            this.rutaArchivo.Name = "rutaArchivo";
            this.rutaArchivo.Size = new System.Drawing.Size(552, 22);
            this.rutaArchivo.TabIndex = 6;
            // 
            // textAnalizar
            // 
            this.textAnalizar.Location = new System.Drawing.Point(59, 178);
            this.textAnalizar.Name = "textAnalizar";
            this.textAnalizar.Size = new System.Drawing.Size(552, 617);
            this.textAnalizar.TabIndex = 7;
            this.textAnalizar.Text = "";
            // 
            // Analizar
            // 
            this.Analizar.AutoSize = true;
            this.Analizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Analizar.Depth = 0;
            this.Analizar.Icon = null;
            this.Analizar.Location = new System.Drawing.Point(749, 146);
            this.Analizar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Analizar.MouseState = MaterialSkin.MouseState.HOVER;
            this.Analizar.Name = "Analizar";
            this.Analizar.Primary = false;
            this.Analizar.Size = new System.Drawing.Size(104, 36);
            this.Analizar.TabIndex = 8;
            this.Analizar.Text = "Analizar";
            this.Analizar.UseVisualStyleBackColor = true;
            this.Analizar.Click += new System.EventHandler(this.Analizar_Click);
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(722, 498);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(598, 243);
            this.Result.TabIndex = 9;
            this.Result.Text = "";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(0, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // Otros
            // 
            this.Otros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Otros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirTokensToolStripMenuItem,
            this.imprimirErroresToolStripMenuItem});
            this.Otros.Image = ((System.Drawing.Image)(resources.GetObject("Otros.Image")));
            this.Otros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Otros.Name = "Otros";
            this.Otros.Size = new System.Drawing.Size(59, 24);
            this.Otros.Text = "Otros";
            this.Otros.ToolTipText = "Otros";
            // 
            // imprimirTokensToolStripMenuItem
            // 
            this.imprimirTokensToolStripMenuItem.Name = "imprimirTokensToolStripMenuItem";
            this.imprimirTokensToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.imprimirTokensToolStripMenuItem.Text = "Imprimir Tokens";
            this.imprimirTokensToolStripMenuItem.Click += new System.EventHandler(this.ImprimirTokensToolStripMenuItem_Click);
            // 
            // imprimirErroresToolStripMenuItem
            // 
            this.imprimirErroresToolStripMenuItem.Name = "imprimirErroresToolStripMenuItem";
            this.imprimirErroresToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.imprimirErroresToolStripMenuItem.Text = "Imprimir Errores";
            this.imprimirErroresToolStripMenuItem.Click += new System.EventHandler(this.ImprimirErroresToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 851);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Analizar);
            this.Controls.Add(this.textAnalizar);
            this.Controls.Add(this.rutaArchivo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.calendario);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox rutaArchivo;
        private System.Windows.Forms.RichTextBox textAnalizar;
        private MaterialSkin.Controls.MaterialFlatButton Analizar;
        private System.Windows.Forms.ToolStripDropDownButton Archivo;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Result;
        private System.Windows.Forms.ToolStripLabel toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton Otros;
        private System.Windows.Forms.ToolStripMenuItem imprimirTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirErroresToolStripMenuItem;
    }
}

