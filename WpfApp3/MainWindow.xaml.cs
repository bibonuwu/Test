﻿using System;
using System.Net.Http;
using System.Windows;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private const string versionFileUrl = "https://raw.githubusercontent.com/bibonuwu/Test/main/WpfApp3/version.txt"; // Замените на ваш URL
        private const string currentVersion = "9"; // Текущая версия приложенияddds

        public MainWindow()
        {
            InitializeComponent();
            CheckForUpdates();
        }

        private async void CheckForUpdates()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string latestVersion = await client.GetStringAsync(versionFileUrl);

                    if (latestVersion.Trim() != currentVersion)
                    {
                        MessageBoxResult result = MessageBox.Show("Доступно обновление. Хотите скачать новую версию?",
                                                                  "Обновление доступно",
                                                                  MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            // Замените на URL-адрес вашей новой версии
                            System.Diagnostics.Process.Start("https://github.com/bibonuwu/Test/releases/latest");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке обновлений: {ex.Message}");
            }
        }
    }
}
