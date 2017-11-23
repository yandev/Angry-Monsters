using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using newproj.Properties;

namespace newproj
{
    
    public partial class Form1 : Form
    {
        
        int a;        
        Form2 Mainform;
        private string name;
        public int X = 0;
        public int Y = 0;
        int Newtime;
        int Mytime;
        System.Windows.Forms.Button[,] btnArray = new System.Windows.Forms.Button[5, 5];
        ResourceManager rm = Resources.ResourceManager;
      
      

        public Form1()
              
        {
            InitializeComponent();

            Image green_monster = (Image)rm.GetObject("green_monster_happy_icon_1");


            int text1=1;
            for (int rows = 0; rows <= 4; rows++)
            {
                for (int col = 0; col <= 4; col++)
                {

                    btnArray[rows, col] = new System.Windows.Forms.Button();
                    X = rows;
                    Y = col;
                    this.btnArray[rows,col].Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //btnArray[rows, col].Text = text1.ToString();
                    btnArray[rows, col].Click += new System.EventHandler(this.btnArray_Click);
                    btnArray[rows, col].Name = X + " " + Y;
                    tableLayoutPanel1.Controls.Add(btnArray[rows, col], col, rows);
                    btnArray[rows, col].Width = 100;
                    btnArray[rows, col].Height = 100;
                    btnArray[rows, col].BackColor = System.Drawing.Color.Green;
                    btnArray[rows, col].BackgroundImage = green_monster;                                        
                    btnArray[rows, col].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    text1++;
                }
            }

        }
        void btnArray_Click(object sender, EventArgs e)
        {


            Button s = (Button)sender;
            int x = int.Parse(s.Name.Split()[0]);
            int y = int.Parse(s.Name.Split()[1]);
            int row = btnArray.GetLength(0) - 1;
            int col = btnArray.GetLength(1) - 1;
            if ((x == 0) && (y == 0))//x=0,y=0
            {
                ChangeProp(x, y);//0,0
                ChangeProp(x, col);//0,4
                ChangeProp(row, y);//4,0
                ChangeProp(x, y + 1);//0,1
                ChangeProp(x + 1, y);//1,0

            }
            else
                if ((x == row) && (y == 0))//x=4,y=0
                {
                    ChangeProp(row, y);//4,0
                    ChangeProp(row, y + 1);//4,1
                    ChangeProp(row - 1, y);//3,0
                    ChangeProp(row, col);//4,4
                    ChangeProp(0, y);//0,0
                }
                else
                    if ((x == 0) && (y == col))//x=0,y=4
                    {
                        ChangeProp(x, col);//0,4
                        ChangeProp(x + 1, col);//1,4
                        ChangeProp(x, col - 1);//0,3
                        ChangeProp(col, col);//4,4
                        ChangeProp(x, x);//0,0
                    }
                    else
                        if ((x == row) && (y == col))//x=4,y=4
                        {
                            ChangeProp(row, col);//4,4
                            ChangeProp(row, 0);//4,0
                            ChangeProp(row, col - 1);//4,3
                            ChangeProp(0, col);//0,4
                            ChangeProp(row - 1, col);//3,4
                        }
                        else
                            if ((x == 0))//x=0
                            {
                                ChangeProp(x, y);
                                ChangeProp(row, y);
                                ChangeProp(x, y + 1);
                                ChangeProp(x, y - 1);
                                ChangeProp(x + 1, y);
                            }
                            else
                                if (x == row)//x=4
                                {
                                    ChangeProp(x, y);
                                    ChangeProp(0, y);
                                    ChangeProp(x, y + 1);
                                    ChangeProp(x, y - 1);
                                    ChangeProp(x - 1, y);
                                }
                                else
                                    if (y == 0)//y=0
                                    {
                                        ChangeProp(x, y);
                                        ChangeProp(x, col);
                                        ChangeProp(x + 1, y);
                                        ChangeProp(x - 1, y);
                                        ChangeProp(x, y + 1);
                                    }
                                    else
                                        if (y == col)
                                        {
                                            ChangeProp(x, y);
                                            ChangeProp(x, 0);
                                            ChangeProp(x + 1, y);
                                            ChangeProp(x - 1, y);
                                            ChangeProp(x, y - 1);
                                        }
                                        else
                                        {
                                            ChangeProp(x, y);
                                            ChangeProp(x + 1, y);
                                            ChangeProp(x - 1, y);
                                            ChangeProp(x, y + 1);
                                            ChangeProp(x, y - 1);
                                        }
        }
        private void ChangeProp(int i, int j)
        {
            Image red_monster = (Image)rm.GetObject("red_monster_icon");
            Image green_monster = (Image)rm.GetObject("green_monster_happy_icon_1");
            if (btnArray[i, j].BackColor == System.Drawing.Color.Green)
            {
                btnArray[i, j].BackColor = System.Drawing.Color.Red;
                btnArray[i, j].BackgroundImage = red_monster;
                btnArray[i, j].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;            
                
            }
            else
                if (btnArray[i, j].BackColor == System.Drawing.Color.Red)
                {
                    btnArray[i, j].BackColor = System.Drawing.Color.Green;
                btnArray[i, j].BackgroundImage = green_monster;
                    btnArray[i, j].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                }
            Checker();
            if (Checker() == 25)
            {                
                timer1.Enabled = false;
                Newtime = int.Parse(label1.Text);                                
                MessageBox.Show("You Won");                
                SaveToFile(Newtime);                                               
            }
        }
        private int Checker()
        {
            
            int n=0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (btnArray[row, col].BackColor == System.Drawing.Color.Red)
                    {                        
                        n++;
                        continue;
                    }
                    else
                        break;
                }
            }
            return  n;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream FileStrmRead;

            if(File.Exists("MindBoggleRecordScore.txt")){
                timer1.Enabled = true;



                FileStrmRead = new FileStream("MindBoggleRecordScore.txt", FileMode.Open, FileAccess.Read);
                StreamReader RdFile = new StreamReader(FileStrmRead);
                RdFile.BaseStream.Seek(0, SeekOrigin.Begin);
                string firstLineName = RdFile.ReadLine();
                string SecondLineTime = RdFile.ReadLine();
                RdFile.Close();
                FileStrmRead.Close();


                int stringlastPosname = firstLineName.IndexOf(':');
                int stringlastPostime = SecondLineTime.IndexOf(':');
                string namestrg = firstLineName.Substring(1, stringlastPosname);
                string timestrg = SecondLineTime.Substring(1, stringlastPostime);
                
            } else{
                try
                {
                    
                    FileStrmRead = new FileStream("MindBoggleRecordScore.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    FileStrmRead.Flush();
                    StreamWriter WrFile = new StreamWriter(FileStrmRead);

                    WrFile.WriteLine("Name:" + "Kaysoft Developments");//Name of Player                
                    WrFile.Write("Timer:" + "10000000");//time elapsed;                
                    WrFile.Close();
                }
                catch
                {
                    MessageBox.Show("Opps Something went Wrong Please Try again");
                }
                
              
            }
          
                
            
            

        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            a =  int.Parse(label1.Text);
            a += 1;
            label1.Text = a.ToString();
        }
         
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            label1.Text = "0";
            a = 0;
            Mainform = new Form2();
            Mainform.Show();
           
        }

        private void SaveToFile(int Mytime)
        {
           
            
                this.Mytime = Mytime;
                FileStream FileStrmRead = new FileStream("MindBoggleRecordScore.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader RdFile = new StreamReader(FileStrmRead);
                RdFile.BaseStream.Seek(0, SeekOrigin.Begin);                
                string fristlinename = RdFile.ReadLine();
                string SecondLineTime = RdFile.ReadLine();

                int stringStartPos = SecondLineTime.IndexOf(':');
                string Oldtimestrg = SecondLineTime.Substring((stringStartPos + 1), (SecondLineTime.Length - (stringStartPos + 1)));
                RdFile.Close();

                if ((fristlinename == null )||(SecondLineTime == null))
                {
                    textBox1.Visible = true;
                    button2.Visible = true;
                    label2.Visible = true;

                }
                else
                {
                    int Oldtimeint = int.Parse(Oldtimestrg);

                    if ((Mytime < Oldtimeint))
                    {
                        textBox1.Visible = true;
                        button2.Visible = true;
                        label2.Visible = true;
                    }
                    else
                    {
                        this.Close();
                    }




                }


            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("You have to enter your name.\n As the record holder in this game");
            }
            else
            {
                name = textBox1.Text;
                MessageBox.Show(name);
                FileStream FileStrmWrite = new FileStream("MindBoggleRecordScore.txt", FileMode.Truncate, FileAccess.Write);
                FileStrmWrite.Flush();
                StreamWriter WrFile = new StreamWriter(FileStrmWrite);

                WrFile.WriteLine("Name:"+name);//Name of Player                
                WrFile.Write("Timer:"+this.Mytime);//time elapsed;                
                WrFile.Close();               
                this.Close();                
                textBox1.Visible = false;
                button2.Visible = false;
                label2.Visible = false;
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            FileStream FileStrmRead = new FileStream("MindBoggleRecordScore.txt", FileMode.Open, FileAccess.Read);
            StreamReader NewRead = new StreamReader(FileStrmRead);
            NewRead.BaseStream.Seek(0, SeekOrigin.Begin);
            string FirstLineName = NewRead.ReadLine();            
            string SecondLineTime = NewRead.ReadLine();            
            MessageBox.Show(FirstLineName + "\r\n"+ SecondLineTime);
            NewRead.Close();
        }
        

    }
}
