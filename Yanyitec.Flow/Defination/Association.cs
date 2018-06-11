using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Flow.Defination
{
    public class Association :Element
    {
        public Guid From { get; set; }
        public Guid To { get; set; }

        /// <summary>
        /// 定点
        /// </summary>
        public string Points { get; set; }

        public string Label { get; set; }
    }
}
