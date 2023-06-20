using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

// Task - Create Picture Downloader application using Webclient.

namespace Downloader
{
    public partial class MainWindow : Window
    {
        CancellationTokenSource cancellation;

        private WebClient client;
        public string? DownloadTo { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            client = new WebClient();

            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted1; ;
        }

        // Choose destination folder
        private void ToFolderClicked(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                DownloadTo = dialog.FileName;
                destinationBox.Text = DownloadTo;
            }
        }

        // Download using parameters
        private void DownloadClick(object sender, RoutedEventArgs e)
        {
            if (client.IsBusy)
            {
                MessageBox.Show("Web Client is busy! Try again later...");
                return;
            }

            var height = heightBox.Text;
            var width = widthBox.Text;
            var theme = themeBox.Text;

            var source = $"htpps://source.unsplash.com/random/{width}x{height}/?{theme}&1";

            string picName = Guid.NewGuid().ToString();
            //string sourceAdress = System.IO.Path.GetExtension(source);

            string destination = destinationBox.Text;
            string dest = System.IO.Path.Combine(destination, $"{picName}.png");

            MessageBox.Show(destinationBox.Text);
            client.DownloadFileAsync(new Uri(source), dest);
        }

        private async void DownloadFileAsync(string address, string destination)
        {
            if (string.IsNullOrWhiteSpace(destinationBox.Text))
            {
                MessageBox.Show("No destination was given!");
            }

            await client.DownloadFileTaskAsync(address, destination);
        }

        private void Client_DownloadFileCompleted1(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download complete!");
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        // Cancel downloading process
        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            cancellation?.Cancel();
            this.Close();
        }
    }
}
