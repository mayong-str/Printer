using LabelCommon;
using System.Data;

namespace LabelMaker
{
    public static class FieldMappingClass
    {
        /// <summary>将标签元素的Context替换为DataTable中相应字段的值。
        /// 
        /// </summary>
        /// <param name="lc">(LabelClass)标签类实例</param>
        /// <param name="dt">(DataTable)表</param>
        public static void Mapping(LabelClass lc, DataTable dt)
        {
            foreach (var item in lc.Elements)
            {
                if (item.GetType() == typeof(BarcodeElementClass))
                {
                    BarcodeElementClass bec = (BarcodeElementClass)item;
                    if (!string.IsNullOrEmpty(bec.Mapping))
                    {
                        bec.Context = SearchField(bec.Mapping, dt);
                    }
                }
                else if (item.GetType() == typeof(TextElementClass))
                {
                    TextElementClass tec = (TextElementClass)item;
                    if (!string.IsNullOrEmpty(tec.Mapping))
                    {
                        tec.Context = SearchField(tec.Mapping, dt);
                    }
                }
                else if (item.GetType() == typeof(QrCodeElementClass))
                {
                    QrCodeElementClass qrec = (QrCodeElementClass)item;
                    if (!string.IsNullOrEmpty(qrec.Mapping))
                    {
                        qrec.Context = SearchField(qrec.Mapping, dt);
                    }
                }
            }
        }

        /// <summary>根据Mapping字符串从DataTable中搜索并取得Context
        /// 
        /// </summary>
        /// <param name="mappingString">Mapping字符串</param>
        /// <param name="dt">(DataTable)表</param>
        /// <returns>Context</returns>
        private static string SearchField(string mappingString, DataTable dt)
        {
            if (dt.Rows.Count <= 0) return string.Empty;
            foreach (DataColumn col in dt.Columns)
            {
                if (mappingString.Equals(col.ColumnName))
                {
                    return dt.Rows[0][mappingString].ToString();
                }
            }
            return string.Empty;
        }
    }
}
