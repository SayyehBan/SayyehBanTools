/// <summary>
/// اینترفیس ارسال پیام به صورت سنکرون
/// </summary>
public interface ISendMessages
{
    /// <summary>
    /// ارسال پیام
    /// </summary>
    /// <param name="message"></param>
    /// <param name="exchange"></param>
    /// <param name="QueueName"></param>
    void SendMessage(BaseMessage message,string? exchange, string? QueueName);
}
