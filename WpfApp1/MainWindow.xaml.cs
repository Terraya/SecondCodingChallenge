using System;
using System.Diagnostics;
using System.Windows;
using WpfApp1.Services;
using WpfApp1.Util;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public readonly string firstFileName = "FirstDrawing.jpg";
        public readonly string secondFileName = "SecondDrawing.jpg";

        public MainWindow()
        {
            InitializeComponent();
            FileUtil.InitializeFolder();

            CompareAverageHashAlgorithm();
            CompareDifferenceHashAlgorithm();
        }

        public void CompareAverageHashAlgorithm()
        {
            AverageHashService averageHashService = new AverageHashService();

            var result = averageHashService.CompareAsync(firstFileName, firstFileName);
            Trace.WriteLine(result.Result);

            result = averageHashService.CompareAsync(firstFileName, secondFileName);
            Trace.Write(result);
        }

        public void CompareDifferenceHashAlgorithm()
        {
            DifferenceHashService differenceHashService = new DifferenceHashService();

            var result = differenceHashService.CompareAsync(firstFileName, firstFileName);
            Trace.WriteLine(result);

            result = differenceHashService.CompareAsync(firstFileName, secondFileName);
            Trace.Write(result);
        }
    }
}
