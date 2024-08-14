﻿using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalR.Services.SignalRCommentServices;
using MultiShop.SignalR.Services.SignalRMessageServices;

namespace MultiShop.SignalR.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ISignalRMessageService _signalRService;
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRMessageService signalRService, ISignalRCommentService signalRCommentService)
        {
            _signalRService = signalRService;
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.TotalCommentCount();

            var getTotalMessageCount =  await _signalRService.TotalMessageByReceiverId("1");

            await Clients.All.SendAsync("ReceiverCommentCount", getTotalCommentCount);
            await Clients.All.SendAsync("ReceiverMessageCount", getTotalMessageCount);
        }
    }
}