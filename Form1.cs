﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Macro
{
    public partial class Main_MacroForm : Form
    {
        public CrosshairForm Crosshair = new CrosshairForm();

        private static bool MacroSwitch = false;
        private static bool ChatSwitch = false;
        private static bool CrossHairSwitch = false;
        private static bool CEO_MODE = false;
        private static string CUSTOM_CHAT_C = "github.com/H4rry217/My_Macro";
        private static List<Keyboard.ScanCodeShort> CUSTOM_CHAT = new List<Keyboard.ScanCodeShort>()
        {
            Keyboard.ScanCodeShort.KEY_T
        };

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        public const int WM_CHAR = 0x102;

        private KeyEventHandler myKeyEventHandeler = null;//按键钩子
        private KeyboardHook k_hook = new KeyboardHook();

        private MouseEventHandler myMouseHandeler = null;//按键钩子
        private MouseHook m_hook = new MouseHook();

        private string[] MacroChat = new string[]
        {
            "CRY", "RIP", "NOOB", "NICE HACK", ".", "CUSTOM_CHAT"
        };

        public Main_MacroForm()
        {
            InitializeComponent();
            fk_u_mother();
        }

        public void stopListen()
        {
            if (myKeyEventHandeler != null)
            {
                k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
                myKeyEventHandeler = null;
                k_hook.Stop();//关闭键盘钩子
            }

            /*if (myMouseHandeler != null)
            {
                m_hook.OnMouseActivity -= myMouseHandeler;//取消按键事件
                myMouseHandeler = null;
                m_hook.Stop();//关闭鼠标钩子
            }*/
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MacroSwitch)
            {
                if (myKeyEventHandeler != null)
                {
                    k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
                    myKeyEventHandeler = null;
                    k_hook.Stop();//关闭键盘钩子
                }

                /*if (myMouseHandeler != null)
                {
                    m_hook.OnMouseActivity -= myMouseHandeler;//取消按键事件
                    myMouseHandeler = null;
                    m_hook.Stop();//关闭鼠标钩子
                }*/
            }
            else
            {
                myKeyEventHandeler = new KeyEventHandler(hook_KeyDown);
                k_hook.KeyDownEvent += myKeyEventHandeler;//钩住键按下
                k_hook.Start();//安装键盘钩子

                /*myMouseHandeler = new MouseEventHandler(hook_MouseButtonDown);
                m_hook.OnMouseActivity += myMouseHandeler;//钩住键按下
                m_hook.Start();//安装鼠标钩子*/
            }

            MacroSwitch = !MacroSwitch;
            button1.BackgroundImage = MacroSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;
        }

        private void fk_u_mother()
        {
            foreach (string chat in MacroChat)
            {
                listBox1.Items.Add(chat);
            }
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 192)
            {
                /*Keyboard.KeyUP(Keyboard.ScanCodeShort.SHIFT, false);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                Keyboard.KeyDown(Keyboard.ScanCodeShort.KEY_C, false);
                Thread.Sleep(40);
                Keyboard.KeyDown(Keyboard.ScanCodeShort.CAPITAL, false);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                Keyboard.KeyUP(Keyboard.ScanCodeShort.CAPITAL, false);
                Keyboard.KeyUP(Keyboard.ScanCodeShort.KEY_C, false);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);*/

                 if (ChatSwitch)
                {
                    if (listBox1.SelectedItem == null) return;

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_T);

                    /*List<Keyboard.ScanCodeShort> forScancodeDic =
                        listBox1.SelectedItem.ToString().Equals("CUSTOM_CHAT") ? CUSTOM_CHAT : MacroChat[listBox1.SelectedItem.ToString()].ToList();

                    foreach (Keyboard.ScanCodeShort key in forScancodeDic)
                    {
                        Keyboard.FuckingPressKey(key);
                    }
                    */
                    SendKeys.Send(listBox1.SelectedItem.ToString().Equals("CUSTOM_CHAT")? CUSTOM_CHAT_C: listBox1.SelectedItem.ToString());

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);

                    return;
                }
            }

            if ((int)ModifierKeys == (int)Keys.Control)
            {
                switch (e.KeyValue)
                {
                    case (int)Keys.NumPad1:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.KeyDown(Keyboard.ScanCodeShort.KEY_C, false);
                        Keyboard.KeyDown(Keyboard.ScanCodeShort.CAPITAL, false);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.KeyUP(Keyboard.ScanCodeShort.CAPITAL, false);
                        Keyboard.KeyUP(Keyboard.ScanCodeShort.KEY_C, false);
                        break;
                    case (int)Keys.NumPad4:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep(50);
                        //Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep((int)numericUpDown3.Value);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep((int)numericUpDown3.Value);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep((int)numericUpDown3.Value);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        break;
                    case (int)Keys.NumPad5:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep(50);
                        //Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        /////
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);

                        break;
                    case (int)Keys.NumPad7:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Thread.Sleep(100);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep(100);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        break;
                    case (int)Keys.NumPad8:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.SPACE);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;
                    case (int)Keys.NumPad9:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.SPACE);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;
                    default:
                        return;
                }

            }

        }

        /*private void hook_MouseButtonDown(object sender, MouseEventArgs e)
        {

            if (e.Button.Equals(MouseButtons.Middle))
            {
                if (ChatSwitch)
                {
                    if (listBox1.SelectedItem == null) return;

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_T);

                    List<Keyboard.ScanCodeShort> forScancodeDic =
                        listBox1.SelectedItem.ToString().Equals("CUSTOM_CHAT") ? CUSTOM_CHAT : MacroChat[listBox1.SelectedItem.ToString()].ToList();

                    foreach (Keyboard.ScanCodeShort key in forScancodeDic)
                    {
                        Keyboard.FuckingPressKey(key);
                    }

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);

                    return;
                }
            }
        }*/

        private void Main_MacroForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopListen();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ChatSwitch = !ChatSwitch;
            button2.BackgroundImage = ChatSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CrossHairSwitch = !CrossHairSwitch;
            button3.BackgroundImage = CrossHairSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;

            if (CrossHairSwitch)
            {
                Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                Crosshair.Show();
            }
            else
            {
                Crosshair.Hide();
            }
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            CEO_MODE = !CEO_MODE;
            button4.BackgroundImage = CEO_MODE ? Properties.Resources.switch_on : Properties.Resources.switch_off;

        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            /*CUSTOM_CHAT.Clear();

            foreach (char c in textBox1.Text)
            {
                CUSTOM_CHAT.Add(Keyboard.Key2ScanCodeMap[c.ToString().ToUpper()]);
            }*/

            CUSTOM_CHAT_C = textBox1.Text;

            textBox1.ForeColor = Color.Green;
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.DeepPink;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject("bilibili.com/video/BV1SK411J7eA/");
            (new Form2()).Show();
        }

    }
}
