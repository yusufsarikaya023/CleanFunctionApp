namespace CleanFunctionApp.Domain.Aggregation.Common;

public class Pagination
{
    public Pagination() => (Page, Rows) = (1, 10);
    public Pagination(int page, int rows) => (Page, Rows) = (page, rows);

    private int _page;
    public int Page
    {
        get => _page > 0 ? _page : 1;
        set => _page = value;
    }

    private int _rows;
    public int Rows
    {
        get => _rows > 0 ? _rows : 10;
        set => _rows = value;
    }

    public bool IsWhole { get; set; }
    public static Pagination Whole()
    {
        return new Pagination() { IsWhole = true };
    }
}
