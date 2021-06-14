using System;
using System.Timers;
using System.Windows;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace test1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        // public string[] Lines { get; set; }
        //public class StreamReader : TextReader;
        protected void Button1_Click(object sender, EventArgs e)
        {
            //MsgBox("successful process ..");
            
            main();
        }
        public void main() { 

            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            
            int i, i1, k,k2, l=0, j, n, nu, r, r1,r2, max, a=0, rnd, f, dir=0, logo=0;
            int lml, rml, ml, mls, g, ming, maxg, selseq, z = 0, tf = 30, h=1;
            string md;
            char ch1;

            if (CheckBox2.Checked)
                logo = 1;
            else
                logo = 0;

            if (radRiskLevel.SelectedValue == "1")
                f = 1;
            else
                f = 2;
                 

            md= RadioButtonList1.SelectedValue;


            if (RadioButtonList2.SelectedValue == "1")
             h = 1;
            else
             h = 2;
            

            if (CheckBox1.Checked == true)
                dir = 1;
            else
                dir = 0;

           
            r1 = 0;
            n = 0;
            double sum = 0;
            string subnuc=" ";
            bool b = false, b1=false;

            char[,] seqdata = new char[1000, 2000];
            char[,] seqdatarev = new char[2000, 2000];
            char[,] seq1 = new char[2000, 50];
            char[,] seq2 = new char[30000, 200];
            char[,] seq2rev = new char[30000, 200];
            char[,] seq3 = new char[1000, 2000];
            char[,] seq3rev = new char[2000, 2000];
            char[,] state = new char[1000,2000];
            char[,] statefinal = new char[1000,10];
            char[] match = new char[50];

            int[,] positionl = new int[30000, 100];
            int[,] positionr = new int[30000, 100];
            int[,] positionlrev = new int[30000, 100];
            int[,] positionrrev = new int[30000, 100];


            lml = Convert.ToInt16(DropDownList1.SelectedItem.Value);
            rml = Convert.ToInt16(DropDownList2.SelectedItem.Value);
            ming = Convert.ToInt16(DropDownList3.SelectedItem.Value);
            maxg = Convert.ToInt16(DropDownList4.SelectedItem.Value);
            tf = Convert.ToInt16(DropDownList5.SelectedItem.Value);

            string[] strArr = TextBox1.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
            TextBox4.Text = "direction" + dir.ToString() + "\nLength of Left Motif:" + lml.ToString() + "\tLength of Right Motif:" + rml.ToString()+"\nMinimum Gap:"+ming+ "\tMaximum Gap:" + maxg;

            r2 = strArr.Length;

            if (strArr[r2 - 1].Length<2)
                r2--;
             
          
            if (r2 > 500)
                r2 = 500;

            if (f == 2)
                r = r2;
            else
                r = r2 / 2;

            selseq = z;
            mls = lml + rml;
            ml = lml + rml;

            

            if (md == "1" || md=="3")
                nu = 4;
            else if (md == "2")
            {
                nu = 16;
                ml = ml - 1;
            }
            else
                nu = 4;

            int[] lenstr = new int[r*2];
            int[] lenstrs = new int[r*2];
            int[] dilenstr = new int[r*2];

            if(maxg!=0 && maxg < ming)
            {
                MsgBox("Error, Maximum Gap Length should be equal or bigger than the Minimum Gap Length.");
                b1 = true;
            }

            if((rml>0) && (ming==0 || maxg==0))
            {
                MsgBox("Plese select Gap Length.");
                b1 = true;
            }

            if (maxg > ming)
                k2 = mls + maxg;
            else
                k2 = mls + ming;

            if (f == 2)
            { 
               for (i = 0; i < r; i++)
               {  
                   lenstr[i] = strArr[i].Length;
                    if (lenstr[i] < k2)
                    {
                        MsgBox("Error, your sequences data is less than motif length + gap length, please set again.");
                        b1 = true;
                    }
                    
               }
            }
            if (f == 1)
            {
                k = 0;
                for (i = 0; i < r2; i++)
                {
                    if (i % 2 == 1)
                    {
                        lenstr[k] = strArr[i].Length;
                        if (lenstr[k] < k2)
                        {
                            MsgBox("Error, the your sequence data is less than motif length + gap length.");
                            b1 = true;
                        }
                        //TextBox4.Text += Convert.ToString(lenstr[k]) + " ";
                        k++;
                    }
                    else
                    {
                        dilenstr[k] = strArr[i].Length;
                    }
                }
            }

            if (logo == 1) { 
                ml = lenstr[1];
                if (md == "2")
                   ml--;
            }

            for (i = 0; i < r; i++)
            {
                if (md == "2")
                    lenstrs[i] = lenstr[i]-1;
                else if(md=="1" || md == "3")
                    lenstrs[i] = lenstr[i];
            }

            for (i = 0; i < r; i++)
            {
                if (md == "2")
                    lenstrs[i+r] = lenstr[i];
                else if (md == "1" || md == "3")
                    lenstr[i+r] = lenstr[i];
            }



            TextBox2.Text += lml.ToString() + "\n" + rml.ToString() + "\n" + ming.ToString() + "\n" 
                + maxg.ToString() + "\n" + md.ToString()+"\n"+f.ToString();

            

            int[,] rndnuml = new int[2000, 100];
            int[,] rndnumr = new int[2000, 100];
            int[,] initialmotif = new int[1000, 2];
            double[,] freq = new double[nu, ml];
            double[,] freq1 = new double[nu, ml];
            double[,] freq1rev = new double[nu, ml];
            double[] bg = new double[nu];
            double[] bgrev = new double[nu];
            int[] numnuc = new int[nu];
            int[] numnucrev = new int[nu];
            int[] numnuc2 = new int[nu];
            double[] score1 = new double[30000];
            double[] score1rev = new double[30000];
            double[] entropy = new double[2000];
            double[] entropytotal = new double[100];
            double[] testi = new double[1000];
            double[,] scorefinal = new double[r*2,100];
            char[,] ran1 = new char[1000, 100];
            char[,] finalmotif = new char[1000, 50];
            string[] diseq = new string[r];
            string[] da = new string[nu];

            if (md == "1" || md == "3")
            {
                da[0] = "A"; da[1] = "C"; da[2] = "G"; da[3] = "T";
            }
            else if(md == "2")
            {
                da[0] = "AA"; da[1] = "AC"; da[2] = "AG"; da[3] = "AT";
                da[4] = "CA"; da[5] = "CC"; da[6] = "CG"; da[7] = "CT";
                da[8] = "GA"; da[9] = "GC"; da[10] = "GG"; da[11] = "GT";
                da[12] = "TA"; da[13] = "TC"; da[14] = "TG"; da[15] = "TT";
            }

            //textmining();
            //selectrandom();
            //startlocation();

            //step1();
            //step2();
            //step3();

            if (logo==1)
            {
                textmining();
                weblogo();
            }
            if (logo == 0)
            {
                if ((b1 == false))
                {
                    textmining();
                    selectrandom();
                    startlocation();
                    step4();
                    chart();
                }
                else
                    MsgBox("error");
            }
            if (h == 1)
            {
                secondmotif();
            }
                        //for future add 3-nucleotide and top 3 motif and find seem motif in sequence ....


            //----------------------------------------------------------------------------
            void textmining()
            {
                string ch;
                bool w=false;
                max = 0;
                for (i = 0; i < nu; i++)
                {
                    numnuc[i] = 0;
                    numnucrev[i] = 0;
                }

                    if (f == 2)
                {
                    for (i = 0; i < r; i++)
                    {
                        
                        for (j = 0; j < lenstr[i]; j++)
                        {

                            {
                                if (strArr[i][j] == 'a' || strArr[i][j] == 'A')
                                {
                                    seqdata[i, j] = 'A';

                                }
                                else if (strArr[i][j] == 'c' || strArr[i][j] == 'C')
                                {
                                    seqdata[i, j] = 'C';

                                }
                                else if (strArr[i][j] == 'g' || strArr[i][j] == 'G')
                                {
                                    seqdata[i, j] = 'G';

                                }
                                else if (strArr[i][j] == 't' || strArr[i][j] == 'T')
                                {
                                    seqdata[i, j] = 'T';

                                }
                               
                            }

                        }
                    }
                }
                else if (f == 1)
                {
                    k = 0;
                    n = 0;
                    for(i=0; i<r2; i++)
                    {

                        if (i % 2 == 0)
                        {
                            diseq[n] = strArr[i];
                            n++;
                        }
                        else if (i % 2 == 1)
                        {
                            for (j = 0; j < lenstr[k]; j++)
                            {
                                if (strArr[i][j] == 'a' || strArr[i][j] == 'A')
                                {
                                    seqdata[k, j] = 'A';

                                }
                                else if (strArr[i][j] == 'c' || strArr[i][j] == 'C')
                                {
                                    seqdata[k, j] = 'C';

                                }
                                else if (strArr[i][j] == 'g' || strArr[i][j] == 'G')
                                {
                                    seqdata[k, j] = 'G';

                                }
                                else if (strArr[i][j] == 't' || strArr[i][j] == 'T')
                                {
                                    seqdata[k, j] = 'T';

                                }

                            }
                            k++;
                        }                     
                    }
                }
                    /*
             for(i=0; i<r; i++)
                {
                    for(j=0; j < lenstr[i]; j++)
                    {
                        TextBox2.Text += seqdata[i, j];

                    }
                    TextBox2.Text += '\n';
                }
                */
                for (i = 0; i < r; i++)
                {
                    for (j = 0; j < lenstrs[i]; j++)
                    {
                        ch = seqdata[i, j].ToString();
                        if (md == "2")
                            ch += seqdata[i, j + 1].ToString();
                        for (k = 0; k < nu; k++)
                        {
                            if (ch == da[k])
                                numnuc[k] += 1;
                        }
                    }
                }
                //--------------------------Reverce Sequence--------------------------------------

                if (dir == 1)
                {
                    /*
                    for (i = 0; i < r; i++)
                    {
                        k = 0;
                        for (j = 0; j < lenstr[i]; j++)
                        {
                            seqdatarev[i, j] = seqdata[i, j];
                        }
                    }
                    */


                    for (i = 0; i < r; i++)
                    {
                        k = 0;
                        for (j = lenstr[i] - 1; j >= 0; j--)
                        {
                            ch1 = seqdata[i, j];

                            if (ch1 == 'A')
                                ch1 = 'T';
                            else if (ch1 == 'C')
                                ch1 = 'G';
                            else if (ch1 == 'G')
                                ch1 = 'C';
                            else if (ch1 == 'T')
                                ch1 = 'A';

                            seqdatarev[i, k] = ch1;
                            k++;
                        }

                    }



                    for (i = 0; i < r; i++)
                    {
                        for (j = 0; j < lenstrs[i]; j++)
                        {
                            ch = seqdatarev[i, j].ToString();
                            if (md == "2")
                                ch += seqdatarev[i, j + 1].ToString();
                            for (k = 0; k < nu; k++)
                            {
                                if (ch == da[k])
                                    numnucrev[k] += 1;
                            }
                            /*
                            ch = seqdatarev[i + r, j].ToString();
                            if (md == 2)
                                ch += seqdatarev[i + r, j + 1].ToString();
                            for (k = 0; k < nu; k++)
                            {
                                if (ch == da[k])
                                    numnucrev[k] += 1;
                            }*/
                        }
                    }
                    for (i = 0; i < r; i++)
                    {
                        for (j = 0; j < lenstrs[i]; j++)
                        {
                            TextBox3.Text += seqdatarev[i, j];
                        }
                        TextBox3.Text += "\n";
                        
                    }

                    for(i=0; i<nu; i++)
                    {
                        TextBox2.Text += i.ToString()+"- " + numnucrev[i].ToString()+"\n";
                    }
                    
                }    }
            //------------------------------------------------------------------

            void weblogo()
            {
                int wl = 0;

                for (i = 0; i < r; i++)
                {
                    if (i < (r - 2))
                    {
                        if (lenstr[i] != lenstr[i + 1])
                            wl = 1;
                    }

                    for (j = 0; j < (lenstr[i]); j++)
                    {
                        finalmotif[i, j] = seqdata[i, j];
                    }  
                }
                if (wl == 0)
                {
                  
                    chart();
                }
            }
           
            //------------------------------------------------------------------
            void selectrandom()
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                int y, x = rml + maxg + 3;

                for (i = 0; i < r; i++)
                {
                    rndnuml[i, r1] = rand.Next(0, lenstr[i] - x);
                }

                for (i = 0; i < r*2; i++)
                {
                    y = rndnuml[i, r1] + lml;
                    rndnumr[i, r1] = rand.Next(y + ming, y + maxg + 1 );
                    // TextBox3.Text += rndnuml[i, r1].ToString() + "  ";
                    //  TextBox3.Text += rndnumr[i, r1].ToString() + " ";
                    // TextBox3.Text += ((rndnumr[i, r1] - rndnuml[i, r1]) - lml).ToString();
                    // TextBox3.Text += '\n';
                }

            }
            //-----------------------------------------------------------------------
            void startlocation()
            {
                for (i = 0; i < r; i++)
                {
                    k = 0;
                    rnd = rndnuml[i, r1];
                    for (j = rnd; j < (rnd + lml); j++)
                    {
                        ran1[i, k] = seqdata[i, j];
                        
                        k++;
                    }
                    rnd = rndnumr[i, r1];
                    for (j = rnd; j < (rnd + rml); j++)
                    {
                        ran1[i, k] = seqdata[i, j];
                        k++;
                    }
                }
      

            }

            //-------------------------------------------------------------

            void count(char[,] test1)
            {

                for (i = 0; i < nu; i++)
                {
                    numnuc2[i] = 0;
                    for (j = 0; j < ml; j++)
                    {
                        freq[i, j] = 0;
                    }
                }

              //  if (dir == 0)
              //  {
                    for (i = 0; i < r; i++)
                    {
                        for (j = 0; j < ml; j++)
                        {
                            subnuc = test1[i, j].ToString();
                            if (md == "2")
                                subnuc += test1[i, j + 1].ToString();


                            for (k = 0; k < nu; k++)
                            {
                                if (da[k] == subnuc)
                                {
                                    numnuc2[k]++;
                                    freq[k, j]++;
                                }
                            }
                        }
                    }
               // }
                 if (dir == 1000)
                {
                    for (i = 0; i < r*2; i++)
                    {
                        for (j = 0; j < ml; j++)
                        {
                            subnuc = test1[i, j].ToString();
                            if (md == "2")
                                subnuc += test1[i, j + 1].ToString();


                            for (k = 0; k < nu; k++)
                            {
                                if (da[k] == subnuc)
                                {
                                    numnuc2[k]++;
                                    freq[k, j]++;
                                }
                            }
                        }
                    }
                }

           
            }
            //-------------------------------------------------------------
            void PPM()
            {

                for (i = 0; i < nu; i++)
                {
                    for (j = 0; j < ml; j++)
                        freq1[i, j] = (float)(freq[i, j] / (r + 1));

                }
            }
            //-------------------------------------------------------------

            void selectseq()
            {
                //if (dir == 0)
                {
                    for (i = 0; i < r; i++)
                    {
                        k = 0;
                        rnd = rndnuml[i, r1];
                        for (j = rnd; j < (rnd + lml); j++)
                        {
                            seq3[i, k] = seqdata[i, j];
                            k++;
                        }
                        rnd = rndnumr[i, r1];
                        for (j = rnd; j < (rnd + rml); j++)
                        {
                            seq3[i, k] = seqdata[i, j];
                            k++;
                        }
                    }

                    for (j = 0; j < mls; j++)
                        seq3[selseq, j] = '*';
                }

                //------------Reverse Sequence-------------------- 
                
                if (dir == 1000)
                {
                    for (i = 0; i < r*2; i++)
                    {
                        k = 0;
                        rnd = rndnuml[i, r1];
                        for (j = rnd; j < (rnd + lml); j++)
                        {
                            seq3rev[i, k] = seqdatarev[i, j];
                            k++;
                        }
                        rnd = rndnumr[i, r1];
                        for (j = rnd; j < (rnd + rml); j++)
                        {
                            seq3rev[i, k] = seqdatarev[i, j];
                            k++;
                        }
                    }
                    for (j = 0; j < mls; j++)
                        seq3rev[selseq, j] = '*';

                }


               

            }

            //-------------------------------------------------------------

            void background()
            {
                int[] test = new int[nu];
                string ch;

                //if (dir == 0)
                {
                    for (i = 0; i < nu; i++)
                    {
                        test[i] = 0;
                        bg[i] = 0;
                    }

                    for (i = 0; i < lenstrs[z]; i++)
                        for (j = 0; j < nu; j++)
                        {
                            ch = seqdata[z, i].ToString();

                            if (md == "2")
                                ch += seqdata[z, i + 1].ToString();

                            if (ch == da[j])
                                test[j]++;
                        }

                    //n++;
                    sum = 0;
                    count(seq3);
                    for (i = 0; i < nu; i++)
                    {
                        bg[i] = numnuc[i] - numnuc2[i] - test[i];
                        sum = sum + bg[i];
                    }



                    for (i = 0; i < nu; i++)
                    {
                        if (md == "1" || md == "3")
                            bg[i] = (bg[i] + 0.25) / sum;
                        else if(md=="2")
                            bg[i] = (bg[i] + 0.625) / sum;

                        for (j = 0; j < ml; j++)
                            if (md == "1" || md == "3")
                                freq1[i, j] = (double)(freq[i, j] + 0.25) / (r);
                            else if (md == "2")
                                freq1[i, j] = (double)(freq[i, j] + 0.0625) / (r);

                    }
                }

      
                //------------------Reverse sequence--------------------------
                
                 if (dir == 1000)
                { 
                for (i = 0; i < nu; i++)
                {
                    test[i] = 0;
                    bgrev[i] = 0;
                }

                for (i = 0; i < lenstrs[z]; i++)
                    for (j = 0; j < nu; j++)
                    {
                        ch = seqdatarev[z, i].ToString();

                        if (md == "2")
                            ch += seqdatarev[z, i + 1].ToString();

                        if (ch == da[j])
                            test[j]++;
                    }

                sum = 0;
                count(seq3rev);
                for (i = 0; i < nu; i++)
                {
                    bgrev[i] = numnucrev[i] - numnuc2[i] - test[i];
                    sum = sum + bgrev[i];
                }

           

                    for (i = 0; i < nu; i++)
                    {
                        if (md == "1" || md == "3")
                            bgrev[i] = (bgrev[i] + 0.25) / sum;
                        else if (md == "2")
                            bgrev[i] = (bgrev[i] + 0.625) / sum;


                        for (j = 0; j < ml; j++)
                            if (md == "1" || md == "3")
                                freq1rev[i, j] = (double)(freq[i, j] + 0.25) / (r);
                            else if (md == "2")
                                freq1rev[i, j] = (double)(freq[i, j] + 0.0625) / (r);

                    }
                }

            }

            //-------------------------------------------------------------------------

            void subseqlength()
            {
                a = 0;
                for (i = ming; i <= maxg; i++)
                {
                    for (l = 0; l < (lenstr[z] - mls - i); l++)
                    {
                        k = 0;
                        for (j = 0; j < mls; j++)
                            if (j < lml)
                                seq2[a, j] = seqdata[z, l + j];
                            else
                                seq2[a, j] = seqdata[z, l + j + i];


                        positionl[a, r1] = l;
                        positionr[a, r1] = l + lml + i;
                        a++;
                    }

                }
           
            }

            //-------------------------------------------------------------------------

            void subseqlengthrev()
            {
                a = 0;
                for (i = ming; i <= maxg; i++)
                {
                    for (l = 0; l < (lenstr[z] - mls - i); l++)
                    {
                        k = 0;
                        for (j = 0; j < mls; j++)
                            if (j < lml)
                                seq2rev[a, j] = seqdatarev[z, l + j];
                            else
                                seq2rev[a, j] = seqdatarev[z, l + j + i];


                        positionlrev[a, r1] = l;
                        positionrrev[a, r1] = l + lml + i;
                        a++;
                    }

                }

            }

            //---------------------------------------------------------------------------

            void score()
            {
                double div, maxscore;
                sum = 0;
                int k1=0;
               // for (i = 0; i < nu; i++)
               //     TextBox2.Text += "\n" + da[i] + ":" + bg[i];

                for (i = 0; i < a; i++)
                {
                    score1[i] = 0;
                    div = 0;
                    for (j = 0; j < ml; j++)
                    {
                        subnuc = seq2[i, j].ToString();
                        if (md == "2")
                            subnuc += seq2[i, j + 1].ToString();

                        for (k = 0; k < nu; k++)
                        {
                            if (subnuc == da[k])
                            {
                                //TextBox4.Text += freq1[k, j].ToString("F");
                                div = div + Math.Log(bg[k]);
                                score1[i] = score1[i] + Math.Log(freq1[k, j]);
                            }

                        }

                       // if (j < ml - 1)
                        //    TextBox4.Text += "+";
                       // else
                        //    TextBox4.Text += " / " + div.ToString("F");
                    }
                    score1[i] = score1[i] / div;
                    //TextBox4.Text += " = " + score1[i].ToString("F") + "\n";
                    sum = sum + score1[i];
                }
                
                maxscore = score1[0];
                for (i = 1; i < a; i++)
                    if (maxscore > score1[i])
                    {
                        maxscore = score1[i];
                        k1 = i;
                    }
               // TextBox3.Text += "\n" + "MAX Score:" + maxscore.ToString() + "  Site:" + k;
                rndnuml[z, r1] = positionl[k1, r1];
                rndnumr[z, r1] = positionr[k1, r1];
                state[z, r1] = 'P';
            }

            //---------------------------------------------------------------------------

            void scorerev()
            {
                double div,div1, maxscore,maxscorerev,sumrev=0;
                string subnuc1;
                sum = 0;
                int k1 = 0, k1rev = 0;
                // for (i = 0; i < nu; i++)
                //     TextBox2.Text += "\n" + da[i] + ":" + bg[i];

                for (i = 0; i < a; i++)
                {
                    //score1[i] = 0;
                    score1rev[i] = 0;
                    //div = 0;
                    div1 = 0;
                    for (j = 0; j < ml; j++)
                    {
                        //subnuc = seq2[i, j].ToString();
                        subnuc1 = seq2rev[i, j].ToString();
                        if (md == "2")
                        {
                            //subnuc += seq2[i, j + 1].ToString();
                            subnuc1 += seq2rev[i, j + 1].ToString();
                        }

                        for (k = 0; k < nu; k++)
                        {
                            if (subnuc == da[k])
                            {
                                //TextBox4.Text += freq1[k, j].ToString("F");
                                //div = div + Math.Log(bg[k]);
                                //score1[i] = score1[i] + Math.Log(freq1[k, j]);
                                div1 = div1 + Math.Log(bgrev[k]);
                                score1rev[i] = score1rev[i] + Math.Log(freq1rev[k, j]);
                            }
                        }

                        // if (j < ml - 1)
                        //    TextBox4.Text += "+";
                        // else
                        //    TextBox4.Text += " / " + div.ToString("F");
                    }
                    //score1[i] = score1[i] / div;
                    score1rev[i] = score1rev[i] / div1;
                     //TextBox4.Text += " = " + score1[i].ToString("F") + "\n";
                    //sum = sum + score1[i];
                    sumrev = sumrev + score1rev[i];
                    //TextBox3.Text += " = " + score1rev[i].ToString("F") + "\n";
                }

                //maxscore = score1[0];
                maxscorerev = score1rev[0];
                /*
                for (i = 1; i < a; i++)
                    if (maxscore > score1[i])
                    {
                        maxscore = score1[i];
                        k1 = i;
                    }*/
                for (i = 1; i < a; i++)
                    if (maxscorerev > score1rev[i])
                    {
                        maxscorerev = score1rev[i];
                        k1rev = i;
                    }
                scorefinal[z, r1] = maxscorerev;
                /*
                if (maxscore < maxscorerev)
                {
                    rndnuml[z, r1] = positionl[k1, r1];
                    rndnumr[z, r1] = positionr[k1, r1];
                    state[z, r1] = 'P';
                }
                else
                {*/
                
                    rndnuml[z, r1] = positionlrev[k1rev, r1];
                    rndnumr[z, r1] = positionrrev[k1rev, r1];
                if (z < r)
                    state[z, r1] = 'P';
                else
                    state[z, r1] = 'N';
               
                //}
            }

            //---------------------------------------------------------------------------

            void PFM()
            {
                //if (dir == 1)
                {
                   // n = r;
                   // for (i = 0; i < r; i++)
                    {
                     //   if (scorefinal[i, r1] > scorefinal[i + r, r1])
                        {
                      //      rndnuml[i, r1] = rndnuml[i + r, r1];
                       //     state[i, r1] = 'N';
                        }
                    }
                }
                //else
                   // n = r;

                

                    for (j = 0; j < r; j++)
                    {
                        k = 0;
                        for (i = rndnuml[j, r1]; i < rndnuml[j, r1] + lml; i++)
                        {
                        if (state[j, r1] == 'P')
                            seq1[j, k] = seqdata[j, i];
                        else if(state[j,r1]=='N')
                            seq1[j, k] = seqdatarev[j, i];
                        k++;
                        }

                        for (i = rndnumr[j, r1]; i < rndnumr[j, r1] + rml; i++)
                        {
                        if (state[j, r1] == 'P')
                            seq1[j, k] = seqdata[j, i];
                        else if (state[j, r1] == 'N')
                            seq1[j, k] = seqdatarev[j, i];
                        k++;
                        }

                    }

                    count(seq1);
                    //PPM();
                    

                    for (i = 0; i < nu; i++)
                    {
                        for (j = 0; j < ml; j++)
                            if (md == "1" || md == "3")
                                freq1[i, j] = (double)(freq[i, j] + 0.25) / (r);
                            else if (md == "2")
                            freq1[i, j] = (double)(freq[i, j] + 0.0625) / (r);
                    }

                    for (i = 0; i < ml; i++)
                    {
                        entropy[i] = 0;
                        for (j = 0; j < nu; j++)
                            entropy[i] = entropy[i] + (freq1[j, i] * Math.Log(freq1[j, i]));
                        entropy[i] = entropy[i] * (-1);
                    }
                    entropytotal[r1] = 0;
                    for (i = 0; i < ml; i++)
                        entropytotal[r1] = entropytotal[r1] + entropy[i];

                    TextBox2.Text += "\n" + "Entropy:" + entropytotal[r1];
                    
            }

            //---------------------------------------------------------------------------

            void step1()
            {
                selseq = z;
                selectseq();
                background();  
                subseqlength();
                score();

            }

            //---------------------------------------------------------------------------

            void step2()
            {
                if (md == "3")
                {
                    //z = 0;
                    while (z < max)
                    {
                        r = 4;
                        step1();
                        z++;
                    }
                }
                else { 
                z = 0;
               
                    while (z < r)
                    {
                        step1();
                        z++;
                    }
                }

                PFM();
            }

            //---------------------------------------------------------------------------

            void step3()
            {
                TextBox2.Text += "\n TEST \n";
                double f1, f2, f3 = 0;
                b = false;
                int x2 = 0, temp1 = 0;

                while ((b == false) && (temp1 < 11))
                {

                    step2();
                    f2 = entropytotal[r1];
                    f1 = Math.Abs(f2 - f3);
                    if (f1 < 0.000000001)
                    {
                        b = true;
                        x2++;
                        TextBox2.Text += "\n" + "f1:" + f2.ToString() + "  f2:" + f3.ToString();
                        testi[r1] = f2;

                    }
                    else
                    {
                        // x2 = temp2;
                        temp1++;
                        f3 = f2;
                    }
                }
                if (temp1 > 9)
                {
                    testi[r1] = f3;
                    TextBox2.Text += "\n more than 10 step \n";
                }




            }

            //---------------------------------------------------------------------------

            void step4()
            {
                
                if (md == "3")
                {
                    TextBox2.Text += "test machine learning";
                    z = 0;
                    max = 2;
                    step3();
                    z = 2;
                    max = 4;
                    step3();
                    sum = testi[0];
                    l = 0;
                    r = 4;
                }
                else
                {
                    for (i1 = 0; i1 < tf; i1++)
                    {

                        z = 0;
                        step3();
                        r1++;
                        TextBox2.Text += "\n" + "**New Random Number** \n";
                        selectrandom();

                    }

                    sum = testi[0];
                    l = 0;

                    TextBox4.Text += "\n Entropy:\n";
                    for (i = 0; i < tf; i++)
                    {
                        TextBox4.Text += (i + 1).ToString() + "- " + testi[i].ToString("F") + "\n";
                        if (testi[i] < sum)
                        {
                            sum = testi[i];
                            l = i;
                        }

                    }
                }
                
              
                TextBox4.Text += "\n Minimum Entropy is:"+sum.ToString("0.###")+"\n\n";

                for (i = 0; i < r; i++)
                {
                    initialmotif[i, 0] = rndnuml[i, l];
                    initialmotif[i, 1] = rndnumr[i, l];
                    statefinal[i, 0] = state[i, l];
                }

                

                for (i = 0; i < r; i++)
                {
                    k = 0;
                    for (j = initialmotif[i, 0]; j < (initialmotif[i, 0] + lml); j++)
                    {
                        
                            finalmotif[i, k] = seqdata[i, j];
                        
                        k++;
                    }
                    for (j = initialmotif[i, 1]; j < (initialmotif[i, 1] + rml); j++)
                    {
                        
                            finalmotif[i, k] = seqdata[i, j];
                        
                        k++;
                    }
                }

                count(finalmotif);
                if (dir == 1)
                {

                    for (i = 0; i < ml; i++)
                    {
                        k =(int) freq[0, i];
                        l = 0;
                        for (j = 0; j < nu; j++)
                        {
                            if (freq[j, i] > k)
                            {
                                k = (int)freq[j, i];
                                l = j;
                            }

                        }
                        if (l == 0)
                        {
                            match[i] = 'A';
                        }
                        else if (l == 1)
                        {
                            match[i] = 'C';
                        }
                        else if (l == 2)
                        {
                            match[i] = 'G';
                        }
                        else if (l == 3)
                        {
                            match[i] = 'T';
                        }
                    }

                    int[] degree = new int[r];
                    int[] degreerev = new int[r];
                    int[] degree2 = new int[1000];
                    int i2, k3, j2, max2 = 0, l2 = 0; ;



                    for (i = 0; i < r; i++)
                    {
                        degree[i] = 0;
                        for (j = 0; j < ml; j++)
                        {
                            if (match[j] == finalmotif[i, j])
                                degree[i]++;
                        }
                    }


                    z = 0;
                    r1 = 0;


                    for (i2 = 0; i2 < r; i2++)
                    {
                        z = i2;
                        r1 = 0;
                        l2 = 0;
                        max2 = 0;
                        subseqlengthrev();
                        for (k3 = 0; k3 < a; k3++)
                        {

                            degree2[k3] = 0;
                            for (j2 = 0; j2 < ml; j2++)
                            {
                                if (match[j2] == seq2rev[k3, j2])
                                    degree2[k3]++;
                            }
                            if (max2 < degree2[k3])
                            {
                                max2 = degree2[k3];
                                l2 = k3;
                            }
                           // degreerev[k3] = max2;
                        }
                        TextBox3.Text += i2.ToString() + "-" + max2.ToString() + "\n";

                        if (max2 > degree[i2])
                        {
                            initialmotif[i2, 0] = positionlrev[l2, 0];
                            initialmotif[i2, 1] = positionrrev[l2, 0];
                            statefinal[i2, 0] = 'N';
                            TextBox3.Text += l2.ToString() + "-L:" + positionlrev[l2, 0] + "   R:" + positionrrev[l2, 0] + "\n";
                        }
                    }

                    for (i = 0; i < r; i++)
                    {
                        TextBox3.Text += i.ToString() + "- " + degree[i].ToString() + "   Rev:" + degreerev[i].ToString() + "\n";
                    }


                    for (i = 0; i < r; i++)
                    {
                        k = 0;
                        for (j = initialmotif[i, 0]; j < (initialmotif[i, 0] + lml); j++)
                        {
                            if (statefinal[i, 0] == 'N')
                            {
                                //    finalmotif[i, k] = seqdata[i, j];
                                //else
                                finalmotif[i, k] = seqdatarev[i, j];
                                k++;
                            }
                        }
                        for (j = initialmotif[i, 1]; j < (initialmotif[i, 1] + rml); j++)
                        {
                            if (statefinal[i, 1] == 'N')
                            {
                                //      finalmotif[i, k] = seqdata[i, j];
                                //   else
                                finalmotif[i, k] = seqdatarev[i, j];
                                k++;
                            }
                        }
                    }
                }
                TextBox4.Text += "\n________________________________________________________________________________________________\n";
                if (rml == 0)
                    TextBox4.Text += "Position of Motif:\t ";
                if (rml > 0)
                {
                    TextBox4.Text += "Position of left Motif:\t ";
                    TextBox4.Text += "Position of Right Motif:";
                }
                TextBox4.Text += "\n";
                for (i = 0; i < r; i++)
                {
                    TextBox4.Text += (initialmotif[i, 0]+1)+ "\t\t\t\t";
                    if(rml>0)
                        TextBox4.Text += (initialmotif[i, 1] + 1);
                    TextBox4.Text += "\n";

                }
                    TextBox4.Text += "\n________________________________________________________________________________________________";
                TextBox4.Text += "\n\n The position weight matrix:\n\n\t";
                for (i = 0; i < ml; i++)
                    TextBox4.Text += (i + 1).ToString() + "\t";
                TextBox4.Text += "\n\t";
                for (i = 0; i < ml; i++)
                    TextBox4.Text +=  "_______"+"\t";
                TextBox4.Text += "\n\n";
                count(finalmotif);

                for(i=0; i<nu; i++) {
                    TextBox4.Text += da[i] + "\t";
                    for(j=0; j<ml; j++)
                    {
                        TextBox4.Text += freq[i, j]+"\t";
                    }
                    TextBox4.Text += "\n";
                }
                TextBox4.Text += "\n_________________________________________________________________________________________________";
                TextBox4.Text += "\n\n";
                if(f==2)
                TextBox4.Text += "Name"+"\t" + "Sequences Motifs"+"\n\n";
                else
                    TextBox4.Text += "Sequences Motifs:" + "\n\n";
                for (i = 0; i < r; i++)
                {
                    if (f == 1)
                        TextBox4.Text += diseq[i] + "\n";
                    else
                        TextBox4.Text += (i + 1).ToString() +"-"+ "\t";
                    for (j = 0; j < mls; j++)
                        TextBox4.Text += finalmotif[i, j].ToString();
                    TextBox4.Text += "\t" + statefinal[i, 0];
                    TextBox4.Text += "\n";
                }

            }

            //---------------------------------------------------------------------------
            void secondmotif()
            {
                int k21, min = 0,k3,k4,k5, l3=0,i3,j3,a1;
                int[] scoremotif1= new int[r];
                int[,] scoremotif2 = new int[1000,1000];
                string[,] secmotif = new string[6000, 2000];

                TextBox2.Text = "TF Second";
                count(finalmotif);
                for (i = 0; i < ml; i++)
                {
                    k = (int)freq[0, i];
                    l = 0;
                    for (j = 0; j < nu; j++)
                    {                       
                        if (freq[j, i] > k)
                        {
                            k21 = (int)freq[j, i];
                            l = j;
                        }

                    }
                    if (l == 0)
                    {
                        match[i] = 'A';
                    }
                    else if (l == 1)
                    {
                        match[i] = 'C';
                    }
                    else if (l == 2)
                    {
                        match[i] = 'G';
                    }
                    else if (l == 3)
                    {
                        match[i] = 'T';
                    }
                }
                //TextBox3.Text += k21.ToString()+"\n";
                TextBox4.Text += "\n------------------Best Mach------------------\n";
                for (i = 0; i < ml; i++)
                    TextBox4.Text += match[i]+"\t";
                TextBox4.Text += "\n";

                for(i=0; i<r; i++)
                {
                    for(j=0; j<ml; j++)
                    {
                        for(k=0; k<nu; k++)
                        {
                            if (finalmotif[i, j].ToString() == da[k])
                            {
                                scoremotif1[i] += (int)freq[k, j];
                                
                            }
                        }
                    }
                    if (i == 0)
                    {
                        l3 = 0;
                        min = scoremotif1[0];
                    }

                    if(min > scoremotif1[i])
                    {
                        min = scoremotif1[i];
                        l3 = i;
                    }

                    TextBox3.Text += i + ":" + scoremotif1[i] + "\n";
                }
                TextBox2.Text += "\n Minimum:" + min+"\n";
                TextBox3.Text += "Min:" + l3.ToString() + "-" + scoremotif1[l3].ToString();
                TextBox3.Text += "\n";

                for (i=0; i<r; i++)
                {
                    k3 = ml + maxg;
                    k4 = lenstrs[i] - k3 - initialmotif[i,0];
                    //for (j=0; j<lenstrs[i]; j++)
                    {
                        //if (initialmotif[i, 0] > k3)
                        {
                            //for(i3=0; i3<initialmotif[i,0]-k3; i3++)
                            {
                                k5 = 0;
                                a = 0;
                                a1 = 0;
                                for (i3 = ming; i3 <= maxg; i3++)
                                {

                                    for (l = 0; l < (lenstr[i] - mls - i3); l++)
                                    {
                                        scoremotif2[i, l] = 0;
                                        k = 0;
                                        if ( l > (initialmotif[i, 1] + rml) || l< (initialmotif[i, 0]-mls-i3))
                                        {
                                            for (j3 = 0; j3 < mls; j3++)
                                            {
                                                if (j3 < lml)
                                                {
                                                    seq2[a, j3] = seqdata[i, l + j3];
                                                    for (k5 = 0; k5 < nu; k5++)
                                                    {
                                                        if (seq2[a, j3].ToString() == da[k5])
                                                        {
                                                            scoremotif2[i, l] += (int)freq[k5, j3];
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    seq2[a, j3] = seqdata[i, l + j3 + i3];
                                                    for (k5 = 0; k5 < nu; k5++)
                                                    {
                                                        if (seq2[a, j3].ToString() == da[k5])
                                                        {
                                                            scoremotif2[i, l] += (int)freq[k5, j3];
                                                        }
                                                    }
                                                }

                                                TextBox3.Text += seq2[a, j3];
                                                secmotif[i, a1] += seq2[a, j3];
                                            }

                                            TextBox3.Text += " - " + scoremotif2[i, l] + "\n";

                                            if (min <= scoremotif2[i, l])
                                            {
                                                TextBox4.Text += "Site:" + (i + 1).ToString() + " Left Position:" + (l + 1).ToString()+", Right Position:"+(l+1+i3+lml).ToString() + " - " + secmotif[i, a1] + " : " + scoremotif2[i, l] + "\n";
                                            }
                                            a1++;
                                            positionl[a, i] = l;
                                            positionr[a, i] = l + lml + i3;
                                            a++;
                                        }   
                                    }

                                }
                            }
                        }
                    }
                }

            }
            //---------------------------------------------------------------------------
          void chart()
            {
                string f1 = md;
                count(finalmotif);
                /*if (f1 == 1) { 
                int[,] gg = new int[,] { { 11, 12, 3, 13, 8, 15 },
                                         {3,8,11,16,0,10 },
                                         {5,2,4,7,10,8 },
                                         {14,8,3,16,10,1 }};
              */
                // else { 
                double[,] gg = new double[nu,ml];
                for (i = 0; i < nu; i++)
                {
                    for (j = 0; j < ml; j++)
                    {
                        gg[i, j] = freq[i, j];
                    }
                }
                TextBox2.Text = TextBox2.Text + "\n---------TEST--------\n";
                for (i = 0; i < nu; i++)
                {
                    for (j = 0; j < ml; j++)
                    {
                        TextBox3.Text = TextBox3.Text + gg[i, j] + " ";
                    }
                    TextBox3.Text = TextBox3.Text + "\n";
                }
                // }
                /*   int[,] gg = new int[,] { { 80, 0, 0, 0, 0, 0 },
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
                Application["user1"] = gg;
                Application["user2"] = f1;
                Application["user3"] = nu;
                Application["user4"] = ml;
                Application["user5"] = logo;
                Application["user"] = TextBox4.Text;

                Response.Redirect("result1.aspx");
                
                

            }
            //---------------------------------------------------------------------------

        }
        void MsgBox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

       

        
    
        /*
        private void bind()
        {
            DataTable tblDatas = new DataTable("Datas");
            DataColumn dc = null;
            dc = tblDatas.Columns.Add("CustomerId", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//
            dc.AutoIncrementSeed = 1;//
            dc.AutoIncrementStep = 1;//
            dc.AllowDBNull = false;
            dc = tblDatas.Columns.Add("Name", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("Count", Type.GetType("System.Int32"));
            DataRow newRow;
            for (int i = 0; i < 6; i++)
            {
                newRow = tblDatas.NewRow();
                newRow["Name"] = "Count" + i.ToString();
                newRow["Count"] = 20 + (i * 2);
                tblDatas.Rows.Add(newRow);
            }
            ViewState["dt"] = tblDatas;
            GridView1.DataSource = tblDatas;
            GridView1.DataBind();

        }*/

        protected void Button3_Click(object sender, EventArgs e)
        {
            

            int[,] gg = new int[,] { { 11, 12, 3, 13, 8, 15 },
                                     {3,8,11,16,0,10 },
                                     {5,2,4,7,10,8 },
                                     {14,8,3,16,10,1 }};

            DataTable tblDatas = new DataTable("Datas");
            DataColumn dc = null;
             dc = tblDatas.Columns.Add("CustomerId", Type.GetType("System.Int32"));
             dc.AutoIncrement = true;//
             dc.AutoIncrementSeed = 1;//
             dc.AutoIncrementStep = 1;//
             dc.AllowDBNull = false;
             dc = tblDatas.Columns.Add("Name", Type.GetType("System.String"));
             dc = tblDatas.Columns.Add("Count1", Type.GetType("System.Int32"));
             dc = tblDatas.Columns.Add("Count2", Type.GetType("System.Int32"));
             DataRow newRow;



            for (int i = 0; i < 6; i++)
            {
                newRow = tblDatas.NewRow();
                newRow["Name"] = "Count" + i.ToString();
                newRow["Count1"] = gg[1,i];
                newRow["Count2"] = gg[2, i];
                tblDatas.Rows.Add(newRow);
            }



            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string[] strArr1 = TextBox5.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
            int i, j,q=0,u=0;
            string num;
            TextBox2.Text = "";
            //TextBox2.Text += strArr1.Length;
            for (i = 0; i < strArr1.Length; i++)
            {
                //if (i % 2 == 0)
                {
                    
                    u = 0;
                    q = 0;
                    TextBox2.Text +="\n";
                    TextBox3.Text += "\n";
                    for (j = 0; j < strArr1[i].Length; j++)
                    {

                        if (strArr1[i][j] == 'A' || strArr1[i][j] == 'C' || strArr1[i][j] == 'G' || strArr1[i][j] == 'T')
                        {
                            //j += 2;
                            TextBox2.Text += strArr1[i][j];
                            //j++;
                            //if (strArr1[i][j] != ' ')
                            //    TextBox2.Text += strArr1[i][j];
                           // j += 1;
                           // if (strArr1[i][j] != ' ')
                           //     TextBox2.Text += strArr1[i][j];
                           // j++;
                        }
                            //if (strArr1[i][j] == ' ' && u==1)
                            {
                           // j += 2;
                           //     TextBox3.Text += strArr1[i][j];
                          //  j++;
                          //  if (strArr1[i][j] != ' ')
                            {
                           //     j++;
                            //    TextBox3.Text += strArr1[i][j];
                            }
                           // u = 0;
                            }
                    

                        // if ((strArr1[i][j] == 'A' || strArr1[i][j] == 'C' || strArr1[i][j] == 'G' || strArr1[i][j] == 'T'))
                        {
                            //if (q == 0)
                            {
                               // TextBox2.Text += j;
                               // q = 1;
                            }
                            //u++;
                        //    TextBox2.Text += j;
                        //    q = 1;
                        }
                        //if((strArr1[i][j] == 'A' || strArr1[i][j] == 'C' || strArr1[i][j] == 'G' || strArr1[i][j] == 'T') && q == 1)
                        {
                        //    u++;
                            //TextBox2.Text += "\n";
                        }
                    }
                    //TextBox3.Text += u;
                }
            }
            TextBox5.Text = "";
        }

        

        

        protected void CheckBox2_CheckedChanged1(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = "1";
            DropDownList2.SelectedValue = "0";
            DropDownList3.SelectedValue = "0";
            DropDownList4.SelectedValue = "0";
            if (CheckBox2.Checked == true)
            {
                RadioButtonList2.Enabled = false;
                DropDownList1.Enabled = false;
                DropDownList2.Enabled = false;
                DropDownList3.Enabled = false;
                DropDownList4.Enabled = false;
                DropDownList5.Enabled = false;
                CheckBox1.Enabled = false;
                Label1.Visible = true;
            }
            else
            {
                RadioButtonList2.Enabled = true;
                DropDownList1.Enabled = true;
                DropDownList2.Enabled = true;
                DropDownList3.Enabled = true;
                DropDownList4.Enabled = true;
                DropDownList5.Enabled = true;
                CheckBox1.Enabled = true;
                Label1.Visible = false;
            }

        }
    }
}    

