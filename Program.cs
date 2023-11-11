Console.Write("Expression: ");
string? input = Console.ReadLine();
CheckData output = Check(input);
if (output.LeftUnmatched == null && output.RightUnmatched == null)
{
    Console.WriteLine("Match.");
    return;
}
if (output.LeftUnmatched != null)
{
    Console.WriteLine($"Left unmatch: {output.LeftUnmatched}");
    return;
}
Console.WriteLine($"Right unmatch: {output.RightUnmatched}");

CheckData Check(string? input)
{
    CheckData output = new CheckData();
    if (input == null) return output;
    bool inside = false;
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == '(')
        {
            if (inside && output.LeftUnmatched == null)
            {
                output.LeftUnmatched = i;
            }
            inside = true;
        }
        if (input[i] == ')')
        {
            if (!inside && output.RightUnmatched == null)
            {
                output.RightUnmatched = i;
            }
            inside = false;
        }
    }
    return output;
}
struct CheckData
{
    public int? LeftUnmatched;
    public int? RightUnmatched;
    public CheckData() { LeftUnmatched = null; RightUnmatched = null; }
};