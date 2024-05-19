using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {
        void WelcomeMessage();

        void Instructions();

        int ShowActions();

        int ShowActions(IItem item);

        int ShowActions(Enemy enemy);

        int ShowActions(IItem item, Enemy enemy);

        int ShowDirections(Room room);

        void ShowRoom(Room room);

        void MoveDirection(Direction direction);

        void Attack(int damage);

        void EnemyAttack(int damage);
    }
}