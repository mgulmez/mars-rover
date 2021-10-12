using System;

namespace MarsRover
{
    class Program
    {
        const string RetryMessage = "Tekrar denemek istermisiniz? Evet için Enter, Hayır için Esc tuşuna basınız";
        static void Main(string[] args)
        {
            var plateSize = GetPlateSize();
            if (plateSize == null) return;

            var order = 1;
            while (true)
            {

                var position = GetRoverPosition(order);
                if (position == null) break;

                if (position.X > plateSize.Width || position.Y > plateSize.Height || position.X < 0 || position.Y < 0)
                {
                    Console.WriteLine("Rover bilinmeyen bir bölgeye yerleştirilmiş.");
                    Console.WriteLine();
                    continue;
                }

                    var directive = GetDirective(order);
                if (directive == null) break;

                var roverKnownPos = directive.ComputePosition(position);

                if(roverKnownPos.X > plateSize.Width || roverKnownPos.Y > plateSize.Height || roverKnownPos.X < 0 || roverKnownPos.Y < 0)
                {
                    Console.WriteLine("Rover bilinmeyen bir bölgede kayboldu");
                } 
                else if (roverKnownPos != null)
                    Console.WriteLine($"Rover'ın bilinen son koordinatı: X:{roverKnownPos.X}, Y:{roverKnownPos.Y}, Yönü: {roverKnownPos.Direction}");

                Console.WriteLine();
                order++;
            }
        }

        static PlateSize GetPlateSize()
        {
            try
            {
                Console.Write("Lütfen plato boyutunu giriniz (Örn: 5 5):");
                var plateSize = PlateSize.Parse(Console.ReadLine());
                return plateSize;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(RetryMessage);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    return null;
                else return GetPlateSize();
            }
        }

        static Position GetRoverPosition(int roverNo)
        {
            try
            {
                Console.Write($"Lütfen {roverNo}. sırasındaki rover'ın konumunu ve yönünü giriniz (Örn: 1 1 N):");
                var position = Position.Parse(Console.ReadLine());
                return position;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(RetryMessage);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    return null;
                else return GetRoverPosition(roverNo);
            }
        }
        static CommandPackage GetDirective(int roverNo)
        {
            try
            {
                Console.Write($"Lütfen {roverNo}. sırasındaki rover'a gönderilecek komut dizisini giriniz (Örn: LMLMMRM):");
                var position = CommandPackage.Parse(Console.ReadLine());
                return position;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(RetryMessage);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    return null;
                else return GetDirective(roverNo);
            }
        }
    }
}
