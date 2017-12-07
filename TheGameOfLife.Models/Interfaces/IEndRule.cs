using System;
using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Interfaces
{
    public interface IEndRule
    {
        Func<bool> IsEnd { get; }
    }
}