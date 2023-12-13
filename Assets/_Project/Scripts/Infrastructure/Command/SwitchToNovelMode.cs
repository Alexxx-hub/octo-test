using Naninovel;

namespace _Project.Scripts.Infrastructure.Command
{
    [CommandAlias("novel")]
    public class SwitchToNovelMode : Naninovel.Command
    {
        public StringParameter ScriptName;
        public StringParameter Label;

        public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
        {
            var ui = Engine.GetService<IUIManager>();
            await ui.InitializeServiceAsync();
            
            var naniCamera = Engine.GetService<ICameraManager>().Camera;
            naniCamera.enabled = true;

            // 3. Load and play specified script (if assigned).
            if (Assigned(ScriptName))
            {
                var scriptPlayer = Engine.GetService<IScriptPlayer>();
                await scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label);
            }

            // 4. Enable Naninovel input.
            var inputManager = Engine.GetService<IInputManager>();
            inputManager.ProcessInput = true;
        }
    }
}