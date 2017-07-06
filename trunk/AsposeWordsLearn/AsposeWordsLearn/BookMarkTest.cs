using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeWordsLearn
{
    using System.Drawing;

    using Aspose.Words;

    /// <summary>
    /// 书签用法
    /// </summary>
    public class BookMarkTest
    {
        /// <summary>
        /// 模板路径
        /// </summary>
        private const string TemplateFile = "Template/BookMarkTemplate.docx";
        /// <summary>
        /// 保存路径
        /// </summary>
        private const string SaveDocFile = "BookMarkTest.docx";

        /// <summary>
        /// 处理逻辑
        /// </summary>
        public void ProcessAction()
        {
            Aspose.Words.Document doc = new Aspose.Words.Document(TemplateFile);
            Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);

            BookMarkTestMethod(doc, builder);

            InsertDocumentTest(doc, builder);

            doc.Save(SaveDocFile);
            System.Diagnostics.Process.Start(SaveDocFile);
        }

        /// <summary>
        /// 测试书签
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="builder"></param>
        public void BookMarkTestMethod(Document doc, DocumentBuilder builder)
        {
            builder.Font.Color = Color.Red;

            var bookMark1 = doc.Range.Bookmarks["bookmark1"];
            builder.MoveTo(bookMark1.BookmarkEnd);
            builder.Write("此处原来只有一个标签");
            doc.Range.Fields[3].Remove();

            var bookMark3 = doc.Range.Bookmarks["bookmark3"];
            bookMark3.Text = "我是替换后的文字";

            var bookMark2 = doc.Range.Bookmarks["bookmark2"];
            builder.MoveTo(bookMark2.BookmarkStart);
            builder.Font.Color = Color.Red;
            builder.Writeln("在段落前面插入文字");
            builder.MoveTo(bookMark2.BookmarkEnd);
            builder.InsertBreak(BreakType.LineBreak);
            builder.Font.Color = Color.Red;
            builder.Writeln("在段落后面插入文字");
        }

        /// <summary>
        /// 插入另一文档内容
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="builder"></param>
        public void InsertDocumentTest(Document doc, DocumentBuilder builder)
        {
            string srcDocPath = "Template/InsertContent.docx";
            Document srcDoc = new Document(srcDocPath);
            var bookMark4 = doc.Range.Bookmarks["bookmark4"];
            builder.MoveToBookmark("bookmark4");
            InsertDocument(bookMark4.BookmarkStart.ParentNode, srcDoc);
        }

        /// <summary>
        /// 在节点后插入另一文档内容
        /// </summary>
        /// <param name="insertAfterNode"></param>
        /// <param name="srcDoc"></param>
        static void InsertDocument(Node insertAfterNode, Document srcDoc)
        {
            // Make sure that the node is either a paragraph or table.
            if ((!insertAfterNode.NodeType.Equals(NodeType.Paragraph)) &
              (!insertAfterNode.NodeType.Equals(NodeType.Table)))
                throw new ArgumentException("The destination node should be either a paragraph or table.");

            // We will be inserting into the parent of the destination paragraph.
            CompositeNode dstStory = insertAfterNode.ParentNode;

            // This object will be translating styles and lists during the import.
            NodeImporter importer = new NodeImporter(srcDoc, insertAfterNode.Document, ImportFormatMode.KeepSourceFormatting);

            // Loop through all sections in the source document.
            foreach (Section srcSection in srcDoc.Sections)
            {
                // Loop through all block level nodes (paragraphs and tables) in the body of the section.
                foreach (Node srcNode in srcSection.Body)
                {
                    // Let's skip the node if it is a last empty paragraph in a section.
                    if (srcNode.NodeType.Equals(NodeType.Paragraph))
                    {
                        Paragraph para = (Paragraph)srcNode;
                        if (para.IsEndOfSection && !para.HasChildNodes)
                            continue;
                    }

                    // This creates a clone of the node, suitable for insertion into the destination document.
                    Node newNode = importer.ImportNode(srcNode, true);

                    // Insert new node after the reference node.
                    dstStory.InsertAfter(newNode, insertAfterNode);
                    insertAfterNode = newNode;
                }
            }
        }
    }
}
