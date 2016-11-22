﻿using Digipolis.BusinessLogicDecorated.Inputs;
using Digipolis.BusinessLogicDecorated.Inputs.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digipolis.BusinessLogicDecorated.Operators
{
    public interface IAsyncQueryOperator<TEntity> : IAsyncQueryOperator<TEntity, QueryInput<TEntity>>
    {
    }

    public interface IAsyncQueryOperator<TEntity, TInput>
        where TInput : class, IHasIncludes<TEntity>, IHasFilter<TEntity>, IHasOrder<TEntity>
    {
        Task<IEnumerable<TEntity>> QueryAsync(TInput input = null);
    }
}
