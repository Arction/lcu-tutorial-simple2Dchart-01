// ------------------------------------------------------------------------------------------------------
// LightningChart® example code: First Simple 2D Chart Demo
//
// If you need any assistance, or notice error in this example code, please contact support@arction.com. 
//
// Permission to use this code in your application comes with LightningChart® license. 
//
// http://arction.com/ | support@arction.com | sales@arction.com
//
// © Arction Ltd 2009-2017. All rights reserved.  
// ------------------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;

// Arction namespaces
using Arction.WinForms.Charting;                // LightningChartUltimate and general types 
using Arction.WinForms.Charting.SeriesXY;       // Series for 2D chart     

namespace SimpleLine_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 1. Create chart instance and store it member variable.
            var chart = new LightningChartUltimate(/*Type your License key here...*/);

            // 2. Set chart control into the parent container.
            chart.Parent = this;         //Set form as parent 
            chart.Dock = DockStyle.Fill; //Maximize to parent client area

            // 3. Prepare data for line-series.
            var rand = new Random();
            int pointCounter = 70;

            var data = new SeriesPoint[pointCounter];
            for (int i = 0; i < pointCounter; i++)
            {
                data[i].X = (double)i;
                data[i].Y = rand.Next(0, 100);
            }

            // 4. Add PointLineSeries for variable-interval data, progressing by X.
            var series = new PointLineSeries(chart.ViewXY, chart.ViewXY.XAxes[0], chart.ViewXY.YAxes[0]);
            series.LineStyle.Color = Color.Orange;

            // 5. Set data-points into series.
            series.Points = data;

            // 6. Add the series into list of point-line-series.
            chart.ViewXY.PointLineSeries.Add(series);

            // 7. Auto-scale X and Y axes.
            chart.ViewXY.ZoomToFit();

            #region Hiden polishing

            CusomizeChart(chart);

            #endregion
        }

        void CusomizeChart(LightningChartUltimate chart)
        {
            chart.Background.Color = Color.FromArgb(255, 30, 30, 30);
            chart.Background.GradientFill = GradientFill.Solid;
            chart.ViewXY.GraphBackground.Color = Color.FromArgb(255, 20, 20, 20);
            chart.ViewXY.GraphBackground.GradientFill = GradientFill.Solid;
            chart.Title.Color = Color.FromArgb(255, 249, 202, 3);
            chart.Title.MouseHighlight = MouseOverHighlight.None;

            foreach (var yAxis in chart.ViewXY.YAxes)
            {
                yAxis.Title.Color = Color.FromArgb(255, 249, 202, 3);
                yAxis.Title.MouseHighlight = MouseOverHighlight.None;
                yAxis.MajorGrid.Color = Color.FromArgb(35, 255, 255, 255);
                yAxis.MajorGrid.Pattern = LinePattern.Solid;
                yAxis.MinorDivTickStyle.Visible = false;
            }

            foreach (var xAxis in chart.ViewXY.XAxes)
            {
                xAxis.Title.Color = Color.FromArgb(255, 249, 202, 3);
                xAxis.Title.MouseHighlight = MouseOverHighlight.None;
                xAxis.MajorGrid.Color = Color.FromArgb(35, 255, 255, 255);
                xAxis.MajorGrid.Pattern = LinePattern.Solid;
                xAxis.MinorDivTickStyle.Visible = false;
                xAxis.ValueType = AxisValueType.Number;
            }
        }
    }
}
