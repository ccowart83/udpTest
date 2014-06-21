using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace udpTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			UdpClient ucs = new UdpClient(11000);

			string data = "TYPE: WM-DISCOVER\r\n" +
				"VERSION: 1.0\r\n\r\n" + 
				"services:com.marvell.wm.system*\r\n\r\n";

			Byte[] sendBytes = Encoding.ASCII.GetBytes(data);
			ucs.Connect("255.255.255.255", 1900);
			ucs.Send(sendBytes, sendBytes.Length);


			IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
			UdpClient ucr = new UdpClient(11000);


			byte[] receiveBytes = ucr.Receive(ref RemoteIpEndPoint);
			string receiveData = Encoding.ASCII.GetString (receiveBytes);
			//string output = Encoding.ASCII.GetString(receiveBytes.ToString());

			Console.WriteLine("Received Data:\n\r" + receiveData.ToString());
		
			//Console.WriteLine (output);

			ucr.Close();
			ucs.Close();
		}
	}
}
