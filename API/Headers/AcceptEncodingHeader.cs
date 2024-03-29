﻿using System.Net.Sockets;
using System.Text;
using API.Headers.Structs;
using API.Requests;

namespace API.Headers;

public class AcceptEncodingHeader : Header
{
    public AcceptEncoding[] AcceptEncodings;
    
    public override void Read(HttpRequest request,string content)
    {
        
    }

    public override async Task Write(NetworkStream stream)
    {
        var sb = new StringBuilder();
        sb.Append("Accept-Encoding: ");
        foreach (var accept in AcceptEncodings)
        {
            sb.Append(accept);
        }

        sb.Remove(sb.Length - 2, sb.Length);
        stream.WriteStringAsync(sb.ToString());
    }
}