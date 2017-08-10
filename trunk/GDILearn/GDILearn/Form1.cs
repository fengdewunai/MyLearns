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
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net.NetworkInformation;
    using System.Resources;

    using GDILearn.Properties;

    public partial class Form1 : Form
    {
        /// <summary>
        /// 画布宽度
        /// </summary>
        private const int PaintWidth = 1276;

        /// <summary>
        /// 画布高度
        /// </summary>
        private const int PaintHeight = 1789;

        /// <summary>
        /// 内边距
        /// </summary>
        private const int PaintPadding = 116;

        /// <summary>
        /// 保存图片路径
        /// </summary>
        private const string SavePathFormat = "第{0}页.png";

        /// <summary>
        /// 选择题答题区域高度
        /// </summary>
        private const int ChoiceQuestionHeight = 30 + 16*4 + 15*3;

        /// <summary>
        /// 填空题答题区域高度
        /// </summary>
        private const int FillBlankQuestionHeight = 40;

        /// <summary>
        /// 主观题题答题区域高度
        /// </summary>
        private const int ResponseQuestionHeight = 20 + 5 + 123;

        /// <summary>
        /// 题目类型名称区域高度
        /// </summary>
        private const int QuestionNameHeight = 40;

        /// <summary>
        /// 特殊颜色
        /// </summary>
        private readonly Color specialColor = ColorTranslator.FromHtml("#E4007F");
        /// <summary>
        /// 黑色
        /// </summary>
        private readonly Color generalColor = Color.Black;

        /// <summary>
        /// 图片默认格式
        /// </summary>
        private readonly ImageFormat imageFormat = ImageFormat.Png;




        private Image choiceImageA = Resource1.ChoiceA1;
        private Image choiceImageB = Resource1.ChoiceB;
        private Image choiceImageC = Image.FromFile("ChoiceC.png");
        private Image choiceImageD = Image.FromFile("ChoiceD.png");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(PaintWidth, PaintHeight, PixelFormat.Format24bppRgb);
            var graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.White);

            ScantronCreation answerSheetModel = new ScantronCreation()
                                                          {
                                                              Bitmap = bitmap,
                                                              Graphics = graphics,
                                                              PageNumber = 1,
                                                              PointX = PaintPadding,
                                                              PointY = PaintPadding
                                                          };

            this.InitPage(answerSheetModel);
            this.DrawQuestion(answerSheetModel);
            


            pictureBox1.Image = bitmap;

            bitmap.Save(string.Format(SavePathFormat, answerSheetModel.PageNumber), this.imageFormat);
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    bitmap.Save(stream, ImageFormat.Png);
            //}
            graphics.Dispose();
            bitmap.Dispose();
            
        }

        /// <summary>
        /// 初始化画布
        /// </summary>
        /// <param name="answerSheetModel"></param>
        private void InitPage(ScantronCreation answerSheetModel)
        {
            this.DrawLocatingPoint(answerSheetModel);
            this.DrawTopAndEndLine(answerSheetModel);
            this.DrawPersonInfo(answerSheetModel);
            this.DrawPageNumber(answerSheetModel, answerSheetModel.PageNumber);
        }

        /// <summary>
        /// 换页
        /// </summary>
        /// <param name="answerSheetModel"></param>
        public void ChangePage(ScantronCreation answerSheetModel)
        {
            answerSheetModel.Bitmap.Save(string.Format(SavePathFormat, answerSheetModel.PageNumber), this.imageFormat);
            answerSheetModel.Graphics.Clear(Color.White);
            answerSheetModel.PageNumber += 1;
            answerSheetModel.PointX = PaintPadding;
            answerSheetModel.PointY = PaintPadding;
            this.InitPage(answerSheetModel);
        }

        /// <summary>
        /// 绘制定位点
        /// </summary>
        /// <param name="answerSheetModel"></param>
        private void DrawLocatingPoint(ScantronCreation answerSheetModel)
        {
            var sideLength = 40;
            var solidBrush = new SolidBrush(this.generalColor);
            answerSheetModel.Graphics.FillRectangle(solidBrush, PaintPadding, PaintPadding, sideLength, sideLength);
            answerSheetModel.Graphics.FillRectangle(solidBrush, PaintPadding, PaintHeight - PaintPadding - sideLength, sideLength, sideLength);
            answerSheetModel.Graphics.FillRectangle(solidBrush, PaintWidth - PaintPadding - sideLength, PaintHeight - PaintPadding - sideLength, sideLength, sideLength);
            answerSheetModel.Graphics.FillRectangle(solidBrush, PaintWidth - PaintPadding - sideLength, PaintPadding, sideLength, sideLength);
            this.AddPointY(answerSheetModel, sideLength);
        }

        /// <summary>
        /// 绘制顶部横线
        /// </summary>
        /// <param name="answerSheetModel"></param>
        private void DrawTopAndEndLine(ScantronCreation answerSheetModel)
        {
            this.AddPointY(answerSheetModel, 10);
            var penWidth = 2;
            var color = this.specialColor;
            this.DrawLine(answerSheetModel, new Point(answerSheetModel.PointX, answerSheetModel.PointY), new Point(answerSheetModel.PointX + 1044, answerSheetModel.PointY), color, penWidth);
            this.DrawLine(answerSheetModel, new Point(answerSheetModel.PointX, PaintHeight - PaintPadding - 40 - 10), new Point(answerSheetModel.PointX + 1044, PaintHeight - PaintPadding - 40 - 10), this.specialColor, penWidth);
            this.AddPointY(answerSheetModel, penWidth);
        }

        /// <summary>
        /// 绘制人员信息
        /// </summary>
        /// <param name="answerSheetModel">graphics</param>
        private void DrawPersonInfo(ScantronCreation answerSheetModel)
        {
            this.AddPointY(answerSheetModel, 10);
            DrawRectangle(answerSheetModel, answerSheetModel.PointX, answerSheetModel.PointY, 634, 100);
            DrawRectangle(answerSheetModel, answerSheetModel.PointX + 644, answerSheetModel.PointY, 400, 100);
            this.DrawString(answerSheetModel, "班级", 20, true, false, answerSheetModel.PointX + 20, answerSheetModel.PointY + 38);
            this.DrawString(answerSheetModel, "姓名", 20, true, false, answerSheetModel.PointX + 330, answerSheetModel.PointY + 38);
            var pen = new Pen(this.specialColor);
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 5, 5 };
            answerSheetModel.Graphics.DrawLine(pen, new Point(answerSheetModel.PointX + 80, answerSheetModel.PointY + 65), new Point(answerSheetModel.PointX + 284, answerSheetModel.PointY + 65));
            answerSheetModel.Graphics.DrawLine(pen, new Point(answerSheetModel.PointX + 390, answerSheetModel.PointY + 65), new Point(answerSheetModel.PointX + 615, answerSheetModel.PointY + 65));
            this.AddPointY(answerSheetModel, 110);
        }

        /// <summary>
        /// 绘制所有题目信息
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawQuestion(ScantronCreation answerSheetModel)
        {
            var bitQuestionNumber = 1;
            var hasSingleChoice = true;
            var hasMultipleChoice = true;
            var hasCloseTest = true;
            var hasBlank = true;
            var hasResponse = true;
            if (hasSingleChoice)
            {     
                this.DrawChoiceQuestion(answerSheetModel, "单选题", bitQuestionNumber);
                bitQuestionNumber ++;
            }
            if (hasMultipleChoice)
            {
                this.DrawChoiceQuestion(answerSheetModel, "多选题", bitQuestionNumber);
                bitQuestionNumber++;
            }
            if (hasCloseTest)
            {
                this.DrawChoiceQuestion(answerSheetModel, "完形填空", bitQuestionNumber);
                bitQuestionNumber++;
            }
            if (hasBlank)
            {
                this.DrawFillBlankQuestion(answerSheetModel, bitQuestionNumber);
                bitQuestionNumber++;
            }
            if (hasResponse)
            {
                this.DrawResponseQuestion(answerSheetModel, bitQuestionNumber);
                bitQuestionNumber++;
            }
        }

        /// <summary>
        /// 绘制选择题
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawChoiceQuestion(ScantronCreation answerSheetModel, string questionName, int bitQuestionNumber)
        {
            var tempQuestionNumber = new int[135];
            if (bitQuestionNumber == 1)
            {
                tempQuestionNumber = new int[25];
            }
            var tempPointX = answerSheetModel.PointX;
            this.DrawQuestionName(answerSheetModel, questionName, bitQuestionNumber);
            this.AddPointY(answerSheetModel, 60);
            var font = new Font("汉仪旗黑-50S", 18, GraphicsUnit.Pixel);
            var solidBrush = new SolidBrush(this.generalColor);
            for (int i = 0; i < tempQuestionNumber.Length; i++)
            {
                if (i % 20 == 0)
                {
                    tempPointX = answerSheetModel.PointX;
                    answerSheetModel.PointY = i == 0 ? answerSheetModel.PointY : answerSheetModel.PointY + 30 + 16 * 4 + 15 * 3 + 40;
                    ChangePageResult(answerSheetModel, ChoiceQuestionHeight);
                    this.DrawQuestionLocation(answerSheetModel, tempPointX, answerSheetModel.PointY + 30);
                    this.DrawQuestionLocation(answerSheetModel, tempPointX, answerSheetModel.PointY + 30 + 16 * 4 + 15 * 3 - 10);
                    tempPointX += 15 + 42;
                }
                var numberSpace = i >= 10 ? 4 : 9;
                numberSpace = i >= 100 ? -2 : numberSpace;
                answerSheetModel.Graphics.DrawString(i.ToString(), font, solidBrush, tempPointX + numberSpace, answerSheetModel.PointY);
                DrawChoice(answerSheetModel, "A", tempPointX, answerSheetModel.PointY + 30);
                DrawChoice(answerSheetModel, "B", tempPointX, answerSheetModel.PointY + 30 + 16 + 15);
                DrawChoice(answerSheetModel, "C", tempPointX, answerSheetModel.PointY + 30 + 16 + 15 + 16 + 15);
                DrawChoice(answerSheetModel, "D", tempPointX, answerSheetModel.PointY + 30 + 16 + 15 + 16 + 15 + 16 + 15);
                tempPointX += 33 + 15;
            }
            this.AddPointY(answerSheetModel, 30 + 16 * 4 + 15 * 3 + 20);
        }

        /// <summary>
        /// 绘制填空题
        /// </summary>
        /// <param name="graphics">graphics</param>
        /// <param name="bitQuestionNumber">大题题号</param>
        private void DrawFillBlankQuestion(ScantronCreation answerSheetModel, int bitQuestionNumber)
        {
            var tempQuestionNumber = new int[2];
            this.DrawQuestionName(answerSheetModel, "填空题", bitQuestionNumber);
            this.AddPointY(answerSheetModel, 70);
            for (int i = 0; i < tempQuestionNumber.Length; i++)
            {
                ChangePageResult(answerSheetModel, FillBlankQuestionHeight);
                this.DrawQuestionLocation(answerSheetModel, answerSheetModel.PointX, answerSheetModel.PointY);
                this.DrawString(answerSheetModel, i.ToString(),18,true,true,answerSheetModel.PointX + 25,answerSheetModel.PointY);
                //Todo 需要确定下面answerSheetModel.PointX + 40中40的确切值
                this.DrawLine(answerSheetModel, new Point(answerSheetModel.PointX + 40, answerSheetModel.PointY + 40), new Point(answerSheetModel.PointX + 1044, answerSheetModel.PointY + 40),this.specialColor);
                this.AddPointY(answerSheetModel, 40 + (i == tempQuestionNumber.Length - 1 ? 20 : 30));
            }
            
        }

        /// <summary>
        /// 绘制解答题
        /// </summary>
        /// <param name="graphics">graphics</param>
        /// <param name="bitQuestionNumber">大题题号</param>
        private void DrawResponseQuestion(ScantronCreation answerSheetModel, int bitQuestionNumber)
        {
            var tempQuestionNumber = new int[2];
            this.DrawQuestionName(answerSheetModel, "解答题", bitQuestionNumber);
            this.AddPointY(answerSheetModel, 45);
            var pen = new Pen(ColorTranslator.FromHtml("#FBA1D0"));
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 5, 5 };
            for (int i = 0; i < tempQuestionNumber.Length; i++)
            {
                ChangePageResult(answerSheetModel, ResponseQuestionHeight);
                answerSheetModel.Graphics.DrawLine(pen, new Point(answerSheetModel.PointX + 25, answerSheetModel.PointY), new Point(answerSheetModel.PointX + 1044 - 25, answerSheetModel.PointY));
                this.AddPointY(answerSheetModel, 6);
                this.DrawQuestionLocation(answerSheetModel, answerSheetModel.PointX, answerSheetModel.PointY);
                this.DrawString(answerSheetModel, "（该区域禁止作答）", 12, false, true, answerSheetModel.PointX + 25, answerSheetModel.PointY);
                this.AddPointY(answerSheetModel, 14);
                answerSheetModel.Graphics.DrawLine(pen, new Point(answerSheetModel.PointX + 25, answerSheetModel.PointY), new Point(answerSheetModel.PointX + 1044 - 25, answerSheetModel.PointY));
                this.AddPointY(answerSheetModel, 5);
                this.DrawRectangle(answerSheetModel, answerSheetModel.PointX + 25, answerSheetModel.PointY, 1019,123);
                this.DrawString(answerSheetModel, i.ToString(), 18, true, true, answerSheetModel.PointX + 35, answerSheetModel.PointY + 10);
                this.AddPointY(answerSheetModel, 123 + 5);
            }
        }

        /// <summary>
        /// 添加页码
        /// </summary>
        /// <param name="graphics">graphics</param>
        /// <param name="pageNumber">页码</param>
        private void DrawPageNumber(ScantronCreation answerSheetModel, int pageNumber)
        {
            this.DrawString(answerSheetModel, pageNumber.ToString(), 14, true, false, PaintWidth / 2, PaintHeight - 50);
        }

        /// <summary>
        /// 绘制大题名称
        /// </summary>
        /// <param name="answerSheetModel">graphics</param>
        /// <param name="name">题目名称</param>
        private void DrawQuestionName(ScantronCreation answerSheetModel, string name, int bitQuestionNumber)
        {
            ChangePageResult(answerSheetModel, QuestionNameHeight);
            var color = this.specialColor;
            var userColor = Color.FromArgb(80, color);
            var solidBrush = new SolidBrush(userColor);
            answerSheetModel.Graphics.FillRectangle(solidBrush, answerSheetModel.PointX, answerSheetModel.PointY, 1044, 40);
            var questionName = string.Concat(NumberToChinese(bitQuestionNumber), "、", name);
            this.DrawString(answerSheetModel, questionName, 20, true, false, answerSheetModel.PointX + 30, answerSheetModel.PointY + 8);
        }

        /// <summary>
        /// 绘制选项
        /// </summary>
        /// <param name="answerSheetModel"></param>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DrawChoice(ScantronCreation answerSheetModel, string name, int x, int y)
        {
            Image choiceImage = null;
            switch (name)
            {
                case "A":
                    choiceImage = this.choiceImageA;
                    break;
                case "B":
                    choiceImage = this.choiceImageB;
                    break;
                case "C":
                    choiceImage = this.choiceImageC;
                    break;
                case "D":
                    choiceImage = this.choiceImageD;
                    break;
            }
            if (choiceImage != null)
            {
                answerSheetModel.Graphics.DrawImage(choiceImage, new Point(x, y));
            }
            
        }

        /// <summary>
        /// 绘制题目定位点
        /// </summary>
        /// <param name="graphics">graphics</param>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        private void DrawQuestionLocation(ScantronCreation answerSheetModel, int x, int y)
        {
            var solidBrush = new SolidBrush(this.generalColor);
            answerSheetModel.Graphics.FillRectangle(solidBrush, x, y, 15, 10);
        }

        /// <summary>
        /// 绘制直线
        /// </summary>
        /// <param name="graphics">graphics</param>
        /// <param name="pointStart">起始点</param>
        /// <param name="pointEnd">终止点</param>
        /// <param name="color">画笔颜色</param>
        /// <param name="penWidth">画笔宽度</param>
        private void DrawLine(ScantronCreation answerSheetModel, Point pointStart, Point pointEnd, Color color, int penWidth = 1)
        {
            var pen = new Pen(color, penWidth);
            answerSheetModel.Graphics.DrawLine(pen, pointStart, pointEnd);
        }

        /// <summary>
        /// 绘制长方形
        /// </summary>
        /// <param name="graphics">graphics</param>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="width">长度</param>
        /// <param name="height">高度</param>
        private void DrawRectangle(ScantronCreation answerSheetModel, int x, int y, int width, int height)
        {
            var color = this.specialColor;
            var pen = new Pen(color, 1);
            answerSheetModel.Graphics.DrawRectangle(pen, x, y, width, height);
        }

        /// <summary>
        /// 绘制文字
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="name"></param>
        /// <param name="fontSize"></param>
        /// <param name="isBlackColor"></param>
        /// <param name="isSpecialFont"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DrawString(ScantronCreation answerSheetModel, string name, int fontSize, bool isBlackColor, bool isSpecialFont, int x, int y)
        {
            var fontFamily = isSpecialFont ? "汉仪旗黑-50S" : "微软雅黑";
            var font = new Font(fontFamily, fontSize, GraphicsUnit.Pixel);
            var solidBrush = new SolidBrush(isBlackColor ? this.generalColor : this.specialColor);
            answerSheetModel.Graphics.DrawString(name, font, solidBrush, x, y);
        }

        /// <summary>
        /// 增加pointY值
        /// </summary>
        /// <param name="addLength">增加的长度</param>
        private void AddPointY(ScantronCreation answerSheetModel,int addLength)
        {
            answerSheetModel.PointY = answerSheetModel.PointY + addLength;
        }

        /// <summary>
        /// 数组转换为汉子，只考虑两位数情况
        /// </summary>
        /// <param name="number">带转换数字</param>
        /// <returns></returns>
        private string NumberToChinese(int number)
        {
            string[] chineseArray = new string[] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };
            if (number >= 100)
            {
                return number.ToString();
            }
            if (number <= 10)
            {
                return chineseArray[number];
            }
            if (number / 10 == 1)
            {
                return string.Concat(chineseArray[10], number % 10 == 0 ? string.Empty : chineseArray[number % 10]);
            }
            return string.Concat(chineseArray[number / 10], "十", number % 10 == 0 ? string.Empty : chineseArray[number % 10]);
        }

        /// <summary>
        /// 判断是否需要换页，如果需要则换页并返回true
        /// </summary>
        /// <param name="answerSheetModel"></param>
        /// <param name="questionRowHeight"></param>
        /// <returns></returns>
        private bool ChangePageResult(ScantronCreation answerSheetModel, int questionRowHeight)
        {
            if (answerSheetModel.PointY + questionRowHeight > PaintHeight - PaintPadding - 40 - 10 - 10)
            {
                this.ChangePage(answerSheetModel);
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 参数Model
    /// </summary>
    public class ScantronCreation
    {
        public Bitmap Bitmap { get; set; }

        public Graphics Graphics { get; set; }

        public int PageNumber { get; set; }

        public int PointX { get; set; }

        public int PointY { get; set; }
    }
}
