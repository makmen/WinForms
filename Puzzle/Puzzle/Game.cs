//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Puzzle
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public Game()
        {
            this.Results = new HashSet<Results>();
        }
    
        public int id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
    
        public virtual ICollection<Results> Results { get; set; }
    }
}
