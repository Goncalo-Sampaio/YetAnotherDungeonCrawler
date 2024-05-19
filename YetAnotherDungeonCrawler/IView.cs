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

        void ShowRoom(Room room);

        int ShowDirections(bool north, bool south, bool east, bool west);

        void MoveDirection(Direction direction);

        void NotMove(Direction direction);

        void ShowHealth(int health);

        void Attack(int damage);

        void EnemyAttack(int damage);

        void UseHealingPotion(int healing);
    }
}