using System;
using System.Linq;

namespace MarsRover
{
    public static class Extensions
    {
        public static DirectionKey ChangeDirection(this DirectionKey currentDirection, CommandKey commandKey)
        {
            var values = Enum.GetValues(typeof(DirectionKey)).Cast<DirectionKey>().ToList();
            var indexOfCurrent = values.IndexOf(currentDirection);
            if (commandKey == CommandKey.L)
                indexOfCurrent--;
            else if (commandKey == CommandKey.R)
                indexOfCurrent++;

            if (indexOfCurrent < 0)
            {
                values.Reverse();
                indexOfCurrent *= -1;
                indexOfCurrent--;
            }

            return values.Skip(indexOfCurrent).FirstOrDefault(); ;
        }
        public static DirectionKey ComputeDirection(this DirectionKey baseDirection, DirectionKey absoluteDirection)
        {
            var values = Enum.GetValues(typeof(DirectionKey)).Cast<DirectionKey>().ToList();
            var indexOfAbsoluteDirection = values.IndexOf(absoluteDirection);
            var indexOfBaseDirection = values.IndexOf(baseDirection);
            var computedDirection = indexOfBaseDirection - indexOfAbsoluteDirection;
            do
            {
                if (computedDirection > 0) baseDirection = baseDirection.ChangeDirection(CommandKey.R);
                else baseDirection = baseDirection.ChangeDirection(CommandKey.L);
                computedDirection = computedDirection > 0 ? computedDirection - 1 : computedDirection + 1;
            }
            while (computedDirection != 0);

            return baseDirection;
        }
    }
}
