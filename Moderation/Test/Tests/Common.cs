using PoliNetwork.Telegram.Objects.Bot;

namespace ModerationTest.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void StartBot()
    {
        var telegramBotWrapper = new TestBot();
        telegramBotWrapper.Start(new CancellationToken());
        Assert.Pass();
    }
}