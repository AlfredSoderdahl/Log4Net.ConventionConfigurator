using System.Collections.Generic;
using log4net.Appender;
using log4net.Core;

namespace Log4Net.ConventionConfigurator {
    public interface IConfigureLogging {
        Level Level { get; }
        IEnumerable<IAppender> GetAppenders();
    }
}