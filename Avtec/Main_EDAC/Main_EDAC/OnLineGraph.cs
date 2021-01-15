using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Diagnostics;
using Automation.BDaq; 

namespace Logger
{
    public partial class OnLineGraph : Form       
    {
        private MathInterval rangeY = new MathInterval();
        private MathInterval rangeX = new MathInterval();/// <summary>
        /// ////////////graph declaration///
        double[] m_graphScaled = new double[5];
        ListViewItem m_firstItem = new ListViewItem();
        ListViewItem m_secondItem = new ListViewItem();
        double ip, ip1 = 00.00;

        graph m_simGraph = null;
        
        public OnLineGraph()
        {
            InitializeComponent();
        }

        private void OnLineGraph_Load(object sender, EventArgs e)
        {
            ////////graph/////
            m_simGraph = new graph(pictureBox.Size, pictureBox);
            m_simGraph.InitGraph(5, 1);
            ConfigureGraph1();
            //fill_Combo(); 

            //InitLitView();
            //int Rn = 0;
            //    while (Rn < 125)
            //    {
            //       listBox1.Items.Add(Global.PNo[Rn].ToString() + "   " +Global.PSName[Rn].ToString());  
            //       Rn += 1;
            //    }            
        }
        //private void fill_Combo()
        //{
        //    for (int i = 0; i <= 75; i++)
        //    {
        //        comboBox1.Items.Add(Global.PNo[i] + " " + Global.PSName[i]);
        //        comboBox2.Items.Add(Global.PNo[i] + " " + Global.PSName[i]);
        //        comboBox3.Items.Add(Global.PNo[i] + " " + Global.PSName[i]);
        //        comboBox4.Items.Add(Global.PNo[i] + " " + Global.PSName[i]);
        //        comboBox5.Items.Add(Global.PNo[i] + " " + Global.PSName[i]);
        //    }
        //    comboBox1.SelectedIndex = 0;
        //    comboBox2.SelectedIndex = 1;
        //    comboBox3.SelectedIndex = 7;
        //    comboBox4.SelectedIndex = 10;
        //    comboBox5.SelectedIndex = 13;
        //}

        private void ConfigureGraph()
        {

            rangeX.Type = (int)MathIntervalType.RightClosedBoundary;
            rangeX.Min = 0;
            rangeX.Max = 30;//rangeX.Max is fixed to 10 seconds.
            TimeUnit timeunit = TimeUnit.Second;
            m_simGraph.SetXCoordinate(rangeX, label_XCoordinateMin, label_XCoordinateMax, timeunit);
            rangeY.Max = 10; // Convert.ToDouble(numericUpDown8.Value);
            rangeY.Min = 10; //Convert.ToDouble(numericUpDown7.Value);

            ValueUnit unit = (ValueUnit)(-1); // Don't show unit in the label.

            //if (radioButton7.Checked == true)
            //{
            //    rangeY.Max = 3;
            //    rangeY.Min = 0;
            //}
            //else if (radioButton8.Checked == true)
            //{
            //    rangeY.Max = 10;
            //    rangeY.Min = 0;
            //}
            m_simGraph.SetYCoordinate(rangeY, label_YCoordinateMax, label_YCoordinateMin, label_YCoordinateMiddle, unit);

            m_simGraph.clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            tmrGraph.Stop();
            this.Close(); 
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           tmrGraph.Start();

        }
        private void ConfigureGraph1()
        {
            rangeX.Type = (int)MathIntervalType.RightClosedBoundary;
            rangeX.Min = 0;
            rangeX.Max = 30;//rangeX.Max is fixed to 10 seconds.
            TimeUnit timeunit = TimeUnit.Second;
            m_simGraph.SetXCoordinate(rangeX,label_XCoordinateMin,label_XCoordinateMax, timeunit);
            
            
            rangeY.Max = 10;
            rangeY.Min = 0;
            ValueUnit unit = (ValueUnit)(-1);
            m_simGraph.SetYCoordinate(rangeY,label_YCoordinateMax,label_YCoordinateMin ,label_YCoordinateMiddle, unit);
            m_simGraph.clear();
        }

        private void plot_graph()
        {
            m_simGraph.Plot(m_graphScaled, 5, 1, 960 / 10);

            int interval = 10;
            if (interval > 10)
            {
                tmrGraph.Interval = interval;
            }
        }

        private void tmrGraph_Tick(object sender, EventArgs e)
        {
            if ((double.Parse(Global.GenData[0]) / 2000) <= 0)
            {
               m_graphScaled[0] = m_graphScaled[0];
            }
            else
            {
                m_graphScaled[0] = double.Parse(Global.GenData[0]) / 2000;
            } //*********************
            if ((double.Parse(Global.GenData[1]) / 50) <= 0)
            {
               m_graphScaled[1] = m_graphScaled[1];
            }
            else
            {
                m_graphScaled[1] = double.Parse(Global.GenData[1]) / 50;
            } 
            //**********************
            if ((double.Parse(Global.GenData[22]) / 50) <= 0)
            {
                m_graphScaled[2] = m_graphScaled[2];
            }
            else
            {
                m_graphScaled[2] = double.Parse(Global.GenData[22]);
            }
            //**********************
            if ((double.Parse(Global.GenData[25]) / 20) <= 0)
            {
                m_graphScaled[3] = m_graphScaled[3];
            }
            else
            {
                m_graphScaled[3] = double.Parse(Global.GenData[25]) / 20;
            }//********************************

            if ((double.Parse(Global.GenData[40]) / 100) <= 0)
            {
                m_graphScaled[4] = m_graphScaled[4];
            }
            else
            {
                m_graphScaled[4] = double.Parse(Global.GenData[40]) / 100;
            }
           
           
            plot_graph();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrGraph.Stop(); 
        }

       





    }
}
