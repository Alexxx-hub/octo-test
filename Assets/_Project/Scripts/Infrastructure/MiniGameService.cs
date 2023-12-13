using _Project.Scripts.Infrastructure.Command;
using Naninovel;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure
{
    [InitializeAtRuntime]
    public class MiniGameService : IEngineService
    {
        private readonly ScriptPlayer _scriptPlayer;
        private CustomVariableManager _customVar;

        private string _playerName;
        private string _taskText;
        private string[] _tasks = new string[5];
        private bool _isRingPicked;
        private int _locOneCurrState;
        private int _locTwoCurrState;
        private int _resault;
        
        public MiniGameService(ScriptPlayer scriptPlayer, CustomVariableManager svm)
        {
            _scriptPlayer = scriptPlayer;
            _customVar = svm;
        }
        
        public UniTask InitializeServiceAsync()
        {
            return UniTask.CompletedTask;
        }

        public void ResetService()
        {
            
        }

        public void DestroyService()
        {
            
        }

        public void LoadMiniGame()
        {
            SceneManager.LoadScene("Demo", LoadSceneMode.Single);
        }

        public void LoadNovelGame()
        {
            SceneManager.LoadScene("MainNovel", LoadSceneMode.Single);

            var switchCommand = new SwitchToNovelMode {ScriptName = "LocationTwo", Label = "AfterGame"};
            switchCommand.ExecuteAsync().Forget();
            
            LoadVariables();
        }

        public void SaveVariables()
        {
            _playerName = _customVar.GetVariableValue("PlayerName");
            _taskText = _customVar.GetVariableValue("TaskText");
            _tasks[0] = _customVar.GetVariableValue("FirstTask");
            _tasks[1] = _customVar.GetVariableValue("SecondTask");
            _tasks[2] = _customVar.GetVariableValue("ThirdTask");
            _tasks[3] = _customVar.GetVariableValue("FourthTask");
            _tasks[4] = _customVar.GetVariableValue("FifthTask");
            _isRingPicked = ConvertToBool(_customVar.GetVariableValue("isRingPicked"));
            _locOneCurrState = int.Parse(_customVar.GetVariableValue("LocationOneCurrentState"));
            _locTwoCurrState = int.Parse(_customVar.GetVariableValue("LocationTwoCurrentState"));
        }

        private void LoadVariables()
        {
            _customVar.SetVariableValue("PlayerName", _playerName);
            _customVar.SetVariableValue("TaskText", _taskText);
            _customVar.SetVariableValue("FirstTask", _tasks[0]);
            _customVar.SetVariableValue("SecondTask", _tasks[1]);
            _customVar.SetVariableValue("ThirdTask", _tasks[2]);
            _customVar.SetVariableValue("FourthTask", _tasks[3]);
            _customVar.SetVariableValue("FifthTask", _tasks[4]);
            _customVar.SetVariableValue("isRingPicked", _isRingPicked.ToString());
            _customVar.SetVariableValue("LocationOneCurrentState", _locOneCurrState.ToString());
            _customVar.SetVariableValue("LocationTwoCurrentState", _locTwoCurrState.ToString());
        }
        
        private bool ConvertToBool(string data)
        {
            bool value;
            
            switch (data)
            {
                case "false":
                    value = false;
                    break;
                case "true":
                    value = true;
                    break;
                default: value = false;
                    break;
            }

            return value;
        }
    }
}