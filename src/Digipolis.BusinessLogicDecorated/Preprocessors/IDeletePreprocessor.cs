﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digipolis.BusinessLogicDecorated.Preprocessors
{
    public interface IDeletePreprocessor<TEntity> : IDeletePreprocessor<TEntity, object>
    {
    }

    public interface IDeletePreprocessor<TEntity, TInput>
    {
        void PreprocessForDelete(int id, ref TInput input);
    }
}