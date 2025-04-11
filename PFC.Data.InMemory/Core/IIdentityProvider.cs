namespace PFC.Data.InMemory.Core;

public interface IIdentityProvider<out TId>
{
    TId Next(Type seed);
}