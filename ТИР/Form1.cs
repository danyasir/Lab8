using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        internal System.Windows.Forms.PictureBox PictureBox;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black; 
            this.Load += Form1_Load;
            this.MouseClick += Form1_Click;
        }

        private void Form1_Load(object sender, EventArgs e) // фон
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(450, 0, 1000,1000);
            Region myRegion = new Region(myPath);
            this.Region = myRegion;
        }
        private void Form1_Click(object sender, EventArgs e) // обработка клика, создание "отверстия"
        {
            this.PictureBox = new PictureBox(); // при надатии добавляем новый обьект
            this.PictureBox.BackColor = Color.FromArgb(((Byte)(255)), ((Byte)(128)), ((Byte)(128))); 


            this.PictureBox.Location = new Point(Cursor.Position.X - 52, Cursor.Position.Y - 75); // местоположение попадания
            this.PictureBox.Size = new Size(90, 90); // размер 
            
        
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath(); // задаем   
            gp.AddEllipse(0, 0, PictureBox.Width - 15, PictureBox.Height - 15);                     // новому
            Region rg = new Region(gp);                                                             // обьекту
            PictureBox.Region = rg;                                                                 // форму круга
            
            this.ClientSize = new Size(this.Width, this.Height);                                // делаем
            this.Controls.AddRange(new Control[]                                                // обьект    
            {                                                                                   // прозрачным
                this.PictureBox                                                                 //
            });                                                                                 //
            this.TransparencyKey = Color.FromArgb(((Byte)(255)), ((Byte)(128)), ((Byte)(128))); //
        }
    }
}
