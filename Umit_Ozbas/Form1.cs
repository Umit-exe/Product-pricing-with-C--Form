using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umit_Ozbas
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
        
        public class dugum
        {
            public int _code;
            public string _name;
            public int _price;
            public dugum next;
            public dugum before;
        }

        static int counter;
        dugum ilk = null;
        dugum son = null;

        private void button1_Click(object sender, EventArgs e)//DÜĞÜM EKLEME
        {
            dugum yeni = new dugum();
            dugum temp = ilk;
            if((textBox1.Text=="")|| (textBox2.Text =="")||(textBox3.Text==""))
            {
                MessageBox.Show("Ürün Kodu, Adı veya Fiyat Bilgisi Boş Bırakılamaz!");
            }
            else
            {
                if (ilk == null)
                {
                    yeni._code = Convert.ToInt32(textBox1.Text);
                    yeni._name = textBox2.Text;
                    yeni._price = Convert.ToInt32(textBox3.Text);
                    ilk = yeni;
                    son = ilk;
                    ilk.before = null;
                    son.next = null;
                    counter++;//ÜRÜN SAYACI
                }
                else
                {
                    while (temp!=null)
                    {
                        if(temp._code != Convert.ToInt32(textBox1.Text))
                        {
                            temp = temp.next;
                            if (temp == null)
                            {
                                yeni._code = Convert.ToInt32(textBox1.Text);
                                yeni._name = textBox2.Text;
                                yeni._price = Convert.ToInt32(textBox3.Text);
                                son.next = yeni;
                                yeni.before = son;
                                son = yeni;
                                son.next = null;
                                counter++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Aynı Kayıttan Var");
                            break;
                        }
                    }
                }
            }
        }
        public void urunleri_listele (dugum ilk)
        {
            while (ilk != null)
            {
                dataGridView1.Rows.Add(ilk._code, ilk._name, ilk._price);
                ilk = ilk.next;
            }
        }
        private void button6_Click(object sender, EventArgs e)//LİSTELEME
        {
            dataGridView1.Rows.Clear();//DATAGRİDİ TEMİZLİYOR
            urunleri_listele(ilk);
        }

        private void button2_Click(object sender, EventArgs e)//SİLİNECEK KAYIT BULUNUYOR
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Kod Kısmı Boş Bırakılamaz");
            }
            else
            {
                if (counter == 0)
                {
                    MessageBox.Show("Hiç Ürün Yok");
                }
                dugum temp = ilk;
                while (temp != null)
                {
                    if (temp._code != Convert.ToInt32(textBox4.Text)) {
                        temp = temp.next;
                        if (temp == null)
                        {
                            MessageBox.Show(textBox4.Text + " Kodlu Ürün Bulunamadı");
                            textBox4.Text = "";
                        }
                    }
                    else
                    {
                        textBox4.Text = temp._code.ToString();
                        textBox5.Text = temp._name.ToString();
                        textBox6.Text = temp._price.ToString();
                        break;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Silinecek Ürün Kodunu Giriniz!");
            }
            else
            {
                if (counter > 0)
                {
                    int code = Convert.ToInt32(textBox4.Text);
                    dugum silinecek = ilk;
                    while (silinecek._code != code)
                    {
                        silinecek = silinecek.next;
                        if (silinecek == null)
                        {
                            MessageBox.Show("Kayıt Yok");
                            goto git;
                        }
                    }
                    if (silinecek == ilk)
                    {
                        ilk = silinecek.next;
                    }
                    else
                    {
                        silinecek.before.next = silinecek.next;
                    }
                    if (silinecek == son)
                    {
                        son = silinecek.before;
                    }
                    else
                    {
                        silinecek.next.before = silinecek.before;
                    }
                    MessageBox.Show("Ürün Silindi!");
                    counter--;
                }
                else
                {
                    MessageBox.Show("Silecek Öge Kalmadı");
                }
            git:;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Kod Kısmı Boş");
            }
            else
            {
                if (counter == 0)
                {
                    MessageBox.Show("Hiç Ürün Yok");
                }
                dugum temp = ilk;
                while (temp != null)
                {
                    if (temp._code != Convert.ToInt32(textBox7.Text))
                    {
                        temp = temp.next;
                        if (temp == null)
                        {
                            MessageBox.Show(textBox7.Text + " Kodlu Ürün Bulunamadı.");
                            textBox7.Text = "";
                        }
                    }
                    else
                    {
                        textBox7.Text = temp._code.ToString();
                        textBox8.Text = temp._name.ToString();
                        textBox9.Text = temp._price.ToString();
                        break;
                    }
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dugum temp = ilk;
            if ((textBox7.Text == "") || (textBox8.Text == "") || (textBox9.Text == ""))
            {
                MessageBox.Show("Ürün Kodu, Adı veya Fiyat bilgisi Boş!");
            }
            else
            {
                while (temp != null)
                {
                    if (temp._code != Convert.ToInt32(textBox7.Text))
                    {
                        temp = temp.next;
                        if (temp == null)
                        {
                            MessageBox.Show("Ürün Bulunamadı!");
                            goto git;
                        }
                    }
                    else
                    {
                        temp._price = Convert.ToInt32(textBox9.Text);
                        MessageBox.Show("Fiyat Güncellendi!");
                        goto git;
                    }
                }
            git:;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
