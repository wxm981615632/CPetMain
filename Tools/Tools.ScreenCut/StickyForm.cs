﻿using System;
using System.Drawing;
using System.Windows.Forms;

using System.Threading;
using System.Drawing.Imaging;

namespace Tools.ScreenCut
{
    public partial class StickyForm : Form
    {
        private static int count;
        public StickyForm(Bitmap bmp) {
            InitializeComponent();
            bitmap = bmp;
            count++;
            this.FormClosing += (s, e) => {
                bmp.Dispose();
                count--;
                if (count == 0) {
                    this.Close();
                }
            };

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private Bitmap bitmap;
        public Bitmap Bmp {
            get { return bitmap; }
        }

        private Point ptOriginal;
        private bool bMouseEnter;
        private bool bLoad;
        private bool bMinimum;
        private bool bMaxmum;
        private Size szForm;
        private float fScale;
        private int zoomCount = 0;
        private int zoomNum = 0;

        private const int minWidth = 30;
        private const int minHeight = 30;

        private Rectangle rectSaveO;
        private Rectangle rectSaveC;

        private bool bOnSaveO;
        private bool bOnSaveC;
        private bool bOnClose;

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            this.Width = bitmap.Width + 2;
            this.Height = bitmap.Height + 2;
            szForm = bitmap.Size;
            fScale = 1;
            this.Twist();
        }

        protected override void OnMouseClick(MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) this.Close();
            if (e.Button == MouseButtons.Left) {
                if (e.X >= this.Width - 20 && e.Y <= 20) this.Close();
            }
            if (bOnSaveC) SaveBmp(false);
            if (bOnSaveO) SaveBmp(true);
            base.OnMouseClick(e);
        }

        protected override void OnDoubleClick(EventArgs e) {
            base.OnDoubleClick(e);
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else {
                this.WindowState = FormWindowState.Normal;
                this.Twist();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            ptOriginal = e.Location;
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle)
                this.Location = (Point)((Size)MousePosition - (Size)ptOriginal);
            if (rectSaveO.Contains(e.Location)) {
                if (!bOnSaveO) {
                    bOnSaveO = true;
                    this.Invalidate(bOnSaveO);
                }
            } else {
                if (bOnSaveO) {
                    bOnSaveO = false;
                    this.Invalidate(bOnSaveO);
                }
            }
            if (rectSaveC.Contains(e.Location)) {
                if (!bOnSaveC) {
                    bOnSaveC = true;
                    this.Invalidate(rectSaveC);
                }
            } else {
                if (bOnSaveC) {
                    bOnSaveC = false;
                    this.Invalidate(rectSaveC);
                }
            }
            if (e.X >= this.Width - 20 && e.Y <= 20) {
                if (!bOnClose) {
                    bOnClose = true;
                    this.ContextMenuStrip = contextMenuStrip;
                    this.Invalidate(new Rectangle(this.Width - 20, 1, 19, 19));
                }
            } else {
                if (bOnClose) {
                    bOnClose = false;
                    this.ContextMenuStrip = null;
                    this.Invalidate(new Rectangle(this.Width - 20, 1, 19, 19));
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseEnter(EventArgs e) {
            bMouseEnter = true;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e) {
            bOnSaveC = bOnSaveO = bMouseEnter = false;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e) {
            if (bMouseEnter) {
                //float nIncrement = 0;
                //if (e.Delta > 0) {
                //    if (this.Width < Screen.PrimaryScreen.Bounds.Width
                //        || this.Height < Screen.PrimaryScreen.Bounds.Height)
                //        nIncrement = 0.1F;
                //    else return;
                //}
                //if (e.Delta < 0) {
                //    if (this.Width > 100 || this.Height > 30)
                //        nIncrement = -0.1F;
                //    else return;
                //}

                //fScale += nIncrement;
                //this.SuspendLayout();
                //if (!bMinimum && !bMaxmum) {
                //    int x = (int)(MousePosition.X - (int)(e.X / (fScale - nIncrement)) * fScale);
                //    int y = (int)(MousePosition.Y - (int)(e.Y / (fScale - nIncrement)) * fScale);
                //    this.Location = new Point(x,y);
                //}
                //this.Size = new Size((int)(szForm.Width * fScale + 2),(int)(szForm.Height * fScale + 2));
                //this.ResumeLayout();
                timer.Stop();
                Zoom(e.Delta);
            }
            base.OnMouseWheel(e);
        }

        private void Zoom(int delta) {
            
            if (delta >= 1) {
                zoomCount = 5;
            } else if (delta <= -1) {
                zoomCount = -5;
            }
            if (zoomCount != 0) {
                timer.Start();

            }
        }

        private void timer_Tick(object sender, EventArgs e) {
            if (zoomCount > 0) {
                zoomNum++;
                zoomOut();
            } else {
                zoomNum--;
                zoomIn();
            }
            this.ResumeLayout();
        }
        /// <summary>
        /// 放大
        /// </summary>
        private void zoomOut() {
            int w = this.Width;
            int h = this.Height;
            float wDivH = szForm.Width * 1.0F / szForm.Height;
            fScale  +=0.01F;
            double deltaW = szForm.Width * 0.01;
            double deltaH = szForm.Height * 0.01;
            if (deltaW < 1)
                deltaW = 1;
            if (deltaH < 1)
                deltaH = 1;
            this.SuspendLayout();
            if (bMaxmum) {
                zoomNum = 0;
                timer.Stop();
            }
            int width = Convert.ToInt32(w + deltaW);
            int height = Convert.ToInt32(h + deltaH);
            if (height > minHeight) {//校正宽高比
                height = (int)(width / wDivH);
            }
            deltaW = width - w;
            deltaH = height - h;
            Size newSize = new Size(width, height);
            int deltaX = (int)(deltaW * ((MousePosition.X - this.Location.X) * 1.0 / w));
            int deltaY = (int)(deltaH * ((MousePosition.Y - this.Location.Y) * 1.0 / h));
            this.Location = new Point(this.Location.X - deltaX, this.Location.Y - deltaY);
            this.Size = newSize;
            if (zoomNum >= 25) {
                zoomNum = 0;
                timer.Stop();
            }
        }
        /// <summary>
        /// 缩小
        /// </summary>
        private void zoomIn() {
            int w = this.Width;
            int h = this.Height;
            float wDivH = szForm.Width * 1.0F / szForm.Height;
            fScale -= 0.01F;
            double deltaW = szForm.Width * 0.01;
            double deltaH = szForm.Height * 0.01;
            if (deltaW < 1)
                deltaW = 1;
            if (deltaH < 1)
                deltaH = 1;
            this.SuspendLayout();
            if (bMinimum) {
                zoomNum = 0;
                timer.Stop();
            }
            int width = Convert.ToInt32(w - deltaW);
            int height = Convert.ToInt32(h - deltaH);
            if (height > minHeight) {//校正宽高比
                height = (int)(width / wDivH);
            }
            deltaW = w - width;
            deltaH = h - height;
            Size newSize = new Size(width, height);
            int deltaX = (int)(deltaW * ((MousePosition.X - this.Location.X) * 1.0 / w));
            int deltaY = (int)(deltaH * ((MousePosition.Y - this.Location.Y) * 1.0 / h));
            this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            this.Size = newSize;
            if (zoomNum <= -25) {
                zoomNum = 0;
                timer.Stop();
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (bitmap == null) {
                MessageBox.Show("Bitmap cannot be null!");
                this.Close();
            }
            Graphics g = e.Graphics;
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(0, 174, 255)));
            g.DrawImage(bitmap, 1, 1, this.Width - 2, this.Height - 2);
            g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            pen.Dispose();
            if (bMouseEnter || bLoad) {
                using (SolidBrush sb = new SolidBrush(Color.FromArgb(150, 0, 0, 0))) {
                    //g.FillRectangle(sb, 1, 1, this.Width - 2, this.Height - 2);
                    //sb.Color = Color.FromArgb(150, 0, 255, 255);

                    //StringFormat sf = new StringFormat();

                    //string strDraw = "Original:\t[" + m_bmp.Width + "," + m_bmp.Height + "]"
                    //    + "\tScale:" + ((double)(this.Width - 2) / m_bmp.Width).ToString("F2") + "[W]"
                    //    + "\r\nCurrent:\t[" + (this.Width - 2) + "," + (this.Height - 2) + "]"
                    //    + "\tScale:" + ((double)(this.Height - 2) / m_bmp.Height).ToString("F2") + "[H]";
                    //sf.SetTabStops(0.0F, new float[] { 60.0F, 60.0F });
                    //Rectangle rectString = new Rectangle(new Point(1, 1), g.MeasureString(strDraw, this.Font, this.Width, sf).ToSize());
                    //rectString.Inflate(1, 1);
                    //g.FillRectangle(sb, rectString);
                    //g.DrawString(strDraw, this.Font, Brushes.Wheat, rectString, sf);

                    //rectString = new Rectangle(0, this.Height - 2 * this.Font.Height - 1,
                    //    this.Width, this.Font.Height * 2);
                    //sf.Alignment = StringAlignment.Far;
                    //g.FillRectangle(sb, rectString);
                    //g.DrawString("Move [W,S,A,D] ReSize [T,G,F,H]\r\nScale [MouseWheel] Exit [MouseRight]", this.Font, Brushes.Wheat, rectString, sf);
                    //g.DrawString("SaveOriginal\r\nSaveCurrent", this.Font, Brushes.Wheat, rectString.X + 12, rectString.Y);

                    g.FillRectangle(sb, this.Width - 21, 1, 20, 20);
                    if (bOnClose)
                        g.FillRectangle(Brushes.Red, this.Width - 20, 1, 19, 19);

                    //sb.Color = m_bOnSaveO ? Color.Red : Color.Wheat;
                    //m_rectSaveO = new Rectangle(2, rectString.Y + 2, 10, this.Font.Height - 3);
                    //g.FillRectangle(sb, m_rectSaveO);
                    //sb.Color = m_bOnSaveC ? Color.Red : Color.Wheat;
                    //m_rectSaveC = new Rectangle(2, rectString.Y + this.Font.Height + 1, 10, this.Font.Height - 2);
                    //g.FillRectangle(sb, m_rectSaveC);
                }
            }
            base.OnPaint(e);
        }
        /// <summary>
        /// w/s/a/d控制上下左右移动，t/g/f/h控制缩放
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e) {
            if (e.KeyChar == 'w') this.Top -= 1;
            if (e.KeyChar == 's') this.Top += 1;
            if (e.KeyChar == 'a') this.Left -= 1;
            if (e.KeyChar == 'd') this.Left += 1;
            if (e.KeyChar == 't') szForm.Height = (int)(((this.Height -= 1) - 2) / fScale);
            if (e.KeyChar == 'g') szForm.Height = (int)(((this.Height += 1) - 2) / fScale);
            if (e.KeyChar == 'f') szForm.Width = (int)(((this.Width -= 1) - 2) / fScale);
            if (e.KeyChar == 'h') szForm.Width = (int)(((this.Width += 1) - 2) / fScale);
            base.OnKeyPress(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            if (width < minWidth) width = minWidth;
            if (width > Screen.PrimaryScreen.Bounds.Width) width = w;
            if (height < minHeight) height = minHeight;
            if (height > Screen.PrimaryScreen.Bounds.Height) height = h;
            bMinimum = (width == minWidth || height == minHeight);
            bMaxmum = (width == w || height == h);
            if (bMaxmum) 
                x = y = 0;
            base.SetBoundsCore(x, y, width, height, specified);
        }

        private void tsmiOTC_Click(object sender, EventArgs e) {
            this.SetClipBoard(true);
        }

        private void tsmiCTC_Click(object sender, EventArgs e) {
            this.SetClipBoard(false);
        }

        private void tsmiSaveOriginal_Click(object sender, EventArgs e) {
            this.SaveBmp(true);
        }

        private void tsmiSaveCurrent_Click(object sender, EventArgs e) {
            this.SaveBmp(false);
        }

        private void tsmiHelp_Click(object sender, EventArgs e) {
            MessageBox.Show(
                "MoveWindow\t[W,A,S,D],[MouseMiddle]\r\n\t\t[MouseDown and move]\r\n" +
                "ReSizeWindow\t[T,F,G,H],[MouseWheel]\r\n" +
                "WindowState\t[MouseDoubleClick]");
        }

        private void tsmiClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Twist() {
            Thread threadShow = new Thread(new ThreadStart(() => {
                for (int i = 0; i < 4; i++) {
                    bLoad = !bLoad;
                    this.Invalidate();
                    Thread.Sleep(250);
                }
            }));
            threadShow.IsBackground = true;
            threadShow.Start();
        }

        private void SetClipBoard(bool bOriginal) {
            if (bOriginal) {
                Clipboard.SetImage(bitmap);
                return;
            }
            using (Bitmap bmp = new Bitmap(this.Width - 2, this.Height - 2, PixelFormat.Format24bppRgb)) {
                using (Graphics g = Graphics.FromImage(bmp)) {
                    g.DrawImage(bitmap, 0, 0, this.Width - 2, this.Height - 2);
                    Clipboard.SetImage(bmp);
                }
            }
        }

        private void SaveBmp(bool bOriginal) {
            saveDlg.Filter = Util.SUPPORT_EXTENSION_FILTER;
            saveDlg.FilterIndex = 3;
            saveDlg.FileName = Util.GetSavePicPath();
            if (saveDlg.ShowDialog() == DialogResult.OK) {
                using (Bitmap bmp = bOriginal ? bitmap.Clone() as Bitmap : new Bitmap(this.Width - 2, this.Height - 2, PixelFormat.Format24bppRgb)) {
                    using (Graphics g = Graphics.FromImage(bmp)) {
                        if (bOriginal) {
                            g.DrawImage(bmp, 0, 0, this.Width - 2, this.Height - 2);
                        } else {
                            g.DrawImage(bitmap, 0, 0, this.Width - 2, this.Height - 2);
                        }
                    }
                    switch (saveDlg.FilterIndex) {
                        case 1:
                            bmp.Save(saveDlg.FileName, ImageFormat.Bmp);
                            break;
                        case 2:
                            bmp.Save(saveDlg.FileName, ImageFormat.Jpeg);
                            break;
                        case 3:
                            bmp.Save(saveDlg.FileName, ImageFormat.Png);
                            break;
                    }
                    Clipboard.SetImage(bmp);
                }
            }
        }
    }
}
