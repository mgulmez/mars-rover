using System;

namespace MarsRover
{
    public class Position
    {
        /// <summary>
        /// Birim olarak x koordinatındaki konumu
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Birim olarak y koordinatındaki konumu
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Koordinat eksenindeki yönü
        /// </summary>
        public DirectionKey Direction { get; set; }
        public Position(int x, int y, DirectionKey direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }


        public static Position Parse(string info)
        {
            var position = info.Replace("x", " ").Replace("-", " ").ToUpper();

            // fazla boşlukları al
            while (position.Contains("  ")) position = position.Replace("  ", "");

            var positionArr = position.Split(' ');
            if (positionArr.Length != 3) throw new System.Exception("Konum anlaşılamadı.");

            if (!int.TryParse(positionArr[0], out var x)) throw new System.Exception("X ekseni geçerli bir değer değil");
            if (!int.TryParse(positionArr[1], out var y)) throw new System.Exception("Y ekseni geçerli bir değer değil");
            if (!Enum.TryParse(typeof(DirectionKey), positionArr[2], out var direction)) throw new System.Exception("Yön geçerli bir değer değil");

            return new Position(x, y, (DirectionKey)direction);
        }

        public override string ToString() => $"{X} {Y} {Direction}";
    }
}
