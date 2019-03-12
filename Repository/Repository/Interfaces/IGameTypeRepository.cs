﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IGameTypeRepository : IBaseRepository<GameType>, IDisposable
    {
        IQueryable<GameType> GetList();
    }
}
