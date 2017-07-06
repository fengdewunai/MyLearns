using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeWordsLearn
{
    using System.Drawing;

    using Aspose.Words;
    using Aspose.Words.Drawing;
    using Aspose.Words.Reporting;

    public class HandleMergeFieldInsertDocument : IFieldMergingCallback
    {
        public void FieldMerging(FieldMergingArgs args)
        {
            if (args.DocumentFieldName.Equals("name"))
            {
                // 使用DocumentBuilder处理图片的大小
                DocumentBuilder builder = new DocumentBuilder(args.Document);
                builder.MoveToMergeField(args.FieldName);
                builder.Font.Color = Color.BlueViolet;
                builder.Write(args.FieldValue.ToString());
            }
        }

        public void ImageFieldMerging(ImageFieldMergingArgs args)
        {
            if (args.DocumentFieldName.Equals("photo"))
            {
                // 使用DocumentBuilder处理图片的大小
                DocumentBuilder builder = new DocumentBuilder(args.Document);
                builder.MoveToMergeField(args.FieldName);

                Shape shape = builder.InsertImage(args.FieldValue.ToString());

                // 设置x,y坐标和高宽.
                shape.Left = 0;
                shape.Top = 0;
                shape.Width = 100;
                shape.Height = 120;
            }
        }
    }
}
