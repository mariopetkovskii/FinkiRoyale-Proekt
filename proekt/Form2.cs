using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proekt
{


    public partial class form2 : Form
    {

        public global globalna;// klasa global vo koja ima samo eden parametar sostojba vo koja se cuva vkupnata sostojba na pari
        public int sostojba { get; set; }
        public int[] color = new int[2];// cuva vlog za crno ili crveno, 0 ako nema vlog
        public int[] rows = new int[3];// cuva vlog za redovite 1,2 i 3, 0 ako nema vlog
        public int[] nizaRange = new int[5];// cuva vlog za prvite 12, vtorite 12, tretite 12, prvite 18, vtorite 18 broevi, 0 ako nema vlog
        public int[] parnost = new int[2];// cuva vlog za paren ili neparen, 0 ako nema vlog
        List<Button> buttons;// cuva lista na site vlogovi odnosno buttoni na koi ima staveno vlog
        List<Button> results;// cuva lista od site rezultati dobieni od vrtenjata
        public int[] niza = new int[37];// cuva vlog za broevite od 0 do 37, 0 ako nema vlog
        public int timeleft;
        public int vkupnoVlog = 0;


        public form2()
        {
            globalna = new global(0);
            InitializeComponent();
            DoubleBuffered = true;
            buttons = new List<Button>();
            results = new List<Button>();
            timeleft = 30;
            timer1.Start();
            timer2.Start();

            initArrays();

        }

        public void initArrays()
        {
            for (int i = 0; i < 37; i++)
            {
                niza[i] = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                rows[i] = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                nizaRange[i] = 0;
            }
            for (int i = 0; i < 2; i++)
            {
                color[i] = 0;
                parnost[i] = 0;
            }
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            generateRandom();
            results.Add(btnResult);
            shiftResults();
            int vkupno = 0;
            calculateWin(vkupno);
            removeVlogs(vkupno);
        }

        public void generateRandom()
        {
            Random random = new Random();
            for (int i = 0; i < 25; i++)
            {

                int number = random.Next(0, 37);
                if (number == 0)
                {
                    btnResult.Text = number.ToString();
                    btnResult.BackColor = Color.ForestGreen;
                }
                else if (number > 0 && number <= 10)
                {
                    if (number % 2 == 0)
                    {
                        btnResult.Text = number.ToString();
                        btnResult.BackColor = Color.Black;
                    }
                    else
                    {
                        btnResult.Text = number.ToString();
                        btnResult.BackColor = Color.Maroon;
                    }
                }
                else if (number > 10 && number < 19)
                {
                    if (number % 2 == 0)
                    {
                        btnResult.Text = number.ToString();
                        btnResult.BackColor = Color.Maroon;
                    }
                    else
                    {
                        btnResult.Text = number.ToString();
                        btnResult.BackColor = Color.Black;
                    }
                }
                else if (number > 19 && number <= 28)
                {
                    if (number % 2 == 0)
                    {
                        btnResult.Text = number.ToString();
                        btnResult.BackColor = Color.Black;
                    }
                    else
                    {
                        btnResult.Text = number.ToString();
                        btnResult.BackColor = Color.Maroon;
                    }
                }
                else if (number > 28 && number <= 36)
                {
                    if (number % 2 == 0)
                    {
                        btnResult.Text = number.ToString();
                        btnResult.BackColor = Color.Maroon;
                    }
                    else
                    {
                        btnResult.Text = number.ToString();
                        btnResult.BackColor = Color.Black;
                    }


                }


                System.Threading.Thread.Sleep(200);
                btnResult.Refresh();

            }
        }

        public void calculateWin(int vkupno)
        {

            for (int i = 0; i < color.Length; i++)
            {
                if (btnResult.BackColor == Color.Maroon)
                {
                    if (color[0] != 0)
                    {
                        vkupno += color[0] * 2;
                        tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (color[0] * 2)).ToString();
                        color[0] = 0;
                    }
                }
                else if (btnResult.BackColor == Color.Black)
                {
                    if (color[1] != 0)
                    {
                        vkupno += color[1] * 2;
                        tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (color[1] * 2)).ToString();
                        color[1] = 0;
                    }
                }

            }

            if (Convert.ToInt32(btnResult.Text) > 0 && Convert.ToInt32(btnResult.Text) < 13)
            {
                if (nizaRange[0] != 0)
                {
                    vkupno += nizaRange[0] * 3;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (nizaRange[0] * 3)).ToString();
                    nizaRange[0] = 0;
                }
            }

            if (Convert.ToInt32(btnResult.Text) > 12 && Convert.ToInt32(btnResult.Text) < 25)
            {
                if (nizaRange[1] != 0)
                {
                    vkupno += nizaRange[1] * 3;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (nizaRange[1] * 3)).ToString();
                    nizaRange[1] = 0;
                }
            }


            if (Convert.ToInt32(btnResult.Text) > 24 && Convert.ToInt32(btnResult.Text) < 37)
            {
                if (nizaRange[2] != 0)
                {
                    vkupno += nizaRange[2] * 3;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (nizaRange[2] * 3)).ToString();
                    nizaRange[2] = 0;
                }
            }

            if (Convert.ToInt32(btnResult.Text) > 0 && Convert.ToInt32(btnResult.Text) < 19)
            {
                if (nizaRange[3] != 0)
                {
                    vkupno += nizaRange[3] * 2;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (nizaRange[3] * 2)).ToString();
                    nizaRange[3] = 0;
                }
            }


            if (Convert.ToInt32(btnResult.Text) > 18 && Convert.ToInt32(btnResult.Text) < 37)
            {
                if (nizaRange[4] != 0)
                {
                    vkupno += nizaRange[4] * 2;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (nizaRange[4] * 2)).ToString();
                    nizaRange[4] = 0;
                }
            }


            if (Convert.ToInt32(btnResult.Text) % 2 == 0)
            {
                if (parnost[0] != 0)
                {
                    vkupno += parnost[0] * 2;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (parnost[0] * 2)).ToString();
                    parnost[0] = 0;
                }
            }

            if (Convert.ToInt32(btnResult.Text) % 2 != 0)
            {
                if (parnost[1] != 0)
                {
                    vkupno += parnost[1] * 2;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (parnost[1] * 2)).ToString();
                    parnost[1] = 0;
                }
            }


            if (Convert.ToInt32(btnResult.Text) % 3 == 0)
            {
                if (rows[0] != 0)
                {
                    vkupno += rows[0] * 3;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (rows[0] * 3)).ToString();
                    rows[0] = 0;
                }
            }

            if (Convert.ToInt32(btnResult.Text) % 3 == 1)
            {
                if (rows[2] != 0)
                {
                    vkupno += rows[2] * 3;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (rows[2] * 3)).ToString();
                    rows[2] = 0;
                }
            }

            if (Convert.ToInt32(btnResult.Text) % 3 == 2)
            {
                if (rows[1] != 0)
                {
                    vkupno += rows[1] * 3;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (rows[1] * 3)).ToString();
                    rows[1] = 0;
                }
            }


            if (niza[Convert.ToInt32(btnResult.Text)] != 0)
            {
                vkupno += niza[Convert.ToInt32(btnResult.Text)] * 36;
                tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + (niza[Convert.ToInt32(btnResult.Text)] * 36)).ToString();
                for (int i = 0; i < 37; i++)
                {
                    niza[i] = 0;
                }

            }

            labelDobivka.Text = "+ " + vkupno.ToString();
            panel3.Visible = true;
        }


        public void shiftResults()
        {
            if (results.Count == 1)
            {
                btnlast1.Text = results.ElementAt(0).Text;
                btnlast1.BackColor = results.ElementAt(0).BackColor;
            }
            else if (results.Count == 2)
            {
                btnlast2.Text = btnlast1.Text;
                btnlast2.BackColor = btnlast1.BackColor;
                btnlast1.Text = results.ElementAt(1).Text;
                btnlast1.BackColor = results.ElementAt(1).BackColor;
            }
            else if (results.Count == 3)
            {
                btnlast3.Text = btnlast2.Text;
                btnlast3.BackColor = btnlast2.BackColor;
                btnlast2.Text = btnlast1.Text;
                btnlast2.BackColor = btnlast1.BackColor;
                btnlast1.Text = results.ElementAt(2).Text;
                btnlast1.BackColor = results.ElementAt(2).BackColor;
            }
            else if (results.Count == 4)
            {
                btnlast4.Text = btnlast3.Text;
                btnlast4.BackColor = btnlast3.BackColor;
                btnlast3.Text = btnlast2.Text;
                btnlast3.BackColor = btnlast2.BackColor;
                btnlast2.Text = btnlast1.Text;
                btnlast2.BackColor = btnlast1.BackColor;
                btnlast1.Text = results.ElementAt(3).Text;
                btnlast1.BackColor = results.ElementAt(3).BackColor;
            }
            else if (results.Count == 5)
            {
                btnlast5.Text = btnlast4.Text;
                btnlast5.BackColor = btnlast4.BackColor;
                btnlast4.Text = btnlast3.Text;
                btnlast4.BackColor = btnlast3.BackColor;
                btnlast3.Text = btnlast2.Text;
                btnlast3.BackColor = btnlast2.BackColor;
                btnlast2.Text = btnlast1.Text;
                btnlast2.BackColor = btnlast1.BackColor;
                btnlast1.Text = results.ElementAt(4).Text;
                btnlast1.BackColor = results.ElementAt(4).BackColor;
            }
            else
            {
                btnlast5.Text = btnlast4.Text;
                btnlast5.BackColor = btnlast4.BackColor;
                btnlast4.Text = btnlast3.Text;
                btnlast4.BackColor = btnlast3.BackColor;
                btnlast3.Text = btnlast2.Text;
                btnlast3.BackColor = btnlast2.BackColor;
                btnlast2.Text = btnlast1.Text;
                btnlast2.BackColor = btnlast1.BackColor;
                btnlast1.Text = results.ElementAt(results.Count - 1).Text;
                btnlast1.BackColor = results.ElementAt(results.Count - 1).BackColor;
            }
        }

        public void removeVlogs(int vkupno)
        {
            vkupnoVlog = 0;
            foreach (Button b in buttons)
            {
                b.BackgroundImage = null;
            }

            vkupno = 0;
            color[0] = 0;
            color[1] = 0;

            parnost[0] = 0;
            parnost[1] = 0;

            for (int i = 0; i < 37; i++)
            {
                niza[i] = 0;
            }

            for (int i = 0; i < 3; i++)
            {
                rows[i] = 0;
            }

            for (int i = 0; i < 5; i++)
            {
                nizaRange[i] = 0;
            }
        }





        private void btnCrveno_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btnCrveno.BackgroundImage == null)
                {
                    buttons.Add(btnCrveno);
                    ImaVlog red = new ImaVlog(Convert.ToInt32(nudVlog.Value), "crveno");
                    color[0] = red.vlog;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - color[0]).ToString();
                    btnCrveno.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btnCrveno);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + color[0]).ToString();
                    color[0] = 0;
                    btnCrveno.BackgroundImage = null;
                }
            }
        }

        private void btnCrno_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btnCrno.BackgroundImage == null)
                {
                    buttons.Add(btnCrno);
                    ImaVlog black = new ImaVlog(Convert.ToInt32(nudVlog.Value), "crno");
                    color[1] = black.vlog;
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - color[1]).ToString();
                    btnCrno.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btnCrno);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + color[1]).ToString();
                    color[1] = 0;
                    btnCrno.BackgroundImage = null;
                }
            }
        }

        private void btnParen_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btnParen.BackgroundImage == null)
                {
                    buttons.Add(btnParen);

                    parnost[0] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - parnost[0]).ToString();
                    btnParen.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btnParen);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + parnost[0]).ToString();
                    parnost[0] = 0;
                    btnParen.BackgroundImage = null;
                }
            }
        }

        private void btnNeparen_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btnNeparen.BackgroundImage == null)
                {
                    buttons.Add(btnNeparen);

                    parnost[1] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - parnost[1]).ToString();
                    btnNeparen.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btnNeparen);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + parnost[1]).ToString();
                    parnost[1] = 0;
                    btnNeparen.BackgroundImage = null;
                }
            }

        }

        private void btn1st12_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn1st12.BackgroundImage == null)
                {
                    buttons.Add(btn1st12);
                    nizaRange[0] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - nizaRange[0]).ToString();
                    btn1st12.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn1st12);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + nizaRange[0]).ToString();
                    nizaRange[0] = 0;
                    btn1st12.BackgroundImage = null;
                }
            }
        }

        private void btn2nd12_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn2nd12.BackgroundImage == null)
                {
                    buttons.Add(btn2nd12);
                    nizaRange[1] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - nizaRange[1]).ToString();
                    btn2nd12.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn2nd12);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + nizaRange[1]).ToString();
                    nizaRange[1] = 0;
                    btn2nd12.BackgroundImage = null;
                }
            }



        }

        private void btn3rd12_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn3rd12.BackgroundImage == null)
                {
                    buttons.Add(btn3rd12);
                    nizaRange[2] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - nizaRange[2]).ToString();
                    btn3rd12.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn3rd12);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + nizaRange[2]).ToString();
                    nizaRange[2] = 0;
                    btn3rd12.BackgroundImage = null;
                }
            }
        }

        private void btn1st18_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn1st18.BackgroundImage == null)
                {
                    buttons.Add(btn1st18);
                    nizaRange[3] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - nizaRange[3]).ToString();
                    btn1st18.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn1st18);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + nizaRange[3]).ToString();
                    nizaRange[3] = 0;
                    btn1st18.BackgroundImage = null;
                }
            }
        }

        private void btn2nd18_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn2nd18.BackgroundImage == null)
                {
                    buttons.Add(btn2nd18);
                    nizaRange[4] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - nizaRange[4]).ToString();
                    btn2nd18.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn2nd18);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + nizaRange[4]).ToString();
                    nizaRange[4] = 0;
                    btn2nd18.BackgroundImage = null;
                }
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn0.BackgroundImage == null)
                {
                    buttons.Add(btn0);
                    niza[0] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[0]).ToString();
                    btn0.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn0);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[0]).ToString();
                    niza[0] = 0;
                    btn0.BackgroundImage = null;
                }
            }
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn1.BackgroundImage == null)
                {
                    buttons.Add(btn1);
                    niza[1] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[1]).ToString();
                    btn1.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn1);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[1]).ToString();
                    niza[1] = 0;
                    btn1.BackgroundImage = null;
                }
            }
        }


        private void btn2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn2.BackgroundImage == null)
                {
                    buttons.Add(btn2);
                    niza[2] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[2]).ToString();
                    btn2.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn2);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[2]).ToString();
                    niza[2] = 0;
                    btn2.BackgroundImage = null;
                }
            }
        }


        private void btn3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn3.BackgroundImage == null)
                {
                    buttons.Add(btn3);
                    niza[3] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[3]).ToString();
                    btn3.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn3);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[3]).ToString();
                    niza[3] = 0;
                    btn3.BackgroundImage = null;
                }
            }
        }


        private void btn4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn4.BackgroundImage == null)
                {
                    buttons.Add(btn4);
                    niza[4] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[4]).ToString();
                    btn4.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn4);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[4]).ToString();
                    niza[4] = 0;
                    btn4.BackgroundImage = null;
                }
            }
        }


        private void btn5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn5.BackgroundImage == null)
                {
                    buttons.Add(btn5);
                    niza[5] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[5]).ToString();
                    btn5.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn5);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[5]).ToString();
                    niza[5] = 0;
                    btn5.BackgroundImage = null;
                }
            }
        }


        private void btn6_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn6.BackgroundImage == null)
                {
                    buttons.Add(btn6);
                    niza[6] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[6]).ToString();
                    btn6.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn6);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[6]).ToString();
                    niza[6] = 0;
                    btn6.BackgroundImage = null;
                }
            }
        }


        private void btn7_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn7.BackgroundImage == null)
                {
                    buttons.Add(btn7);
                    niza[7] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[7]).ToString();
                    btn7.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn7);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[7]).ToString();
                    niza[7] = 0;
                    btn7.BackgroundImage = null;
                }
            }
        }


        private void btn8_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn8.BackgroundImage == null)
                {
                    buttons.Add(btn8);
                    niza[8] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[8]).ToString();
                    btn8.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn8);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[8]).ToString();
                    niza[8] = 0;
                    btn8.BackgroundImage = null;
                }
            }
        }


        private void btn9_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn9.BackgroundImage == null)
                {
                    buttons.Add(btn9);
                    niza[9] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[9]).ToString();
                    btn9.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn9);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[9]).ToString();
                    niza[9] = 0;
                    btn9.BackgroundImage = null;
                }
            }
        }


        private void btn10_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn10.BackgroundImage == null)
                {
                    buttons.Add(btn10);
                    niza[10] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[10]).ToString();
                    btn10.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn10);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[10]).ToString();
                    niza[10] = 0;
                    btn10.BackgroundImage = null;
                }
            }
        }


        private void btn11_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn11.BackgroundImage == null)
                {
                    buttons.Add(btn11);
                    niza[11] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[11]).ToString();
                    btn11.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn11);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[11]).ToString();
                    niza[11] = 0;
                    btn11.BackgroundImage = null;
                }
            }
        }


        private void btn12_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn12.BackgroundImage == null)
                {
                    buttons.Add(btn12);
                    niza[12] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[12]).ToString();
                    btn12.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn12);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[12]).ToString();
                    niza[12] = 0;
                    btn12.BackgroundImage = null;
                }
            }
        }


        private void btn13_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn13.BackgroundImage == null)
                {
                    buttons.Add(btn13);
                    niza[13] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[13]).ToString();
                    btn13.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn13);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[13]).ToString();
                    niza[13] = 0;
                    btn13.BackgroundImage = null;
                }
            }
        }


        private void btn14_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn14.BackgroundImage == null)
                {
                    buttons.Add(btn14);
                    niza[14] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[14]).ToString();
                    btn14.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn14);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[14]).ToString();
                    niza[14] = 0;
                    btn14.BackgroundImage = null;
                }
            }
        }


        private void btn15_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn15.BackgroundImage == null)
                {
                    buttons.Add(btn15);
                    niza[15] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[15]).ToString();
                    btn15.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn15);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[15]).ToString();
                    niza[15] = 0;
                    btn15.BackgroundImage = null;
                }
            }
        }


        private void btn16_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn16.BackgroundImage == null)
                {
                    buttons.Add(btn16);
                    niza[16] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[16]).ToString();
                    btn16.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn16);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[16]).ToString();
                    niza[16] = 0;
                    btn16.BackgroundImage = null;
                }
            }
        }


        private void btn17_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn17.BackgroundImage == null)
                {
                    buttons.Add(btn17);
                    niza[17] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[17]).ToString();
                    btn17.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn17);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[17]).ToString();
                    niza[17] = 0;
                    btn17.BackgroundImage = null;
                }
            }
        }


        private void btn18_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn18.BackgroundImage == null)
                {
                    buttons.Add(btn18);
                    niza[18] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[18]).ToString();
                    btn18.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn18);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[18]).ToString();
                    niza[18] = 0;
                    btn18.BackgroundImage = null;
                }
            }
        }


        private void btn19_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn19.BackgroundImage == null)
                {
                    buttons.Add(btn19);
                    niza[19] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[19]).ToString();
                    btn19.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn19);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[19]).ToString();
                    niza[19] = 0;
                    btn19.BackgroundImage = null;
                }
            }
        }


        private void btn20_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn20.BackgroundImage == null)
                {
                    buttons.Add(btn20);
                    niza[20] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[20]).ToString();
                    btn20.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn20);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[20]).ToString();
                    niza[20] = 0;
                    btn20.BackgroundImage = null;
                }
            }
        }


        private void btn21_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn21.BackgroundImage == null)
                {
                    buttons.Add(btn21);
                    niza[21] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[21]).ToString();
                    btn21.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn21);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[21]).ToString();
                    niza[21] = 0;
                    btn21.BackgroundImage = null;
                }
            }
        }


        private void btn22_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn22.BackgroundImage == null)
                {
                    buttons.Add(btn22);
                    niza[22] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[22]).ToString();
                    btn22.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn22);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[22]).ToString();
                    niza[22] = 0;
                    btn22.BackgroundImage = null;
                }
            }
        }


        private void btn23_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn23.BackgroundImage == null)
                {
                    buttons.Add(btn23);
                    niza[23] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[23]).ToString();
                    btn23.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn23);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[23]).ToString();
                    niza[23] = 0;
                    btn23.BackgroundImage = null;
                }
            }
        }


        private void btn24_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn24.BackgroundImage == null)
                {
                    buttons.Add(btn24);
                    niza[24] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[24]).ToString();
                    btn24.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn24);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[24]).ToString();
                    niza[24] = 0;
                    btn24.BackgroundImage = null;
                }
            }
        }


        private void btn25_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn25.BackgroundImage == null)
                {
                    buttons.Add(btn25);
                    niza[25] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[25]).ToString();
                    btn25.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn25);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[25]).ToString();
                    niza[25] = 0;
                    btn25.BackgroundImage = null;
                }
            }
        }


        private void btn26_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn26.BackgroundImage == null)
                {
                    buttons.Add(btn26);
                    niza[26] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[26]).ToString();
                    btn26.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn26);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[26]).ToString();
                    niza[26] = 0;
                    btn26.BackgroundImage = null;
                }
            }
        }


        private void btn27_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn27.BackgroundImage == null)
                {
                    buttons.Add(btn27);
                    niza[27] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[27]).ToString();
                    btn27.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn27);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[27]).ToString();
                    niza[27] = 0;
                    btn27.BackgroundImage = null;
                }
            }
        }


        private void btn28_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn28.BackgroundImage == null)
                {
                    buttons.Add(btn28);
                    niza[28] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[28]).ToString();
                    btn28.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn28);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[28]).ToString();
                    niza[28] = 0;
                    btn28.BackgroundImage = null;
                }
            }
        }


        private void btn29_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn29.BackgroundImage == null)
                {
                    buttons.Add(btn29);
                    niza[29] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[29]).ToString();
                    btn29.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn29);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[29]).ToString();
                    niza[29] = 0;
                    btn29.BackgroundImage = null;
                }
            }
        }


        private void btn30_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn30.BackgroundImage == null)
                {
                    buttons.Add(btn30);
                    niza[30] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[30]).ToString();
                    btn30.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn30);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[30]).ToString();
                    niza[30] = 0;
                    btn30.BackgroundImage = null;
                }
            }
        }


        private void btn31_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn31.BackgroundImage == null)
                {
                    buttons.Add(btn31);
                    niza[31] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[31]).ToString();
                    btn31.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn31);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[31]).ToString();
                    niza[31] = 0;
                    btn31.BackgroundImage = null;
                }
            }
        }


        private void btn32_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn32.BackgroundImage == null)
                {
                    buttons.Add(btn32);
                    niza[32] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[32]).ToString();
                    btn32.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn32);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[32]).ToString();
                    niza[32] = 0;
                    btn32.BackgroundImage = null;
                }
            }
        }


        private void btn33_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn33.BackgroundImage == null)
                {
                    buttons.Add(btn33);
                    niza[33] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[33]).ToString();
                    btn33.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn33);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[33]).ToString();
                    niza[33] = 0;
                    btn33.BackgroundImage = null;
                }
            }
        }


        private void btn34_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn34.BackgroundImage == null)
                {
                    buttons.Add(btn34);
                    niza[34] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[34]).ToString();
                    btn34.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn34);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[34]).ToString();
                    niza[34] = 0;
                    btn34.BackgroundImage = null;
                }
            }
        }


        private void btn35_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn35.BackgroundImage == null)
                {
                    buttons.Add(btn35);
                    niza[35] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[35]).ToString();
                    btn35.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn35);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[35]).ToString();
                    niza[35] = 0;
                    btn35.BackgroundImage = null;
                }
            }
        }


        private void btn36_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn36.BackgroundImage == null)
                {
                    buttons.Add(btn36);
                    niza[36] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - niza[36]).ToString();
                    btn36.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn36);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + niza[36]).ToString();
                    niza[36] = 0;
                    btn36.BackgroundImage = null;
                }
            }
        }

        private void btn1red_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn1red.BackgroundImage == null)
                {
                    buttons.Add(btn1red);
                    rows[0] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - rows[0]).ToString();
                    btn1red.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn1red);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + rows[0]).ToString();
                    rows[0] = 0;
                    btn1red.BackgroundImage = null;
                }
            }
        }

        private void btn2red_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn2red.BackgroundImage == null)
                {
                    buttons.Add(btn2red);
                    rows[1] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - rows[1]).ToString();
                    btn2red.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn1red);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + rows[1]).ToString();
                    rows[1] = 0;
                    btn2red.BackgroundImage = null;
                }
            }
        }

        private void btn3red_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbSostojba.Text) < Convert.ToInt32(nudVlog.Value))
            {
                MessageBox.Show("Немате доволно пари");
            }
            else
            {
                if (btn3red.BackgroundImage == null)
                {
                    buttons.Add(btn3red);
                    rows[2] = Convert.ToInt32(nudVlog.Value);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) - rows[2]).ToString();
                    btn3red.BackgroundImage = new Bitmap(proekt.Properties.Resources.zeton);
                }
                else
                {
                    buttons.Remove(btn3red);
                    tbSostojba.Text = (Convert.ToInt32(tbSostojba.Text) + rows[2]).ToString();
                    rows[2] = 0;
                    btn3red.BackgroundImage = null;
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            panel2.Width += 1;
            if (panel2.Width > 714)
            {

                timer1.Stop();
                timer1.Start();
                panel2.Width = 5;
                timeleft = 31;
                timer2.Start();
                button2.PerformClick();
                label4.Visible = false;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timeleft -= 1;
            label3.Text = string.Format("{0}", timeleft);
            if(timeleft == 27)
            {
                panel3.Visible = false;
                lbVkupno.Text = "+ "+0.ToString();
            }
            if (timeleft == 0)
            {
                timer2.Stop();
                label4.Visible = true;

            }
        }
        SoundPlayer music = new SoundPlayer();
        Boolean audio = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            tbSostojba.Text = sostojba.ToString();

            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = BackColor;
            button2.UseVisualStyleBackColor = true;

            SoundPlayer song = new SoundPlayer("song.wav");
            music = song;
            music.PlayLooping();

            
        }

        

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (audio)
            {
                music.Stop();
                audio = false;
            }
            else
            {
                music.PlayLooping();
                audio = true;
            }
        }

        private void btnNazad_Click(object sender, EventArgs e)
        {
            music.Stop();
            globalna.sostojba = Convert.ToInt32(tbSostojba.Text);
            DialogResult = DialogResult.Cancel;
        }


       
    }
}
