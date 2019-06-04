using System.Collections.Generic;
using System.Text;
namespace NFine.Code
{
    /// <summary>
    /// by.L 2018年9月7日 10:10:14  树结构方法
    /// </summary>
    public static class TreeSelect
    {
        /// <summary>
        /// 讲树结构数据返回的数据格式形成为： {[{"id":"1","text":"A级","parentid":"0"}]}
        /// </summary>
        /// <param name="data">树数据</param>
        /// <returns></returns>
        public static string TreeSelectJson(this List<TreeSelectModel> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(TreeSelectJson(data, "0", "")); // 走TreeSelectJson方法，形成树结构样式，
            sb.Append("]");
            return sb.ToString();
        }
        /// <summary>
        /// 形成树结构方法 (判断parentid是否等于0，True则跳出tabline赋值的空格值(ps：只有父级id是0不进赋值空格条件，其他全部遍历空格累加)，False则赋值空格值，以此往下推1空格，2空格...)
        /// </summary>
        /// <param name="data">树数据</param>
        /// <param name="parentId">父id</param>
        /// <param name="blank">赋值空格值，每下一级赋值上一级的空格值+1</param>
        /// <returns></returns>
        private static string TreeSelectJson(List<TreeSelectModel> data, string parentId, string blank)
        {
            StringBuilder sb = new StringBuilder();
            var ChildNodeList = data.FindAll(t => t.parentId == parentId);
            var tabline = "";
            if (parentId != "0")
            {
                tabline = "　　";  //除父级id不赋值
            }
            if (ChildNodeList.Count > 0)
            {
                tabline = tabline + blank;
            }
            foreach (TreeSelectModel entity in ChildNodeList)
            {
                entity.text = tabline + entity.text;
                string strJson = entity.ToJson();
                sb.Append(strJson);
                sb.Append(TreeSelectJson(data, entity.id, tabline));
            }
            return sb.ToString().Replace("}{", "},{");
        }
    }
}