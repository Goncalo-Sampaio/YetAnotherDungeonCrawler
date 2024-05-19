using System;
using System.Collections.Generic;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {
        void WelcomeMessage();

        void Instructions();

        void DeadMessage();

        void EndMessage();

        void InvalidOption();

        void AfterMenu();

        int ShowActions();

        int ShowActions(IItem item);

        int ShowActions(Enemy enemy);

        int ShowActions(IItem item, Enemy enemy);

        int ShowDirections(bool north, bool south, bool east, bool west);

        void MoveDirection(Direction direction);

        void NotMove(Direction direction);

        void ShowHealth(int health);

        void Attack(int damage);

        void EnemyAttack(int damage);

        void NotEnoughItems();

        void UseHealingPotion(int healing);
    }
}