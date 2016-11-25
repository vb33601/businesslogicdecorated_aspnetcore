﻿using Digipolis.BusinessLogicDecorated.Inputs;
using Digipolis.BusinessLogicDecorated.Operators;
using Digipolis.BusinessLogicDecorated.Preprocessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digipolis.BusinessLogicDecorated.Decorators
{
    public class AsyncQueryPreprocessingDecorator<TEntity> : AsyncQueryPreprocessingDecorator<TEntity, QueryInput<TEntity>>, IAsyncQueryOperator<TEntity>
    {
        public AsyncQueryPreprocessingDecorator(IAsyncQueryOperator<TEntity, QueryInput<TEntity>> queryOperator, IQueryPreprocessor<TEntity, QueryInput<TEntity>> preprocessor) : base(queryOperator, preprocessor)
        {
        }
    }

    public class AsyncQueryPreprocessingDecorator<TEntity, TInput> : AsyncQueryDecorator<TEntity, TInput>
        where TInput : QueryInput<TEntity>
    {
        public AsyncQueryPreprocessingDecorator(IAsyncQueryOperator<TEntity, TInput> queryOperator, IQueryPreprocessor<TEntity, TInput> preprocessor) : base(queryOperator)
        {
            Preprocessor = preprocessor;
        }

        public IQueryPreprocessor<TEntity, TInput> Preprocessor { get; set; }

        public override Task<IEnumerable<TEntity>> QueryAsync(TInput input = default(TInput))
        {
            Preprocessor.PreprocessForQuery(ref input);

            return QueryOperator.QueryAsync(input);
        }
    }
}
