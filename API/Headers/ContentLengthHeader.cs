﻿using System.Net.Sockets;
using API.Requests;

namespace API.Headers;

[Header]
public class ContentLengthHeader : Header
{
    public int Length;

    public override void Read(HttpRequest request, string content)
    {
        if (content.Contains("Content-Length:"))
        {
            Length = int.Parse(content.Substring("Content-Length: ".Length,
                content.Length - "Content-Length: ".Length));
            request.AddHeader(this);
        }
    }

    public override async Task Write(NetworkStream stream)
    {
        await stream.WriteStringAsync($"Content-Length: {Length}");
    }
}