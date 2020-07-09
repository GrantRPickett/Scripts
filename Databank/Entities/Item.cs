using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
	public class Item: IEntity {
        private string title;
        private string description;

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }

        public Item(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
        public static Item getFake()
        {
            return new Item("title", "description");
        }
	}
