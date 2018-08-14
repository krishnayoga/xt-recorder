namespace AI_StreamingAI
{
   partial class StreamingAIForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StreamingAIForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.waveformAiCtrl1 = new Automation.BDaq.WaveformAiCtrl(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartXY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBox_holdX = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartXY)).BeginInit();
            this.SuspendLayout();
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(628, 450);
            this.button_stop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(76, 26);
            this.button_stop.TabIndex = 19;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_pause
            // 
            this.button_pause.Location = new System.Drawing.Point(544, 450);
            this.button_pause.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(76, 26);
            this.button_pause.TabIndex = 18;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(461, 450);
            this.button_start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(76, 26);
            this.button_start.TabIndex = 17;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // waveformAiCtrl1
            // 
            this.waveformAiCtrl1._StateStream = ((Automation.BDaq.DeviceStateStreamer)(resources.GetObject("waveformAiCtrl1._StateStream")));
            this.waveformAiCtrl1.DataReady += new System.EventHandler<Automation.BDaq.BfdAiEventArgs>(this.waveformAiCtrl1_DataReady);
            this.waveformAiCtrl1.Overrun += new System.EventHandler<Automation.BDaq.BfdAiEventArgs>(this.waveformAiCtrl1_Overrun);
            this.waveformAiCtrl1.CacheOverflow += new System.EventHandler<Automation.BDaq.BfdAiEventArgs>(this.waveformAiCtrl1_CacheOverflow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(72, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 20);
            this.label1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(70, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 20);
            this.label2.TabIndex = 21;
            // 
            // chartXY
            // 
            chartArea1.Name = "ChartArea1";
            this.chartXY.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartXY.Legends.Add(legend1);
            this.chartXY.Location = new System.Drawing.Point(41, 12);
            this.chartXY.Name = "chartXY";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartXY.Series.Add(series1);
            this.chartXY.Size = new System.Drawing.Size(680, 410);
            this.chartXY.TabIndex = 23;
            this.chartXY.Text = "chart1";
            // 
            // checkBox_holdX
            // 
            this.checkBox_holdX.AutoSize = true;
            this.checkBox_holdX.Location = new System.Drawing.Point(502, 429);
            this.checkBox_holdX.Name = "checkBox_holdX";
            this.checkBox_holdX.Size = new System.Drawing.Size(75, 22);
            this.checkBox_holdX.TabIndex = 24;
            this.checkBox_holdX.Text = "Hold X";
            this.checkBox_holdX.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 25;
            this.label4.Text = "Data X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "Data Y";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "Max X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 467);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "Max Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "Min X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(328, 467);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 18);
            this.label8.TabIndex = 30;
            this.label8.Text = "Min Y";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(226, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 20);
            this.label9.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(380, 429);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2, 20);
            this.label10.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(223, 467);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2, 20);
            this.label11.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(377, 467);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(2, 20);
            this.label12.TabIndex = 34;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(583, 424);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 35;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // StreamingAIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 496);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_holdX);
            this.Controls.Add(this.chartXY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_pause);
            this.Controls.Add(this.button_start);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StreamingAIForm";
            this.Text = "Streaming AI";
            this.Load += new System.EventHandler(this.StreamingBufferedAiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartXY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button button_stop;
      private System.Windows.Forms.Button button_pause;
      private System.Windows.Forms.Button button_start;
		private Automation.BDaq.WaveformAiCtrl waveformAiCtrl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartXY;
        private System.Windows.Forms.CheckBox checkBox_holdX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_save;
    }
}

