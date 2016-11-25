﻿using Digipolis.BusinessLogicDecorated.Operators;
using Digipolis.BusinessLogicDecorated.Preprocessors;
using Digipolis.BusinessLogicDecorated.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digipolis.BusinessLogicDecorated.Configuration
{
    public interface IAsyncUpdateOperatorConfiguration<TEntity> : IOperatorConfiguration<IAsyncUpdateOperator<TEntity>>
    {
        IAsyncUpdateOperatorConfiguration<TEntity> WithPreprocessing(Func<IServiceProvider, IUpdatePreprocessor<TEntity>> preprocessorFactory = null);
        IAsyncUpdateOperatorConfiguration<TEntity> WithPreprocessing<TPreprocessor>()
            where TPreprocessor : class, IUpdatePreprocessor<TEntity>;

        IAsyncUpdateOperatorConfiguration<TEntity> WithValidation(Func<IServiceProvider, IUpdateValidator<TEntity>> validatorFactory = null);
        IAsyncUpdateOperatorConfiguration<TEntity> WithValidation<TValidator>()
            where TValidator : class, IUpdateValidator<TEntity>;
    }

    public interface IAsyncUpdateOperatorConfiguration<TEntity, TInput> : IOperatorConfiguration<IAsyncUpdateOperator<TEntity, TInput>>
    {
        IAsyncUpdateOperatorConfiguration<TEntity, TInput> WithPreprocessing(Func<IServiceProvider, IUpdatePreprocessor<TEntity, TInput>> preprocessorFactory = null);
        IAsyncUpdateOperatorConfiguration<TEntity, TInput> WithPreprocessing<TPreprocessor>()
            where TPreprocessor : class, IUpdatePreprocessor<TEntity, TInput>;

        IAsyncUpdateOperatorConfiguration<TEntity, TInput> WithValidation(Func<IServiceProvider, IUpdateValidator<TEntity, TInput>> validatorFactory = null);
        IAsyncUpdateOperatorConfiguration<TEntity, TInput> WithValidation<TValidator>()
            where TValidator : class, IUpdateValidator<TEntity, TInput>;
    }
}
