using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Interfaces
{
    /// <summary>
    /// Strategy pattern
    /// </summary>
    public interface IEndRule
    {
        bool IsEnd();
    }
}