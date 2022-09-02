﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace FishingGame.AsyncLoading
{
    public interface ILoaderAsync<T> where T : ILoadable
    {
        public int LoadIndex { get; }
        public int LoadLength { get; }
        public IEnumerable<T> LoadQueue { get; }
        public void EnqueueLoadable(in T loadable);
        public void EnqueueLoadables(in IEnumerable<T> loadables);
        public IUniTaskAsyncEnumerable<T> ProcessQueueEnumerable();
    }
}