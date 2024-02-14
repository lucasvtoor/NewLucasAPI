﻿using API.Requests;

namespace API.Headers;

[Header]

public class AcceptRangesHeader : Header
{
    internal string RangeUnit;
    public override void Read(HttpRequest request, string content)
    {
        if(!content.Contains("Accept-Ranges: ")) return;
        RangeUnit = content.Substring("Accept-Ranges: ".Length);

    }

    public override async Task Write(HttpResponse response)
    {
        await response.WriteOutputAsync($"Accept-Ranges: {RangeUnit}");
    }
}