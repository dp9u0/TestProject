using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp {
    public partial class Form1 : Form {

        delegate string InvokeDelegate();

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
                    Text = "Test:" + DateTime.Now.Ticks.ToString();
                }
            });
            thread.Start();
        }
    }
}
