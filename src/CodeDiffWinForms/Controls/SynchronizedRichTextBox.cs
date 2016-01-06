using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeDiffWinForms.Controls
{
    public partial class SynchronizedRichTextBox : RichTextBox
    {
        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x020A;

        private HashSet<SynchronizedRichTextBox> _inSync = new HashSet<SynchronizedRichTextBox>();

        public void AddRTB(SynchronizedRichTextBox other)
        {
            _inSync.Add(other);
        }

        public SynchronizedRichTextBox()
        {
            InitializeComponent();
        }

        internal void Scroll(Message msg)
        {
            Message scrollMessage = Message.Create(this.Handle, msg.Msg, msg.WParam, msg.LParam);
            base.WndProc(ref scrollMessage);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_VSCROLL || m.Msg == WM_MOUSEWHEEL)
            {
                foreach (var item in _inSync)
                {
                    item.Scroll(m);
                }
            }
            base.WndProc(ref m);
        }
    }
}
