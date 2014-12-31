using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Domaci_za_decembar.Klase;

namespace Domaci_za_decembar
{
    public partial class DodavanjeStdForm : Form
    {
        

        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\deFaccto\Programiranje\StormWind\Domaci za decembar\Domaci za decembar\baza.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        

        public DodavanjeStdForm()
        {
            
            
            InitializeComponent();

            for (int i = 0; i < SpisakStdForm.f.N; i++)
            {
                listBox1.Items.Add(SpisakStdForm.f[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int x = listBox1.SelectedIndex + 1;

                cm.Connection = cn;                
                cn.Open();
                cm.CommandText = "insert into Student (Ime, Prezime, Br_Indexa, Id_faxa) values ('" + imeTxt.Text + "', '" + prezimeTxt.Text + "', '" + indexTxt.Text +"', '" + x + "')";
                cm.ExecuteNonQuery();
                cm.Clone();
                cn.Close();
                        
                SpisakStdForm.s.dodajStudenta((Fax)listBox1.SelectedItem, imeTxt.Text, prezimeTxt.Text, indexTxt.Text);
                 
               
                MessageBox.Show("Uspesno ste ubacili novog studenta");
            }

            catch
            {
                MessageBox.Show("Greska");
                cn.Close();
            }

            imeTxt.Text = "";
            prezimeTxt.Text = "";
            indexTxt.Text = "";
            
        }

        private void DodavanjeStdForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            SpisakStdForm ss = new SpisakStdForm();
            
            ss.Refresh();
            //ss.izlisajStudente();
        }
    }
}
