using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendOtherSoftMsg
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

        #region bVk参数 常量定义

        public const byte vbKeyLButton = 0x1;    // 鼠标左键
        public const byte vbKeyRButton = 0x2;    // 鼠标右键
        public const byte vbKeyCancel = 0x3;     // CANCEL 键
        public const byte vbKeyMButton = 0x4;    // 鼠标中键
        public const byte vbKeyBack = 0x8;       // BACKSPACE 键
        public const byte vbKeyTab = 0x9;        // TAB 键
        public const byte vbKeyClear = 0xC;      // CLEAR 键
        public const byte vbKeyReturn = 0xD;     // ENTER 键
        public const byte vbKeyShift = 0x10;     // SHIFT 键
        public const byte vbKeyControl = 0x11;   // CTRL 键
        public const byte vbKeyAlt = 18;         // Alt 键  (键码18)
        public const byte vbKeyMenu = 0x12;      // MENU 键
        public const byte vbKeyPause = 0x13;     // PAUSE 键
        public const byte vbKeyCapital = 0x14;   // CAPS LOCK 键
        public const byte vbKeyEscape = 0x1B;    // ESC 键
        public const byte vbKeySpace = 0x20;     // SPACEBAR 键
        public const byte vbKeyPageUp = 0x21;    // PAGE UP 键
        public const byte vbKeyEnd = 0x23;       // End 键
        public const byte vbKeyHome = 0x24;      // HOME 键
        public const byte vbKeyLeft = 0x25;      // LEFT ARROW 键
        public const byte vbKeyUp = 0x26;        // UP ARROW 键
        public const byte vbKeyRight = 0x27;     // RIGHT ARROW 键
        public const byte vbKeyDown = 0x28;      // DOWN ARROW 键
        public const byte vbKeySelect = 0x29;    // Select 键
        public const byte vbKeyPrint = 0x2A;     // PRINT SCREEN 键
        public const byte vbKeyExecute = 0x2B;   // EXECUTE 键
        public const byte vbKeySnapshot = 0x2C;  // SNAPSHOT 键
        public const byte vbKeyDelete = 0x2E;    // Delete 键
        public const byte vbKeyHelp = 0x2F;      // HELP 键
        public const byte vbKeyNumlock = 0x90;   // NUM LOCK 键

        //常用键 字母键A到Z
        public const byte vbKeyA = 65;
        public const byte vbKeyB = 66;
        public const byte vbKeyC = 67;
        public const byte vbKeyD = 68;
        public const byte vbKeyE = 69;
        public const byte vbKeyF = 70;
        public const byte vbKeyG = 71;
        public const byte vbKeyH = 72;
        public const byte vbKeyI = 73;
        public const byte vbKeyJ = 74;
        public const byte vbKeyK = 75;
        public const byte vbKeyL = 76;
        public const byte vbKeyM = 77;
        public const byte vbKeyN = 78;
        public const byte vbKeyO = 79;
        public const byte vbKeyP = 80;
        public const byte vbKeyQ = 81;
        public const byte vbKeyR = 82;
        public const byte vbKeyS = 83;
        public const byte vbKeyT = 84;
        public const byte vbKeyU = 85;
        public const byte vbKeyV = 86;
        public const byte vbKeyW = 87;
        public const byte vbKeyX = 88;
        public const byte vbKeyY = 89;
        public const byte vbKeyZ = 90;

        //数字键盘0到9
        public const byte vbKey0 = 48;    // 0 键
        public const byte vbKey1 = 49;    // 1 键
        public const byte vbKey2 = 50;    // 2 键
        public const byte vbKey3 = 51;    // 3 键
        public const byte vbKey4 = 52;    // 4 键
        public const byte vbKey5 = 53;    // 5 键
        public const byte vbKey6 = 54;    // 6 键
        public const byte vbKey7 = 55;    // 7 键
        public const byte vbKey8 = 56;    // 8 键
        public const byte vbKey9 = 57;    // 9 键


        public const byte vbKeyNumpad0 = 0x60;    //0 键
        public const byte vbKeyNumpad1 = 0x61;    //1 键
        public const byte vbKeyNumpad2 = 0x62;    //2 键
        public const byte vbKeyNumpad3 = 0x63;    //3 键
        public const byte vbKeyNumpad4 = 0x64;    //4 键
        public const byte vbKeyNumpad5 = 0x65;    //5 键
        public const byte vbKeyNumpad6 = 0x66;    //6 键
        public const byte vbKeyNumpad7 = 0x67;    //7 键
        public const byte vbKeyNumpad8 = 0x68;    //8 键
        public const byte vbKeyNumpad9 = 0x69;    //9 键
        public const byte vbKeyMultiply = 0x6A;   // MULTIPLICATIONSIGN(*)键
        public const byte vbKeyAdd = 0x6B;        // PLUS SIGN(+) 键
        public const byte vbKeySeparator = 0x6C;  // ENTER 键
        public const byte vbKeySubtract = 0x6D;   // MINUS SIGN(-) 键
        public const byte vbKeyDecimal = 0x6E;    // DECIMAL POINT(.) 键
        public const byte vbKeyDivide = 0x6F;     // DIVISION SIGN(/) 键


        //F1到F12按键
        public const byte vbKeyF1 = 0x70;   //F1 键
        public const byte vbKeyF2 = 0x71;   //F2 键
        public const byte vbKeyF3 = 0x72;   //F3 键
        public const byte vbKeyF4 = 0x73;   //F4 键
        public const byte vbKeyF5 = 0x74;   //F5 键
        public const byte vbKeyF6 = 0x75;   //F6 键
        public const byte vbKeyF7 = 0x76;   //F7 键
        public const byte vbKeyF8 = 0x77;   //F8 键
        public const byte vbKeyF9 = 0x78;   //F9 键
        public const byte vbKeyF10 = 0x79;  //F10 键
        public const byte vbKeyF11 = 0x7A;  //F11 键
        public const byte vbKeyF12 = 0x7B;  //F12 键

        #endregion


        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);
        //ShowWindow参数  
        private const int SW_SHOWNORMAL = 1;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWNOACTIVATE = 4;
        //SendMessage参数  
        private const int WM_KEYDOWN = 0X100;
        private const int WM_KEYUP = 0X101;
        private const int WM_SYSCHAR = 0X106;
        private const int WM_SYSKEYUP = 0X105;
        private const int WM_SYSKEYDOWN = 0X104;
        private const int WM_CHAR = 0X102;

        public delegate bool CallBack(int hwnd, int lParam);
        [DllImport("user32")]
        public static extern int EnumWindows(CallBack x, int y);
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        static extern IntPtr SetActiveWindow(IntPtr hWnd);

        private void OpenPlatForm(string path)
        {
            Process proc = Process.Start(path);
            SetActiveWindow(proc.MainWindowHandle);
            SetForegroundWindow(proc.MainWindowHandle);
        }

        private void SendSteamUsrAndPwd()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                IntPtr maindHwnd = FindWindow("vguiPopupWindow", "Steam 登录"); //获得句柄   
                SetWindowPos(maindHwnd, (IntPtr)(-1), 0, 0, 0, 0, 0x0040 | 0x0001); //设置窗口位置  
                SetCursorPos(123, 100); //设置鼠标位置
                SetCursorPos(123, 100); //设置鼠标位置
                SetCursorPos(123, 100); //设置鼠标位置  
                Thread.Sleep(500);
                mouse_event(0x0002, 0, 0, 0, 0); //模拟鼠标按下操作  
                mouse_event(0x0004, 0, 0, 0, 0); //模拟鼠标放开操作  
                //SendKeys.SendWait("^A"); //ctrl+a
                //Thread.Sleep(2000);
                //SendKeys.SendWait("{DELETE}"); //delete 清除上次用户名
                //Thread.Sleep(500);

                Thread.Sleep(500);
                //模拟按下ctrl键
                keybd_event(vbKeyControl, 0, 0, 0);
                //模拟按下A键
                keybd_event(vbKeyA, 0, 0, 0);

                Thread.Sleep(500);

                keybd_event(vbKeyControl, 0, 2, 0);
                keybd_event(vbKeyA, 0, 2, 0);

                Thread.Sleep(500);
                SendKeys.SendWait("{DELETE}"); //delete 清除上次用户名

                //for (int i = 0; i < 99; i++)
                //{
                //    keybd_event((byte)Keys.Delete, 0,0,0);
                //    keybd_event((byte)Keys.Delete, 0,2, 0);
                //    //SendKeys.SendWait("{DELETE}"); //delete 清除上次用户名

                //}
                SendKeys.SendWait(TBuser.Text);   //模拟键盘输入游戏ID  
                Thread.Sleep(100);
                SendKeys.SendWait("{TAB}"); //模拟键盘输入TAB
                Thread.Sleep(100);
                SendKeys.SendWait(TBpwd.Text); //模拟键盘输入游戏密码  
                Thread.Sleep(100);
                SendKeys.SendWait("{ENTER}"); //模拟键盘输入ENTER 
            }));

        }

        private void Steam_Click(object sender, RoutedEventArgs e)
        {
            OpenPlatForm(@TBsteam.Text);

            Thread td = new Thread(() =>
            {
                Thread.Sleep(5000);
                SendSteamUsrAndPwd();
            });
            td.SetApartmentState(ApartmentState.STA);
            td.Start();

        }

        private void SendBxzwUsrAndPwd()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                IntPtr maindHwnd = FindWindow("Qt5QWindowIcon", "暴雪战网登录"); //获得句柄   
                SetWindowPos(maindHwnd, (IntPtr)(-1), 0, 0, 0, 0, 0x0040 | 0x0001); //设置窗口位置  
                SetCursorPos(38, 190); //设置鼠标位置  
                mouse_event(0x0002, 0, 0, 0, 0); //模拟鼠标按下操作  
                mouse_event(0x0004, 0, 0, 0, 0); //模拟鼠标放开操作  
                //SendKeys.SendWait("^A"); //ctrl+a
                //Thread.Sleep(1500);
                for (int i = 0; i < 99; i++)
                {
                    SendKeys.SendWait("{DELETE}"); //delete 清除上次用户名
                    Thread.Sleep(5);
                }

                SendKeys.SendWait("14923349@163.com");//SendKeys.SendWait(TBuser.Text);   //模拟键盘输入游戏ID  
                Thread.Sleep(100);
                SendKeys.SendWait("{TAB}"); //模拟键盘输入TAB
                Thread.Sleep(100);
                SendKeys.SendWait("@qq14923349@");//SendKeys.SendWait(TBpwd.Text); //模拟键盘输入游戏密码  
                Thread.Sleep(100);
                SendKeys.SendWait("{ENTER}"); //模拟键盘输入ENTER 
            }));
        }

        private void BTbxzw_Click(object sender, RoutedEventArgs e)
        {
            OpenPlatForm(@TBbxzw.Text);

            Thread td = new Thread(() =>
            {
                Thread.Sleep(5000);
                SendBxzwUsrAndPwd();
            });
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void SendWeGameUsrAndPwd()
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                IntPtr maindHwnd = FindWindow("Qt5QWindowIcon", "暴雪战网登录"); //获得句柄   
                SetWindowPos(maindHwnd, (IntPtr)(-1), 0, 0, 0, 0, 0x0040 | 0x0001); //设置窗口位置  
                SetCursorPos(124, 100); //设置鼠标位置  
                mouse_event(0x0002, 0, 0, 0, 0); //模拟鼠标按下操作  
                mouse_event(0x0004, 0, 0, 0, 0); //模拟鼠标放开操作  
                SendKeys.SendWait("^A"); //ctrl+a
                Thread.Sleep(1000);
                SendKeys.SendWait("{DELETE}"); //delete 清除上次用户名
                Thread.Sleep(100);
                SendKeys.SendWait(TBuser.Text);   //模拟键盘输入游戏ID  
                Thread.Sleep(100);
                SendKeys.SendWait("{TAB}"); //模拟键盘输入TAB
                Thread.Sleep(100);
                SendKeys.SendWait(TBpwd.Text); //模拟键盘输入游戏密码  
                Thread.Sleep(100);
                SendKeys.SendWait("{ENTER}"); //模拟键盘输入ENTER 
            }));
        }

        private void WeGame_Click(object sender, RoutedEventArgs e)
        {
            OpenPlatForm(@TBWeGame.Text);

            Thread td = new Thread(() =>
            {
                Thread.Sleep(5000);
                SendWeGameUsrAndPwd();
            });
            td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void ca_Click(object sender, RoutedEventArgs e)
        {
            ////模拟按下ctrl键
            keybd_event(vbKeyControl, 0, 0, 0);
            ////模拟按下A键
            keybd_event(vbKeyA, 0, 0, 0);


            //keybd_event(vbKeyControl, 0, 2, 0);
            //keybd_event(vbKeyA, 0, 2, 0);
            //SendKeys.SendWait("^A"); //ctrl+a
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TBWeGame.AddHandler(System.Windows.Controls.TextBox.MouseLeftButtonDownEvent, new MouseButtonEventHandler(TBWeGame_MouseLeftButtonDown), true);
        }

        private void TBWeGame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ////模拟按下ctrl键
            keybd_event(vbKeyControl, 0, 0, 0);
            ////模拟按下A键
            keybd_event(vbKeyA, 0, 0, 0);

            keybd_event(vbKeyControl, 0, 2, 0);
            keybd_event(vbKeyA, 0, 2, 0);
            //SendKeys.SendWait("^A"); //ctrl+a
            
        }


        #region 废弃


        //    #region 获取另一系统文本框值        
        //    [DllImport("User32.dll", EntryPoint = "FindWindow")]
        //    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //    [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        //    public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        //    [DllImport("User32.dll", EntryPoint = "FindEx")]
        //    public static extern IntPtr FindEx(IntPtr hwnd, IntPtr hwndChild, string lpClassName, string lpWindowName);
        //    [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        //    private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, StringBuilder lParam);

        //    [DllImport("user32.dll")]
        //    public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);

        //    public delegate bool CallBack(IntPtr hwnd, int lParam);
        //    #endregion

        //public static int WM_GETTEXT = 0x000D;

        //    private void find_Click(object sender, RoutedEventArgs e)
        //    {
        //        //IntPtr maindHwnd = FindWindow("vguiPopupWindow", "Steam 登录"); //获得句柄   
        //        IntPtr maindHwnd = FindWindow("TWINCONTROL", "WeGame"); //获得句柄   
        //        if (maindHwnd != IntPtr.Zero)
        //        {
        //            Console.WriteLine("找到了窗体！");
        //            IntPtr maindHwndp = FindWindowEx(maindHwnd, IntPtr.Zero, "Edit", "11");
        //            if (maindHwndp != IntPtr.Zero)
        //            {
        //                Console.WriteLine("找到输入框！");
        //                const int buffer_size = 1024;
        //                StringBuilder buffer = new StringBuilder(buffer_size);
        //                SendMessage(maindHwndp, WM_GETTEXT, buffer_size, buffer);
        //                Console.WriteLine(string.Format("取到的值是：{0}", buffer.ToString()));//取值一直是空字符串
        //            }
        //        }

        //        //EnumChildWindows();
        //    }


        //    private void EnumChildWindows() {



        //        IntPtr iResult = IntPtr.Zero;
        //        // 首先在父窗体上查找控件
        //        iResult = FindWindow("vguiPopupWindow", "Steam 登录"); //获得句柄   
        //        // 如果找到直接返回控件句柄
        //        if (iResult == IntPtr.Zero)
        //            return ;

        //        // 枚举子窗体，查找控件句柄
        //        int i = EnumChildWindows(
        //        iResult,
        //        (h, l) =>
        //        {
        //            IntPtr f1 = FindWindowEx(h, IntPtr.Zero, null, null);
        //            if (f1 == IntPtr.Zero)
        //                return true;
        //            else
        //            {
        //                iResult = f1;
        //                return false;
        //            }
        //        },
        //        0);
        //        // 返回查找结果
        //        return ;
        //    }

        #endregion


    }


}
