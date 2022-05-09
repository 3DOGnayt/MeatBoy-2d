using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CoinsController : IDisposable
    {
        private const float _animationSpeed = 10f;

        private LevelObjectView _playerView;
        private SpriteAnimatorController _coinAnimator;
        private List<CoinView> _coinViews;

        public CoinsController(LevelObjectView player, List<CoinView> coins, SpriteAnimatorController coinAnimator)
        {
            _playerView = player;
            _coinAnimator = coinAnimator;
            _coinViews = coins;
            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (CoinView coinView in _coinViews)
            {
                _coinAnimator.StartAnimation(coinView._spriteRenderer, AnimState.Run, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(CoinView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _coinAnimator.StopAnimation(contactView._spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
       
    }
}
