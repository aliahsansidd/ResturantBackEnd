﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Core.Base.Generic;
using SSH.Core.Constant;
using SSH.Core.DTO;
using SSH.Core.Entity;
using SSH.Core.Enum;
using SSH.Core.Extensions;
using SSH.Core.Infrastructure;
using SSH.Core.IRepository;
using SSH.Core.IService;

namespace SSH.Service
{
    public class ConsultancyTimingService : Service<IConsultancyTimingRepository, ConsultancyTiming, ConsultancyTimingDTO, int>, IConsultancyTimingService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public ConsultancyTimingService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.ConsultancyTimingRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }
    }
}
