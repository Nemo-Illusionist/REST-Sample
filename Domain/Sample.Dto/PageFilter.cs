using Radilovsoft.Rest.Infrastructure.Contract.Dto;

namespace Sample.Dto
{
    public class PageFilter : IPageFilter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}