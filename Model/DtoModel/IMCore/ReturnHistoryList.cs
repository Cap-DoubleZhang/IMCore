using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DtoModel.IMCore
{
    public class ReturnHistoryList
    {
        /// <summary>
        /// 被发送人名称
        /// </summary>
        public string UserShowName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadPortrait { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }
    }
}
