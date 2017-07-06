using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;

namespace AsposeWordsLearn
{
    using System.Data;
    using System.Drawing;

    using Aspose.Words.Tables;

    /// <summary>
    /// 创建表格
    /// </summary>
    public class BuildTableTest
    {
        /// <summary>
        /// 模板路径
        /// </summary>
        private const string TemplateFile = "Template/BuildTableTemplate.docx";
        /// <summary>
        /// 保存路径
        /// </summary>
        private const string SaveDocFile = "BuildTableTest.docx";

        /// <summary>
        /// 处理逻辑
        /// </summary>
        public void ProcessAction()
        {
            Document doc = new Document(TemplateFile);
            DocumentBuilder builder = new DocumentBuilder(doc);
            CreateTable(doc, builder);
            CreateTableByMergeMail(doc, builder);
            CreateCircleTableByMergeMail(doc, builder);
            CreateInsetTable(doc, builder);
            CreateTableByHtml(doc, builder);

            doc.Save(SaveDocFile);
            System.Diagnostics.Process.Start(SaveDocFile);
        }

        /// <summary>
        /// 创建table
        /// </summary>
        /// <param name="builder"></param>
        public void CreateTable(Document doc, DocumentBuilder builder)
        {
            builder.MoveToBookmark("table1");
            builder.StartTable();
            CreateCell(builder, "第一段标题");
            builder.CellFormat.HorizontalMerge = CellMerge.First;
            CreateCell(builder, "第一段标题");
            builder.CellFormat.HorizontalMerge = CellMerge.Previous;
            CreateCell(builder, "第二段标题");
            builder.CellFormat.HorizontalMerge = CellMerge.First;
            CreateCell(builder, "第二段标题");
            builder.CellFormat.HorizontalMerge = CellMerge.Previous;
            builder.EndRow();
            CreateCell(builder, "班级");
            CreateCell(builder,"姓名");
            CreateCell(builder, "性别");
            CreateCell(builder, "年龄");
            builder.EndRow();
            CreateCell(builder, "1班");
            builder.CellFormat.VerticalMerge = CellMerge.First;
            CreateCell(builder, "张三");
            CreateCell(builder, "男");
            builder.CellFormat.VerticalMerge = CellMerge.First;
            CreateCell(builder, "19");
            builder.EndRow();
            CreateCell(builder, "1班");
            builder.CellFormat.VerticalMerge = CellMerge.Previous;
            CreateCell(builder, "李四");
            CreateCell(builder, "男");
            builder.CellFormat.VerticalMerge = CellMerge.Previous;
            CreateCell(builder, "18");
            builder.CellFormat.VerticalMerge = CellMerge.First;
            builder.EndRow();
            CreateCell(builder, "1班");
            builder.CellFormat.VerticalMerge = CellMerge.Previous;
            CreateCell(builder, "王五");
            CreateCell(builder, "女");
            CreateCell(builder, "18");
            builder.CellFormat.VerticalMerge = CellMerge.Previous;
            builder.EndRow();
            builder.EndTable();
        }

        /// <summary>
        /// 采用MailMerge方式填充
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="builder"></param>
        public void CreateTableByMergeMail(Document doc, DocumentBuilder builder)
        {
            string logoPath = "Template/person.jpg";
            string[] fieldNames = { "name", "sex", "BirthDay", "Address","photo" };
            string[] fieldValues = { "张三", "男", "2000-09-02", "江西南昌", logoPath };
            doc.MailMerge.FieldMergingCallback = new HandleMergeFieldInsertDocument();
            doc.MailMerge.Execute(fieldNames, fieldValues);
        }

        /// <summary>
        /// 采用MailMerge方式循环填充
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="builder"></param>
        public void CreateCircleTableByMergeMail(Document doc, DocumentBuilder builder)
        {
            var dt = this.CreateTestDataTable();
            dt.TableName = "person";
            doc.MailMerge.ExecuteWithRegions(dt);
            doc.MailMerge.ExecuteWithRegions(dt);
        }

        /// <summary>
        /// 内嵌表格
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="builder"></param>
        public void CreateInsetTable(Document doc, DocumentBuilder builder)
        {
            DataSet dataSet = new DataSet();
            var dt = this.CreateTestDataTable();
            var insetDt = CreateInsetDataTable();
            dt.TableName = "person";
            insetDt.TableName = "score";
            dataSet.Tables.Add(dt);
            dataSet.Tables.Add(insetDt);
            dataSet.Relations.Add(new DataRelation("UserAndScore", dt.Columns["编号"], insetDt.Columns["学生编号"]));
            doc.MailMerge.ExecuteWithRegions(dataSet);
        }

        /// <summary>
        /// 通过html创建表格
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="builder"></param>
        public void CreateTableByHtml(Document doc, DocumentBuilder builder)
        {
            builder.MoveToBookmark("table5");
            builder.InsertHtml("<table border='1'>" +
                               "<tr>" +
                               "<td style='color:red'>Cell1</td>" +
                               "<td>Cell2</td>" +
                               "</tr>" +
                               "<tr>" +
                               "<td>Cell3</td>" +
                               "<td>Cell4</td>" +
                               "</tr>" +
                               "</table>");
        }


        /// <summary>
        /// 插入单元格
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="text"></param>
        public void CreateCell(DocumentBuilder builder, string text ,double width=100 )
        {
            builder.Font.Color = Color.Crimson;
            builder.InsertCell();// 添加一个单元格
            builder.CellFormat.Borders.LineStyle = LineStyle.Single;
            builder.CellFormat.Borders.Color = System.Drawing.Color.Black;
            builder.CellFormat.Width = width;
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;//垂直居中对齐
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;//水平居中对齐
            builder.CellFormat.VerticalMerge = CellMerge.None;
            builder.Write(text);
        }

        /// <summary>
        /// 创建测试数据
        /// </summary>
        /// <returns></returns>
        public DataTable CreateTestDataTable()
        {
            var dt = new DataTable();
            foreach (var column in "编号,姓名,出生日期".Split(','))
            {
                dt.Columns.Add(new DataColumn() { ColumnName = column });
            }
            DataRow row = null;
            for (int i = 0; i < 5; i++)
            {
                row = dt.NewRow();
                row["编号"] = i;
                row["姓名"] = "NO " + i.ToString();
                row["出生日期"] = DateTime.Now.ToString();
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 内嵌表格测试数据
        /// </summary>
        public DataTable CreateInsetDataTable()
        {
            var dt = new DataTable();
            foreach (var column in "学生编号,学科,成绩".Split(','))
            {
                dt.Columns.Add(new DataColumn() { ColumnName = column });
            }
            DataRow row = null;
            for (int i = 0; i < 5; i++)
            {
                row = dt.NewRow();
                row["学生编号"] = i;
                row["学科"] = "语文";
                row["成绩"] = (i*10).ToString();
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["学生编号"] = i;
                row["学科"] = "数学";
                row["成绩"] = (i * 5).ToString();
                dt.Rows.Add(row);
            }
            return dt;
        }
        
    }
}
