using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace HGINF
{
    public partial class Form3 : Form
    {
        bool a = false;
        bool b = false;
        public Form3()
        {
            InitializeComponent();
            maskedTextBox1.SelectionStart = 0;
            textBox2.SelectionStart = 0;
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
                Form form = new Form4();
                form.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show("Mail.Send: " + e.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamReader sr = new StreamReader("pcnum.conf");
            String line = sr.ReadToEnd();
            string strNum = line;
            string strPC = "";
            if (radioButton1.Checked)
            {
                strPC = "IT";
            }
            if (radioButton2.Checked)
            {
                strPC = "WEB";
            }
            if (radioButton3.Checked)
            {
                strPC = "1C";
            }
            string strPNum = maskedTextBox1.Text;
            string strFIO = textBox2.Text;
            if (strFIO == "" || strPC == "" || strFIO == "Как вас зовут" || strPC == "" || strNum == "(   )    -")
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
            else
            {
                //SendMail("smtp.gmail.com", "hginformer@gmail.com", "Hgroup911adm", "aukustik@yandex.ru", "Заказ звонка от " + strFIO, "Отдел: " + strPC + "\n\nИмя: " + strFIO + "\n\nНомер телефона: +7 " + strNum, "");
                WorkBD.putMessege(strFIO, strPC, strPNum, strNum);

                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox2_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                b = true;
            }

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (a == false)
            {
                maskedTextBox1.Text = "";
                maskedTextBox1.ForeColor = Color.Black;
                a = true;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pictureBox3.Image = Properties.Resources.направления__1_;
            }
            else
            {
                pictureBox3.Image = Properties.Resources.направления__4_;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pictureBox4.Image = Properties.Resources.направления__2_;
            }
            else
            {
                pictureBox4.Image = Properties.Resources.направления__5_;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                pictureBox5.Image = Properties.Resources.направления__3_;
            }
            else
            {
                pictureBox5.Image = Properties.Resources.направления__6_;
            }
        }
    }
}
