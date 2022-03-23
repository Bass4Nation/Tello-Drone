using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Input;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tello
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string ipAdress = "192.168.10.1";
        string udpPort = "8889";
        string command;
        public MainPage()
        {
            this.InitializeComponent();

            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
        }



        private void Drive_Trello(string commands)
        {
            try
            {
                byte[] data = new byte[1024];
                string input, stringData;
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.10.1"), 8889);

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                data = Encoding.ASCII.GetBytes(commands);
                server.SendTo(data, data.Length, SocketFlags.None, ip);

                //IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                //EndPoint Remote = (EndPoint)sender;

                //data = new byte[1024];
                //int receivedDataLength = server.ReceiveFrom(data, ref Remote);

                //Console.WriteLine("Message received from {0}:", Remote.ToString());
                //Console.WriteLine(Encoding.ASCII.GetString(data, 0, receivedDataLength));

                server.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        private async void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args)
        {
            if (args.KeyCode == 32) //Escape
            {
                Drive_Trello("command");
            }            
            if (args.KeyCode == 27) //Escape
            {
                Drive_Trello("land");
            }
            if (args.KeyCode == 13) //Enter
            {
                Drive_Trello("takeoff");
            }
            if (args.KeyCode == 119) //w
            {
                Drive_Trello("forward 20");
            }
            if (args.KeyCode == 115) //s
            {
                Drive_Trello("back 20");
            }
            if (args.KeyCode == 97) //a
            {
                Drive_Trello("left 30");
            }
            if (args.KeyCode == 100) //d
            {
                Drive_Trello("right 30");
            }
        }

        private void Button_Forward(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Drone going forward");
            Drive_Trello("forward 20");
        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            Drive_Trello("command");
        }

        private void Button_Land(object sender, RoutedEventArgs e)
        {
            Drive_Trello("land");
        }

        private void Button_TakeOff(object sender, RoutedEventArgs e)
        {
            Drive_Trello("takeoff");
        }

        private void Button_Up(object sender, RoutedEventArgs e)
        {
            Drive_Trello("up 20");
        }

        private void Button_Down(object sender, RoutedEventArgs e)
        {
            Drive_Trello("down 20");
        }

        private void Button_Right(object sender, RoutedEventArgs e)
        {
            Drive_Trello("right 20");
        }

        private void Button_Left(object sender, RoutedEventArgs e)
        {
            Drive_Trello("left 20");
        }

        private void Button_Backward(object sender, RoutedEventArgs e)
        {
            Drive_Trello("backward 20");
        }

        private void Button_FlipForward(object sender, RoutedEventArgs e)
        {
            Drive_Trello("flip f");
        }

        private void Button_FlipBackward(object sender, RoutedEventArgs e)
        {
            Drive_Trello("flip b");
        }

        private void Button_FlipLeft(object sender, RoutedEventArgs e)
        {
            Drive_Trello("flip l");
        }

        private void Button_FlipRight(object sender, RoutedEventArgs e)
        {
            Drive_Trello("flip r");
        }

        private void Button_Start_Stream(object sender, RoutedEventArgs e)
        {
            Drive_Trello("streamon");
        }

        private void Button_Stop_Stream(object sender, RoutedEventArgs e)
        {
            Drive_Trello("streamoff");
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(TakeOffLand);
        }
    }
}
