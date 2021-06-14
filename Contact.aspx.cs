using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging ;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.UI.DataVisualization.Charting;








namespace test1
{
    public partial class Contact : Page
    {
        /*
        protected int Rows
        {
            get { return ViewState["Rows"] != null ? (int)ViewState["Rows"] : 0; }
            set { ViewState["Rows"] = value; }
        }
        protected int Colums
        {
            get { return ViewState["Colums"] != null ? (int)ViewState["Colums"] : 0; }
            set { ViewState["Colums"] = value; }
        }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            
          

        }
        public System.Drawing.Image bitmap;
        //---------------------------------------------------------------------

        protected void Button1_Click(object sender, EventArgs e)
        {
            int  i,j,k,x,y,n=4,m=40, down = 0, right=75;
            double test, test1, test2, max, min, r, z, w,q,f=100;
            bool f1 = false, f2 = false, f3 = false, f4 = false;
            string name = "font";
            double[,] sort = new double[n, m];
            int[,] ch = new int[n, m];
            double[,] data = new double[,] { {  6,4,10,15,10,0,5,0,0,0,20,0,0,7,0,0,5,0,6,4,10,15,10,0,0,0,6,4,10,15,6,4,10,15,10,0,5,0,0,0}, 
                                             {  5,6,0,10,0,9,5,5,0,5,0,20,0,0,12,9,5,5,5,6,0,10,0,5,5,0, 5,6,0,10,5,6,0,10,0,9,5,5,0,5}, 
                                             { 9,5,5,0,5,5,6,0,10,0,0,0,20,6,8,5,6,0,9,5,5,0,5,0,10,0, 9,5,5,0,9,5,5,0,5,5,6,0,10,0},
                                             {0,5,0,0,0, 6,4,10,15,10,0,0,0,7,0,6,4,10,0,5,0,0,0,10,15,10,0,5,0,0,0,5,0,0,0, 6,4,10,15,10} };
            double[,] data2 = new double[n, m];
            double[,] obs = new double[n,m];
            double[,] obs1 = new double[n, m];




            for (i=0; i<m; i++)
            {
                max = 0;
                test = 0;
                test1 = 0;
                test2 = 0;

                for(j=0; j<n; j++)
                {
                    max = max + data[j, i];    
                }

                for (j = 0; j < n; j++)
                {
                    data2[j, i] = data[j, i] / max;
                    
                }
                test2 = 0;
                for (j = 0; j < n; j++)
                {
                    if (data2[j, i] > 0)
                        test2 += data2[j, i] * Math.Log(data2[j,i],2);

                    //TextBox3.Text = TextBox3.Text + test2.ToString("F") + "  ";
                }
                //TextBox3.Text = TextBox3.Text + "\n";
                for (j = 0; j < n; j++)
                {
                    r = 2 + test2;
                    test = data2[j, i] * r;

                   // TextBox2.Text = TextBox2.Text + test.ToString() + "\n";
                    obs1[j, i] = test;
                }
                //TextBox2.Text = TextBox2.Text + "\n-------------\n";
            }

            for (i = 0; i < n; i++)
              for (j = 0; j < m; j++)
                 obs[i, j] = obs1[i, j];


          for (i=0; i<m; i++)
          {  
                for(j=0; j < n; j++)
                {
                    //sort[j, i] = data[j, i];
                    //ch[j, i] = 0;
                    for(k=0; k<(4-1-j); k++)
                    {
                        
                        if (obs1[k, i] > obs1[k+1, i])
                        {
                            min = obs1[k, i];
                            obs1[k, i] = obs1[k + 1, i];
                            obs1[k + 1, i] = min;
                            
                        }
                    }
                   // TextBox1.Text += obs1[j, i] + "   ";

                }
               // TextBox1.Text += "\n";
          }
           // TextBox1.Text += "\n--------------------\n";

            for (i = 0; i < m; i++)
            {
                f1 = false; f2 = false; f3 = false; f4 = false;
                for (j = 0; j < n; j++)
                {
                    
                    if (obs[3, i] == obs1[j, i] && f1==false)
                    {
                        ch[j, i] = 3;
                        f1 = true;
                        goto outer;
                    }
                    if (obs[2, i] == obs1[j, i] && f2 == false)
                    {
                        ch[j, i] = 2;
                        f2 = true;
                        goto outer;
                    }
                    if (obs[1, i] == obs1[j, i] && f3 == false)
                    {
                        ch[j, i] = 1;
                        f3 = true;
                        goto outer;
                    }
                    if (obs[0, i] == obs1[j, i] && f4 == false)
                    {
                        ch[j, i] = 0;
                        f4 = true;
                        goto outer;
                    }
                    outer:
                    continue;
                }
            }

                    for (i=0; i<n; i++)
            {
                for(j=0; j<m; j++)
                {
                   // TextBox1.Text += obs1[i, j].ToString("F") + ":"+ch[i,j].ToString()+" -- ";
                }
               // TextBox1.Text += "\n";
            }


            string text = txttext.Text.Trim();
            
            Bitmap bitmap = new Bitmap(1200,300,PixelFormat.Format64bppPArgb);
            
            Graphics graphics = Graphics.FromImage(bitmap);
            
            //bitmap = new Bitmap(bitmap, new Size(512, 512));
            bitmap.SetResolution(1200, 1200);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            //graphics.DrawImage(bitmap,500,100,500,100);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Center;
            Font font2 = new Font("Times New Roman", (int)(15), FontStyle.Bold, GraphicsUnit.Pixel);

            Bitmap img1 = (Bitmap)System.Drawing.Image.FromFile("G:/A.jpg", true);
            Bitmap img2 = (Bitmap)System.Drawing.Image.FromFile("G:/C.jpg", true);
            Bitmap img3 = (Bitmap)System.Drawing.Image.FromFile("G:/G.jpg", true);
            Bitmap img4 = (Bitmap)System.Drawing.Image.FromFile("G:/T.jpg", true);
            
            k = 1;
            z = 275;
            x = 100;

            if (m > 11 && m<=15 )
            {
                x =(int)(100-(Math.Sqrt(m-8-1)*10));
                f = x;
            }
            else if (m > 15 && m<=18)
            {
                x = (int)(100 - (Math.Sqrt(m - 8 ) * 12));
                f = x;
            }
            else if(m > 18 && m <= 22)
            {
                x = (int)(100 - (Math.Sqrt(m - 8 ) * 13));
                f = x;
            }
            else if (m > 22 && m <= 40)
            {
                x = (int)(100 - (Math.Sqrt(m - 8) * 14));
                f = x;
            }



           // TextBox2.Text += "\n/////////// \n";
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                  
                    if (obs1[j, i] > 0)
                    {
                        q = obs1[j, i] * f;
                        w = z - q;
                        y = (int)q;
                        z = w;
                        down = (int)w;
                        //TextBox2.Text += "\n" + m.ToString();
                        if (ch[j, i] == 0)
                        {
                            RectangleF src = new RectangleF(right, down, x, y);
                            
                            
                            graphics.DrawImage(img1, src);
                        }

                        else if (ch[j, i] == 1)
                        {
                            RectangleF src = new RectangleF(right, down, x, y);
                           
                            graphics.DrawImage(img2, src);
                        }


                        else if (ch[j, i] == 2)
                        {
                            RectangleF src = new RectangleF(right, down, x, y);
                            
                            graphics.DrawImage(img3, src);
                        }


                        else if (ch[j, i] == 3)
                        {
                            RectangleF src = new RectangleF(right, down, x, y);
                           
                            graphics.DrawImage(img4, src);
                        }


                    }

                }
                
                graphics.DrawString(k.ToString(), font2, new SolidBrush(Color.FromArgb(0, 0, 0)), right+(x/2), 280, sf);
                k++;
                z = 275;
                down = 0;
                right += x;
            }


            /*
                        k = 1;
                        for ( i = 0; i < 3; i++)
                        {

                            for (j = 0; j < 4; j++)
                            {
                                if (obs1[j, i] > 0)
                                {
                                    Font font1 = new Font("Arial", (int)((obs1[j, i]) * 100) + 1, FontStyle.Bold, GraphicsUnit.Pixel);


                                    if (ch[j, i] == 0)
                                    {

                                            down -= Convert.ToInt16(((obs1[j, i])) * 92);
                                        graphics.DrawString("A", font1, new SolidBrush(Color.FromArgb(0, 255, 0)), right, down, sf);
                                    }



                                    else if (ch[j, i] == 1)
                                    {

                                            down -= Convert.ToInt16(((obs1[j, i])) * 92);
                                        graphics.DrawString("C", font1, new SolidBrush(Color.FromArgb(0, 0, 255)), right, down, sf);
                                    }


                                    else if (ch[j, i] == 2)
                                    {

                                            down -= Convert.ToInt16(((obs1[j, i])) * 92);
                                        graphics.DrawString("G", font1, new SolidBrush(Color.FromArgb(255, 150, 0)), right, down, sf);
                                    }


                                    else if (ch[j, i] == 3)
                                    {

                                            down -= Convert.ToInt16(((obs1[j, i])) * 92);

                                        graphics.DrawString("T", font1, new SolidBrush(Color.FromArgb(255, 0, 0)), right, down, sf);
                                    }


                                }

                            }
                            graphics.DrawString(k.ToString(), font2, new SolidBrush(Color.FromArgb(0, 0, 0)), right, 255, sf);
                            k++;
                            down = 250;
                            right += 150;
                        }
                        */
            int t =(int) (z - 2 * f);
            int z1 = (int)(z);
            int t1 = ((z1 - t) / 2)+t;

            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            graphics.DrawString("2", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, t, sf);
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70,t), new Point(65, t));
            graphics.DrawString("1", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, t1, sf);
            
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, t1), new Point(65,t1 ));
            graphics.DrawString("0", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, z1, sf);
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, z1), new Point(65, z1));
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, z1), new Point(70,t));
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, z1), new Point(right, z1));
            //graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, 70), new Point(600, 70));


            
            //graphics.RotateTransform(90F, MatrixOrder.Append);
            // graphics.TranslateTransform(40, 170);
            //graphics.RotateTransform(90);
            graphics.DrawString("bits", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 40,t1,sf);

            
            
            
            
            
            

            graphics.Flush();
            graphics.Dispose();
            string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".jpg";
            bitmap.Save(Server.MapPath("~/") + fileName, ImageFormat.Jpeg);
            imgtext.ImageUrl = "~/" + fileName;
            imgtext.Visible = true;


            graphics.Dispose();
            bitmap.Dispose();

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
          
            int rows =Convert.ToInt16( TextBox1.Text);
            int cols = Convert.ToInt16(TextBox2.Text);
          
            for (int j = 0; j < rows; j++)
            {
                TableRow r = new TableRow();
                for (int i = 0; i < cols; i++)
                {
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl("row " + j.ToString() + ", cell " + i.ToString()));
                    r.Cells.Add(c);
                }
                tb1.Rows.Add(r);
            }

        }

      
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int i, j, n;
            int[,] gg = new int[,] { { 11, 12, 3, 13, 8, 15 },
                                     {3,8,11,16,0,10 },
                                     {5,2,4,7,10,8 },
                                     {14,8,3,16,10,1 }};
            string[] name = new string[] { "A", "C", "G", "T","U","N","Y" };
            DataTable dt = new DataTable();

            dt.Columns.Add("Data", Type.GetType("System.String"));

            dt.Columns.Add("Value1", Type.GetType("System.Int32"));
            dt.Columns.Add("Value2", Type.GetType("System.Int32"));
            dt.Columns.Add("Value3", Type.GetType("System.Int32"));
            dt.Columns.Add("Value4", Type.GetType("System.Int32"));

            DataRow row;
            for(i=0; i<4; i++)
            {
                row = dt.NewRow();
                row["Data"] = "Column" + (i + 1).ToString();
                row["Value1"] = gg[0, i];
                row["Value2"] = gg[1, i];
                row["Value3"] = gg[2, i];
                row["Value4"] = gg[3, i];
                dt.Rows.Add(row);
            }

            Legend leg = new Legend();
 
            Chart1.Legends.Add(leg);

            for ( i = 1; i < dt.Columns.Count; i++)

            {
                
                Series series = new Series();
                if (i == 1)
                    series.Color = System.Drawing.Color.Green;
                else if (i == 2)
                    series.Color = System.Drawing.Color.Blue;
                else if (i == 3)
                    series.Color = System.Drawing.Color.Orange;
                else if (i == 4)
                    series.Color = System.Drawing.Color.Red;

                series.LegendText = name[i-1];
                series.IsValueShownAsLabel = true;
                series.LabelAngle = 0;
                series.Font = new Font("Arial", 10);
                series.SmartLabelStyle.Enabled = true;
                
                foreach (DataRow dr in dt.Rows)

                {
                   
                    int y = (int)dr[i];

                    series.Points.AddXY(dr["Data"].ToString(), y);
                   
                }
                
                Chart1.Series.Add(series);
               
            }

            
        }

        
    }

}