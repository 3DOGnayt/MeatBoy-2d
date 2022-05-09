using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public interface IQuest : IDisposable
    {
        event EventHandler<IQuest> Complited;
        bool IsComplited { get; }
        void Reset();

    }
}
