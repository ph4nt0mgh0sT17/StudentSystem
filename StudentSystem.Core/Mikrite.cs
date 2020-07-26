using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace StudentSystem.Core
{
    public static class Mikrite
    {
        public static MikriteContainer Container { get; private set; }

        public static IServiceProvider Provider => Container?.Provider;

        public static void Build(this MikriteContainer container)
        {
            container.Build();
        }

        public static void Build(IServiceProvider provider)
        {
            Container.Build(provider);
        }

        public static MikriteContainer Construct()
        {
            Container = new MikriteContainer();

            return Container;
        }

        public static MikriteContainer Construct(MikriteContainer container)
        {
            Container = container;

            return Container;
        }

        public static T Service<T>()
        {
            return Provider.GetService<T>();
        }
    }
}
