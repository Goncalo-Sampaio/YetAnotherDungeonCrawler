using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {
        void WelcomeMessage();

        void Instructions();

        int ShowActions();

        int ShowActions(Item item);

        int ShowActions(Enemy enemy);

        int ShowActions(Item item, Enemy enemy);

        int ShowDirection();

        void ShowRoom();

        void MoveDirection();

        void EnterBattle();
    }
}