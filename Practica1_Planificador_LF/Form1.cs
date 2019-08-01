using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

//Material Design
using MaterialSkin;
using MaterialSkin.Controls;


namespace Practica1_Planificador_LF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void Analizar_Click(object sender, EventArgs e)
        {

            /*calendario.MaxSelectionCount = 1;
            textBox1.Text = calendario.SelectionRange.Start.ToShortDateString();
            TreeNode newNode = new TreeNode("Text for new node");
            arbol.SelectedNode.Nodes.Add(newNode);*/
        }


        /*MENU BAR*/

        /*Nueva pestaña*/
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        /*Abrir archivo*/
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscar = new OpenFileDialog();

            if (buscar.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo.Text = buscar.FileName;

            }

            if (File.Exists(rutaArchivo.Text))  //verifica si el archivo existe
            {

                StreamReader leer = new StreamReader(rutaArchivo.Text);
                
                string linea;
                
                try
                    {
                    linea = leer.ReadLine();
                    while (linea != null)
                    {
                        textAnalizar.AppendText(linea + "\n");
                            linea = leer.ReadLine();
                        }
                    analizarCadena();

                }


                catch (Exception)
                    {

                        MessageBox.Show("Error");
                    }

                
            }
            else
            {
                MessageBox.Show("No se ha encontrado la ruta o archivo", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }


        public async void analizarCadena()
        {

            char[] charsRead = new char[textAnalizar.Text.Length];
            using (StringReader reader = new StringReader(textAnalizar.Text))
            {
                await reader.ReadAsync(charsRead, 0, textAnalizar.Text.Length);
            }

            StringBuilder reformattedText = new StringBuilder();
            using (StringWriter writer = new StringWriter(reformattedText))
            {
                foreach (char c in charsRead)
                {
                    if (char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsDigit(c) || char.IsSeparator(c) || char.IsSymbol(c)
                        || char.IsLetterOrDigit(c) || char.IsPunctuation(c) || char.IsControl(c) || char.IsSurrogate(c) || char.IsUpper(c))
                    {
                        await writer.WriteLineAsync(char.ToLower(c));
                    }
                }
            }
            Result.Text = reformattedText.ToString();

        }

    }
}
