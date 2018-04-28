﻿using Teme.Shared.Data.Context;
using Teme.Shared.Data.Repos;

namespace Teme.Shared.Logic
{
    public class BaseLogic : IBaseLogic
    {

    }

    public class BaseLogic<TIRepo> : BaseLogic where TIRepo : IBaseRepo
    {
        protected TIRepo Repo { get; }

        protected BaseLogic(TIRepo repo)
        {
            Repo = repo;
        }
    }

}