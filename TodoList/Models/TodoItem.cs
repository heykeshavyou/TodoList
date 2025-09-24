using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Models
{
    public class TodoItem
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }          
        public string Title { get; set; }    
        public string Description { get; set; } 
        public Priority Priority { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        public DateTime? DueDate { get; set; } 
        public bool IsCompleted { get; set; } 
    }

}
