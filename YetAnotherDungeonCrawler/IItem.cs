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
        /// <summary>
        /// Item's name
        /// </summary>
        string Name {get; set;}
        /// <summary>
        /// Item's effect
        /// </summary>
        void Use(Character target);   
    }
}