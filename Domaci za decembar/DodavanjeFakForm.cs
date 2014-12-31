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
    public partial class SpisakFaxForm : Form
    {

        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\deFaccto\Programiranje\StormWind\Domaci za decembar\Domaci za decembar\baza.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        ListaFax f;
        


        public SpisakFaxForm()
        {
            InitializeComponent();

            promeniBtt.Enabled = false;
            obrisiBtt.Enabled = false;

            cm.Connection = cn;
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

            for (int i = 0; i < f.N; i++)
            {
                listBox1.Items.Add(f[i]);
            }

           
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nazivTxt.Text = listBox1.SelectedItem.ToString();
            promeniBtt.Enabled = true;
            obrisiBtt.Enabled = true;
        }

        private void dodajBtt_Click(object sender, EventArgs e)
        {
            try
            {
                cm.Connection = cn;
                cn.Open();
                cm.CommandText = "insert into Fax (Naziv) values ('" + nazivTxt.Text + "')";
                cm.ExecuteNonQuery();
                cm.Clone();
                cn.Close();

                f.dodajFax(nazivTxt.Text);
                listBox1.Items.Clear();
                for (int i = 0; i < f.N; i++)
                {
                    listBox1.Items.Add(f[i]);
                }

                MessageBox.Show("Uspesno ste dodali novi fakultet");
            }

            catch
            {
                MessageBox.Show("Neuspelo povezivanje na bazu");
            }
        }

        private void promeniBtt_Click(object sender, EventArgs e)
        {
            try
            {
                int x = listBox1.SelectedIndex;

                cn.Open();
                cm.CommandText = "update Fax set Naziv='" + nazivTxt.Text + "'";
                cm.ExecuteNonQuery();
                cm.Clone();
                cn.Close();

                f[x].Naziv = null;
                f[x].Naziv = nazivTxt.Text;

                for (int i = 0; i < f.N; i++)
                {
                    listBox1.Items.Add(f[i]);
                }
            }

            catch
            {

            }
        }

        private void obrisiBtt_Click(object sender, EventArgs e)
        {
            try
            {
                int x = listBox1.SelectedIndex;

                cm.Connection = cn;
                cn.Open();
                cm.CommandText = "delete from Fax where Naziv ='" + nazivTxt.Text + "'";
                cm.ExecuteNonQuery();
                cm.Clone();
                cn.Close();

                f[x].Naziv = "";
                listBox1.Items.Clear();

                for (int i = 0; i < f.N; i++)
                {
                    listBox1.Items.Add(f[i]);
                }

                cm.Connection = cn; // brisanje svih studenata iz tabele koji su upisani na fakultet koji je obrisan
                cn.Open();
                cm.CommandText = "delete from Student where Id_faxa='" + (x + 1) + "'";
                cm.Clone();
                cn.Close();

                

                MessageBox.Show("Uspesno ste obrisali fakultet");
            }

            catch
            {
                MessageBox.Show("Neuspelo povezivanje na bazu");
            }
        }

        
    }
}
