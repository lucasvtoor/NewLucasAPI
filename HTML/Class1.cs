namespace HTML;

public class DocType
{
    private string Type = "html";


    public override string ToString()
    {
        return $"<!DOCTYPE {Type}>";
    }
}

public class A : HyperLink
{
}

public enum InputModes
{
    Decimal,
    Email,
    None,
    Numeric,
    Search,
    Tel,
    Text,
    Url
}

public interface IGlobal
{
    public char AccessKey { get; set; }
    public string CSSClass { get; set; }
    public bool ContentEditable { get; set; }
    public Dictionary<string, string> DataTags { get; set; }
    public string Dir { get; set; }
    public bool Draggable { get; set; }
    public string EnterKeyHint { get; set; }
    public bool Hidden { get; set; }
    public string Id { get; set; }
    public string Lang { get; set; }
    public string Title { get; set; }
    public string Style { get; set; }
    public bool Inert { get; set; }
    public InputModes InputMode { get; set; }
    public string PopOver { get; set; }
    public bool SpellCheck { get; set; }
    public bool Translate { get; set; }
    public int TabIndex { get; set; }
}

public interface IEvent
{
}

public class Tag : IGlobal, IEvent
{
    public List<Tag> Inner;
}

public class HyperLink : Tag
{
    public string Href;
    public string Download;
    public string HrefLang;
    public string Media;
    public string Ping;
    public ReferrerPolicy ReferrerPolicy;
    public Rel Rel;
    public Target Target;
    public string Type;
}

public enum Target
{
    Blank,
    Parent,
    Self,
    Top
}

public enum ReferrerPolicy
{
    NoReferrer,
    NoReferrerWhenDowngrade,
    Origin,
    OriginWhenCrossOrigin,
    SameOrigin,
    StrictOrigin,
    StrictOriginWhenCrossOrigin,
    UnsafeUrl
}

public enum Rel
{
    Alternate,
    Author,
    Bookmark,
    External,
    Help,
    License,
    Next,
    Nofollow,
    Noreferrer,
    Pingback,
    Preconnect,
    Prefetch,
    Prev,
    Search,
    Tag
}

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

public class Abbreviation : Tag
{
}

public class Abbr : Abbreviation
{
}

public class Map : Tag
{
    public string Name;
}

public class Address : Tag
{
}

public enum Shape
{
    Default,
    Rect,
    Circle,
    Poly
}

public class Area : Tag
{
    public Map Parent;
    public string Alt;
    public string Coords;
    public string Download;
    public string Href;
    public string HrefLang;
    public string Media;
    public ReferrerPolicy ReferrerPolicy;
    public Rel Rel;
    public Shape Shape;
    public string Type;
}

public class Article : Tag
{
}

public class Aside : Tag
{
}

public enum Preload
{
    Auto,
    Metadata,
    None
}

public class Audio : Tag
{
    public bool Autoplay;
    public bool Controls;
    public bool Loop;
    public bool Muted;
    public Preload Preload;
    public string Src;
}

public class Bold : Tag
{
}

public class B : Bold
{
}

public class Base : Tag
{
    public string Href;
    public Target Target;
}

public class BiDirectionalIsolation : Tag
{
}

public class BDI : BiDirectionalIsolation
{
}

public class BiDirectionalOverride : Tag
{
}

public class BDO : BiDirectionalOverride
{
    public bool Dir;
}

public class BlockQuote : Tag
{
    public string Cite;
}

public class Body : Tag
{
}

public class Br : Tag
{
}

public enum FormEncodingType
{
    ApplicationXWWWFormUrlEncoded,
    MultiPartFormData,
    TextPlain
}

public enum FormMethod
{
    Get,
    Post
}

public enum PopOverTargetAction
{
    Hide,
    Show,
    Toggle
}

public enum Type
{
    Button,
    Reset,
    Submit
}

public class Button : Tag
{
    public bool AutoFocus;
    public bool Disables;
    public string Form;
    public string FormAction;
    public FormEncodingType FormEncodingType;
    public bool FormNoValidate;
    public Target FormTarget;
    public string PopOverTarget;
    public PopOverTargetAction PopOverTargetAction;
    public string Name;
    public Type Type;
    public string Value;
}

public class Canvas : Tag
{
    public int Height;
    public int Width;
}

public class Caption : Tag
{
}

public class Cite : Tag
{
}

public class Code : Tag
{
}

public class Col : Tag
{
    public int Span;
}

public class Column : Col
{
}

public class ColGroup : Tag
{
    public int Span;
}

public class ColumnGroup : ColGroup
{
}

public class Data : Tag
{
    public string Value;
}

public class DataList : Tag
{
}

public class DD : Tag
{
}

public class Del : Tag
{
    public string Cite;
    public DateTime DateTime;
}

public class Deleted : Del
{
}

public class Details : Tag
{
    public bool Open;
}

public class Dfn : Tag
{
}

public class DefinitionElement : Dfn
{
}

public class Dialog : Tag
{
    public bool Open;
}

public class Div : Tag
{
}

public class Division : Div
{
}

public class Dl : Tag
{
}

public class DList : Tag
{
}

public class Dt : Tag
{
}

public class Em : Tag
{
}

public class Emphasized : Em
{
}

public class Embed : Tag
{
    public int Height;
    public int Width;
    public string Src;
    public string Type;
}

public class FieldSet : Tag
{
    public bool Disabled;
    public string FormId;
    public string Name;
}

public class FigCaption : Tag
{
}

public class FigureCaption : Tag
{
}

public class Figure : Tag
{
}

public class Footer : Tag
{
}

public class Form : Tag
{
    public string AcceptCharset;
    public string Action;
    public bool AutoComplete;
    public FormEncodingType EncodingType;
    public FormMethod Method;
    public string Name;
    public bool NoValidate;
    public Rel Rel;
    public Target Target;
}

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

public class H1 : H
{
    public H1()
    {
        Size = 1;
    }
}

public class H2 : H
{
    public H2()
    {
        Size = 2;
    }
}

public class H3 : H
{
    public H3()
    {
        Size = 3;
    }
}

public class H4 : H
{
    public H4()
    {
        Size = 4;
    }
}

public class H5 : H
{
    public H5()
    {
        Size = 5;
    }
}

public class H6 : H
{
    public H6()
    {
        Size = 6;
    }
}

public class Head : Tag
{
}

public class Header : Tag
{
}

public class HGroup : Tag
{
}

public class Hr : Tag
{
}

public class Html : Tag
{
}

public class I : Tag
{
}

public class Italic : I
{
}

public enum Loading
{
    Eager,
    Lazy
}

public enum Sandbox
{
    AllowForms,
    AllowPointerLock,
    AllowPopups,
    AllowSameOrigin,
    AllowScripts,
    AllowTopNavigation
}

public class IFrame : Tag
{
    public string Allow;
    public bool AllowFullScreen;
    public bool AllowPaymentRequest;
    public int Height;
    public Loading Loading;
    public string Name;
    public ReferrerPolicy ReferrerPolicy;
    public Sandbox Sandbox;
    public string Src;
    public string SrcDoc;
    public int Width;
}

public class InlineFrame : IFrame
{
}

public class Image : Img
{
}

public enum CrossOrigin
{
    Anonymous,
    UseCredentials
}

public class Img : Tag
{
    public string Alt;
    public CrossOrigin CrossOrigin;
    public int Height;
    public bool IsMap;
    public Loading Loading;
    public string LongDesc;
    public ReferrerPolicy ReferrerPolicy;
    public string Sizes;
    public string Src;
    public string SrcSet;
    public string UseMap;
    public int Width;
}

public enum InputType
{
    Button,
    Checkbox,
    Color,
    Date,
    DateTimeLocal,
    Email,
    File,
    Hidden,
    Image,
    Month,
    Number,
    Password,
    Radio,
    Range,
    Reset,
    Search,
    Submit,
    Tel,
    Text,
    Time,
    Url,
    Week
}

public class Input : Tag
{
    public InputType InputType;
    public string Accept;
    public string Alt;
    public bool AutoComplete;
    public bool AutoFocus;
    public bool Checked;
    public string DirName;
    public bool Disabled;
    public string FormId;
    public string FormAction;
    public FormEncodingType FormEncodingType;
    public FormMethod FormMethod;
    public bool FormNoValidate;
    public Target Target;
    public int Pixels;
    public long Max;
    public int MaxLength;
    public long Min;
    public int MinLength;
    public bool Multiple;
    public string Name;
    public string Pattern;
    public string PlaceHolder;
    public string PopOverTarget;
    public PopOverTargetAction PopOverTargetAction;
    public bool ReadOnly;
    public bool Required;
    public int Size;
    public string Src;
    public string Step;
    public string Value;
    public int Width;
}

public class Ins : Tag
{
    public string Cite;
    public DateTime DateTime;
}

public class Inserted : Ins
{
}

public class Kbd : Tag
{
}

public class Keyboard : Kbd
{
}

public class Label : Tag
{
    public string ElementId;
    public string FormId;
}

public class Legend : Tag
{
}

public class Li : Tag
{
    public int Value;
}

public class ListItem : Li
{
}

public class Link : Tag
{
    public CrossOrigin CrossOrigin;
    public string Href;
    public string HrefLang;
    public string Media;
    public ReferrerPolicy ReferrerPolicy;
    public Rel Rel;
    public string Sizes;
    public string Ttile;
    public string Type;
}

public class Main : Tag
{
}

public class Mark : Tag
{
}

public class Menu : Tag
{
}

public enum HttpEquivalent
{
    ContentSecurityPolicy,
    ContentType,
    DefaultStyle,
    Refresh
}

public enum MetaName
{
    ApplicationName,
    Author,
    Description,
    Generator,
    Keywords,
    Viewport
}

public class Meta : Tag
{
    public string CharSet;
    public string Content;
    public HttpEquivalent HttpEquivalent;
    public MetaName Name;
}

public class Meter : Tag
{
    public string FormId;
    public int High;
    public int Low;
    public int Max;
    public int Min;
    public int Optimum;
    public int Value;
}

public class Nav : Tag
{
}

public class Navigation : Nav
{
}

public class NoScript : Tag
{
}

public class Object : Tag
{
    public string Data;
    public string FormId;
    public int Height;
    public string Name;
    public string Type;
    public bool TypeMustMatch;
    public string UseMap;
    public int Width;
}

public class Ol : Tag
{
    public bool Reversed;
    public int Start;
    public string Type;
}

public class OptGroup : Tag
{
    public bool Disabled;
    public string Label;
}

public class OptionGroup : OptGroup
{
}

public class Option : Tag
{
    public bool Disabled;
    public string Label;
    public bool Selected;
    public string Value;
}

public class Output
{
    public string For;
    public string Form;
    public string Name;
}

public class P : Tag
{
}

public class Paragraph : P
{
}

public class Param : Tag
{
    public string Name;
    public string Value;
}

public class Picture : Tag
{
}

public class Pre : Tag
{
    
}

public class Progress : Tag
{
    public int Max;
    public int Value;
}

public class Q : Tag
{
    public string Cite;
}

public class Quote : Tag
{
    
}

public class Rp : Tag
{
    
}

public class RubyParentheses : Rp
{
    
}

public class Rt : Tag
{
    
}

public class Ruby : Tag
{
    
}

public class S : Tag
{
    
}

public class Samp : Tag
{
    
}

public class Script : Tag
{
    public string Async;
    public CrossOrigin CrossOrigin;
    public string Defer;
    public string Integrity;
    public bool NoModule;
    public ReferrerPolicy ReferrerPolicy;
    public string Src;
    public string Type;
}

public class Search : Tag
{
    
}

public class Section : Tag
{
    
}