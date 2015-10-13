using System.Linq;
using System.Reflection;
using ConventionByReflection;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;

namespace Log4Net.ConventionConfigurator {
    public static class ConventionConfigurator {
        public static void Configure(Level level) {
            var callingAssembly = Assembly.GetCallingAssembly();
            var repository = (Hierarchy) LogManager.GetRepository();
            repository.Root.Level = level;
            BasicConfigurator.Configure(repository, FindAppenders(level, callingAssembly));
        }

        private static IAppender[] FindAppenders(Level level, Assembly callingAssembly) {
            return Activator.CreateInstances<IConfigureLogging>(callingAssembly)
                            .Where(i => i.Level >= level)
                            .SelectMany(s => s.GetAppenders()).ToArray();
        }
    }
}