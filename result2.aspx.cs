using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace test1
{
    public partial class result1 : System.Web.UI.Page
    {
        protected void Page_Load1(object sender, EventArgs e)
        {
            int i, j, n,y,m;
            string e2;
            e2 = (string)(Application["user2"]);
            n= (int)(Application["user3"]);
            m= (int)(Application["user4"]);
            /*
            double[,] gg = new double[,] { { 80, 0, 0, 0, 0, 0 },
                                               { 0,0,0,10,0,0},
                                               { 0,0,0,0,30,0},
                                               {0,0,0,0,0, 0 },
                                               { 0, 0, 0, 30, 0, 0 },
                                               { 0,0,0,0,0,0},
                                               { 0,0,50,0,0,0},
                                               {0,60,0,0,0, 0 },
                                               { 0, 0, 20, 0, 0, 0 },
                                               { 0,0,0,0,0,0},
                                               { 0,0,0,0,0,10},
                                               {0,0,0,0,0, 0 },
                                               { 0, 20, 0, 15, 0, 0 },
                                               { 0,0,0,0,50,0},
                                               { 0,0,10,0,0,0},
                                               {0,0,0,0,0, 70 }
            };*/
            double[,] gg = (double[,])(Application["user1"]);
            //gg=(int[,])Application["user1"];

            // int[,] entropy = new int[,] {{15,11,17,12,16,14},{9,8,10,12,7,9} };



            string[] name = new string[] { "AA", "AC", "AG", "AT", "CA", "CC", "CG", "CT",
                                            "GA", "GC", "GG", "GT", "TA", "TC", "TG", "TT"};
            string[] name2 = new string[] { "A", "C", "G", "T" };
            DataTable dt = new DataTable();

            dt.Columns.Add("Data", Type.GetType("System.String"));

            dt.Columns.Add("Value1", Type.GetType("System.Int32"));
            dt.Columns.Add("Value2", Type.GetType("System.Int32"));
            dt.Columns.Add("Value3", Type.GetType("System.Int32"));
            dt.Columns.Add("Value4", Type.GetType("System.Int32"));
            dt.Columns.Add("Value5", Type.GetType("System.Int32"));
            dt.Columns.Add("Value6", Type.GetType("System.Int32"));
            dt.Columns.Add("Value7", Type.GetType("System.Int32"));
            dt.Columns.Add("Value8", Type.GetType("System.Int32"));
            dt.Columns.Add("Value9", Type.GetType("System.Int32"));
            dt.Columns.Add("Value10", Type.GetType("System.Int32"));
            dt.Columns.Add("Value11", Type.GetType("System.Int32"));
            dt.Columns.Add("Value12", Type.GetType("System.Int32"));
            dt.Columns.Add("Value13", Type.GetType("System.Int32"));
            dt.Columns.Add("Value14", Type.GetType("System.Int32"));
            dt.Columns.Add("Value15", Type.GetType("System.Int32"));
            dt.Columns.Add("Value16", Type.GetType("System.Int32"));

            DataRow row;

            if (e2 == "1")
            {
                for (i = 0; i < m; i++)
                {
                    row = dt.NewRow();
                    row["Data"] = "Column" + (i + 1).ToString();
                    row["Value1"] = gg[0, i];
                    row["Value2"] = gg[1, i];
                    row["Value3"] = gg[2, i];
                    row["Value4"] = gg[3, i];
                    dt.Rows.Add(row);
                }
            }
            else if (e2 == "2")
            {
                for (i = 0; i < m; i++)
                {
                    row = dt.NewRow();
                    row["Data"] = "Column" + (i + 1).ToString();
                    row["Value1"] = gg[0, i];
                    row["Value2"] = gg[1, i];
                    row["Value3"] = gg[2, i];
                    row["Value4"] = gg[3, i];
                    row["Value5"] = gg[4, i];
                    row["Value6"] = gg[5, i];
                    row["Value7"] = gg[6, i];
                    row["Value8"] = gg[7, i];
                    row["Value9"] = gg[8, i];
                    row["Value10"] = gg[9, i];
                    row["Value11"] = gg[10, i];
                    row["Value12"] = gg[11, i];
                    row["Value13"] = gg[12, i];
                    row["Value14"] = gg[13, i];
                    row["Value15"] = gg[14, i];
                    row["Value16"] = gg[15, i];
                    dt.Rows.Add(row);
                }

            }

            Legend leg = new Legend();

            Chart1.Legends.Add(leg);
            leg.Enabled = true;
            leg.Docking = Docking.Bottom;
            leg.Font = new Font("Arial", 7);
            

           // for (i = 1; i < dt.Columns.Count; i++)
            for (i = 1; i <= n; i++)
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

                if(e2=="1")
                    series.LegendText = name2[i-1 ];
                else
                    series.LegendText = name[i-1 ]; 

                series.IsValueShownAsLabel = true;
                series.LabelAngle = 0;
                series.Font = new Font("Arial", 6);
                series.SmartLabelStyle.Enabled = true;

                foreach (DataRow dr in dt.Rows)

                {

                    y = (int)dr[i];

                    series.Points.AddXY(dr["Data"].ToString(), y);

                }

                Chart1.Series.Add(series);
                

            }
            //--------------------------------------------------------------
            
        



            //--------------------------------------------------------------

            int k, x, down = 0, right = 75;
           
            double test, test1, test2, max, min, r, z, w, q, f = 100;
            bool f1 = false, f2 = false, f3 = false, f4 = false,
                f5 = false, f6 = false, f7 = false, f8 = false,
                f9 = false, f10 = false, f11 = false, f12 = false,
                f13 = false, f14 = false, f15 = false, f16 = false;
            
            double[,] sort = new double[n, m];
            int[,] ch = new int[n, m];

            //double[,] data =  (double[,])(Application["user1"]);
            double[,] data = new double[n, m];
            data = gg;

            double[,] datadi = new double[n, m];
            datadi = gg;
            /*
            double[,] data = new double[,] { {  6,4,10,15,10,0,5,0,0,0,20,0,0,7,0,0,5,0,6,4,10,15,10,0,0,0,6,4,10,15,6,4,10,15,10,0,5,0,0,0},
                                             {  5,6,0,10,0,9,5,5,0,5,0,20,0,0,12,9,5,5,5,6,0,10,0,5,5,0, 5,6,0,10,5,6,0,10,0,9,5,5,0,5},
                                             { 9,5,5,0,5,5,6,0,10,0,0,0,20,6,8,5,6,0,9,5,5,0,5,0,10,0, 9,5,5,0,9,5,5,0,5,5,6,0,10,0},
                                             {0,5,0,0,0, 6,4,10,15,10,0,0,0,7,0,6,4,10,0,5,0,0,0,10,15,10,0,5,0,0,0,5,0,0,0, 6,4,10,15,10} };
            double[,] datadi = new double[,] { { 80, 0, 0, 0, 0, 0 },
                                               { 0,0,0,10,0,0},
                                               { 0,0,0,0,30,0},
                                               {0,0,0,0,0, 0 },
                                               { 0, 0, 0, 30, 0, 0 },
                                               { 0,0,0,0,0,0},
                                               { 0,0,50,0,0,0},
                                               {0,60,0,0,0, 0 },
                                               { 0, 0, 20, 0, 0, 0 },
                                               { 0,0,0,0,0,0},
                                               { 0,0,0,0,0,10},
                                               {0,0,0,0,0, 0 },
                                               { 0, 20, 0, 15, 0, 0 },
                                               { 0,0,0,0,50,0},
                                               { 0,0,10,0,0,0},
                                               {0,0,0,0,0, 70 }
            };
            */
            double[,] data2 = new double[n, m];
            double[,] obs = new double[n, m];
            double[,] obs1 = new double[n, m];




            for (i = 0; i < m; i++)
            {
                max = 0;
                test = 0;
                test1 = 0;
                test2 = 0;

                for (j = 0; j < n; j++)
                {
                    max = max + datadi[j, i];
                }

                for (j = 0; j < n; j++)
                {
                    data2[j, i] = datadi[j, i] / max;

                }
                test2 = 0;
                for (j = 0; j < n; j++)
                {
                    if (data2[j, i] > 0)
                        test2 += data2[j, i] * Math.Log(data2[j, i], 2);

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


            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    //sort[j, i] = data[j, i];
                    //ch[j, i] = 0;
                    for (k = 0; k < (n - 1 - j); k++)
                    {

                        if (obs1[k, i] > obs1[k + 1, i])
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
                f5 = false; f6 = false; f7 = false; f8 = false;
                f9 = false; f10 = false; f11 = false; f12 = false;
                f13 = false; f14 = false; f15 = false; f16 = false;
                for (j = 0; j < n; j++)
                {
                    if (e2 == "1")
                    {
                        if (obs[3, i] == obs1[j, i] && f12 == false)
                        {
                            ch[j, i] = 3;
                            f12 = true;
                            goto outer;
                        }
                        if (obs[2, i] == obs1[j, i] && f13 == false)
                        {
                            ch[j, i] = 2;
                            f13 = true;
                            goto outer;
                        }

                        if (obs[1, i] == obs1[j, i] && f15 == false)
                        {
                            ch[j, i] = 1;
                            f15 = true;
                            goto outer;
                        }
                        if (obs[0, i] == obs1[j, i] && f16 == false)
                        {
                            ch[j, i] = 0;
                            f16 = true;
                            goto outer;
                        }
                    }
                    else if (e2 == "2")
                    {

                        if (obs[15, i] == obs1[j, i] && f1 == false)
                        {
                            ch[j, i] = 15;
                            f1 = true;
                            goto outer;
                        }
                        if (obs[14, i] == obs1[j, i] && f2 == false)
                        {
                            ch[j, i] = 14;
                            f2 = true;
                            goto outer;
                        }
                        if (obs[13, i] == obs1[j, i] && f3 == false)
                        {
                            ch[j, i] = 13;
                            f3 = true;
                            goto outer;
                        }
                        if (obs[12, i] == obs1[j, i] && f14 == false)
                        {
                            ch[j, i] = 12;
                            f14 = true;
                            goto outer;
                        }
                        if (obs[11, i] == obs1[j, i] && f4 == false)
                        {
                            ch[j, i] = 11;
                            f4 = true;
                            goto outer;
                        }
                        if (obs[10, i] == obs1[j, i] && f5 == false)
                        {
                            ch[j, i] = 10;
                            f5 = true;
                            goto outer;
                        }
                        if (obs[9, i] == obs1[j, i] && f6 == false)
                        {
                            ch[j, i] = 9;
                            f6 = true;
                            goto outer;
                        }
                        if (obs[8, i] == obs1[j, i] && f7 == false)
                        {
                            ch[j, i] = 8;
                            f7 = true;
                            goto outer;
                        }
                        if (obs[7, i] == obs1[j, i] && f8 == false)
                        {
                            ch[j, i] = 7;
                            f8 = true;
                            goto outer;
                        }
                        if (obs[6, i] == obs1[j, i] && f9 == false)
                        {
                            ch[j, i] = 6;
                            f9 = true;
                            goto outer;
                        }
                        if (obs[5, i] == obs1[j, i] && f10 == false)
                        {
                            ch[j, i] = 5;
                            f10 = true;
                            goto outer;
                        }
                        if (obs[4, i] == obs1[j, i] && f11 == false)
                        {
                            ch[j, i] = 4;
                            f11 = true;
                            goto outer;
                        }
                        if (obs[3, i] == obs1[j, i] && f12 == false)
                        {
                            ch[j, i] = 3;
                            f12 = true;
                            goto outer;
                        }
                        if (obs[2, i] == obs1[j, i] && f13 == false)
                        {
                            ch[j, i] = 2;
                            f13 = true;
                            goto outer;
                        }

                        if (obs[1, i] == obs1[j, i] && f15 == false)
                        {
                            ch[j, i] = 1;
                            f15 = true;
                            goto outer;
                        }
                        if (obs[0, i] == obs1[j, i] && f16 == false)
                        {
                            ch[j, i] = 0;
                            f16 = true;
                            goto outer;
                        }
                    }
                        
                    outer:
                    continue;
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    // TextBox1.Text += obs1[i, j].ToString("F") + ":"+ch[i,j].ToString()+" -- ";
                }
                // TextBox1.Text += "\n";
            }


            //string text = txttext.Text.Trim();

            Bitmap bitmap = new Bitmap(1200, 300, PixelFormat.Format64bppPArgb);

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

            Bitmap img11 = (Bitmap)System.Drawing.Image.FromFile("G:/AA.jpg", true);
            Bitmap img12 = (Bitmap)System.Drawing.Image.FromFile("G:/AC.jpg", true);
            Bitmap img13 = (Bitmap)System.Drawing.Image.FromFile("G:/AG.jpg", true);
            Bitmap img14 = (Bitmap)System.Drawing.Image.FromFile("G:/AT.jpg", true);
            Bitmap img15 = (Bitmap)System.Drawing.Image.FromFile("G:/CA.jpg", true);
            Bitmap img16 = (Bitmap)System.Drawing.Image.FromFile("G:/CC.jpg", true);
            Bitmap img17 = (Bitmap)System.Drawing.Image.FromFile("G:/CG.jpg", true);
            Bitmap img18 = (Bitmap)System.Drawing.Image.FromFile("G:/CT.jpg", true);
            Bitmap img19 = (Bitmap)System.Drawing.Image.FromFile("G:/GA.jpg", true);
            Bitmap img20 = (Bitmap)System.Drawing.Image.FromFile("G:/GC.jpg", true);
            Bitmap img21 = (Bitmap)System.Drawing.Image.FromFile("G:/GG.jpg", true);
            Bitmap img22 = (Bitmap)System.Drawing.Image.FromFile("G:/GT.jpg", true);
            Bitmap img23 = (Bitmap)System.Drawing.Image.FromFile("G:/TA.jpg", true);
            Bitmap img24 = (Bitmap)System.Drawing.Image.FromFile("G:/TC.jpg", true);
            Bitmap img25 = (Bitmap)System.Drawing.Image.FromFile("G:/TG.jpg", true);
            Bitmap img26 = (Bitmap)System.Drawing.Image.FromFile("G:/TT.jpg", true);


            k = 1;
            z = 275;
            x = 100;

            if (m > 11 && m <= 15)
            {
                x = (int)(100 - (Math.Sqrt(m - 8 - 1) * 10));
                f = x;
            }
            else if (m > 15 && m <= 18)
            {
                x = (int)(100 - (Math.Sqrt(m - 8) * 12));
                f = x;
            }
            else if (m > 18 && m <= 22)
            {
                x = (int)(100 - (Math.Sqrt(m - 8) * 13));
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
                        if (e2 == "1")
                        {
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
                        else if (e2 == "2")
                        {
                            if (ch[j, i] == 0)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img11, src);
                            }
                            else if (ch[j, i] == 1)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img12, src);
                            }
                            else if (ch[j, i] == 2)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img13, src);
                            }
                            else if (ch[j, i] == 3)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img14, src);
                            }
                            else if (ch[j, i] == 4)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img15, src);
                            }
                            else if (ch[j, i] == 5)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img16, src);
                            }
                            else if (ch[j, i] == 6)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img17, src);
                            }
                            else if (ch[j, i] == 7)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img18, src);
                            }
                            else if (ch[j, i] == 8)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img19, src);
                            }
                            else if (ch[j, i] == 9)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img20, src);
                            }
                            else if (ch[j, i] == 10)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img21, src);
                            }
                            else if (ch[j, i] == 11)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img22, src);
                            }
                            else if (ch[j, i] == 12)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img23, src);
                            }
                            else if (ch[j, i] == 13)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img24, src);
                            }
                            else if (ch[j, i] == 14)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img25, src);
                            }
                            else if (ch[j, i] == 15)
                            {
                                RectangleF src = new RectangleF(right, down, x, y);
                                graphics.DrawImage(img26, src);
                            }

                        }

                }
                }

                graphics.DrawString(k.ToString(), font2, new SolidBrush(Color.FromArgb(0, 0, 0)), right + (x / 2), 280, sf);
                k++;
                z = 275;
                down = 0;
                right += x;
            }


            int t = (int)(z - 2 * f);
            int z1 = (int)(z);
            int t1 = ((z1 - t) / 2) + t;
            int t2 = (t1 - t) / 2 + t;
            int z2 = (z1 - t1) / 2 + t1;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, t), new Point(65, t));
            if (e2 == "1")
            {
                graphics.DrawString("2", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, t, sf);
                graphics.DrawString("1", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, t1, sf);
            }
            else if(e2 == "2")
            {
                graphics.DrawString("4", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, t, sf);
                graphics.DrawString("2", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, t1, sf);
            }

            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, t1), new Point(65, t1));
            graphics.DrawString("0", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, z1, sf);
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, z1), new Point(65, z1));
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, z1), new Point(70, t));
            graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, z1), new Point(right, z1));
            //graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, 70), new Point(600, 70));

            if (e2 == "2")
            {
                graphics.DrawString("3", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, t2, sf);
                graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, t2), new Point(65, t2));
                graphics.DrawString("1", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 60, z2, sf);
                graphics.DrawLine(new Pen(Color.Gray, 2), new Point(70, z2), new Point(65, z2));
            }


            //graphics.RotateTransform(90F, MatrixOrder.Append);
            // graphics.TranslateTransform(40, 170);
            //graphics.RotateTransform(90);
            graphics.DrawString("bits", font2, new SolidBrush(Color.FromArgb(0, 0, 0)), 40, t1, sf);








            graphics.Flush();
            graphics.Dispose();
            string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".jpg";
            bitmap.Save(Server.MapPath("~/weblogo_image/") + fileName, ImageFormat.Jpeg);
            imgtext.ImageUrl = "~/weblogo_image/" + fileName;
            imgtext.Visible = true;


            graphics.Dispose();
            bitmap.Dispose();


            //--------------------------------------------------------------

            TextBox1.Text = Application["user"].ToString();
        }
    }
}