using Euri_backend.Utillities;

namespace Euri_backend.Data.Dto;

public class MetadataDto<T>
{
    public MetadataDto(PagedList<T> data)
    {
 
        TotalCount = data.TotalCount;
        PageSize = data.PageSize;
        CurrentPage = data.CurrentPage;
        TotalPages = data.TotalPages;
        HasNext = data.HasNext;
        HasPrevious = data.HasPrevious;
    }

    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
}