namespace HTML;

public static class HtmlExtensions
{
    public static string ToString(this Rel rel)
    {
        return rel.ToString().ToLower();
    }

    public static string ToString(this Target target)
    {
        switch (target)
        {
            case Target.Blank:
                return "_blank";
            case Target.Parent:
                return "_parent";
            case Target.Self:
                return "_self";
            case Target.Top:
                return "_top";
            default:
                throw new ArgumentException("Invalid referrer policy");
        }
    }

    public static string ToString(this ReferrerPolicy referrerPolicy)
    {
        switch (referrerPolicy)
        {
            case ReferrerPolicy.NoReferrer:
                return "no-referrer";
            case ReferrerPolicy.NoReferrerWhenDowngrade:
                return "no-referrer-when-downgrade";
            case ReferrerPolicy.Origin:
                return "origin";
            case ReferrerPolicy.OriginWhenCrossOrigin:
                return "origin-when-cross-origin";
            case ReferrerPolicy.SameOrigin:
                return "same-origin";
            case ReferrerPolicy.StrictOrigin:
                return "strict-origin";
            case ReferrerPolicy.StrictOriginWhenCrossOrigin:
                return "strict-origin-when-cross-origin";
            case ReferrerPolicy.UnsafeUrl:
                return "unsafe-url";
            default:
                throw new ArgumentException("Invalid referrer policy");
        }
    }
}