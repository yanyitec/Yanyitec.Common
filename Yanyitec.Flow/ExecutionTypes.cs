using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Flow
{
    public enum ExecutionTypes
    {
        /// <summary>
        /// c#源代码
        /// </summary>
        CSharp,
        /// <summary>
        /// 编译后的dotnet
        /// </summary>
        DotnetIL,
        /// <summary>
        /// JS脚本
        /// </summary>
        ES
    }
}
