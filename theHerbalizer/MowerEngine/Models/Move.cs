﻿namespace MowerEngine.Models
{
    public record Move
    {
        public MoveType Type { get; set; }

        public int Value { get; set; }

        public Move()
        {
        }
    }
}