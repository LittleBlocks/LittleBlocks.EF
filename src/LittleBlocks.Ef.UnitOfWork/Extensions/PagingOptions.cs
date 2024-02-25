namespace LittleBlocks.Ef.UnitOfWork.Extensions
{
    public class PagingOptions
    {
        private const int DefaultPageSize = 20;

        public PagingOptions(int pageIndex, int pageSize = DefaultPageSize)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageSize);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pageIndex);

            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public PagingOptions() : this(0, DefaultPageSize)
        {
        }

        public int PageIndex { get; }
        public int PageSize { get; }
    }
}