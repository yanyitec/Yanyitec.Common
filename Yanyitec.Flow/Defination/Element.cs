using System;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Flow.Defination
{
    public class Element :Entity
    {
        public Guid DiagramId { get; set; }
        /// <summary>
        /// 标题 显示用
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述 显示用
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public DiagramTypes DiagramType { get; set; }

        /// <summary>
        /// 横坐标
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// 纵坐标
        /// </summary>
        public int y { get; set; }
        /// <summary>
        /// 宽
        /// </summary>

        public int w { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public int h { get; set; }

        public ActivityStates Status { get; set; }
    }
}
