using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transitions
{
    public partial class TransitionsUI : Form
    {
        //---
        //C# WinForm 控制項隨視窗大小變化而比例改變_start00
        // ~ https://dotblogs.com.tw/davidtalk/2018/06/03/182559
        // ~ https://www.itread01.com/content/1547625088.html
        //---C# WinForm 控制項隨視窗大小變化而比例改變_end00

        //---
        //C# WinForm 控制項隨視窗大小變化而比例改變_start01
        private float m_X;//當前窗體的寬度
        private float m_Y;//當前窗體的高度
        private bool m_isLoaded;  // 是否已設定各控制的尺寸資料到Tag屬性
        //---C# WinForm 控制項隨視窗大小變化而比例改變_end01

        //---
        //C# WinForm 控制項隨視窗大小變化而比例改變_start02
        //將控制項的寬，高，左邊距，頂邊距和字體大小暫存到tag屬性中
        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    SetTag(con);
            }
        }
        //---C# WinForm 控制項隨視窗大小變化而比例改變_end02

        //---
        //C# WinForm 控制項隨視窗大小變化而比例改變_start03
        //根據窗體大小調整控制項大小
        private void SetControls(float newx, float newy, Control cons)
        {
            if (m_isLoaded)
            {
                //遍歷窗體中的控制項，重新設置控制項的值
                foreach (Control con in cons.Controls)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//獲取控制項的Tag屬性值，並分割後存儲字元串數組
                    float a = System.Convert.ToSingle(mytag[0]) * newx;//根據窗體縮放比例確定控制項的值，寬度
                    con.Width = (int)a;//寬度
                    a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                    con.Height = (int)(a);
                    a = System.Convert.ToSingle(mytag[2]) * newx;//左邊距離
                    con.Left = (int)(a);
                    a = System.Convert.ToSingle(mytag[3]) * newy;//上邊緣距離
                    con.Top = (int)(a);
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字體大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        SetControls(newx, newy, con);
                    }
                }
            }
        }
        //---C# WinForm 控制項隨視窗大小變化而比例改變_end03
        public TransitionsUI(String StrInfoe)
        {
            InitializeComponent();
            //---
            //C# WinForm 控制項隨視窗大小變化而比例改變_start05
            m_isLoaded = false;//
            //---C# WinForm 控制項隨視窗大小變化而比例改變_end05

            //---
            //C#控件改变大小时闪烁问题
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, false);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
            //---C#控件改变大小时闪烁问题

            labInfor.Text = StrInfoe;
        }

        private void TransitionsUI_Load(object sender, EventArgs e)
        {
            //---
            //C# WinForm 控制項隨視窗大小變化而比例改變_start04
            if (Screen.AllScreens[0].WorkingArea.Width < 1920)
            {
                m_X = 360 * (Screen.AllScreens[0].WorkingArea.Width / 1920.0f);//獲取窗體的寬度
                m_Y = 90 * (Screen.AllScreens[0].WorkingArea.Height / 1080.0f);//獲取窗體的高度
            }
            else
            {
                m_X = this.Width;
                m_Y = this.Height;
            }
            m_isLoaded = true;// 已設定各控制項的尺寸到Tag屬性中
            SetTag(this);//調用方法
            //---C# WinForm 控制項隨視窗大小變化而比例改變_end04

            //---
            //showOnMonitor
            // 取得延伸螢幕的工作區大小
            Screen extendedScreen = Screen.AllScreens[0];  // 若延伸螢幕為主要螢幕
            Rectangle workingArea = extendedScreen.WorkingArea;

            // 計算視窗的位置
            int x = workingArea.Left + (workingArea.Width - (int)m_X) / 2;
            int y = workingArea.Top + (workingArea.Height - (int)m_Y) / 2;

            // 設定視窗的位置
            this.Location = new Point(x, y);
            //---showOnMonitor

            //---
            //C# WinForm 控制項隨視窗大小變化而比例改變_start07
            if (m_isLoaded)
            {
                float newx;
                float newy;
                if (Screen.AllScreens[0].WorkingArea.Width < 1920)
                {
                    newx = m_X / 360;
                    newy = m_Y / 90;
                }
                else
                {
                    newx = (this.Width) / m_X;
                    newy = (this.Height) / m_Y;
                }


                SetControls(newx, newy, this);
                this.Width = (int)m_X;
                this.Height = (int)m_Y;
            }
            //---C# WinForm 控制項隨視窗大小變化而比例改變_end07
        }
    }

    public class TransitionsFun
    {
        public static TransitionsUI transitionsUI;
        public static void ShowUI(String StrMsg)
        {
            CloseUI();
            transitionsUI = new TransitionsUI(StrMsg);
            transitionsUI.Show();
            transitionsUI.Refresh();//https://stackoverflow.com/questions/50012020/c-sharp-form-show-does-not-paint-labels-in-the-form-to-show-showdialog-do-i
        }
        public static void CloseUI()
        {
            if (transitionsUI != null)
            {
                transitionsUI.Close();
                transitionsUI = null;
            }
        }
    }

}
