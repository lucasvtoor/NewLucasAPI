using System.Net.Sockets;
using API.Headers.Structs;
using API.Requests;

namespace API.Headers;

[Header]

public class LastModifiedHeader : Header
{
    /*
     * Implicitly takes a DateTime cause I'm chill like that.
     */
    public HeaderDate date;

    public override void Read(HttpRequest request, string content)
    {
        if (!content.Contains("Last-Modified:")) return;
        date = new HeaderDate
        {
            DayName = content.Substring(6,3),
            Day = content.Substring(11,2),
            Month = content.Substring(14,3),
            Year = content.Substring(18,4),
            Hour = content.Substring(23,2),
            Minute = content.Substring(26,2),
            Second = content.Substring(29,2)
        };
        request.AddHeader(this);
    }

    public override async Task Write(NetworkStream stream)
    {
        await stream.WriteStringAsync(
            $"Last-Modified: {date.DayName}, {date.Day} {date.Month} {date.Year} {date.Hour}:{date.Minute}:{date.Second} GMT");
    }
}