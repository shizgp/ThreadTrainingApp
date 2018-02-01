﻿using System;
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
using System.Windows.Shapes;

namespace ThreadTrainingApp
{
    /// <summary>
    /// Alert.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Alert : Window
    {
        public Alert()
        {
            InitializeComponent();
            SetFormValues();
        }

        private void SetFormValues()
        {

            // ToDoMsg.Text = ((MainWindow)Application.Current.MainWindow).Message.Text;
            // ToDoMsg.Text = ((MainWindow)Application.Current.MainWindow)
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
