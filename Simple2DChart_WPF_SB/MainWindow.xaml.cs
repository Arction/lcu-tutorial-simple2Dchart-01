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
using System.Windows;
using System.Windows.Media;

// Arction namespaces
using Arction.Wpf.SemibindableCharting;

namespace SimpleLine_WPF_SB
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // 1. Created chart and configure in XAML.
            // 2. Created PointLineSeries and prepared for variable-interval data, progressing by X.
            InitializeComponent();

            // 3. Prepare data for line-series.
            var rand = new Random();
            int pointCounter = 70;

            var data = new SeriesPoint[pointCounter];
            for (int i = 0; i < pointCounter; i++)
            {
                data[i].X = (double)i;
                data[i].Y = rand.Next(0, 100);
            }

            // 4. Set data-points into series.
            series.Points = data;

            // 5. Auto-scale X and Y axes.
            chart.ViewXY.ZoomToFit();

            CusomizeChart((Content as System.Windows.Controls.Grid).Children[0] as LightningChartUltimate);
        }

        private void CusomizeChart(LightningChartUltimate chart)
        {
            chart.ChartBackground.Color = System.Windows.Media.Color.FromArgb(255, 30, 30, 30);
            chart.ChartBackground.GradientFill = GradientFill.Solid;
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
