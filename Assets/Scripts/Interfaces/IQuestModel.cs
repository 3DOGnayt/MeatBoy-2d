using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}
