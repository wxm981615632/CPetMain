﻿using System.ComponentModel;
using System.Windows.Forms;

namespace Tools.ScreenCut
{
    public partial class LTextBox : TextBox {
        private string oriText;
        [Browsable(false)]
        public string OriText {
            get { return oriText; }
            set { oriText = value; }
        }
        [Browsable(false)]
        public bool IsValueChanged {
            get {
                return oriText != this.Text;
            }
        }
        public LTextBox() {
            InitializeComponent();
        }
    }
}
