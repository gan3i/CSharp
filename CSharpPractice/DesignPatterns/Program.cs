using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    class Program
    {
        public enum Color
        {
            Red, Green, Blue
        }
        public enum Size
        {
            Small, Medium, Large, Yuge
        }

        public class Product
        {
            public string Name;
            public Color Color;
            public Size Size;

            public Product(string name, Color color, Size size)
            {
                if (name == null)
                {
                    throw new ArgumentNullException(paramName: nameof(name));
                }
                this.Name = name;
                this.Size = size;
                this.Color = color;
            }
        }

        public interface ISpecification<T>
        {
            bool IsSatisfied(T t);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }
        public class ColorSpecification : ISpecification<Product>
        {
            private Color color;

            public ColorSpecification(Color color)
            {
                this.color = color;
            }

            public bool IsSatisfied(Product t)
            {
                return t.Color == color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private Size Size;
            public SizeSpecification(Size size)
            {
                this.Size = size;
            }
            public bool IsSatisfied(Product product)
            {
                return product.Size == this.Size;
            }
        }

        public class AndSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> first, second;

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                this.first = first ?? throw new ArgumentNullException(paramName: nameof(first));
                this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
            }

            public bool IsSatisfied(T product)
            {
                return first.IsSatisfied(product) && second.IsSatisfied(product);
            }

        }

        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var p in items)
                {
                    if (spec.IsSatisfied(p))
                    {
                        yield return p;
                    }
                }
            }
        }


        public class ProductFilter
        {
            public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
            {
                foreach (var p in products)
                {
                    if (p.Size == size)
                    {
                        yield return p;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Product[] products = new Product[]
             {
                new Product("Apple", Color.Green, Size.Small),
                new Product("Tree", Color.Green, Size.Large),
                new Product("Tree", Color.Blue, Size.Large)
             };
            var bf = new BetterFilter();
            foreach (var p in bf.Filter(products,
                new AndSpecification<Product>(new ColorSpecification(Color.Green), new SizeSpecification(Size.Large))))
            {
                Console.WriteLine($"name : {p.Name}");
            }
            foreach (var p in bf.Filter(products,new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"name : {p.Name}");
            }
        }
    }
}
