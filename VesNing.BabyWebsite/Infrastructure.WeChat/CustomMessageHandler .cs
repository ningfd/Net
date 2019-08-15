using Senparc.NeuChar.Context;
using Senparc.NeuChar.Entities;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.WeChat
{
    internal class CustomMessageHandler : MessageHandler<MessageContext<IRequestMessageBase, IResponseMessageBase>>
    {
        public CustomMessageHandler(Stream inputStream, PostModel postModel)
            : base(inputStream, postModel)
        {
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "这条消息来自于DefaultResponseMessage";
            return responseMessage;
        }
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            ResponseMessageText messageText = base.CreateResponseMessage<ResponseMessageText>();
            if (requestMessage.Content == "ID")
                messageText.Content = "您的OpenID是：" + messageText.FromUserName;
            if (requestMessage.Content == "天气")
                messageText.Content = "抱歉，还未开通此功能！";
            return messageText;
        }
    }
}
