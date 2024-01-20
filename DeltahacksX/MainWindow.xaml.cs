using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using Microsoft.Toolkit.Uwp.Notifications;

namespace DeltahacksX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch time = new Stopwatch();
        private double totalTime = 0;
        private string processName = "League of Legends";
        static bool IsProcessRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public async void ChangeTimer(double minutes)
        {
            time.Stop();
            time.Start();
            while (time.Elapsed.TotalMinutes <= (minutes+totalTime))
            {
                progress_bar.Value = (1-((time.Elapsed.TotalMinutes-totalTime)/minutes))*100;
                await Task.Delay(1000);
            }
            while (IsProcessRunning(processName))
            {

            }
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Time's Up!")
                .AddText("Look away for 20s.")
                .Show();
            await Task.Delay(20000);
            new ToastContentBuilder()
            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813)
            .AddText("Good Job!")
            .AddText("Timer will restart.")
            .Show();
            totalTime += minutes + (1/3);
            ChangeTimer(minutes);
        }
        public void RadioButton_Checked(object sender, RoutedEventArgs e)
        {}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_15Button.IsChecked == true)
            {
                ChangeTimer(15);
            }
            else if (_20Button.IsChecked == true)
            {
                ChangeTimer(20);
            }
            else if (_25Button.IsChecked == true)
            {
                ChangeTimer(25);
            }
            else if (_30Button.IsChecked == true)
            {
                ChangeTimer(30);
            }
            _15Button.IsEnabled = false;
            _20Button.IsEnabled = false;
            _25Button.IsEnabled = false;
            _30Button.IsEnabled = false;
            ConfirmButton.IsEnabled = false;
        }

    }
}
