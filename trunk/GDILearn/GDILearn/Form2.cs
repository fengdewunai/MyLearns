using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILearn
{
    using System.Drawing.Drawing2D;

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /// <summary> 
        /// 窗体的Paint事件的响应方法 
        /// </summary> 
        /// <param name="sender">当前事件触发者(当前窗体)</param> 
        /// <param name="e">附带的事件参数</param> 
        private void Frm_Demo_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics; // 创建当前窗体的Graphics对象 
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Point centerPoint = new Point(150, 100);
            int R = 60;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(centerPoint.X - R, centerPoint.Y - R, R * 2, R * 2);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterPoint = centerPoint;    // 指定路径中心点 
            brush.CenterColor = Color.Red;  // 指定路径中心的颜色 
            brush.SurroundColors = new Color[] { Color.Plum };
            graphics.FillEllipse(brush, centerPoint.X - R, centerPoint.Y - R, R * 2, R * 2);


            centerPoint = new Point(350, 100); 
            R = 20;
            path = new GraphicsPath();
            path.AddEllipse(centerPoint.X - R, centerPoint.Y - R, R * 2, R * 2);
            path.AddEllipse(centerPoint.X - R * 2, centerPoint.Y - R * 2, R * 4, R * 4);
            path.AddEllipse(centerPoint.X - R * 3, centerPoint.Y - R * 3, R * 6, R * 6);
            path.AddEllipse(centerPoint.X - R * 4, centerPoint.Y - R * 4, R * 8, R * 8);
            path.AddEllipse(centerPoint.X - R * 5, centerPoint.Y - R * 5, R * 10, R * 10);
            brush = new PathGradientBrush(path);
            brush.CenterPoint = centerPoint;
            brush.CenterColor = Color.Red;
            brush.SurroundColors = new Color[] { Color.Black, Color.Blue, Color.Green };
            graphics.FillPath(brush, path);
        } 
    }
}
