

namespace Game.Systems.GameSystem
{
    using Game.Model;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class GameSystemBuilder
    {
        public GameSystem Make(GameData gameData)
        {
            GameSystem gameSystem = Resources.Load<GameSystem>("Prefabs/Game/Systems/GameSystem");
            gameSystem = GameObject.Instantiate<GameSystem>(gameSystem);

            gameSystem.InitMainSystem(gameData);

            return gameSystem;
        }
    }

}
