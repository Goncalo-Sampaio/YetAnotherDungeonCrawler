using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public interface IItem
    {
        string Name {get; set;}
        void Use();
        
    }
}