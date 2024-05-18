using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {
        void WelcomeMessage();

        void Instructions();

        void ShowRoom();

        void MoveDirection();

        void EnterBattle();
    }
}