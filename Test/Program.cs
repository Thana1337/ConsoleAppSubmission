
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel.Design;
using Test.Interfaces;
using Test.Services;



var builder = Host.CreateDefaultBuilder().ConfigureServices(services => 
{ 
    services.AddTransient<IContactService, ContactService>();
    services.AddTransient<IMenuService, MenuService>();
    
}).Build();
var serviceProvider = builder.Services;

var menuService = serviceProvider.GetRequiredService<IMenuService>();
menuService.MainMenu();

Console.ReadKey();