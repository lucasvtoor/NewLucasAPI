namespace HTML;

public class DocType
{
    private string Type = "html";


    public override string ToString()
    {
        return $"<!DOCTYPE {Type}>";
    }
}