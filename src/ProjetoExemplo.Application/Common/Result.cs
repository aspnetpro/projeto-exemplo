namespace ProjetoExemplo.Application.Common;

public class Result
{
    private ICollection<string> Errors = new List<string>();

    public bool Success => Errors.Count <= 0;

    public void AddError(string msg)
    {
        Errors.Add(msg);
    }

    public string GetError()
    {
        return Errors.FirstOrDefault();
    }
}
