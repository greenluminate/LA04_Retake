﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SuperheroManager.Logic;
using SuperheroManager.Services;

namespace SuperheroManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
              new ServiceCollection()
              //.AddSingleton<ICreateSuperheroService, CreateSuperheroViaWindow>()
              .AddSingleton<IEditSuperheroViaWindow, EditSuperheroViaWindow>()
              .AddSingleton<ISuperheroLogic, SuperheroLogic>()
              .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
              .BuildServiceProvider()
              );
        }
    }
}
