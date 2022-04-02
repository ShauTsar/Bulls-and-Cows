using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using MailKit.Net.Pop3;
using MimeKit;
using System.Drawing;
namespace WinFormsApp2

{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MailAddress from = new MailAddress(textBox2.Text);
            MailAddress to = new MailAddress(textBox1.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Быки и коровы";
            m.Body = textBox5.Text ;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential(textBox2.Text, textBox3.Text);
            smtp.EnableSsl = true;
            smtp.Send(m);
            MessageBox.Show("Число отправлено");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var client = new Pop3Client())
            {        
                client.Connect("pop.mail.ru", 995, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(textBox2.Text, textBox3.Text);
                var message = client.GetMessage(client.Count-1);
                client.Disconnect(true);
                char [] array = message.HtmlBody.ToCharArray();
                char [] array2 = textBox4.Text.ToCharArray();
                int bools = 0;
                for(int i = 0; i < 4; i++)
                {
                    if (array[i] == array2[i]) bools++;
                    
                }
                int cows = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array2.Length; j++)
                    {
                        if (array[i] == array2[j])
                            cows++;
                    }

                }
                cows = cows - bools;
                listBox1.Items.Add("Ваше число: " + textBox4.Text + ". В нем " + bools.ToString() +
                    " быков и " + cows.ToString() + " коров.");
                if (bools == 4)
                {
                    pictureBox1.Visible = true;
                    MessageBox.Show("Молодчина", "Хорош");
                }

            }   }

        private void button3_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Size = new Size(960,580);
            pictureBox2.Image = Image.FromFile("C:\\Users\\ShauTsar\\Downloads\\31Kl.gif");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pictureBox2);
            MessageBox.Show("Nice try", "BB");
            this.Close();
        }

        
    }
}