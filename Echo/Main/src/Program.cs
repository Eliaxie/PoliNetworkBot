﻿using PoliNetwork.Core.Data;
using PoliNetwork.Core.Utils;
using PoliNetwork.Core.Utils.LoggerNS;
using PoliNetwork.Telegram.Objects.Bot;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Echo;

internal static class Program
{
    private static TelegramBot? _telegramBot;
    private static readonly LogConfig LogConfig = new();

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (_telegramBot == null)
            return;

        // Only process Message updates: https://core.telegram.org/bots/api#message
        if (update.Message is not { } message)
            return;

        if (botClient.BotId != _telegramBot.GetId())
            return;

        //Simply handle every message update with the "echo" method
        await PoliNetwork.Telegram.Utils.Echo.EchoMethod(message, _telegramBot, cancellationToken);
    }

    public static void Main(string[] args)
    {
        Variables.DefaultLogger.SetLogConfing(LogConfig);
        Variables.DefaultLogger.Info("Hello, starting Echo bot!");
        _telegramBot = new TelegramBot("token", LogConfig);
        _telegramBot.Start(HandleUpdateAsync);
        Wait.WaitForeverConsoleReadline();
    }
}