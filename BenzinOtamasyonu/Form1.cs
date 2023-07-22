using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace BenzinOtamasyonu
{
    public partial class Form1 : Form
    {
        
        float S_benzin95 = 0, S_benzin97 = 0, S_dizel = 0, S_eurodizel = 0, S_lpg = 0;
        float D_benzin95 = 0, D_benzin97 = 0, D_dizel = 0, D_eurodizel = 0, D_lpg = 0;
        float E_benzin95 = 0, E_benzin97 = 0, E_dizel = 0, E_eurodizel = 0, E_lpg = 0;
        float F_benzin95 = 0, F_benzin97 = 0, F_dizel = 0, F_eurodizel = 0, F_lpg = 0;
        int maksimumDepoBoyutu = 1000;



        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        public Form1()
        {

            getData();
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            priceUpdate();
        }
        private void priceUpdate()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=localhost; Database=master; Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand Command;
            String sql;


            try
            {
                double yedek = Convert.ToDouble(textBox6.Text);
                float reel = (float)(yedek);
                F_benzin95 = F_benzin95 + (F_benzin95 * reel / 100); // zam için pozitif sayý indirim için negatif sayý girilir.
                sql = "UPDATE YAKIT SET price = '" + F_benzin95 + "' WHERE id = 1;";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                textBox6.Text = "";
            }
            catch (Exception)
            {

            }

            try
            {
                double yedek = Convert.ToDouble(textBox7.Text);
                float reel = (float)(yedek);
                F_benzin97 = F_benzin97 + (F_benzin97 * reel / 100);
                sql = "UPDATE YAKIT SET price = '" + F_benzin97 + "' WHERE id = 2;";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                textBox7.Text = "";
            }
            catch (Exception)
            {


            }


            try
            {
                double yedek = Convert.ToDouble(textBox8.Text);
                float reel = (float)(yedek);
                F_dizel = F_dizel + (F_benzin97 * reel / 100);
                sql = "UPDATE YAKIT SET price = '" + F_dizel + "' WHERE id = 3;";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                textBox8.Text = "";
            }
            catch (Exception)
            {

            }


            try
            {
                double yedek = Convert.ToDouble(textBox9.Text);
                float reel = (float)(yedek);
                F_eurodizel = F_eurodizel + (F_eurodizel * reel / 100);
                sql = "UPDATE YAKIT SET price = '" + F_eurodizel + "' WHERE id = 4;";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                textBox9.Text = "";
            }
            catch (Exception)
            {

            }

            try
            {
                double yedek = Convert.ToDouble(textBox10.Text);
                float reel = (float)(yedek);
                F_lpg = F_lpg + (F_lpg * reel / 100);
                sql = "UPDATE YAKIT SET price = '" + F_lpg + "' WHERE id = 5;";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                textBox10.Text = "";
            }
            catch (Exception)
            {

            }

            cnn.Close();
            getData();
            fiyat_yaz();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stockDisposal();
        }
        private void stockDisposal()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=localhost; Database=master; Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand Command;
            String sql;
            double hesaplama = 0;


            S_benzin95 = float.Parse(numericUpDown1.Value.ToString());
            S_benzin97 = float.Parse(numericUpDown2.Value.ToString());
            S_dizel = float.Parse(numericUpDown3.Value.ToString());
            S_eurodizel = float.Parse(numericUpDown4.Value.ToString());
            S_lpg = float.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled == true)
            {

                D_benzin95 = D_benzin95 - S_benzin95;
                sql = "UPDATE YAKIT SET stock = '" + D_benzin95 + "' WHERE id = 1";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                hesaplama = S_benzin95 * F_benzin95;
                label29.Text = hesaplama.ToString("N") + " TL"; // Ödenecek tutar
            }
            else if (numericUpDown2.Enabled == true)
            {
                D_benzin97 = D_benzin97 - S_benzin97;
                sql = "UPDATE YAKIT SET stock = '" + D_benzin97 + "' WHERE id = 2";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                hesaplama = S_benzin97 * F_benzin97;
                label29.Text = hesaplama.ToString("N") + " TL"; // Ödenecek tutar
            }
            else if (numericUpDown3.Enabled == true)
            {
                hesaplama = S_dizel * F_dizel;
                D_dizel = D_dizel - S_dizel;
                sql = "UPDATE YAKIT SET stock = '" + D_dizel + "' WHERE id = 3";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                label29.Text = hesaplama.ToString("N") + " TL"; // Ödenecek tutar
            }
            else if (numericUpDown4.Enabled == true)
            {
                D_eurodizel = D_eurodizel - S_eurodizel;
                sql = "UPDATE YAKIT SET stock = '" + D_eurodizel + "' WHERE id = 4";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                hesaplama = S_eurodizel * F_eurodizel;
                label29.Text = hesaplama.ToString("N") + " TL"; // Ödenecek tutar
            }
            else if (numericUpDown5.Enabled == true)
            {
                D_lpg = D_lpg - S_lpg;
                sql = "UPDATE YAKIT SET stock = '" + D_lpg + "' WHERE id = 5";
                Command = new SqlCommand(sql, cnn);
                Command.ExecuteNonQuery();
                hesaplama = S_lpg * F_lpg;
                label29.Text = hesaplama.ToString("N") + " TL"; ; // Ödenecek tutar
            }
            cnn.Close();
            getData();
            depo_yaz();
            progressbar();
            numericupdown_value();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (comboBox1.Text == "Benzin (95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Benzin (97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Euro Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            // Seçimi Deðiþtirdiðimde sayýlarý sýfýrlýyor.
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
         
            label29.Text = "__________ TL"; // ödenecek tutar kýsmý 
        }
        private void depo_yaz()
        {
            label6.Text = D_benzin95.ToString("N") + " Lt";
            label7.Text = D_benzin97.ToString("N") + " Lt";
            label8.Text = D_dizel.ToString("N") + " Lt";
            label9.Text = D_eurodizel.ToString("N") + " Lt";
            label10.Text = D_lpg.ToString("N") + " Lt";
        }


        private void fiyat_yaz()
        {
            label16.Text = F_benzin95.ToString("N");
            label17.Text = F_benzin97.ToString("N");
            label18.Text = F_dizel.ToString("N");
            label19.Text = F_eurodizel.ToString("N");
            label20.Text = F_lpg.ToString("N");
        }

        private void getData()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=localhost; Database=master; Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand Command;
            SqlDataReader Reader;
            String sql;
            sql = "Select price,stock from YAKIT;";
            Command = new SqlCommand(sql, cnn);
            Reader = Command.ExecuteReader();
            int i = 0;
            while (Reader.Read())
            {
                if (i == 0)
                {
                    double yedek = Convert.ToDouble(Reader.GetValue(0));
                    F_benzin95 = (float)(yedek);
                    yedek = Convert.ToDouble(Reader.GetValue(1));
                    D_benzin95 = (float)(yedek);
                    
                }
                else if (i == 1)
                {
                    double yedek = Convert.ToDouble(Reader.GetValue(0));
                    F_benzin97 = (float)(yedek);
                    yedek = Convert.ToDouble(Reader.GetValue(1));
                    D_benzin97 = (float)(yedek);
                }
                else if (i == 2)
                {
                    double yedek = Convert.ToDouble(Reader.GetValue(0));
                    F_dizel = (float)(yedek);
                    yedek = Convert.ToDouble(Reader.GetValue(1));
                    D_dizel = (float)(yedek);
                }
                else if (i == 3)
                {   
                    double yedek = Convert.ToDouble(Reader.GetValue(0));
                    F_eurodizel = (float)(yedek);
                    yedek = Convert.ToDouble(Reader.GetValue(1));
                    D_eurodizel = (float)(yedek);
                }
                else
                {
                    double yedek = Convert.ToDouble(Reader.GetValue(0));
                    F_lpg = (float)(yedek);
                    yedek = Convert.ToDouble(Reader.GetValue(1));
                    D_lpg = (float)(yedek);
                }
                i++;
            }
             
            cnn.Close();
            
        }
        private void progressbar()
        {

            progressBar1.Value = Convert.ToInt16(D_benzin95);
            progressBar2.Value = Convert.ToInt16(D_benzin97);
            progressBar3.Value = Convert.ToInt16(D_dizel);
            progressBar4.Value = Convert.ToInt16(D_eurodizel);
            progressBar5.Value = Convert.ToInt16(D_lpg);
            

        }
        private void numericupdown_value()
        {
            //Satýþ Yaparken sayýsal deðer arttýrma
            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(D_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_eurodizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(D_lpg.ToString());
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "AKARYAKIT OTOMASYONU";
            
             //Depo Bilgileri kýsmýndaki ilerleme barýnýn maks deðeri
            progressBar1.Maximum = maksimumDepoBoyutu;
            progressBar2.Maximum = maksimumDepoBoyutu;
            progressBar3.Maximum = maksimumDepoBoyutu;
            progressBar4.Maximum = maksimumDepoBoyutu;
            progressBar5.Maximum = maksimumDepoBoyutu;

            getData();
            fiyat_yaz();
            depo_yaz();
            progressbar();
            numericupdown_value();

            string[] yakit_turleri = { "Benzin (95)", "Benzin (97)", "Dizel", "Euro Dizel", "LPG" };

             comboBox1.Items.AddRange(yakit_turleri); // Burasý Satýþ yap kýsmýnda hangi yakýtý seçebileceðimizi seçerken kullandýðýmýz kýsým. Dýþarýdan Veri giriþi Yapýlmamasý comboBox'ýn DropDownStyle özelliðini DropDownList yapýyoruz.

            // Satýþ yap kýsmýndaki sayýsal arttýrma kýsmýný seçili olma durumunu kaldýrdýk.
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            // Virgülden sonra ne kadar görüneceði kýsmý
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            // Satýþ yap kýsmýndaki arttýrma deðerini ayarlýyoruz.(M double'da hata olmasýn diye.)
            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;

            // Dýþarýdan veri giriþini kapatýyoruz. 
            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        string[] depo_bilgileri;
        private void button1_Click(object sender, EventArgs e)
        {
            stockStore();
        }
        private void stockStore()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=localhost; Database=master; Trusted_Connection=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand Command;
            String sql;
            try
            {
                double yedek = Convert.ToDouble(textBox1.Text);
                E_benzin95 = (float)(yedek);
                if (maksimumDepoBoyutu < D_benzin95 + E_benzin95 || E_benzin95 <= 0)
                    textBox1.Text = "Hata!";

                else
                {
                    float value = D_benzin95 + E_benzin95;
                    sql = "UPDATE YAKIT SET stock = '" + value + "' WHERE id = 1";
                    Command = new SqlCommand(sql, cnn);
                    Command.ExecuteNonQuery();
                    textBox1.Text = "";
                }
            }
            catch (Exception)
            {


            }
            try
            {
                double yedek = Convert.ToDouble(textBox2.Text);
                E_benzin97 = (float)(yedek);
                if (maksimumDepoBoyutu < D_benzin97 + E_benzin97 || E_benzin97 <= 0)
                    textBox2.Text = "Hata!";

                else
                {
                    float value = D_benzin97 + E_benzin97;
                    sql = "UPDATE YAKIT SET stock = '" + value + "' WHERE id = 2";
                    Command = new SqlCommand(sql, cnn);
                    Command.ExecuteNonQuery();
                    textBox2.Text = "";
                }
            }
            catch (Exception)
            {

            }
            try
            {
                double yedek = Convert.ToDouble(textBox3.Text);
                E_dizel = (float)(yedek);
                if (maksimumDepoBoyutu < D_dizel + E_dizel || E_dizel <= 0)
                    textBox3.Text = "Hata!";

                else
                {
                    float value = D_dizel + E_dizel;
                    sql = "UPDATE YAKIT SET stock = '" + value + "' WHERE id = 3";
                    Command = new SqlCommand(sql, cnn);
                    Command.ExecuteNonQuery();
                    textBox3.Text = "";
                }
            }
            catch (Exception)
            {

            }
            try
            {
                double yedek = Convert.ToDouble(textBox4.Text);
                E_eurodizel = (float)(yedek);
                if (maksimumDepoBoyutu < D_eurodizel + E_eurodizel || E_eurodizel <= 0)
                    textBox4.Text = "Hata!";

                else
                {
                    float value = D_eurodizel + E_eurodizel;
                    sql = "UPDATE YAKIT SET stock = '" + value + "' WHERE id = 4";
                    Command = new SqlCommand(sql, cnn);
                    Command.ExecuteNonQuery();
                    textBox4.Text = "";
                }
            }
            catch (Exception)
            {


            }
            try
            {
                double yedek = Convert.ToDouble(textBox5.Text);
                E_lpg = (float)(yedek);
                if (maksimumDepoBoyutu < D_lpg + E_lpg || E_lpg <= 0)
                    textBox5.Text = "Hata!";

                else
                {
                    float value = D_lpg + E_lpg;
                    sql = "UPDATE YAKIT SET stock = '" + value + "' WHERE id = 5";
                    Command = new SqlCommand(sql, cnn);
                    Command.ExecuteNonQuery();
                    textBox5.Text = "";
                }
            }
            catch (Exception)
            {


            }
            //Ekleme yapýldýkdan sonra database'e ekleme iþlemi üzerine yazýyor. Önceki bilgiler gidiyor.

            getData();
            depo_yaz();
            progressbar();
            numericupdown_value();
        }
    }
}