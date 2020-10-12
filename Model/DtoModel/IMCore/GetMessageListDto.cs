using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DtoModel.IMCore
{
    public class GetMessageListDto
    {
        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        public string CurrentId { get; set; }
        /// <summary>
        /// 要获取的聊天者的ID
        /// </summary>
        public string FrientId { get; set; }

    }
}
