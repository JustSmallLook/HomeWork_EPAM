using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_EPAM
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Rectangle
            Console.WriteLine("------------------ Task 1 ------------------\n");
            Rectangle rectangle = new Rectangle();

            Console.Write("Please, enter upper left point X coordinate: ");
            rectangle.upperLeftX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please, enter upper left point Y coordinate: ");
            rectangle.upperLeftY = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please, enter down right point X coordinate: ");
            rectangle.downRightX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please, enter down right point Y coordinate: ");
            rectangle.downRightY = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Square is: " + rectangle.Square());
            Console.WriteLine("Perimeter is: " + rectangle.Perimeter());
            #endregion

            #region Circle

            Circle circle = new Circle();

            Console.Write("Please, enter the radius of the circle: ");
            circle.radius = Convert.ToDouble(Console.ReadLine());

            circle.CircleLenght();
            circle.CircleSquare();
            #endregion

            #region Complex Number

            Console.Write("Please, enter first real part: ");
            double real1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please, enter first imaginary part: ");
            double imaginary1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Please, enter second real part: ");
            double real2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please, enter second imaginary part: ");
            double imaginary2 = Convert.ToDouble(Console.ReadLine());

            ComplexNumber firstComplex = new ComplexNumber(real1, imaginary1);
            ComplexNumber secondComplex = new ComplexNumber(real2, imaginary2);

            ComplexNumber multiplying = firstComplex * secondComplex;
            Console.WriteLine($"Multipling of complex numbers = {multiplying.Real} + {multiplying.Imiginary}i");

            ComplexNumber dividing = firstComplex / secondComplex;
            Console.WriteLine($"Dividing of complex numbers = {dividing.Real} + {dividing.Imiginary}i");
            #endregion
            #region Draw
            Console.WriteLine("\n------------------ Task 2 ------------------\n");

            Rectangle_2 r = new Rectangle_2();
            r.Draw();

            Square s = new Square();
            s.Draw();
            #endregion
            Console.ReadKey();
        }
        class Rectangle
        {
            private int FirstSide;
            private int SecondSide;

            public int upperLeftX { get; set; }
            public int upperLeftY { get; set; }
            public int downRightX { get; set; }
            public int downRightY { get; set; }

            public void LengthSide()
            {
                if (upperLeftX < downRightX)
                    FirstSide = downRightX - upperLeftX;
                else if (upperLeftX > downRightX)
                    FirstSide = upperLeftX - downRightX;
                else
                    FirstSide = 0;


                if (upperLeftY < downRightY)
                    SecondSide = downRightY - upperLeftY;
                else if (upperLeftY > downRightY)
                    SecondSide = upperLeftY - downRightY;
                else
                    SecondSide = 0;
            }

            public int Square()
            {
                LengthSide();
                return FirstSide * SecondSide;
            }

            public int Perimeter()
            {
                LengthSide();
                return 2 * (FirstSide + SecondSide);
            }
        }
        class Circle
        {
            public double radius { get; set; }
            public const double pi = 3.14;

            public void CircleLenght()
            {
                if (radius <= 0)
                {
                    Console.WriteLine("The radius of a circle cannot be less or equal to zero");
                }
                else
                {
                    Console.WriteLine("Circle length is: " + 2 * radius * pi);
                }
            }

            public void CircleSquare()
            {
                if (radius <= 0)
                {
                    Console.WriteLine("The radius of a circle cannot be less or equal to zero");
                }
                else
                {
                    Console.WriteLine("Circle square is: " + radius * radius * pi);
                }
            }
        }
        class ComplexNumber
        {
            public double Real { get; set; }
            public double Imiginary { get; set; }

            public ComplexNumber()
            {
                this.Real = 0;
                this.Imiginary = 0;
            }

            public ComplexNumber(double a, double b)
            {
                this.Real = a;
                this.Imiginary = b;
            }

            public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
            {
                ComplexNumber complex = new ComplexNumber();
                complex.Real = a.Real * b.Real - a.Imiginary * b.Imiginary;
                complex.Imiginary = a.Real * b.Imiginary + a.Imiginary * b.Real;
                return complex;
            }

            public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
            {
                ComplexNumber complex = new ComplexNumber();
                complex.Real = ((a.Real * b.Real) + (a.Imiginary * b.Real)) / ((b.Real * b.Real) + (b.Imiginary * b.Imiginary));
                complex.Imiginary = ((b.Real * a.Imiginary) - (a.Real * b.Imiginary)) / ((b.Real * b.Real) + (b.Imiginary * b.Imiginary));
                return complex;
            }
        }
        internal interface IDrawable
        {
            void Draw();
        }
        abstract class Figure
        {
            public readonly double X;
            public readonly double Y;

            public Figure()
            {
            }

            public Figure(double x, double y)
            {
                X = x;
                Y = y;
            }
            public abstract void Draw();


        }
        class Rectangle_2 : Figure, IDrawable
        {
            public Rectangle_2()
            {
            }

            public Rectangle_2(double x, double y) : base(x, y)
            {

            }

            public override void Draw()
            {
                Console.WriteLine("Rectangle class");
            }

        }
        class Square : Figure
        {
            public Square()
            {
            }

            public Square(double x, double y) : base(x, y)
            {

            }
            public override void Draw()
            {
                Console.WriteLine("Square class");
            }
        }
    }
}
