namespace PFC.Data.InMemory.Core;

public interface IIdentityGenerator<out TId>
{
    TId Next(Type seed);
}