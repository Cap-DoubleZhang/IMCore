using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Model.DtoModel.IMCore;
using IServices.IMCore;
using Common.RedisHelper;
using Microsoft.Extensions.Logging;
using IServices;
using Model;
using Model.EntityModel.IMCore;

namespace CommonBaseRole.Controllers.IMCore
{
    [Route("api/[controller]")]
    [ApiController]
    public class IMController : CommonController
    {
        public string Ip => this.Request.Headers["X-Real-IP"].FirstOrDefault() ?? this.Request.HttpContext.Connection.RemoteIpAddress.ToString();

        private IRedisCacheManager RedisCacheManager;
        private ILogger<IMController> _logger;
        private IHistoryListServices _HistoryListServices;
        private IAllMsgListServices _AllMsgListServices;

        public IMController(IRedisCacheManager redisCacheManager, IHistoryListServices historyListServices, IAllMsgListServices allMsgListServices, ILogger<IMController> logger)
        {
            RedisCacheManager = redisCacheManager;
            _logger = logger;
            _HistoryListServices = historyListServices;
            _AllMsgListServices = allMsgListServices;
        }
        /// <summary>
        /// 需要先链接获取地址
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("pre-connect")]
        public object PrevConnectServer([FromBody] PreContenctDto guid)
        {
            return GetReturnJSONP(ImHelper.PrevConnectServer(guid.guid, this.Ip), true);
        }

        /// <summary>
        /// 用户发送消息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("SendMessage")]
        public async Task<object> SendMessage([FromBody] SendMessageDto dto)
        {
            //if (dto.SendType != WebSocketMsgTypeEnum.ReadInfo)
            //    await _Producer.SenMessage(AllStaticHelper.WaiterMessageQueueName, dto);
            //else
            //    await _Producer.SenMessage(AllStaticHelper.WaiterInfoMessageQueueName, new IMReadMsgDto { ShopORWaiterId = dto.SendId, UserId = dto.ReceiveId });
            ImHelper.SendMessage(dto.SendId, new[] { dto.ReceiveId }, new { sendMsg = dto.Message, dto.SendType, dto.SendId });
            AllMsgList allMsgList = new AllMsgList()
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                SendId = dto.SendId.ToString(),
                ReceiveId = dto.ReceiveId.ToString(),
                Message = dto.Message,
                IsRead = 0,
                CreateTime = DateTime.Now,
                CreateBy = dto.SendId.ToString(),
                LastUpdateTime = DateTime.Now,
            };
            await _AllMsgListServices.SaveEntityInfo(allMsgList);
            return GetReturnJSONP("发送成功");
        }

        /// <summary>
        /// 获取接收的信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("GetMessage")]
        public async Task<object> GetMessageList([FromBody] GetMessageListDto dto)
        {
            List<AllMsgList> allMsgLists = await _AllMsgListServices.GetEntity();
            return GetReturnJSONP(allMsgLists.Where(a => a.SendId == dto.FrientId && a.ReceiveId == dto.CurrentId));
        }
    }
}
