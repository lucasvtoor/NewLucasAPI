namespace API.Headers.Structs;

public struct AcceptEncoding
{
    public EncodingType Type = EncodingType.all;
    public float QWeightedValue = 0.0f;

    public AcceptEncoding(EncodingType type = EncodingType.all,float qWeightedValue = 0.0f)
    {
        Type = type;
        QWeightedValue = qWeightedValue;
    }
}