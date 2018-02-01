using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
using System.Windows.Threading;

namespace ThreadTrainingApp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 클라이언트 Mock 시작
            //Thread clientThread = new Thread(StartUdpSend);
            //clientThread.Start();

            // 클라이언트 정보 수집하는 쓰레드
            Thread serverThread = new Thread(StartUdpRecv);
            serverThread.Start();

        }

        private void StartUdpRecv()
        {
            UdpClient cli = new UdpClient(7777);
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 7777);
            while (true)
            {
                byte[] data = cli.Receive(ref ip);
                string s = Encoding.UTF8.GetString(data);
                Console.WriteLine("{0} / IP: {1}", s, ip.Address);

                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                {
                    Alert alarmWIndow = new Alert();
                    alarmWIndow.ToDoMsg.Text = s;
                    alarmWIndow.Show();
                }));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UdpClient cli = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 7777);
            cli.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            byte[] data = Encoding.UTF8.GetBytes(Message.Text);
            int result = cli.Send(data, data.Length, "", 7777);
            Console.WriteLine("Send Result: {0}", result);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Alert alertWIndow = new Alert();
            alertWIndow.Show();
        }
    }


}
