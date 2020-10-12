using System;
using System.Collections.Generic;
using System.Text;

namespace Model.EntityModel.IMCore
{
    /// <summary>
    /// 全部消息表
    /// </summary>
    public class AllMsgList : EntityCommon
    {
        /// <summary>
        /// 发送者ID
        /// </summary>
        public string SendId { get; set; }
        /// <summary>
        /// 接收者ID
        /// </summary>
        public string ReceiveId { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 是否已读 0:未读 1:已读
        /// </summary>
        public int IsRead { get; set; }
    }
}
