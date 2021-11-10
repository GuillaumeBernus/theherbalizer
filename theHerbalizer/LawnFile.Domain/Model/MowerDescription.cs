﻿using LawnFile.Domain.Extensions;

namespace LawnFile.Domain.Model
{
    class MowerDescription
    {
        public string StartPosition { get; set; }

        public string Route { get; set; }


        public bool Check()
        {
            return StartPosition.IsMowerDescription() && Route.IsMowerRoute();

        }
    }
}