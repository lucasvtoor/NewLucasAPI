namespace API.Headers.Structs;

public struct HeaderDate
{
    public string DayName;
    public string Day;
    public string Month;
    public string Year;
    public string Hour;
    public string Minute;
    public string Second;

    public static implicit operator HeaderDate(DateTime d)
    {
        d = d.ToUniversalTime();
        return new HeaderDate
        {
            DayName = d.ToString("ddd"),
            Day = d.ToString("dd"),
            Month = d.ToString("MMM"),
            Year = d.ToString("yyyy"),
            Hour = d.ToString("hh"),
            Minute = d.ToString("mm"),
            Second = d.ToString("ss")
        };
    }

    public static implicit operator DateTime(HeaderDate d)
    {
        return new DateTime(int.Parse(d.Year), int.Parse(d.Month), int.Parse(d.Day), int.Parse(d.Hour),
            int.Parse(d.Minute), int.Parse(d.Second), DateTimeKind.Utc);
    }
}