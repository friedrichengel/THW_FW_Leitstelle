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

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        StreamWriter log = new System.IO.StreamWriter("fwd.log", true);
        fahrzeug fzg_1 = new fahrzeug();
        fahrzeug fzg_2 = new fahrzeug();
        fahrzeug fzg_3 = new fahrzeug();
        fahrzeug fzg_4 = new fahrzeug();

        public Form1()
        {
            InitializeComponent();
            fzg_1.zustand = 0;
            fzg_2.zustand = 0;
            fzg_3.zustand = 0;
            fzg_4.zustand = 0;
            fzg_1.zeit_1 = 300;
            fzg_1.zeit_2 = 900;
            fzg_1.zeit_3 = 1200;
            fzg_1.zeit_4 = 900;
            fzg_2.zeit_1 = 300;
            fzg_2.zeit_2 = 900;
            fzg_2.zeit_3 = 1200;
            fzg_2.zeit_4 = 900;
            fzg_3.zeit_1 = 300;
            fzg_3.zeit_2 = 900;
            fzg_3.zeit_3 = 1200;
            fzg_3.zeit_4 = 900;
            fzg_4.zeit_1 = 300;
            fzg_4.zeit_2 = 900;
            fzg_4.zeit_3 = 1200;
            fzg_4.zeit_4 = 900;
            log.AutoFlush = true;
            log.WriteLine(DateTime.Now.ToShortTimeString() + " Programm gestartet");
        }

        private void fzg1_timer_Tick(object sender, EventArgs e)
        {
            int zeit_sec;
            int zeit_min;
            int zeit_hou;
            string zeit;

            fzg_1.timer_count = fzg_1.timer_count + 1;

            zeit_sec = (fzg_1.timer_count % 3600) % 60;
            zeit_min = (fzg_1.timer_count % 3600) / 60;
            zeit_hou = fzg_1.timer_count / 3600;

            zeit = zeit_hou.ToString("D2") + ":" + zeit_min.ToString("D2") + ":" + zeit_sec.ToString("D2");

            switch (fzg_1.zustand)
            {
                case 1: //Alamiert
                    fzg1_textBox_al.Text = zeit;
                    if (fzg_1.timer_count >= fzg_1.zeit_1)
                    {
                        fzg1_panel_al.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg1_panel_al.BackColor = Color.Lime;
                    }
                    fzg1_panel_ab.BackColor = Color.Gray;
                    fzg1_panel_ein.BackColor = Color.Gray;
                    fzg1_panel_eb.BackColor = Color.Gray;
                    fzg1_panel_br.BackColor = Color.Gray;
                    fzg1_textBox_ab.Text = "";
                    fzg1_textBox_ein.Text = "";
                    fzg1_textBox_eb.Text = "";
                    fzg1_textBox_br.Text = "";
                    break;
                case 2: //Abgemeldet
                    fzg1_textBox_ab.Text = zeit;
                    if (fzg_1.timer_count >= fzg_1.zeit_2)
                    {
                        fzg1_panel_ab.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg1_panel_ab.BackColor = Color.Lime;
                    }
                    fzg1_panel_ein.BackColor = Color.Gray;
                    fzg1_panel_eb.BackColor = Color.Gray;
                    fzg1_panel_br.BackColor = Color.Gray;
                    break;
                case 3: //Eingetroffen
                    fzg1_textBox_ein.Text = zeit;
                    if (fzg_1.timer_count >= fzg_1.zeit_3)
                    {
                        fzg1_panel_ein.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg1_panel_ein.BackColor = Color.Lime;
                    }
                    fzg1_panel_eb.BackColor = Color.Gray;
                    fzg1_panel_br.BackColor = Color.Gray;
                    break;
                case 4: //Einsatzbereit
                    fzg1_textBox_eb.Text = zeit;
                    if (fzg_1.timer_count >= fzg_1.zeit_4)
                    {
                        fzg1_panel_eb.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg1_panel_eb.BackColor = Color.Lime;
                    }
                    fzg1_panel_br.BackColor = Color.Gray;
                    break;
                case 5: //B-Raum
                    fzg1_textBox_br.Text = zeit;
                    fzg1_panel_br.BackColor = Color.Lime;
                    fzg1_panel_al.BackColor = Color.Gray;
                    fzg1_panel_ab.BackColor = Color.Gray;
                    fzg1_panel_ein.BackColor = Color.Gray;
                    fzg1_panel_eb.BackColor = Color.Gray;
                    fzg1_textBox_al.Text = "";
                    fzg1_textBox_ab.Text = "";
                    fzg1_textBox_ein.Text = "";
                    fzg1_textBox_eb.Text = "";
                    break;
            }
        }

        private void fzg1_button_al_Click(object sender, EventArgs e)
        { 
            if ((fzg1_timer.Enabled == true) && (fzg_1.zustand == 1))
            {
                fzg1_timer.Stop();
                fzg_1.zustand = 0;
            }
            else
            {
                fzg1_timer.Interval = 1000;
                fzg_1.timer_count = 0;
                fzg1_timer.Start();
                fzg_1.zustand = 1;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_1: Alarmiert " + fzg1_textBox_einsatz.Text);
            }
        }

        private void fzg1_button_ab_Click(object sender, EventArgs e)
        {
            if ((fzg1_timer.Enabled == true) && (fzg_1.zustand == 2))
            {
                fzg1_timer.Stop();
                fzg_1.zustand = 0;
            }
            else
            {
                fzg1_timer.Interval = 1000;
                fzg_1.timer_count = 0;
                fzg1_timer.Start();
                fzg_1.zustand = 2;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_1: Abmeldung " + fzg1_textBox_einsatz.Text);
            }
        }

        private void fzg1_button_ein_Click(object sender, EventArgs e)
        {
            if ((fzg1_timer.Enabled == true) && (fzg_1.zustand == 3))
            {
                fzg1_timer.Stop();
                fzg_1.zustand = 0;
            }
            else
            {
                fzg1_timer.Interval = 1000;
                fzg_1.timer_count = 0;
                fzg1_timer.Start();
                fzg_1.zustand = 3;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_1: Eintreffen " + fzg1_textBox_einsatz.Text);
            }
        }

        private void fzg1_button_eb_Click(object sender, EventArgs e)
        {
            if ((fzg1_timer.Enabled == true) && (fzg_1.zustand == 4))
            {
                fzg1_timer.Stop();
                fzg_1.zustand = 0;
            }
            else
            {
                fzg1_timer.Interval = 1000;
                fzg_1.timer_count = 0;
                fzg1_timer.Start();
                fzg_1.zustand = 4;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_1: Einsatzbereit " + fzg1_textBox_einsatz.Text);
            }
        }

        private void fzg1_button_br_Click(object sender, EventArgs e)
        {
            if ((fzg1_timer.Enabled == true) && (fzg_1.zustand == 5))
            {
                fzg1_timer.Stop();
                fzg_1.zustand = 0;
            }
            else
            {
                fzg1_timer.Interval = 1000;
                fzg_1.timer_count = 0;
                fzg1_timer.Start();
                fzg_1.zustand = 5;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_1: B-Raum " + fzg1_textBox_einsatz.Text);
            }
        }

        private void fzg2_button_al_Click(object sender, EventArgs e)
        {
            if ((fzg2_timer.Enabled == true) && (fzg_2.zustand == 1))
            {
                fzg2_timer.Stop();
                fzg_2.zustand = 0;
            }
            else
            {
                fzg2_timer.Interval = 1000;
                fzg_2.timer_count = 0;
                fzg2_timer.Start();
                fzg_2.zustand = 1;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_2: Alarmiert " + fzg2_textBox_einsatz.Text);
            }
        }

        private void fzg3_button_al_Click(object sender, EventArgs e)
        {
            if ((fzg3_timer.Enabled == true) && (fzg_3.zustand == 1))
            {
                fzg3_timer.Stop();
                fzg_3.zustand = 0;
            }
            else
            {
                fzg3_timer.Interval = 1000;
                fzg_3.timer_count = 0;
                fzg3_timer.Start();
                fzg_3.zustand = 1;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_3: Alarmiert " + fzg3_textBox_einsatz.Text);
            }
        }

        private void fzg4_button_al_Click(object sender, EventArgs e)
        {
            if ((fzg4_timer.Enabled == true) && (fzg_4.zustand == 1))
            {
                fzg4_timer.Stop();
                fzg_4.zustand = 0;
            }
            else
            {
                fzg4_timer.Interval = 1000;
                fzg_4.timer_count = 0;
                fzg4_timer.Start();
                fzg_4.zustand = 1;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_4: Alarmiert " + fzg4_textBox_einsatz.Text);
            }
        }

        private void fzg2_button_ab_Click(object sender, EventArgs e)
        {
            if ((fzg2_timer.Enabled == true) && (fzg_2.zustand == 2))
            {
                fzg2_timer.Stop();
                fzg_2.zustand = 0;
            }
            else
            {
                fzg2_timer.Interval = 1000;
                fzg_2.timer_count = 0;
                fzg2_timer.Start();
                fzg_2.zustand = 2;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_2: Abmeldung " + fzg2_textBox_einsatz.Text);
            }
        }

        private void fzg3_button_ab_Click(object sender, EventArgs e)
        {
            if ((fzg3_timer.Enabled == true) && (fzg_3.zustand == 2))
            {
                fzg3_timer.Stop();
                fzg_3.zustand = 0;
            }
            else
            {
                fzg3_timer.Interval = 1000;
                fzg_3.timer_count = 0;
                fzg3_timer.Start();
                fzg_3.zustand = 2;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_3: Abmeldung " + fzg3_textBox_einsatz.Text);
            }
        }

        private void fzg4_button_ab_Click(object sender, EventArgs e)
        {
            if ((fzg4_timer.Enabled == true) && (fzg_4.zustand == 2))
            {
                fzg4_timer.Stop();
                fzg_4.zustand = 0;
            }
            else
            {
                fzg4_timer.Interval = 1000;
                fzg_4.timer_count = 0;
                fzg4_timer.Start();
                fzg_4.zustand = 2;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_4: Abmeldung " + fzg4_textBox_einsatz.Text);
            }
        }

        private void fzg2_button_ein_Click(object sender, EventArgs e)
        {
            if ((fzg2_timer.Enabled == true) && (fzg_2.zustand == 3))
            {
                fzg2_timer.Stop();
                fzg_2.zustand = 0;
            }
            else
            {
                fzg2_timer.Interval = 1000;
                fzg_2.timer_count = 0;
                fzg2_timer.Start();
                fzg_2.zustand = 3;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_2: Eingetroffen " + fzg2_textBox_einsatz.Text);
            }
        }

        private void fzg3_button_ein_Click(object sender, EventArgs e)
        {
            if ((fzg3_timer.Enabled == true) && (fzg_3.zustand == 3))
            {
                fzg3_timer.Stop();
                fzg_3.zustand = 0;
            }
            else
            {
                fzg3_timer.Interval = 1000;
                fzg_3.timer_count = 0;
                fzg3_timer.Start();
                fzg_3.zustand = 3;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_3: Eingetroffen " + fzg3_textBox_einsatz.Text);
            }
        }

        private void fzg4_button_ein_Click(object sender, EventArgs e)
        {
            if ((fzg4_timer.Enabled == true) && (fzg_4.zustand == 3))
            {
                fzg4_timer.Stop();
                fzg_4.zustand = 0;
            }
            else
            {
                fzg4_timer.Interval = 1000;
                fzg_4.timer_count = 0;
                fzg4_timer.Start();
                fzg_4.zustand = 3;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_4: Eingetroffen " + fzg4_textBox_einsatz.Text);
            }
        }

        private void fzg2_button_eb_Click(object sender, EventArgs e)
        {
            if ((fzg2_timer.Enabled == true) && (fzg_2.zustand == 4))
            {
                fzg2_timer.Stop();
                fzg_2.zustand = 0;
            }
            else
            {
                fzg2_timer.Interval = 1000;
                fzg_2.timer_count = 0;
                fzg2_timer.Start();
                fzg_2.zustand = 4;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_2: Einsatzbereit " + fzg2_textBox_einsatz.Text);
            }
        }

        private void fzg3_button_eb_Click(object sender, EventArgs e)
        {
            if ((fzg3_timer.Enabled == true) && (fzg_3.zustand == 4))
            {
                fzg3_timer.Stop();
                fzg_3.zustand = 0;
            }
            else
            {
                fzg3_timer.Interval = 1000;
                fzg_3.timer_count = 0;
                fzg3_timer.Start();
                fzg_3.zustand = 4;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_3: Einsatzbereit " + fzg3_textBox_einsatz.Text);
            }
        }

        private void fzg4_button_eb_Click(object sender, EventArgs e)
        {
            if ((fzg4_timer.Enabled == true) && (fzg_4.zustand == 4))
            {
                fzg4_timer.Stop();
                fzg_4.zustand = 0;
            }
            else
            {
                fzg4_timer.Interval = 1000;
                fzg_4.timer_count = 0;
                fzg4_timer.Start();
                fzg_4.zustand = 4;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_4: Einsatzbereit " + fzg4_textBox_einsatz.Text);
            }
        }

        private void fzg2_button_br_Click(object sender, EventArgs e)
        {
            if ((fzg2_timer.Enabled == true) && (fzg_2.zustand == 5))
            {
                fzg2_timer.Stop();
                fzg_2.zustand = 0;
            }
            else
            {
                fzg2_timer.Interval = 1000;
                fzg_2.timer_count = 0;
                fzg2_timer.Start();
                fzg_2.zustand = 5;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_2: B-Raum " + fzg2_textBox_einsatz.Text);
            }
        }

        private void fzg3_button_br_Click(object sender, EventArgs e)
        {
            if ((fzg3_timer.Enabled == true) && (fzg_3.zustand == 5))
            {
                fzg3_timer.Stop();
                fzg_3.zustand = 0;
            }
            else
            {
                fzg3_timer.Interval = 1000;
                fzg_3.timer_count = 0;
                fzg3_timer.Start();
                fzg_3.zustand = 5;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_3: B-Raum " + fzg3_textBox_einsatz.Text);
            }
        }

        private void fzg4_button_br_Click(object sender, EventArgs e)
        {
            if ((fzg4_timer.Enabled == true) && (fzg_4.zustand == 5))
            {
                fzg4_timer.Stop();
                fzg_4.zustand = 0;
            }
            else
            {
                fzg4_timer.Interval = 1000;
                fzg_4.timer_count = 0;
                fzg4_timer.Start();
                fzg_4.zustand = 5;
                log.WriteLine(DateTime.Now.ToShortTimeString() + " Fzg_4: B-Raum " + fzg4_textBox_einsatz.Text);
            }
        }

        private void fzg2_timer_Tick(object sender, EventArgs e)
        {
            int zeit_sec;
            int zeit_min;
            int zeit_hou;
            string zeit;

            fzg_2.timer_count = fzg_2.timer_count + 1;

            zeit_sec = (fzg_2.timer_count % 3600) % 60;
            zeit_min = (fzg_2.timer_count % 3600) / 60;
            zeit_hou = fzg_2.timer_count / 3600;

            zeit = zeit_hou.ToString("D2") + ":" + zeit_min.ToString("D2") + ":" + zeit_sec.ToString("D2");

            switch (fzg_2.zustand)
            {
                case 1: //Alamiert
                    fzg2_textBox_al.Text = zeit;
                    if (fzg_2.timer_count >= fzg_2.zeit_1)
                    {
                        fzg2_panel_al.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg2_panel_al.BackColor = Color.Lime;
                    }
                    fzg2_panel_ab.BackColor = Color.Gray;
                    fzg2_panel_ein.BackColor = Color.Gray;
                    fzg2_panel_eb.BackColor = Color.Gray;
                    fzg2_panel_br.BackColor = Color.Gray;
                    fzg2_textBox_ab.Text = "";
                    fzg2_textBox_ein.Text = "";
                    fzg2_textBox_eb.Text = "";
                    fzg2_textBox_br.Text = "";
                    break;
                case 2: //Abgemeldet
                    fzg2_textBox_ab.Text = zeit;
                    if (fzg_2.timer_count >= fzg_2.zeit_2)
                    {
                        fzg2_panel_ab.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg2_panel_ab.BackColor = Color.Lime;
                    }
                    fzg2_panel_ein.BackColor = Color.Gray;
                    fzg2_panel_eb.BackColor = Color.Gray;
                    fzg2_panel_br.BackColor = Color.Gray;
                    break;
                case 3: //Eingetroffen
                    fzg2_textBox_ein.Text = zeit;
                    if (fzg_2.timer_count >= fzg_2.zeit_3)
                    {
                        fzg2_panel_ein.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg2_panel_ein.BackColor = Color.Lime;
                    }
                    fzg2_panel_eb.BackColor = Color.Gray;
                    fzg2_panel_br.BackColor = Color.Gray;
                    break;
                case 4: //Einsatzbereit
                    fzg2_textBox_eb.Text = zeit;
                    if (fzg_2.timer_count >= fzg_2.zeit_4)
                    {
                        fzg2_panel_eb.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg2_panel_eb.BackColor = Color.Lime;
                    }
                    fzg2_panel_br.BackColor = Color.Gray;
                    break;
                case 5: //B-Raum
                    fzg2_textBox_br.Text = zeit;
                    fzg2_panel_br.BackColor = Color.Lime;
                    fzg2_panel_al.BackColor = Color.Gray;
                    fzg2_panel_ab.BackColor = Color.Gray;
                    fzg2_panel_ein.BackColor = Color.Gray;
                    fzg2_panel_eb.BackColor = Color.Gray;
                    fzg2_textBox_al.Text = "";
                    fzg2_textBox_ab.Text = "";
                    fzg2_textBox_ein.Text = "";
                    fzg2_textBox_eb.Text = "";
                    break;
            }
        }

        private void fzg3_timer_Tick(object sender, EventArgs e)
        {
            int zeit_sec;
            int zeit_min;
            int zeit_hou;
            string zeit;

            fzg_3.timer_count = fzg_3.timer_count + 1;

            zeit_sec = (fzg_3.timer_count % 3600) % 60;
            zeit_min = (fzg_3.timer_count % 3600) / 60;
            zeit_hou = fzg_3.timer_count / 3600;

            zeit = zeit_hou.ToString("D2") + ":" + zeit_min.ToString("D2") + ":" + zeit_sec.ToString("D2");

            switch (fzg_3.zustand)
            {
                case 1: //Alamiert
                    fzg3_textBox_al.Text = zeit;
                    if (fzg_3.timer_count >= fzg_3.zeit_1)
                    {
                        fzg3_panel_al.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg3_panel_al.BackColor = Color.Lime;
                    }
                    fzg3_panel_ab.BackColor = Color.Gray;
                    fzg3_panel_ein.BackColor = Color.Gray;
                    fzg3_panel_eb.BackColor = Color.Gray;
                    fzg3_panel_br.BackColor = Color.Gray;
                    fzg3_textBox_ab.Text = "";
                    fzg3_textBox_ein.Text = "";
                    fzg3_textBox_eb.Text = "";
                    fzg3_textBox_br.Text = "";
                    break;
                case 2: //Abgemeldet
                   fzg3_textBox_ab.Text = zeit;
                    if (fzg_3.timer_count >= fzg_3.zeit_2)
                    {
                        fzg3_panel_ab.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg3_panel_ab.BackColor = Color.Lime;
                    }
                    fzg3_panel_ein.BackColor = Color.Gray;
                    fzg3_panel_eb.BackColor = Color.Gray;
                    fzg3_panel_br.BackColor = Color.Gray;
                    break;
                case 3: //Eingetroffen
                    fzg3_textBox_ein.Text = zeit;
                    if (fzg_3.timer_count >= fzg_3.zeit_3)
                    {
                        fzg3_panel_ein.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg3_panel_ein.BackColor = Color.Lime;
                    }
                    fzg3_panel_eb.BackColor = Color.Gray;
                    fzg3_panel_br.BackColor = Color.Gray;
                    break;
                case 4: //Einsatzbereit
                    fzg3_textBox_eb.Text = zeit;
                    if (fzg_3.timer_count >= fzg_3.zeit_4)
                    {
                        fzg3_panel_eb.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg3_panel_eb.BackColor = Color.Lime;
                    }
                    fzg3_panel_br.BackColor = Color.Gray;
                    break;
                case 5: //B-Raum
                    fzg3_textBox_br.Text = zeit;
                    fzg3_panel_br.BackColor = Color.Lime;
                    fzg3_panel_al.BackColor = Color.Gray;
                    fzg3_panel_ab.BackColor = Color.Gray;
                    fzg3_panel_ein.BackColor = Color.Gray;
                    fzg3_panel_eb.BackColor = Color.Gray;
                    fzg3_textBox_al.Text = "";
                    fzg3_textBox_ab.Text = "";
                    fzg3_textBox_ein.Text = "";
                    fzg3_textBox_eb.Text = "";
                    break;
            }
        }

        private void fzg4_timer_Tick(object sender, EventArgs e)
        {
            int zeit_sec;
            int zeit_min;
            int zeit_hou;
            string zeit;

            fzg_4.timer_count = fzg_4.timer_count + 1;

            zeit_sec = (fzg_4.timer_count % 3600) % 60;
            zeit_min = (fzg_4.timer_count % 3600) / 60;
            zeit_hou = fzg_4.timer_count / 3600;

            zeit = zeit_hou.ToString("D2") + ":" + zeit_min.ToString("D2") + ":" + zeit_sec.ToString("D2");

            switch (fzg_4.zustand)
            {
                case 1: //Alamiert
                    fzg4_textBox_al.Text = zeit;
                    if (fzg_4.timer_count >= fzg_4.zeit_1)
                    {
                        fzg4_panel_al.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg4_panel_al.BackColor = Color.Lime;
                    }
                    fzg4_panel_ab.BackColor = Color.Gray;
                    fzg4_panel_ein.BackColor = Color.Gray;
                    fzg4_panel_eb.BackColor = Color.Gray;
                    fzg4_panel_br.BackColor = Color.Gray;
                    fzg4_textBox_ab.Text = "";
                    fzg4_textBox_ein.Text = "";
                    fzg4_textBox_eb.Text = "";
                    fzg4_textBox_br.Text = "";
                    break;
                case 2: //Abgemeldet
                    fzg4_textBox_ab.Text = zeit;
                    if (fzg_4.timer_count >= fzg_4.zeit_2)
                    {
                        fzg4_panel_ab.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg4_panel_ab.BackColor = Color.Lime;
                    }
                    fzg4_panel_ein.BackColor = Color.Gray;
                    fzg4_panel_eb.BackColor = Color.Gray;
                    fzg4_panel_br.BackColor = Color.Gray;
                    break;
                case 3: //Eingetroffen
                    fzg4_textBox_ein.Text = zeit;
                    if (fzg_4.timer_count >= fzg_4.zeit_3)
                    {
                        fzg4_panel_ein.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg4_panel_ein.BackColor = Color.Lime;
                    }
                    fzg4_panel_eb.BackColor = Color.Gray;
                    fzg4_panel_br.BackColor = Color.Gray;
                    break;
                case 4: //Einsatzbereit
                    fzg4_textBox_eb.Text = zeit;
                    if (fzg_4.timer_count >= fzg_4.zeit_4)
                    {
                        fzg4_panel_eb.BackColor = Color.Red;
                    }
                    else
                    {
                        fzg4_panel_eb.BackColor = Color.Lime;
                    }
                    fzg4_panel_br.BackColor = Color.Gray;
                    break;
                case 5: //B-Raum
                    fzg4_textBox_br.Text = zeit;
                    fzg4_panel_br.BackColor = Color.Lime;
                    fzg4_panel_al.BackColor = Color.Gray;
                    fzg4_panel_ab.BackColor = Color.Gray;
                    fzg4_panel_ein.BackColor = Color.Gray;
                    fzg4_panel_eb.BackColor = Color.Gray;
                    fzg4_textBox_al.Text = "";
                    fzg4_textBox_ab.Text = "";
                    fzg4_textBox_ein.Text = "";
                    fzg4_textBox_eb.Text = "";
                    break;
            }
        }

        private void change_ov_a_Click(object sender, EventArgs e)
        {
            string temp_br;
            string temp_wache;

            log.WriteLine(DateTime.Now.ToShortTimeString()+" Tausch: " + fzg1_textBox_braum.Text+"<-->"+ fzg2_textBox_braum.Text);
            fzg_1.br = fzg1_textBox_braum.Text;
            fzg_1.wache = fzg1_textBox_wache.Text;
            fzg_2.br = fzg2_textBox_braum.Text;
            fzg_2.wache = fzg2_textBox_wache.Text;
            temp_br = fzg_2.br;
            temp_wache = fzg_2.wache;
            fzg_2.br = fzg_1.br;
            fzg_2.wache = fzg_1.wache;
            fzg_1.br = temp_br;
            fzg_1.wache = temp_wache;
            fzg1_textBox_braum.Text = fzg_1.br;
            fzg1_textBox_wache.Text = fzg_1.wache;
            fzg2_textBox_braum.Text = fzg_2.br;
            fzg2_textBox_wache.Text = fzg_2.wache;
        }

        private void change_ov_b_Click(object sender, EventArgs e)
        {
            string temp_br;
            string temp_wache;

            log.WriteLine(DateTime.Now.ToShortTimeString() + " Tausch: " + fzg3_textBox_braum.Text + "<-->" + fzg4_textBox_braum.Text);
            fzg_3.br = fzg3_textBox_braum.Text;
            fzg_3.wache = fzg3_textBox_wache.Text;
            fzg_4.br = fzg4_textBox_braum.Text;
            fzg_4.wache = fzg4_textBox_wache.Text;
            temp_br = fzg_4.br;
            temp_wache = fzg_4.wache;
            fzg_4.br = fzg_3.br;
            fzg_4.wache = fzg_3.wache;
            fzg_3.br = temp_br;
            fzg_3.wache = temp_wache;
            fzg3_textBox_braum.Text = fzg_3.br;
            fzg3_textBox_wache.Text = fzg_3.wache;
            fzg4_textBox_braum.Text = fzg_4.br;
            fzg4_textBox_wache.Text = fzg_4.wache;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            StreamWriter myWriter = File.CreateText("thw.fwd");

            log.WriteLine(DateTime.Now.ToShortTimeString() + " gespeichert");
            fzg_1.funkrufname = fzg1_textBox_funruf.Text;
            myWriter.WriteLine(fzg_1.funkrufname);
            fzg_1.grfue = fzg1_textBox_grfue.Text;
            myWriter.WriteLine(fzg_1.grfue);
            fzg_1.br = fzg1_textBox_braum.Text;
            myWriter.WriteLine(fzg_1.br);
            fzg_1.wache = fzg1_textBox_wache.Text;
            myWriter.WriteLine(fzg_1.wache);
            fzg_1.einsatz = fzg1_textBox_einsatz.Text;
            myWriter.WriteLine(fzg_1.einsatz);
            fzg_2.funkrufname = fzg2_textBox_funruf.Text;
            myWriter.WriteLine(fzg_2.funkrufname);
            fzg_2.grfue = fzg2_textBox_grfue.Text;
            myWriter.WriteLine(fzg_2.grfue);
            fzg_2.br = fzg2_textBox_braum.Text;
            myWriter.WriteLine(fzg_2.br);
            fzg_2.wache = fzg2_textBox_wache.Text;
            myWriter.WriteLine(fzg_2.wache);
            fzg_2.einsatz = fzg2_textBox_einsatz.Text;
            myWriter.WriteLine(fzg_2.einsatz);
            fzg_3.funkrufname = fzg3_textBox_funruf.Text;
            myWriter.WriteLine(fzg_3.funkrufname);
            fzg_3.grfue = fzg3_textBox_grfue.Text;
            myWriter.WriteLine(fzg_3.grfue);
            fzg_3.br = fzg3_textBox_braum.Text;
            myWriter.WriteLine(fzg_3.br);
            fzg_3.wache = fzg3_textBox_wache.Text;
            myWriter.WriteLine(fzg_3.wache);
            fzg_3.einsatz = fzg3_textBox_einsatz.Text;
            myWriter.WriteLine(fzg_3.einsatz);
            fzg_4.funkrufname = fzg4_textBox_funruf.Text;
            myWriter.WriteLine(fzg_4.funkrufname);
            fzg_4.grfue = fzg4_textBox_grfue.Text;
            myWriter.WriteLine(fzg_4.grfue);
            fzg_4.br = fzg4_textBox_braum.Text;
            myWriter.WriteLine(fzg_4.br);
            fzg_4.wache = fzg4_textBox_wache.Text;
            myWriter.WriteLine(fzg_4.wache);
            fzg_4.einsatz = fzg4_textBox_einsatz.Text;
            myWriter.WriteLine(fzg_4.einsatz);

            myWriter.Close();

        }

        private void button_load_Click(object sender, EventArgs e)
        {
            StreamReader myReader = new StreamReader("thw.fwd");

            log.WriteLine(DateTime.Now.ToShortTimeString() + " geladen");
            fzg1_textBox_funruf.Text = myReader.ReadLine();
            fzg1_textBox_grfue.Text = myReader.ReadLine();
            fzg1_textBox_braum.Text = myReader.ReadLine();
            fzg1_textBox_wache.Text = myReader.ReadLine();
            fzg1_textBox_einsatz.Text = myReader.ReadLine();
            fzg2_textBox_funruf.Text = myReader.ReadLine();
            fzg2_textBox_grfue.Text = myReader.ReadLine();
            fzg2_textBox_braum.Text = myReader.ReadLine();
            fzg2_textBox_wache.Text = myReader.ReadLine();
            fzg2_textBox_einsatz.Text = myReader.ReadLine();
            fzg3_textBox_funruf.Text = myReader.ReadLine();
            fzg3_textBox_grfue.Text = myReader.ReadLine();
            fzg3_textBox_braum.Text = myReader.ReadLine();
            fzg3_textBox_wache.Text = myReader.ReadLine();
            fzg3_textBox_einsatz.Text = myReader.ReadLine();
            fzg4_textBox_funruf.Text = myReader.ReadLine();
            fzg4_textBox_grfue.Text = myReader.ReadLine();
            fzg4_textBox_braum.Text = myReader.ReadLine();
            fzg4_textBox_wache.Text = myReader.ReadLine();
            fzg4_textBox_einsatz.Text = myReader.ReadLine();

            myReader.Close();

     
        }
    }

    public class fahrzeug
    {
        public int zustand;
        public int timer_count;
        public bool activ;
        public string funkrufname;
        public string br;
        public string grfue;
        public string wache;
        public string einsatz;
        public int zeit_1;
        public int zeit_2;
        public int zeit_3;
        public int zeit_4;
    }
}
