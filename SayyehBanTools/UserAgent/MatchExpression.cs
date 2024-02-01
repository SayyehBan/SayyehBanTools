using System.Text.RegularExpressions;

namespace SayyehBanTools.UserAgent;

public class MatchExpression
{
    public List<Regex> Regexes { get; set; }

    public Action<System.Text.RegularExpressions.Match, object> Action { get; set; }
}
