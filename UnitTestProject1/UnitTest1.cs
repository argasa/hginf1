using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HGINF;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UITest
    {
        [TestMethod]
        public void Brightness50()
        {
            var form = new Form1();
            form.pictureBox4_Click(null, null); //нажали на картинку, изменили прозрачность
            form.trackBar1.Value = 50;
            form.pictureBox4_Click(null, null);

            StreamReader sr2 = new StreamReader("opacity.conf");
            string line2 = sr2.ReadToEnd();
            sr2.Close();

            Assert.AreEqual("0,5", line2);

        }


        [TestMethod]
        public void TestPutMessege()
        {
            WorkBD.putMessege("Иванов Иван Иванович", "UzverPC", "4815162342", "stNum", "Есть проблема");

            using (RequestContext db = new RequestContext())
            {
                var blog = db.Requests
                    .Where(b => b.Name == "Иванов Иван Иванович")
                    .FirstOrDefault();
                Assert.AreEqual("Иванов Иван Иванович", blog.Name);
                db.Requests.Remove(blog);
                db.SaveChanges();

               

                //  db.Requests.Find("Иванов Иван Иванович");
                // Пытаемся присоединиться к БД.
                // Assert, если не получилось установить соединение.
                // Извлекаем из БД запись.
                // Assert, если записи нет или она отличается от той, что тут уже есть.
                // Удаление этой записи из БД (мы же не хотим 100500 тестовых примеров через пару месяцев разработки).
            }
        }


        [TestMethod]
        public void SisTestRing()
        {
            var form = new Form1();
            form.button1_Click_1(null, null);
            var form2 = new Form2();

            form2.textBox2.Text = "TESTsis";
            form2.richTextBox1.Text = "заявка_заявка_заявка";
            form2.maskedTextBox1.Text = "5555555555";
            form2.radioButton1.Checked = true;
            form2.button1_Click(null, null);
            form2.Close();
            using (RequestContext db = new RequestContext())
            {
                var blog = db.Requests
                    .Where(b => b.Name == "TESTsis")
                    .FirstOrDefault();
                Assert.AreEqual("TESTsis", blog.Name);
                db.Requests.Remove(blog);
                db.SaveChanges();
                                
            }
        }

    }
}
