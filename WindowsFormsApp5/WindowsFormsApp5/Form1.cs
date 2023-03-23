using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
        }

        char promena1 = ' ';
        int position = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            FileStream veci = new FileStream("znaky.dat", FileMode.Open, FileAccess.Read);
            BinaryReader vec = new BinaryReader(veci, Encoding.GetEncoding("UTF-8"));

            vec.BaseStream.Position = 0;
            while (vec.BaseStream.Position < vec.BaseStream.Length)
            {
                char znak_cteni = vec.ReadChar();
                listBox1.Items.Add(znak_cteni);
                if (znak_cteni == 63)
                {
                    position = (int)vec.BaseStream.Position;
                    vec.BaseStream.Position -= 2;
                    promena1 = vec.ReadChar();
                    break;
                }
            }
            label1.Text = "otaznice je na pozici : " + position;

            veci.Close();
            vec.Close();
        }
    }
}
