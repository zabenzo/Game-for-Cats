using Infrastructure.SceneLoader;

namespace MainMenu
{
    public class MainMenuController
    {
        private readonly ISceneLoader _sceneLoader;

        public MainMenuController(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        
        public void OnPlayButtonClick()
        {
            // TODO:: Enter into new load state and initialize all that scene need.
        }
    }
}