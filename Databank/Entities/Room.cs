using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

	public class Room: IEntity {

        private string title;
        private string description;
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }

        public Room(string title, string description)
        {
            Title = title;
			Description = description;
        }

        public static Room getFakeRoom()
        {
            return new Room("title", "description");
        }
	}

