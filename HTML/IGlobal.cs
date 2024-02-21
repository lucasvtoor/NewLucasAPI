namespace HTML;

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