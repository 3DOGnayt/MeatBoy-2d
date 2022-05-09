using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class QuestConfiguratorController
    {
        private QuestObjectView _singleQuestView;
        private QuestController _singleQuest;
        private CoinQuestModel _model;

        public QuestConfiguratorController(QuestView questView)
        {
            _singleQuestView = questView._singleQuestView;
            _model = new CoinQuestModel();
        }

        public void Init()
        {
            _singleQuest = new QuestController(_singleQuestView, new CoinQuestModel());
            _singleQuest.Reset();
        }
    }
}
