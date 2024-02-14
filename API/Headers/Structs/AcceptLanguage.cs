namespace API.Headers.Structs;

public struct AcceptLanguage
{
    public string Language = "*";
    public float QFactorWeighting = 0f;

    public AcceptLanguage(string language = "*", float QFactorWeighting = 0f)
    {
    }

    public static implicit operator AcceptLanguage(string s)
    {
        var language = s;
        float qfactor = 0;
        if (s.Contains(';'))
        {
            var y = s.Split(';');
            language = y[0];
            qfactor = float.Parse(y[1].Split('=')[1]);
        }
        return new AcceptLanguage{ Language = language, QFactorWeighting = qfactor };
    }

   


    public override string ToString()
    {
        return $"{Language}{QFactorWeighting.QFactorWeight()} ";
    }
}