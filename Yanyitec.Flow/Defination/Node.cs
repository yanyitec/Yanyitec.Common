using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Flow.Defination
{
    public class Node : Element
    {
        public string Alias { get; set; }
        public ExecutionTypes ExecutionType { get; set; }
        /// <summary>
        /// 执行代码
        /// 内容依赖于ExecutionType而定
        /// CCharp c#源代码
        /// DotnetIL type full name.类全名或TypeDesciptor的json
        /// </summary>
        public string ExecutionCode { get; set; }

        public string Imports { get; set; }
    }
}
