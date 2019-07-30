using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Material Design
using MaterialSkin;
using MaterialSkin.Controls;


namespace Practica1_Planificador_LF
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            //Inicializa material design
            MaterialSkinManager ms = MaterialSkinManager.Instance;
            ms.AddFormToManage(this);
            ms.Theme = MaterialSkinManager.Themes.LIGHT;
            /*ms.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
