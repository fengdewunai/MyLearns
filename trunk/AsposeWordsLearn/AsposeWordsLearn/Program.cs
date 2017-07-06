using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeWordsLearn
{
    using System.Data;

    using Aspose.Words;
    using Aspose.Words.Tables;

    class Program
    {
        private const string templateFile = "Template/template.docx";

        private const string saveDocFile = "test.docx";

        static void Main(string[] args)
        {
            //书签
            //var bookMarkTest = new BookMarkTest();
            //bookMarkTest.ProcessAction();

            //创建表格
            var buildTableTest = new BuildTableTest();
            buildTableTest.ProcessAction();
        }

        public static void Test()
        {
            try
            {
                Aspose.Words.Document doc = new Aspose.Words.Document(templateFile);
                Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);

                DataTable nameList = CreateTable("编号,姓名,时间");
                DataRow row = null;
                for (int i = 0; i < 50; i++)
                {
                    row = nameList.NewRow();
                    row["编号"] = i.ToString().PadLeft(4, '0');
                    row["姓名"] = "伍华聪 " + i.ToString();
                    row["时间"] = DateTime.Now.ToString();
                    nameList.Rows.Add(row);
                }

                List<double> widthList = new List<double>();
                for (int i = 0; i < nameList.Columns.Count; i++)
                {
                    builder.MoveToCell(0, 0, i, 0); //移动单元格
                    double width = builder.CellFormat.Width;//获取单元格宽度
                    widthList.Add(width);
                }

                var bmTableTitle = doc.Range.Bookmarks["tableTitle"];
                bmTableTitle.Text = "aaaa";

                var bm = doc.Range.Bookmarks["table"];
                builder.MoveTo(bm.BookmarkEnd);        //开始添加值
                for (var i = 0; i < nameList.Rows.Count; i++)
                {
                    for (var j = 0; j < nameList.Columns.Count; j++)
                    {
                        builder.InsertCell();// 添加一个单元格                    
                        builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                        builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                        builder.CellFormat.Width = widthList[j];
                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                        builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                        builder.Write(nameList.Rows[i][j].ToString());
                    }
                    builder.EndRow();
                }
                builder.EndTable();
                doc.Range.Bookmarks["table"].Text = "";    // 清掉标示  

                var bm2 = doc.Range.Bookmarks["table2"];
                builder.MoveTo(bm2.BookmarkEnd);        //开始添加值
                for (var i = 0; i < nameList.Rows.Count; i++)
                {
                    for (var j = 0; j < nameList.Columns.Count; j++)
                    {
                        builder.InsertCell();// 添加一个单元格                    
                        builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                        builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
                        builder.CellFormat.Width = widthList[j];
                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                        builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
                        builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
                        builder.Write(nameList.Rows[i][j].ToString());
                    }
                    builder.EndRow();
                }
                builder.EndTable();
                doc.Range.Bookmarks["table2"].Text = "";    // 清掉标示  

                builder.MoveToBookmark("mulu");     //目录
                builder.Document.Range.UpdateFields();

                //更新所有域
                //doc.UpdateFields();

                doc.Save(saveDocFile);
                System.Diagnostics.Process.Start(saveDocFile);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static DataTable CreateTable(string columnNames)
        {
            var dt = new DataTable();
            foreach (var columnName in columnNames.Split(','))
            {
                dt.Columns.Add(new DataColumn() { ColumnName = columnName });
            }
            return dt;
        }
    }
}
