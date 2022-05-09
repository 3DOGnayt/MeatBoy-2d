using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private SpriteAnimatorConfig _coinAnimCfg;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<CoinView> _coinViews;
        [SerializeField] private GeneratorLevelView _genView;
        [SerializeField] private QuestView _questView;

        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private CameraController _cameraController;
        private PlayerController _playerController;
        private CannonAimController _cannon;
        private BulletEmitterController _bulletEmitterController;
        private CoinsController _coinsController;
        private GeneratorContoller _levelGenerator;
        private QuestConfiguratorController _questConfigurator;
        //private ParalaxManager _paralaxManager;

        void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _coinAnimCfg = Resources.Load<SpriteAnimatorConfig>("CoinAnimCfg");

            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
            }
            if (_coinAnimCfg)
            {
                _coinAnimator = new SpriteAnimatorController(_coinAnimCfg);
            }

            _cameraController = new CameraController(_playerView.transform, Camera.main.transform);
            _playerController = new PlayerController(_playerView, _playerAnimator);

            _cannon = new CannonAimController(_cannonView._muzzleTransform, _playerView._transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);

            _coinsController = new CoinsController(_playerView, _coinViews, _coinAnimator);

            _levelGenerator = new GeneratorContoller(_genView);

            _levelGenerator.Init();

            _questConfigurator = new QuestConfiguratorController(_questView);
            _questConfigurator.Init();
        }


        void Update()
        {
            _cameraController.Update();
            _playerController.Update();
            _cannon.Update();
            _bulletEmitterController.Update();
            _coinAnimator.Update();
           // _paralaxManager.Update();

        }
    }
}
