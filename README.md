# dotnet web api
Tutorial on building a web API using C# with Microsoft .NET<br/>
**For this tutorial, we will be using dotnet 6.**.

# What you need to have
- dotnet installed.  If you do not have installed, install it from 
<a href="https://dotnet.microsoft.com/en-us/download/dotnet/6.0" target="_blank">here (dotnet 6)</a>. <br/>
- Visual Studio (purple icon) NOT vscode (blue icon). Install it from 
<a href="https://visualstudio.microsoft.com/" target="_blank">here</a>. <br/>

# Tutorial
**Step 1 - Project Setup** <br/>
- launch Visual Studio and create a new project<br/>
- choose API as the template. On the dropdown menu, ensure it selects C#. Once done, click continue
<img width="899" alt="image" src="https://github.com/iskevinlemon/dotnet-web-api/assets/126497052/c82698fd-4155-435f-956e-79db358c9f68"><br/>
 - On the Target Framework dropdown menu, ensure it selects .NET 6.0. On the Advanced, follow the settings as per image below. Once done, click continue
<img width="900" alt="image" src="https://github.com/iskevinlemon/dotnet-web-api/assets/126497052/c9435a75-095c-462a-83d2-7cf581a18757"><br/>
 - For the purpose of this tutorial, my Project name will be Menus API as we will be working with menus. Feel free to choose your own directory for Location of the project. Once done, click Create
<img width="900" alt="image" src="https://github.com/iskevinlemon/dotnet-web-api/assets/126497052/5eeb7ab0-be7e-4383-a533-8be3b9812d32"><br/>
- When the project has been successfully created, your Visual Studio Solution Explorer should look something like this. Your Solution Explorer may look different, but it is alright
<img width="1470" alt="image" src="https://github.com/iskevinlemon/dotnet-web-api/assets/126497052/90003292-f1d7-4a23-9b75-8dedeffaff37"><br/>

**Step 2 - Deleting Boilerplate Codes** <br/>
- Inside the Solution Explorer, delete:<br/>
-- Controllers/<code>WeatherForecastController.cs</code><br/>
-- <code>WeatherForecast.cs</code><br/>

**Step 3 - Creating the MenusController** <br/>
- Inside the Controllers folder, create a new controller. Right click on Controllers folder,Add -> New Class -> ASP.NET Core -> Controller Class. For the name, type MenusController.<br/>
- Inside the <code>MenusController.cs</code>, replace the whole source code with the codes below<br/>
```c#
// MenusController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Menus_API.Controllers
{
    [ApiController]
    [Route("/api/Menus")] // defines the API route. In this case localhost:<port_number>/api/Menus

    public class MenusController : ControllerBase
    {
        [HttpGet(Name = "GetMenus")]
        public IEnumerable<Menu> Get()
        {
            // Sample data of menu items
            // Creating a Menu List containg Menu Objects
            var menus = new List<Menu>
            {
                new Menu { Id = 1, Name = "Breakfast Menu", Price = 10.99, Category = "Breakfast" },
                new Menu { Id = 2, Name = "Lunch Menu", Price = 15.99, Category = "Lunch" },
                new Menu { Id = 3, Name = "Dinner Menu", Price = 20.99, Category = "Dinner" }
                // Add more menu objects as needed
            };
            return menus;
        }

    }

    // Creating a Menu class
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

}
```
**Step 4 - Configuring Project** <br/>
- Inside the Properties folder, open the <code>launchSettings.json</code><br/>
- Replace all contents of <code>launchSettings.json</code> with the following codes<br/>
```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:33341",
      "sslPort": 44358
    }
  },
  "profiles": {
    "Menus_API": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "/api/Menus",
      "applicationUrl": "https://localhost:7019;http://localhost:5009",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "dotnetRunMessages": true
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "/api/Menus",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
- Inside the Solution Explorer folder, open the <code>Program.cs</code><br/>
- Replace all contents of <code>Program.cs</code> with the following codes<br/>
```c#
// Program.cs

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```
- Click Run (play button) to build and launch the project<br/>
<img width="359" alt="image" src="https://github.com/iskevinlemon/dotnet-web-api/assets/126497052/23db52f0-5760-4c12-a8da-5a5c687cbd15"><br/>
- If your project is setup and configured correctly, you should see the following on your browser. Url would be <code>localhost:YOUR_PORT/api/menus</code><br/>
![image](https://github.com/iskevinlemon/dotnet-web-api/assets/126497052/ca694714-d869-4a5c-8f89-1f9747d93563)<br/>

**End of tutorial** <br/>
Source code has also been provided in this repository.
