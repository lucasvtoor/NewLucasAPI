namespace HTML;

public class H : Tag
{
    public short Size
    {
        set
        {
            if (value > 6)
            {
                value = 6;
            }
        }
    }
}