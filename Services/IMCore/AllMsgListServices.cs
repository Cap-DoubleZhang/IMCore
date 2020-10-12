using Model.EntityModel.IMCore;
using System;
using System.Collections.Generic;
using System.Text;
using IServices.IMCore;
using IRepository.IMCore;

namespace Services.IMCore
{
    public class AllMsgListServices : BaseServices<AllMsgList>, IAllMsgListServices
    {
        IAllMsgListRepository _repository;
        public AllMsgListServices(IAllMsgListRepository repository)
        {
            this._repository = repository;
            base.baseRepository = repository;
        }
    }
}
