namespace PFC.Data.InMemory.Core;

public class GuidIdentityProvider: IIdentityProvider<Guid>
{
    public Guid Next(Type seed)
    {
        return Guid.NewGuid();
    }
}