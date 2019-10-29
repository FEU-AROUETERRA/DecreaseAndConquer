using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discrete_Solution
{
    /// <summary>
    /// The Natural class is the implementation of a specific value from the set of natural numbers.
    /// </summary>
    /// <remarks> 
    /// @author: August Bryan N. Florese
    /// @started: 2019-02-25  
    /// @concluded: 2019-02-27
    /// </remarks> 
    public class Natural
    {
        private int value;

        ///<summary>
        ///The default constructor for the class Natural.
        /// </summary> 
        /// <remarks> Sets int value to default as 0.</remarks>
        public Natural()
        {
            this.value = 0;
        }

        ///<summary>
        /// The constructor for the class Natural, sets the int value default to a specified value.
        /// <para> 
        /// @value the default initial value of the natural number.
        /// @exception RuntimeException if the value is negative.
        /// </para>
        /// <para > 
        /// Pre-condition: The number is not null and is within the domain of natural numbers.
        /// Post-condition: The methods may return negative numbers or 0, only after a local operation has been performed.
        /// </para>
        /// </summary>
        public Natural(int value)
        {
            try
            {
                if (value < 0)
                {
                    throw new ArgumentException("Natural numbers cannot be negative");
                }
                this.value = value;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        ///<summary>
        ///Returns the greatest common denominator between the value of this instance and the value of another instance
        ///In .NET, recursive functions are actually slower than non-recursive functions as n increases
        /// </summary> 
        /// <remarks>
        /// X cannot be negative but can be zero; whereas y cannot be negative or zero
        /// </remarks>
        public Natural Gcd(Natural value)
        {
            int x = this.value, y = value.value, temp = 0;
            try
            {
                if (x < 0 || y <= 0)
                    throw new ArgumentException("An invalid argument was detected.");
                else if (y < x)
                {
                    temp = x;
                    x = y;
                    y = temp;
                }
                while (y != 0)
                {
                    temp = x % y;
                    x = y;
                    y = temp;
                }
                this.value = x;
                return this;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        ///<summary>
        ///Checks if the value of this instance is a prime number
        /// </summary>
        /// <remarks>
        /// An extension method was incorporated to handle numbers outside the limit of Int64, however this implementation is not the fastest.
        /// While the method is optimized for long and int numbers, the solution also accepts even larger numbers at the cost of performance
        /// </remarks>
        /// <returns>
        /// True : the value is prime
        /// False : the value is composite or non-natural
        /// </returns>
        public Boolean IsPrime()
        {

            int num = this.value;
            try
            {
                if (this.value <= 1)
                    return false;
                if (this.value == 2 || this.value == 3)
                    return true;
                if (this.value % 2 == 0 || this.value % 3 == 0)
                    return false;
                double limit = (Math.Sqrt(this.value))+1;
                for (int i = 3; i <= limit; i+=2)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //public BigInteger Sqrt()
        //{
        //    int n = this.value;
        //    if (n == 0) return 0;
        //    if (n > 0)
        //    {
        //        int length = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
        //        BigInteger root = BigInteger.One << (length / 2);

        //        while (!isRooted(n, root))
        //        {
        //            root += n / root;
        //            root /= 2;
        //        }

        //        return root;
        //    }
        //    throw new ArithmeticException("NDE");
        //}

        private static Boolean isRooted(int n, int root)
        {
            int lowerBound = root * root;
            int upperBound = (root + 1) * (root + 1);

            return n >= lowerBound && n <= lowerBound + root + root;
        }

        ///<summary>
        ///Returns a String representation of the value of this instance
        /// </summary>
        public override String ToString()
        {
            return Convert.ToString(this.value);
        }

        ///<summary>
        ///Returns a boolean check true or false, whether the gcd of two values is equal to 1.
        /// </summary>
        /// <returns>
        /// @True: 1
        /// </returns>
        public Boolean IsRelativelyPrimeTo(Natural value)
        {
            return (this.Gcd(value).value == 1) ? true : false;
        }
       
       
        ///<summary>
        ///Returns the int32 representation of the value of this instance
        /// </summary>
        public Int32 GetIntValue()
        {
            var str = this.value.ToString();
            if (str.Length <= 9 || this.value <= 2147483647)
                return (Int32)this.value;
            else
                throw new ArgumentException("The value is too large to be contained in the Int32 format.");
        }

        ///<summary>
        ///Returns the int32 representation of the value of this instance as an array of integers
        /// </summary>
        public int[] GetArray(int num)
        {
            String str = num.ToString();
            int[] arr = new int[str.Length];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = str.ElementAt(i) - '0';
            return arr;
        }

        ///<summary>
        ///Returns the int64 representation of the value of this instance.
        /// </summary>
        public Int64 GetLongValue()
        {
            return (Int64)(this.value);
        }

        ///<summary>
        ///Returns the int representation of the value of this instance.
        /// </summary>
        public int GetBigValue()
        {
            return (this.value);
        }
    }
}
