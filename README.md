# CrowiNet

## Quick Start

```csharp
private static class Program
{
    private static void Main()
    {
        using(var crowi = new Crowi("user", "accessToken"))
        {
            var pageList = await crowi.GetPageListAsync();
        }
    }
}
```

## Available End Points

- `pages.list`
- `users.list`
