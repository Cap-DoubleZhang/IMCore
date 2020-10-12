using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DtoModel.IMCore
{
    public class SendMessageDto
    {
        /// <summary>
        /// 发送者ID
        /// </summary>
        public Guid SendId { get; set; }
        /// <summary>
        /// 接受者ID
        /// </summary>
        public Guid ReceiveId { get; set; }
        /// <summary>
        /// 发送消息类型
        /// </summary>
        public WebSocketMsgTypeEnum SendType{ get; set; }
        /// <summary>
        /// 发送消息内容
        /// </summary>
        public string Message { get; set; }
    }
}
