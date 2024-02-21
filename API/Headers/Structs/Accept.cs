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
    public static List<Accept> ParseAcceptHeader(string acceptHeader)
    {
        var accepts = new List<Accept>();

        var mimeStrings = acceptHeader.Split(',');

        foreach (var s in mimeStrings)
        {
            string[] x = s.Split("/");
            var mimeType = x[0];
            var mimeSubType = "";
            float qfactor = 1f; // default q-factor is 1
            if (x[1].Contains(';'))
            {
                var y = x[1].Split(';');
                mimeSubType = y[0].Trim();
                var qFactorEntry = y.FirstOrDefault(entry => entry.Contains("q="));
                if (qFactorEntry != null)
                {
                    qfactor = float.Parse(qFactorEntry.Split('=')[1]);
                }
            }
            else
                mimeSubType = x[1].Trim();
          
            accepts.Add(new Accept { MimeType = mimeType, MimeSubType = mimeSubType, QFactorWeighting = qfactor });
        }
    
        return accepts;
    }

   


    public override string ToString()
    {
        return $"{MimeType}/{MimeSubType}{QFactorWeighting.QFactorWeight()} ";
    }
}