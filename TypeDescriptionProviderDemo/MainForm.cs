#region

using System;
using System.Windows.Forms;

#endregion

namespace TypeDescriptionProviderDemo {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            listBox.DataSource = DemoDataProvider.GetTitles();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e) {
            propertyGrid.SelectedObject = listBox.SelectedItem;
        }
    }
}