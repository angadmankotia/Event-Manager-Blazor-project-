using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventManager;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Optimization: add scoped state management service
builder.Services.AddScoped<AppState>();

await builder.Build().RunAsync();

public class AppState
{
    public List<string> Attendees { get; set; } = new();
    public void AddAttendee(string name)
    {
        if (!string.IsNullOrWhiteSpace(name) && !Attendees.Contains(name))
            Attendees.Add(name);
    }
}
