using Naninovel;

namespace _Project.Scripts.Infrastructure.Command
{
    [CommandAlias("miniGame")]
    public class SwitchToMiniGameMode : Naninovel.Command
    {
        public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
        {
            // 1. Disable Naninovel input.
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = false;

            // 2. Stop script player.
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            scriptPlayer.Stop();
            
            var miniGame = Engine.GetService<MiniGameService>();
            miniGame.SaveVariables();
            
            // 3. Reset state.
            var stateManager = Engine.GetService<IStateManager>();
            await stateManager.ResetStateAsync();
                
            // 4. Switch cameras.
            var naniCamera = Engine.GetService<ICameraManager>().Camera;
            naniCamera.enabled = false;

            var ui = Engine.GetService<IUIManager>();
            ui.DestroyService();

            
            miniGame.LoadMiniGame();

        }
    }
}