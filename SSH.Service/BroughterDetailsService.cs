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
    public class BroughterDetailsService : Service<IBroughterDetailsRepository, BroughterDetails, BroughterDetailsDTO, int>, IBroughterDetailsService
    {
        private readonly ISSHRequestInfo requestInfo;
        private readonly IExceptionHelper exceptionHelper;
        private readonly ISSHUnitOfWork unitOfWork;

        public BroughterDetailsService(
            ISSHUnitOfWork unitOfWork,
            ISSHRequestInfo requestInfo,
            IExceptionHelper exceptionHelper)
            : base(unitOfWork, unitOfWork.BroughterDetailsRepository)
        {
            this.requestInfo = requestInfo;
            this.exceptionHelper = exceptionHelper;
            this.unitOfWork = unitOfWork;
        }
    }
}
