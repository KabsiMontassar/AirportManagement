﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
