
namespace NFine.Code
{
    /// <summary>
    /// by.L   下拉数据 
    /// </summary>
    public class TreeSelectModel
    {
        //树id
        public string id { get; set; }  
        //树文本
        public string text { get; set; }
        //父id
        public string parentId { get; set; }
        //树数据
        public object data { get; set; }
    }
}
