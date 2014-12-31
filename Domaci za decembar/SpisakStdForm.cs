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
    public partial class SpisakStdForm : Form
    {

        public static ListaStudent s;
        public static ListaFax f;
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\deFaccto\Programiranje\StormWind\Domaci za decembar\Domaci za decembar\baza.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        

        public SpisakStdForm()
        {
            InitializeComponent();

            promeniBtt.Enabled = false;
            cm.Connection = cn;

            s = new ListaStudent();
            f = new ListaFax();

            cn.Open();
            cm.CommandText = "select * from Fax";
            dr = cm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    f.dodajFax(dr[1].ToString());
                }
            }
            cn.Close();

            cn.Open();
            cm.CommandText = "select * from Student";
            dr = cm.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    int x = int.Parse(dr[4].ToString()) - 1;
                    s.dodajStudenta(f[x], dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
            }
            cn.Close();




            izlisajStudente();


            for (int i = 0; i < f.N; i++) // dodavanje u ComboBox
            {
                comboBox1.Items.Add(f[i].Naziv);
            }

        }

        public void izlisajStudente()
        {
            

            for (int i = 0; i < s.N; i++) //dodavanje u ListBox
            {
                if (s[i].Ime != null && s[i].Prezime != null && s[i].Index!=null)
                {
                     listBox1.Items.Add(s[i].Ime + " " + s[i].Prezime + " " + s[i].Index);
                }
            }

           
        }

        public void dodajUListu(ListaStudent s)
        {
            try
            {
                listBox1.Items.Add(s[s.N - 1]);
            }

            catch
            {
                MessageBox.Show("Greska");
            }
        }



        
        private void SpisakStdForm_Load(object sender, EventArgs e)
        {
  
        }        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string st = comboBox1.SelectedItem.ToString();

            for (int i = 0; i < s.N; i++)
            {
                if (s[i].Fax.Naziv == st)
                {
                    listBox1.Items.Add(s[i].Ime + " " + s[i].Prezime + " " + s[i].Index);
                }
            }

            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(textBox1.Text!="")
            {
                string st=textBox1.Text;
                for (int i = 0; i < s.N; i++)
                {
                    if(s[i].sadrzi(st))
                    {
                        listBox1.Items.Add(s[i].Ime + " " + s[i].Prezime + " " + s[i].Index);
                    }
                }
            }

            else
            {
                for (int i = 0; i < s.N; i++) 
                {
                    listBox1.Items.Add(s[i].Ime + " " + s[i].Prezime + " " + s[i].Index);
                }
            }
        }

        private void dodajBtt_Click(object sender, EventArgs e)
        {
            DodavanjeStdForm d = new DodavanjeStdForm();
            d.Show();
            
        }

        private void promeniBtt_Click(object sender, EventArgs e)
        {
            try
            {
                int x = listBox1.SelectedIndex + 1;
                int b = listBox1.SelectedIndex;
                

                cn.Open();
                cm.CommandText = "update Student set Ime = '" + imeTxt.Text + "', Prezime = '" + prezimeTxt.Text + "', Br_Indexa = '" + indexTxt.Text + "' where Id = '" + x + "'";
                cm.ExecuteNonQuery();
                cm.Clone();
                cn.Close();

                listBox1.Items.Clear();
                s[b].Ime = "";
                s[b].Ime = imeTxt.Text;
                s[b].Prezime = "";
                s[b].Prezime = prezimeTxt.Text;
                s[b].Index = "";
                s[b].Index = indexTxt.Text;
                izlisajStudente();

                MessageBox.Show("Uspesno ste promenili podatke studenta");

                imeTxt.Text = "";
                prezimeTxt.Text = "";
                indexTxt.Text = "";
                promeniBtt.Enabled = false;
            }

            catch
            {
                MessageBox.Show("Greska");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            imeTxt.Text = s[x].Ime;
            prezimeTxt.Text = s[x].Prezime;
            indexTxt.Text = s[x].Index;
            promeniBtt.Enabled = true;
        }

        private void obirsiStdBtt_Click(object sender, EventArgs e)
        {
            try
            {
                
                    int x = listBox1.SelectedIndex + 1;
                    int b = listBox1.SelectedIndex;
                    int y = comboBox1.SelectedIndex + 1;

                    cn.Open();
                    cm.CommandText = "delete from Student where Ime ='" + imeTxt.Text + "' and Prezime ='" + prezimeTxt.Text + "' and Br_Indexa ='" + indexTxt.Text + "'";
                    cm.ExecuteNonQuery();
                    cm.Clone();
                    cn.Close();

                    s[b].Ime = null;
                    s[b].Prezime = null;
                    s[b].Index = null;
                    s[b].Fax.Naziv = null;
                    listBox1.Items.Clear();
                    izlisajStudente();
             

                    MessageBox.Show("Uspesno ste obrisali studenta");
               

                
                
            }

            catch
            {
                MessageBox.Show("Neuspesno brisanje iz baze");
            }
        }

        

        

        
        
    }
}
