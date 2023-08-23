using System;

namespace Scripts.UI
{
    public class GameOverScreen : Screen
    {
        public Action RestartButtonClic;
        public override void Close()
        {
            CanvasGroup.alpha = 0;
            Button.interactable = false;
        }

        public override void Open()
        {
            CanvasGroup.alpha = 1;
            Button.interactable = true;
        }

        protected override void OnButtonClic()
        {
            RestartButtonClic?.Invoke();
        }
    }
}