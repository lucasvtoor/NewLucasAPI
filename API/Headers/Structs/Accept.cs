namespace API.Headers.Structs;

public struct Accept
{
    public string MimeType = "*";
    public string MimeSubType = "*";
    public float QFactorWeighting = 0f;

    public Accept(string MimeType = "*", string MimeSubType = "*", float QFactorWeighting = 0f)
    {
    }

    public static implicit operator Accept(string s)
    {
        string[] x = s.Split("/");
        var mimeType = x[0];
        var mimeSubType = "";
        float qfactor = 0f;
        if (x[1].Contains(';'))
        {
            var y = x[1].Split(';');
            mimeSubType = y[0];
            qfactor = float.Parse(y[1].Split('=')[1]);
        }
        return new Accept { MimeType = mimeType, MimeSubType = mimeSubType, QFactorWeighting = qfactor };
    }

   


    public override string ToString()
    {
        return $"{MimeType}/{MimeSubType}{QFactorWeighting.QFactorWeight()} ";
    }
}