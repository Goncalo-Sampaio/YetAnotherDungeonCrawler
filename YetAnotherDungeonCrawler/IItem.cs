using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Item Interface
    /// </summary>
    public interface IItem
    {
        string Name {get; set;}
        void Use();
        
    }
}