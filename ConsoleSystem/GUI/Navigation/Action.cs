using ConsoleSystem.Save;

namespace ConsoleSystem.GUI.Navigation
{
    class Action
    {
        public Action(int key)
        {
            this.FindAction(key);
        }

        private void FindAction(int key)
        {
            switch (key)
            {
                case 39:
                    ChangeButton.Next();
                    break;
                case 37:
                    ChangeButton.Back();
                    break;
                case 13:
                    GlobalMemroy.GetButton()?.Active();
                    break;
                case 9:
                    ChangeRangeButton.Next();
                    break;
                case 187:
                case 65:
                    GlobalMemroy.GetRangeButton()?.Add();
                    break;
                case 54:
                case 77:
                    GlobalMemroy.GetRangeButton()?.Min();
                    break;
            }
        }
    }
}
