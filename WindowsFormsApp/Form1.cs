#region

using System;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace WindowsFormsApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Thread thread = new Thread(() => {
                if (InvokeRequired) {
                    Invoke(new InvokeDelegate(() => {
                        Text = DateTime.Now.Ticks.ToString();
                        return Text;
                    }));
                } else {
                    Text = "Test:" + DateTime.Now.Ticks;
                }
            });
            thread.Start();
        }

        private delegate string InvokeDelegate();
    }
}