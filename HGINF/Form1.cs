using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;
using HGINF;
using System.IO;
using System.Diagnostics;


namespace HGINF
{
    public partial class Form1 : Form

       {


        private int width = Screen.PrimaryScreen.Bounds.Width;
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int WM_NCHITTEST = 0x0084;
        const int HTCAPTION = 2;
        bool hidden = false;
        bool set = false;
        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        StreamReader sr = new StreamReader("pcnum.conf");       
        
        public Form1()
        {

            
            StreamReader sr2 = new StreamReader("opacity.conf");
            this.SetStyle(ControlStyles.ResizeRedraw, false);
            InitializeComponent();
            this.Focus();
            String line = sr.ReadToEnd();
            label1.Text = line;
            sr.Close();
            pictureBox5.Visible = false;
            trackBar1.Visible = false;
            string line2 = sr2.ReadToEnd();
            double dLine2 = Convert.ToDouble(line2);
            sr2.Close();
            this.Opacity = dLine2;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDOWN)
            {
                int result = SendMessage(m.HWnd, WM_NCHITTEST, IntPtr.Zero, m.LParam);
                if (result == HTCAPTION)
                    return;
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Focus();
            this.Location = new System.Drawing.Point(width - this.Size.Width, Size.Height/2);//вверх вправо
        }

        private void button1_Click(object sender, EventArgs e)
        {
                     
        }


        public static void SendMail(string smtpServer, string from, string password, string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://informer.hg24.su/mobile.php");
            Form3 formCall = new Form3();
            formCall.Show();
        }

        public void button1_Click_1(object sender, EventArgs e)
        {
            StreamReader sr3 = new StreamReader("pcnum.conf");
            string line = sr3.ReadToEnd();
            sr3.Close();
            //string line2 = Convert.ToString("http://informer.hg24.su//?id=");
            //string php = String.Format("{0}{7}", line2, line);
            Form2 form = new Form2();
            form.Show();
            //System.Diagnostics.Process.Start(php);
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)

        {
                        
           {
                if (hidden == true)                
                {
                                      
                    for (int j = 0; j < 224; j++)
                    {
                        this.Left -= 1;
                        this.Width += 1;
                        if (j % 3 == 0)
                        {
                            this.Refresh();
                        }
                    }
                    this.hidden = false;
                    pictureBox2.Image = Properties.Resources.sett;
                }
                else if (this.hidden == false)
                {
                    if (set == true)
                    {
                        trackBar1.Visible = false;
                        pictureBox5.Visible = false;
                        label3.Visible = false;
                        label2.Visible = false;
                        button4.Visible = false;
                        button5.Visible = false;
                        pictureBox4.Image = Properties.Resources.setting__2_;
                        set = false;
                        StreamReader sr = new StreamReader("pcnum.conf");
                        string line = sr.ReadToEnd();
                        label1.Text = line;
                        sr.Close();
                        File.Delete("opacity.conf");
                        File.WriteAllText("opacity.conf", Convert.ToString(Convert.ToDouble(trackBar1.Value) / 100));
                        this.Refresh();
                                             
                        
                    }
                        for (int x = 0; x < 224; x++)
                        {
                            this.Left += 1;
                            this.Width -= 1;
                        }

                    this.hidden = true;
                    pictureBox2.Image = Properties.Resources.sett2;
                   
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("AnyDesk.exe");
            }
            catch
            {
                MessageBox.Show("Не удалось запустить \"Удаленный помощник\"");
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Image = Properties.Resources.Отправить_заявку_2;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = Properties.Resources.Отправить_заявку;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.заказать_звонок;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.заказать_звонок_2;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.udpomoshred;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.udpomoshwhite;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.Opacity = (trackBar1.Value + 1)/ 100.0;
            label3.Text = Convert.ToString(trackBar1.Value) + "%";
        }

        public void pictureBox4_Click(object sender, EventArgs e)
        {
            if (set == false)
            {
                StreamReader sr2 = new StreamReader("opacity.conf");
                string line2 = sr2.ReadToEnd();
                double dLine2 = Convert.ToDouble(line2);
                sr2.Close();
                trackBar1.Value = Convert.ToInt32(dLine2*100);
                label3.Text = Convert.ToString(trackBar1.Value) + "%";
                label3.Visible = true;
                label2.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                trackBar1.Visible = true;
                pictureBox5.Visible = true;
                pictureBox4.Image = Properties.Resources.setting__1_;
                set = true;
                //form5.Show();
                //form5.Location = this.Location;
                //form5.Left -= 180;
                //form5.Top += 297;
                //for (int j = 0; j < 222; j++)
                //{
                //    form5.Left -= 1;
                //    form5.Width += 1;
                //    if (j % 3 == 0)
                //    {
                //        form5.Refresh();
                //    }
                //}
            }
            else
            {
                trackBar1.Visible = false;
                pictureBox5.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                //for (int x = 0; x < 222; x++)
                //{
                //    form5.Left += 1;
                //    form5.Width -= 1;
                //}
                pictureBox4.Image = Properties.Resources.setting__2_;
                set = false;
                StreamReader sr = new StreamReader("pcnum.conf");
                string line = sr.ReadToEnd();
                label1.Text = line;
                sr.Close();
                File.Delete("opacity.conf");
                File.WriteAllText("opacity.conf", Convert.ToString(Convert.ToDouble(trackBar1.Value)/100));
                //form5.Hide();
               
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form5 = new Form5();
            form5.Show(); 
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Active = true;
            toolTip1.Show("Настройки",pictureBox4);
           
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Active = false;
           
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Active = true;
            toolTip1.Show("Соединено", pictureBox6);
          
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Active = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form f6 = new Form6();
            f6.Show();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
