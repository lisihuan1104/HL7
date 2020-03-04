using System;
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
using System.Xml;

namespace HL7Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String myHL7string = "MSH|^~\\&|455755610_0100||0200||20110624160404|000|QRY^A19^QRY_A19|0123456001|P|2.6\nQRD|||||||||0001^张三^体检号^EQ^AND~0002^East^病区号^EQ^AND\nQRF||20110627|20110803\nPID|1||034123123^^^^MR||0992^张三||198298313000|男\nOBX|1|IS|08001^TakeModel^99MRC||O||||||F\nOBX|2|NM|30525-0^Age^LN||15|yr|||||F";
            string sHL7asXml = HL7ToXmlConverter.ConvertToXml(myHL7string);
            XmlDocument xmlObject = HL7ToXmlConverter.ConvertToXmlObject(myHL7string);
            String value = HL7ToXmlConverter.GetText(xmlObject, "QRD/QRD.9/QRD.9.0", 0);
            String value2 = HL7ToXmlConverter.GetText(xmlObject, "QRD/QRD.9/QRD.9.0");
            String nodeValue = xmlObject.DocumentElement.SelectSingleNode("MSH/MSH.9").InnerText;
            String nodeValue2 = xmlObject.DocumentElement.SelectSingleNode("QRD/QRD.9/QRD.9.0/QRD.9.0.2").InnerText;
            String patientName = xmlObject.DocumentElement.SelectSingleNode("PID/PID.5/PID.5.0/PID.5.0.1").InnerText;
            string obxValue= xmlObject.DocumentElement.SelectSingleNode("OBX/OBX.1").InnerText;
            foreach (XmlElement items in xmlObject.DocumentElement.SelectNodes("OBX"))
            {
                string checkValue = items.SelectSingleNode("OBX.3").InnerText;
                Console.WriteLine(checkValue);
            }
        }
    }
}
