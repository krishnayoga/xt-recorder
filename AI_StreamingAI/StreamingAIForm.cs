/*
 * Dibuat Oleh:
 * Ida Bagus Krishna Yoga Utama <email: hello@krishna.my.id >
 * Arbariyanto Mahmud Wicaksono <email: arbariyantom@gmail.com>
 * 
 * Teknik Elektro 2015
 * Departemen Teknik Elektro
 * Universitas Indonesia
 * 
 * Dibuat pada Agustus 2018
 * Untuk BPPT B2TKS Divisi SBPI
*/

/*
 * Configuration waveformAICtrl1:
 * Channel Count = 3;
 * Frequency (Convert Clock Rate) = 8000;
 * Section Length = 32;
 * 
 * Konfigurasi untuk sampling rate 10Hz (10 data per detik)
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI.DataVisualization;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
//ini
using System.Diagnostics;
//itu
using Automation.BDaq;

namespace AI_StreamingAI
{
   public partial class StreamingAIForm : Form
   {
        #region fields  
        double[]        m_dataScaled;
        bool            m_isFirstOverRun = true;
        double          m_xInc;
        int             dataCount = 0;
        double          last_x_0;
        double          last_x_1;
        bool            firstChecked = true;
        string[]        arrAvgData;
        string[]        arrData;
        double[]        arrSumData;
        double[]        dataPrint;
        double          max_x_1 = 0;
        double          min_x_1 = 1000;
        double          max_x_2 = 0;
        double          min_x_2 = 0;
        double          max_y = 0;
        double          min_y = 1000;
        int             factor_baca;
        int             max_x_chart;
        int             min_x_chart;
        int             max_y_chart;
        int             min_y_chart;
        //ini untuk testing
        int             ms=0,s,m,h;
        int             zero = 0, ten = 10;
        //itu untuk testing
        //ini
        double          label_chart_1, label_chart_2, label_chart_3, label_chart_4, label_chart_5, label_chart_6;
        double          label_chart_7, label_chart_8, label_chart_9, label_chart_10, label_chart_11;
        double          pos_label_1, pos_label_2, pos_label_3, pos_label_4, pos_label_5, pos_label_6;
        double          pos_label_7, pos_label_8, pos_label_9, pos_label_10, pos_label_11;
        int             batas_chart_1, batas_chart_2, batas_chart_3, batas_chart_4, batas_chart_5, batas_chart_6;
        int             batas_chart_7, batas_chart_8, batas_chart_9, batas_chart_10, batas_chart_11;
        //itu
        #endregion
        //ini
        Timer timer = new Timer();
        List<DateTime> TimeList = new List<DateTime>();

        Stopwatch watch = new Stopwatch();
        //itu
        public StreamingAIForm()
        {
            InitializeComponent();
            //ini
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 100;
            //itu
        }
        //ini
        void timer_tick(object sender, EventArgs e)
        {
            //DateTime now = DateTime.Now;
            //TimeList.Add(now);
           
            chartXY.Series[0].Points.AddY(dataPrint[0]);
            chartXY.Series[1].Points.AddY(dataPrint[1]);

            labelhr.Text = watch.Elapsed.ToString();
            
        }
        //itu
        public StreamingAIForm(int deviceNumber)
        {
            InitializeComponent();
	        waveformAiCtrl1.SelectedDevice = new DeviceInformation(deviceNumber);
        }
      
        private void StreamingBufferedAiForm_Load(object sender, EventArgs e)
        {
            if (!waveformAiCtrl1.Initialized)
            {
                MessageBox.Show("No device be selected or device open failed!", "StreamingAI");
                this.Close();
                return;
            }

	        int chanCount = waveformAiCtrl1.Conversion.ChannelCount;
		    int sectionLength = waveformAiCtrl1.Record.SectionLength;
		    m_dataScaled = new double[chanCount * sectionLength];

            dataPrint = new double[3];

		    this.Text = "Streaming AI(" + waveformAiCtrl1.SelectedDevice.Description + ")";

            button_start.Enabled = true;
            button_stop.Enabled = false;
            button_pause.Enabled = false;

            chartXY.Series[0].IsXValueIndexed = false;

        }

        private void HandleError(ErrorCode err)
        {
            if ((err >= ErrorCode.ErrorHandleNotValid) && (err != ErrorCode.Success))
            {
                MessageBox.Show("Sorry ! Some errors happened, the error code is: " + err.ToString(), "StreamingAI");
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //ini untuk testing
            chartXY.Series[0].Points.Clear();

            chartXY.ChartAreas[0].AxisX.CustomLabels.Clear();
            //itu untuk testing
            ErrorCode err = ErrorCode.Success;

            err = waveformAiCtrl1.Prepare();
            //m_xInc = 1.0 / waveformAiCtrl1.Conversion.ClockRate;

            if (err == ErrorCode.Success)
            {
                err = waveformAiCtrl1.Start();
            }

            if (err != ErrorCode.Success)
            {
       	        HandleError(err);
	            return;
            }
            
            button_start.Enabled = false;
            button_pause.Enabled = true;
            button_stop.Enabled = true;
            
            factor_baca = Convert.ToInt32(textBox1.Text);
            //ini
            max_x_chart = Convert.ToInt32(textBox2.Text) * 61 * 9 + 1;
            //itu
            min_x_chart = -max_x_chart;
            max_y_chart = Convert.ToInt32(textBox3.Text);
            min_y_chart = -max_y_chart;
            //ini
            timer.Start();

            watch.Start();
            //itu
            initChart();
        }

	    private void waveformAiCtrl1_DataReady(object sender, BfdAiEventArgs args)
        {
            try
            {
                if (waveformAiCtrl1.State == ControlState.Idle)
                {
	                return;
                }

                if (m_dataScaled.Length < args.Count)
                {
                    m_dataScaled = new double[args.Count];
                }

                ErrorCode err = ErrorCode.Success;
		        int chanCount = waveformAiCtrl1.Conversion.ChannelCount;
			    int sectionLength = waveformAiCtrl1.Record.SectionLength;
                err = waveformAiCtrl1.GetData(args.Count, m_dataScaled);

                if (err != ErrorCode.Success && err != ErrorCode.WarningRecordEnd)
                {
                    HandleError(err);
                    return;
                }

                this.Invoke(new Action(() =>
                {
                    arrSumData = new double[chanCount];

                    for (int i = 0; i < sectionLength; i++)
                    {
                        arrData = new string[chanCount];

                        for (int j = 0; j < chanCount; j++)
                        {
                            int cnt = i * chanCount + j;
                            arrData[j] = m_dataScaled[cnt].ToString("F1");
                            arrSumData[j] += m_dataScaled[cnt];
                            //Console.WriteLine("j ke " + j + " arrsumdata :" + arrSumData[j] + " m_datascaled: " + m_dataScaled[cnt] + " cnt: " + cnt + " chancount: " + chanCount);
                        }
                    }

                    arrAvgData = new string[arrSumData.Length];

                    for (int i = 0; i < arrSumData.Length; i++)
                    {
                        arrAvgData[i] = (arrSumData[i] / sectionLength).ToString("F1");
                        
                        //label3.Text = arrAvgData[2];
                        //Console.WriteLine("i ke " + i + " arrsumdata :" + arrSumData[i]);
                        dataCount++;

                        
                        
                    }

                    dataPrint[0] = Convert.ToDouble(arrAvgData[0]) * factor_baca;
                    dataPrint[1] = Convert.ToDouble(arrAvgData[1]) * factor_baca;
                    dataPrint[2] = Convert.ToDouble(arrAvgData[2]) * factor_baca;

                    label1.Text = dataPrint[0].ToString();
                    label2.Text = dataPrint[1].ToString();

                    if (dataPrint[0] > max_x_1)
                    {
                        max_x_1 = dataPrint[0];
                    }

                    if (dataPrint[0] < min_x_1)
                    {
                        min_x_1 = dataPrint[0];
                    }

                    if (dataPrint[0] > max_x_2)
                    {
                        max_x_2 = dataPrint[1];
                    }

                    if (dataPrint[0] < min_x_2)
                    {
                        min_x_2 = dataPrint[1];
                    }

                    if (dataPrint[1] > max_y)
                    {
                        max_y = dataPrint[2];
                    }

                    if (dataPrint[1] < min_y)
                    {
                        min_y = dataPrint[2];
                    }

                    //chartXY.Series[0].Points.AddXY(arrAvgData[0], arrAvgData[1]);

                    label9.Text = max_x_1.ToString();
                    label10.Text = min_x_1.ToString();
                    label11.Text = max_y.ToString();
                    label12.Text = min_y.ToString();

                    if (checkBox_holdX.Checked && firstChecked)
                    {
                        last_x_0 = dataPrint[0];
                        last_x_1 = dataPrint[1];
                        //last_x = dataCount.ToString();
                        firstChecked = false;
                    }

                    //plotChart(arrAvgData);
                }));

                Console.WriteLine(dataCount / 3);          
            }

            catch
            {
                MessageBox.Show("nilai x dan y salah!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }   
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            ErrorCode err = ErrorCode.Success;      
            err = waveformAiCtrl1.Stop();
            if (err != ErrorCode.Success)
            {
	            HandleError(err);
                return;
            }

            button_start.Enabled = true;
            button_pause.Enabled = false;
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
	        ErrorCode err = ErrorCode.Success;
		    err = waveformAiCtrl1.Stop();
            //ini
            timer.Stop();
            watch.Stop();
            //itu
            if (err != ErrorCode.Success)
            {
			    HandleError(err);
                return;
            }   
          
            button_start.Enabled = true;
            button_pause.Enabled = false;
            button_stop.Enabled = false;
            Array.Clear(m_dataScaled, 0, m_dataScaled.Length);     
        }
     
	    private void waveformAiCtrl1_CacheOverflow(object sender, BfdAiEventArgs e)
        {
            MessageBox.Show("WaveformAiCacheOverflow");
        }

        private void waveformAiCtrl1_Overrun(object sender, BfdAiEventArgs e)
        {
            if (m_isFirstOverRun)
            {
                MessageBox.Show("WaveformAiOverrun");
                m_isFirstOverRun = false;
            }
        }

        private void initChart()
        {
            Array.Clear(m_dataScaled, 0, m_dataScaled.Length);
            Console.WriteLine("hehehehehehe");
            chartXY.Series.Clear();
            chartXY.Series.Add("Series 1");
            chartXY.Series.Add("Series 2");
            chartXY.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartXY.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //ini
            //chartXY.ChartAreas[0].AxisX.Crossing = 0;
            chartXY.ChartAreas[0].AxisY.Crossing = 0;

            chartXY.ChartAreas[0].AxisX.LabelStyle.IntervalOffset = 1000000000;
            chartXY.ChartAreas[0].AxisX.IsLabelAutoFit = false;

            chartXY.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            chartXY.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            
            //chartXY.Series[0].XValueType = ChartValueType.DateTime;
            //chartXY.Series[1].XValueType = ChartValueType.DateTime;

            //DateTime dt = DateTime.MinValue;

            //chartXY.ChartAreas[0].AxisX.Minimum = dt.AddMinutes(0).ToOADate();
            //chartXY.ChartAreas[0].AxisX.Maximum = dt.AddMinutes(50).ToOADate();

            //chartXY.ChartAreas[0].AxisX.Interval = 60;
            //chartXY.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;

            //chartXY.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";

            //this.chartXY.Titles.Add("pt. B2TKS - BPPT");

            
            chartXY.ChartAreas[0].AxisX.Maximum = max_x_chart;
            chartXY.ChartAreas[0].AxisX.Minimum = 0;
            chartXY.ChartAreas[0].AxisY.Maximum = max_y_chart;
            chartXY.ChartAreas[0].AxisY.Minimum = min_y_chart;
            chartXY.ChartAreas[0].AxisX.Interval = max_x_chart / 10;
            chartXY.ChartAreas[0].AxisY.Interval = max_y_chart / 10;

            label_chart_1 = Convert.ToDouble(max_x_chart) * 0;
            label_chart_2 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10;
            label_chart_3 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10 * 2;
            label_chart_4 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10 * 3;
            label_chart_5 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10 * 4;
            label_chart_6 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10 * 5;
            label_chart_7 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10 * 6;
            label_chart_8 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10 * 7;
            label_chart_9 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10 * 8;
            label_chart_10 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9 / 10 * 9;
            label_chart_11 = (Convert.ToDouble(max_x_chart) - 1) / 61 / 9;


            pos_label_1 = max_x_chart * 0;
            pos_label_2 = max_x_chart / 10;
            pos_label_3 = max_x_chart / 10 * 2;
            pos_label_4 = max_x_chart / 10 * 3;
            pos_label_5 = max_x_chart / 10 * 4;
            pos_label_6 = max_x_chart / 10 * 5;
            pos_label_7 = max_x_chart / 10 * 6;
            pos_label_8 = max_x_chart / 10 * 7;
            pos_label_9 = max_x_chart / 10 * 8;
            pos_label_10 = max_x_chart / 10 * 9;
            pos_label_11 = max_x_chart;

            batas_chart_1 = 1;
            batas_chart_2 = Convert.ToInt32(pos_label_2) / 10 * 3;
            batas_chart_3 = Convert.ToInt32(pos_label_3) / 10 * 3;
            batas_chart_4 = Convert.ToInt32(pos_label_4) / 10 * 3;
            batas_chart_5 = Convert.ToInt32(pos_label_5) / 10 * 3;
            batas_chart_6 = Convert.ToInt32(pos_label_6) / 10 * 3;
            batas_chart_7 = Convert.ToInt32(pos_label_7) / 10 * 3;
            batas_chart_8 = Convert.ToInt32(pos_label_8) / 10 * 3;
            batas_chart_9 = Convert.ToInt32(pos_label_9) / 10 * 3;
            batas_chart_10 = Convert.ToInt32(pos_label_10) / 10 * 3;
            batas_chart_11 = Convert.ToInt32(pos_label_11) / 10 * 3; ;


            //CustomLabel chart_label = new CustomLabel(pos_label_2 - 0.5, pos_label_2 + 0.5, label_chart_2.ToString(), 1, LabelMarkStyle.None);

            //chartXY.ChartAreas[0].AxisX.CustomLabels.Add(chart_label);

            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_1- batas_chart_1, pos_label_1+ batas_chart_1, label_chart_1.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_2- batas_chart_2, pos_label_2+ batas_chart_2, label_chart_2.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_3- batas_chart_3, pos_label_3+ batas_chart_3, label_chart_3.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_4- batas_chart_4, pos_label_4+ batas_chart_4, label_chart_4.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_5- batas_chart_5, pos_label_5+ batas_chart_5, label_chart_5.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_6- batas_chart_6, pos_label_6+ batas_chart_6, label_chart_6.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_7- batas_chart_7, pos_label_7+ batas_chart_7, label_chart_7.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_8- batas_chart_8, pos_label_8+ batas_chart_8, label_chart_8.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_9- batas_chart_9, pos_label_9+ batas_chart_9, label_chart_9.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_10- batas_chart_10, pos_label_10+ batas_chart_10, label_chart_10.ToString("F1"), 1, LabelMarkStyle.None);
            chartXY.ChartAreas[0].AxisX.CustomLabels.Add(pos_label_11- batas_chart_11, pos_label_11+ batas_chart_11, label_chart_11.ToString("F1"), 1, LabelMarkStyle.None);
            //itu
            //chartXY.ChartAreas[0].AxisX.CustomLabels.Add(0.5, 1.5, label_chart_2.ToString());

            //ini untuk testing
            //Console.WriteLine(max_x_chart);
            //itu untuk testing
            //chartXY.ChartAreas[0].AxisX.Interval = max_x_chart / 10;
            //chartXY.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            //chartXY.ChartAreas[0].AxisY.Interval = max_y_chart / 10;


            //chartXY.ChartAreas[0].AxisX.Title = "waktu";
            //chartXY.ChartAreas[0].AxisY.Title = "nilai";


        }

        #region not used
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void plotChart(string[] data)
        {
            

            if (checkBox3.Checked)
            {
                dataPrint[0] = -(Convert.ToDouble(arrAvgData[0]));
                Console.WriteLine("halo" + dataPrint[0]);
                last_x_0 = -last_x_0;
            }
            if (checkBox4.Checked)
            {
                dataPrint[1] = -(Convert.ToDouble(arrAvgData[1]));
                last_x_1 = -last_x_1;
            }
            if (checkBox5.Checked)
            {
                dataPrint[2] = -(Convert.ToDouble(arrAvgData[2]));
            }

            if (!checkBox_holdX.Checked)
            {
                if (checkBox1.Checked)
                {
                    chartXY.Series[0].Points.AddXY(dataPrint[0], dataPrint[2]);
                }
                if (checkBox2.Checked)
                {
                    chartXY.Series[1].Points.AddXY(dataPrint[1], dataPrint[2]);
                }
                firstChecked = true;
            }

            if (checkBox_holdX.Checked)
            {
                if (checkBox1.Checked)
                {
                    chartXY.Series[0].Points.AddXY(last_x_0, dataPrint[2]);
                }
                if (checkBox2.Checked)
                {
                    chartXY.Series[1].Points.AddXY(last_x_1, dataPrint[2]);
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.chartXY.SaveImage("D:\\chart.png", ChartImageFormat.Png);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}