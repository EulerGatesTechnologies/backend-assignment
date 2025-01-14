namespace OT.Assessment.App.Model;

public readonly struct PaginationRequest(int pageSize = 10, int pageIndex = 0)
{
    public int PageSize { get; } = pageSize;

    public int PageIndex { get; } = pageIndex;
}

