﻿// ------------------------------------------------------------------------------------------------------
// LightningChart® example code: First Simple 2D Chart Demo.
//
// If you need any assistance, or notice error in this example code, please contact support@arction.com. 
//
// Permission to use this code in your application comes with LightningChart® license. 
//
// http://arction.com/ | support@arction.com | sales@arction.com
//
// © Arction Ltd 2009-2019. All rights reserved.  
// ------------------------------------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;

// Arction namespaces.
using Arction.WinForms.Charting;                // LightningChart and general types.
using Arction.WinForms.Charting.SeriesXY;       // Series for 2D chart.

namespace SimpleLine_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 1. Create chart.
            var chart = new LightningChart();

            // Disable rendering before updating chart properties to improve performance
            // and to prevent unnecessary chart redrawing while changing multiple properties.
            chart.BeginUpdate();

            // 2. Set chart control into the parent container.
            chart.Parent = this;         // Set form as parent.
            chart.Dock = DockStyle.Fill; // Maximize to parent client area.

            // 3. Generate data for series.
            var rand = new Random();
            int pointCounter = 70;

            var data = new SeriesPoint[pointCounter];
            for (int i = 0; i < pointCounter; i++)
            {
                data[i].X = (double)i;
                data[i].Y = rand.Next(0, 100);
            }

            // 4. Define variables for X- and Y-axis.
            var axisX = chart.ViewXY.XAxes[0];
            var axisY = chart.ViewXY.YAxes[0];

            // 5. Create a new PointLineSeries.
            var series = new PointLineSeries(chart.ViewXY, axisX, axisY);
            series.LineStyle.Color = Color.Orange;

            // 6. Set data-points into series.
            series.Points = data;

            // 7. Add series to chart.
            chart.ViewXY.PointLineSeries.Add(series);

            // 8. Auto-scale X- and Y-axes.
            chart.ViewXY.ZoomToFit();

            #region Hidden polishing

            CustomizeChart(chart);

            #endregion

            // Call EndUpdate to enable rendering again.
            chart.EndUpdate();
        }

        #region Hidden polishing
        void CustomizeChart(LightningChart chart)
        {
            chart.Background.Color = Color.FromArgb(255, 30, 30, 30);
            chart.Background.GradientFill = GradientFill.Solid;
            chart.ViewXY.GraphBackground.Color = Color.FromArgb(255, 20, 20, 20);
            chart.ViewXY.GraphBackground.GradientFill = GradientFill.Solid;
            chart.Title.Color = Color.FromArgb(255, 249, 202, 3);
            chart.Title.Highlight = Highlight.None;

            foreach (var yAxis in chart.ViewXY.YAxes) {
                yAxis.Title.Color = Color.FromArgb(255, 249, 202, 3);
                yAxis.Title.Highlight = Highlight.None;
                yAxis.MajorGrid.Color = Color.FromArgb(35, 255, 255, 255);
                yAxis.MajorGrid.Pattern = LinePattern.Solid;
                yAxis.MinorDivTickStyle.Visible = false;
            }

            foreach (var xAxis in chart.ViewXY.XAxes) {
                xAxis.Title.Color = Color.FromArgb(255, 249, 202, 3);
                xAxis.Title.Highlight = Highlight.None;
                xAxis.MajorGrid.Color = Color.FromArgb(35, 255, 255, 255);
                xAxis.MajorGrid.Pattern = LinePattern.Solid;
                xAxis.MinorDivTickStyle.Visible = false;
                xAxis.ValueType = AxisValueType.Number;
            }
        }
        #endregion
    }
}
