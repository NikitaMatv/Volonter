﻿using Koordibnator.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Koordibnator
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static VolonterAgenstvoEntities DB = new VolonterAgenstvoEntities();
        public static Employ AutorEmploy;
    }
}
