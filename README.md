# CrowiNet

## Quick Start

```csharp
private static class Program
{
    private static void Main()
    {
        using(var crowi = new Crowi("accessToken"))
        {
            // get page list for user
            var parameter = new User("user");
            var pageList = await crowi.GetPageListAsync();
        }
    }
}
```

## Available End Points

- `pages.list`
- `users.list`
