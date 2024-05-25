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

        int ShowActions(Player player);

        int ShowActions(Player player,IItem item);

        int ShowActions(Player player,Character enemy);

        int ShowActions(Player player,IItem item, Character enemy);

        int ShowDirections(bool north, bool south, bool west, bool east);

        void MoveDirection(Direction direction);

        void NotMove(Direction direction);

        void AttackBeforeMove();

        void ShowHealth(int health);

        void Attack(int damage);

        void EnemyAttack(int damage);

        void EnemyDead();

        void PickUpMessage(IItem item);

        void NotEnoughItems();

        void UseHeal(int health);       
    }
}