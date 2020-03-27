using DebugConsole.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DebugConsole
{
    public partial class MyConsole : Form
    {
        private List<LogInfo> displayLogs = new List<LogInfo>();

        private List<LogInfo> logs = new List<LogInfo>();

        private Dictionary<LogInfo, int> distinctMap = new Dictionary<LogInfo, int>();

        Bitmap errorIcon;
        Bitmap normalIcon;
        Bitmap warringIcon;

        public MyConsole()
        {
            InitializeComponent();

            DebugLst.DrawItem += DebugLst_DrawItem;
            DebugLst.MeasureItem += DebugLst_MeasureItem;

            errorIcon = Resources.error;
            normalIcon = Resources.normal;
            warringIcon = Resources.warring;

            CheckForIllegalCrossThreadCalls = false;
        }

        private void DebugLst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void DebugLst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(e.Index == -1)
            {
                return;
            }
            e.DrawBackground();
            e.DrawFocusRectangle();

            Color vColor = e.ForeColor;

            LogInfo logInfo = displayLogs[e.Index];

            Bitmap bitmap = null;
            switch (logInfo.msgType)
            {
                case MsgType.Error: bitmap = errorIcon; break;
                case MsgType.Warning: bitmap = warringIcon; break;
                case MsgType.Normal: bitmap = normalIcon; break;
            }
            Rectangle bound1 = new Rectangle(e.Bounds.X + 30, e.Bounds.Y, e.Bounds.Width - 30, e.Bounds.Height);
            Rectangle bound2 = new Rectangle(e.Bounds.X, e.Bounds.Y, 30, 30);

            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font,
                new SolidBrush(Color.White), bound1);

            e.Graphics.DrawImage(bitmap, bound2);
        }

        private void DebugLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lstBox = (ListBox)sender;
            if(lstBox.SelectedItem == null)
            {
                return;
            }

            DetailTb.Text = lstBox.SelectedItem.ToString();
        }

        public void Log(string msg, MsgType msgType, bool isPrintStack = false)
        {
            lock(this)
            {

                var logItem = new LogInfo();

                if(isPrintStack)
                {
                    var stack = new StackTrace(true);
                    logItem.msg = stack.ToString() + "\r\n" + msg;
                }
                else
                {
                    logItem.msg = msg;
                }


                logItem.msgType = msgType;
                logs.Add(logItem);

                var disKey = distinctMap.Keys.FirstOrDefault(l => l.msg.Equals(logItem.msg) && l.msgType == msgType);
                if(disKey == null)
                {
                    distinctMap[logItem] = 1;
                }
                else
                {
                    distinctMap[disKey]++;
                }

                //更新显示
                if (!ErrorCb.Checked && msgType == MsgType.Error)
                {
                    return;
                }

                if (!WarringCb.Checked && msgType == MsgType.Warning)
                {
                    return;
                }

                if (!NormalCb.Checked && msgType == MsgType.Normal)
                {
                    return;
                }

                if (CombineCb.Checked)
                {
                    if (disKey == null)
                    {
                        string str = string.Format("[{0}] {1}", 1, logItem.msg);
                        displayLogs.Add(new LogInfo() { msg = str, msgType = msgType });
                        DebugLst.Items.Add(str);
                    }
                    else
                    {
                        LogInfo logInfo = displayLogs.FirstOrDefault(l => l.msg.Equals(string.Format("[{0}] {1}", distinctMap[disKey] - 1, msg)));
                        string str = string.Format("[{0}] {1}", distinctMap[disKey], logItem.msg);
                        logInfo.msg = str;
                        DebugLst.Items[displayLogs.IndexOf(logInfo)] = str;
                    }
                }
                else
                {
                    displayLogs.Add(logItem);
                    DebugLst.Items.Add(msg);
                }

                AutoScroll();
            }
        }

        private void UpdateLst()
        {
            DebugLst.Items.Clear();
            displayLogs.Clear();

            if(CombineCb.Checked)
            {
                foreach (var item in distinctMap)
                {
                    string str = string.Format("[{0}] {1}", item.Value, item.Key.msg);
                    displayLogs.Add(new LogInfo() { msg = str, msgType = item.Key.msgType});
                }
            }
            else
            {
                displayLogs = logs.GetRange(0, logs.Count);
            }

            if(!ErrorCb.Checked)
            {
                displayLogs.RemoveAll(l => l.msgType == MsgType.Error);
            }

            if(!WarringCb.Checked)
            {
                displayLogs.RemoveAll(l => l.msgType == MsgType.Warning);
            }

            if(!NormalCb.Checked)
            {
                displayLogs.RemoveAll(l => l.msgType == MsgType.Normal);
            }

            foreach(var item in displayLogs)
            {
                DebugLst.Items.Add(item.msg);
            }
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            DebugLst.Items.Clear();
            logs.Clear();
            distinctMap.Clear();
            DetailTb.Clear();
        }

        private void CombineCb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLst();
        }

        private void ErrorCb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLst();
        }

        private void WarringCb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLst();
        }

        private void NormalCb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLst();
        }

        private void AutoScroll()
        {
            bool scroll = false;
            if (this.DebugLst.TopIndex >= this.DebugLst.Items.Count - (int)(this.DebugLst.Height / 30) -1)
                scroll = true;
            if (scroll)
                this.DebugLst.TopIndex = this.DebugLst.Items.Count - (int)(this.DebugLst.Height / 30);
        }

        class LogInfo
        {
            public string msg;
            public MsgType msgType;
        }
    }

    public enum MsgType
    {
        Warning,Error,Normal
    }
}
