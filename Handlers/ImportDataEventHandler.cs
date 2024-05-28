using Assel.Services;
using MediatR;

namespace Assel.Handlers
{
    internal sealed class ImportDataEventHandler : INotificationHandler<ImportDataEvent>
    {
        private readonly ILogger<ImportDataEventHandler> _logger;
        private readonly IImportFact _importFact;

        public ImportDataEventHandler(ILogger<ImportDataEventHandler> logger, IImportFact importFact)
        {
            _logger = logger;
            _importFact = importFact;
        }

        public async Task Handle(ImportDataEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start importing data");

            await _importFact.ImportUniqueDataAsync();

            _logger.LogInformation("Finish importing data");
        }
    }

}
