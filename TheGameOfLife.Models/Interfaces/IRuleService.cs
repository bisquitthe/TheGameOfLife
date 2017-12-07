using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Interfaces
{
    public interface IRuleService
    {
        IEndRule GetEndIfNoAliveRule(Universe universe);
        IEndRule GetEndIfGenerationHasNotChanged(Universe universe);
    }
}