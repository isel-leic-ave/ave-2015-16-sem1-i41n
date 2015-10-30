using System;
using System.Runtime.InteropServices;

class Sample
{
    [DllImport("user32.dll")]
    public static extern int MessageBoxA(int p, string m, string h, int t);

    public static void Main()
    {
        MessageBoxA(0, "Hello World!", "DLLImport Sample", 0);

        System.Windows.Forms.MessageBox.Show("Hello World!", "Windows Forms Sample");
    }
}