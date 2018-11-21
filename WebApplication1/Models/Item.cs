﻿
namespace GameWebApplication.Models
{
    public abstract class Item : BaseModel
    {
        private int Value { get; set; }

        //Foreign key
        public int InventoryId { get; set; }
    }
}
