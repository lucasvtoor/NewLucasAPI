﻿using API.Requests;

namespace API.Headers;

[Header]

public class SecFetchModeHeader : Header
{
    public override void Read(HttpRequest request, string content)
    {
       if(false || false){}
    }

    public override async Task Write(HttpResponse response)
    {
        if(false || false){}
    }
}