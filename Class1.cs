using System;


namespace GeometryLib
{
    public abstract class TGeometryRoot
    {
        // корневой класс библиотеки. В случае добавления новых фигур - наследуем их от данного класса и переопределяем функцию GetResult, и в случае возможности проверки на "прямоугольность" 
        // переопределяем функцию IsRightTriangle. 
        public abstract double GetResult();
        virtual public bool IsRightTriangle() { return false; }
    }

    public class TTriangle : TGeometryRoot
    {
        // класс описывающий треугольник. Наследник от корневого класса. Использование виртуальных методов позволяет расчитывать площадь "не зная о форме объекта на этапе компиляции"
        public double dA, dB, dC;
        public TTriangle (double a,double b, double c)
            // конструктор Перед созданием объекта проверяем на возможность существования заданного параметрами треугольника. В случае если треугольник не существует вызываем исключение.
            // Вообще можно было бы для каждого варианта ошщибки создать отдельные классы исключений, но для простоты органичусь просто Exception с текстовым сообщением.
        {
            if ((a <= 0) || (b <= 0) || (c <= 0))
            {
                throw new Exception("Длина стороны треугольника не может быть меньше или равна 0!");
            }
            if (((a + b) <= c) || ((b + c) <= a) || ((a + c) <= b))
            {
                throw new Exception("Длина стороны треугольника не может быть больше или равна сумме двух других сторон!");
            }
            dA = a;
            dB = b;
            dC = c;
        }
        public override bool IsRightTriangle()
            // проверка на "прямоугольность". Принцип проверки на использовании теоремы пифагора в обратнуом направлении - если квадрат одной стороны равен сумме квадратов двух других - то треугольник
            // прямоугольный. Если нет - то нет.
        {
            double s1 = 0, s2 = 0;

            if ((dA > dB) && (dA > dC))
            {
                s1 = dA * dA;
                s2 = (dB * dB) + (dC * dC);
            }
            if ((dB > dA) && (dB > dC))
            {
                s1 = dB * dB;
                s2 = (dA * dA) + (dC * dC);
            }

            if ((dC > dA) && (dC > dB))
            {
                s1 = dC * dC;
                s2 = (dA * dA) + (dB * dB);
            }

            return (s1 == s2)?true:false;
        }
        override public double GetResult()
            // расчет площади по формуле Герона.
        {
            double p = (dA + dB + dC) / 2;

            return Math.Sqrt(p * (p - dA) * (p - dB) * (p - dC));

        }
    }

    public class TCircle:TGeometryRoot
    {
        public double dR;
        public TCircle(double r)
            // конструктор - перед созданием проверяем на корректность радиуса.
        {
            if (r <= 0)
            {
                throw new Exception("Радиус круга не может быть меньше или равен 0!");
            }

            dR = r;
        }
        public override double GetResult()
            // расчет площади круга...
        {
            return Math.PI * dR * dR;
        }
    }
   
}
