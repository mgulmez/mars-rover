namespace MarsRover
{
    public class PlateSize
    {
        /// <summary>
        /// Birim genişlik
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Birim yükseklik
        /// </summary>
        public int Height { get; set; }
        public PlateSize(int width, int height)
        {
            if (width <= 0) throw new System.Exception("Geçersiz genişlik girdiniz");
            else Width = width;
            if (height <= 0) throw new System.Exception("Geçersiz yükseklik girdiniz");
            else Height = height;
        }
        public static PlateSize Parse(string info)
        {
            var size = info.Replace("x", " ").Replace("-", " ");

            // fazla boşlukları al
            while (size.Contains("  ")) size = size.Replace("  ", "");

            var sizeArr = size.Split(' ');
            if (sizeArr.Length != 2) throw new System.Exception("Alan boyutu anlaşılamadı.");

            if(!int.TryParse(sizeArr[0], out var width)) throw new System.Exception("Genişlik geçerli bir değer değil");
            if(!int.TryParse(sizeArr[1], out var height)) throw new System.Exception("Yükseklik geçerli bir değer değil");

            return new PlateSize(width, height);
        }
    }
}
