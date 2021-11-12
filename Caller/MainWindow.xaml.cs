using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Caller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public delegate void ACTION(string Text);

        [DllImport("PythonConv.dll", CharSet = CharSet.Unicode)]
        extern public static void Init();
        [DllImport("PythonConv.dll", CharSet = CharSet.Unicode)]
        extern public static void Flna();
        [DllImport("PythonConv.dll", CharSet = CharSet.Ansi)]
        extern public static void ExecuteStr(string C);

        [DllImport("PythonConv.dll", CharSet = CharSet.Ansi)]
        extern public static void MessageBoxS(ACTION A);
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (e, v) =>
            {
                Init();
                MessageBoxS((string x)=> { MessageBox.Show(x); });

              //  ExecuteStr("Ts()");
            };
        }
    }
}
