using Model.EntityModel.IMCore;
using System;
using System.Collections.Generic;
using System.Text;
using IServices.IMCore;
using IRepository.IMCore;

namespace Services.IMCore
{
    public class HistoryListServices : BaseServices<HistoryList>, IHistoryListServices
    {
        IHistoryListRepository _repository;
        public HistoryListServices(IHistoryListRepository repository)
        {
            this._repository = repository;
            base.baseRepository = repository;
        }
    }
}
