using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;

namespace AtApi.Service.Framework
{
    /// <summary>
    /// Helper class for guard statements, which allow prettier
    /// code for guard clauses
    /// </summary>
    public class Guard
    {
        /// <summary>
        /// Will throw a <see cref="InvalidOperationException"/> if the assertion
        /// is true, with the specificied message.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// Sample usage:
        /// <code>
        /// Guard.Against(string.IsNullOrEmptyThrow(name), "Name must have a value");
        /// </code>
        /// </example>
        /// <exception cref="InvalidOperationException"></exception>
        [DebuggerStepThrough]
        public static void Against(bool assertion, string message)
        {
            if (assertion)
            {
                throw new InvalidOperationException(message);
            }
            return;
        }

        /// <summary>
        /// Will throw a <see cref="InvalidOperationException"/> if the assertion
        /// is false, with the specificied message.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// Sample usage:
        /// <code>
        /// Guard.Against(string.IsNullOrEmptyThrow(name), "Name must have a not have value");
        /// </code>
        /// </example>
        /// <exception cref="InvalidOperationException"></exception>
        [DebuggerStepThrough]
        public static void For(bool assertion, string message)
        {
            if (!assertion)
            {
                throw new InvalidOperationException(message);
            }
            return;
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> with the specified message
        /// when the assertion
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="assertion"></param>
        /// <param name="message"></param>
        public static void Against<TException>(Func<bool> assertion, string message) where TException : Exception
        {
            //Execute the lambda and if it evaluates to true then throw the exception.
            if (assertion())
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
            return;
        }

        /// <summary>
        /// Will throw exception of type <typeparamref name="TException"/>
        /// with the specified message if the assertion is true
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <example>
        /// Sample usage:
        /// <code>
        /// <![CDATA[
        /// Guard.Against<ArgumentException>(string.IsNullOrEmptyThrow(name), "Name must have a value");
        /// ]]>
        /// </code>
        /// </example>
        public static void Against<TException>(bool assertion, string message) where TException : Exception
        {
            if (assertion)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
            return;
        }

        /// <summary>
        /// Checks an Enum argument to ensure that its value is defined by the specified Enum type.
        /// </summary>
        /// <param name="enumType">The Enum type the value should correspond to.</param>
        /// <param name="value">The value to check for.</param>
        /// <param name="argumentName">The name of the argument holding the value.</param>
        public static void EnumValueIsDefined(Type enumType, object value, string argumentName)
        {
            if (!Enum.IsDefined(enumType, value))
            {
                throw new ArgumentException(argumentName, enumType.ToString());
            }
        }

        /// <summary>
        /// Verifies that an argument type is assignable from the provided type (meaning
        /// interfaces are implemented, or classes exist in the base class hierarchy).
        /// </summary>
        /// <param name="assignee">The argument type.</param>
        /// <param name="providedType">The type it must be assignable from.</param>
        /// <param name="argumentName">The argument name.</param>
        public static void TypeIsAssignableFromType(Type assignee, Type providedType, string argumentName)
        {
            if (!providedType.IsAssignableFrom(assignee))
            {
                throw new ArgumentException(string.Format("Unable to Cast from {0} to {1}", providedType, providedType), argumentName);
            }
        }


        /// <summary>
        /// Represents a parameter guard.
        /// </summary>
        /// <param name="condition"></param>
        public static void IsTrue(bool condition)
        {
            IsTrue(condition, string.Empty);
        }


        /// <summary>
        /// Indicates whether the specified <see cref="Guid"/> object is <b>null</b> or a <see cref="Guid.Empty"/> value.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static void IsNotNullOrEmpty(Guid? guid)
        {
            IsNotNullOrEmpty(guid, string.Empty);
        }

        /// <summary>
        /// Indicates whether the specified <see cref="Guid"/> object is <b>null</b> or a <see cref="Guid.Empty"/> value.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static void IsNotNullOrEmpty(Guid? guid, string parameterName)
        {
            if (null == guid || Guid.Empty == guid)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Indicates whether the specified <see cref="Guid"/> object is <b>null</b> or a <see cref="Guid.Empty"/> value.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static void IsNotNullOrEmpty(Guid guid)
        {
            IsNotNullOrEmpty(guid, string.Empty);
        }


        /// <summary>
        /// Indicates whether the specified <see cref="Guid"/> object is <b>null</b> or a <see cref="Guid.Empty"/> value.
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static void IsNotNullOrEmpty(Guid guid, string parameterName)
        {
            if (Guid.Empty == guid)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        public static void IsFalse(bool condition)
        {
            IsTrue(!condition, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void IsTrue(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void IsFalse(bool condition, string message)
        {
            IsTrue(!condition, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        [DebuggerStepThrough]
        public static void IsNull<T>(T paramValue, string paramName, string message)
        //where T : class
        {
            if (!Equals(paramValue, null))
            {
                throw new ArgumentException(message, paramName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <param name="argName"></param>
        [DebuggerStepThrough]
        public static void IsNotNull<T>(T arg, string argName)
        //where T : class
        {
            if (Equals(arg, null))
            {
                throw new ArgumentNullException(argName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue"></param>
        [DebuggerStepThrough]
        public static void IsNull<T>(T paramValue)
        //where T : class
        {
            IsNull(paramValue, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        [DebuggerStepThrough]
        public static void IsNotNull<T>(T arg)
        //where T : class
        {
            IsNotNull(arg, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        [DebuggerStepThrough]
        public static void IsNotNull<T>(T paramValue, string paramName, string message)
        //where T : class
        {
            if (Equals(paramValue, null))
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        [DebuggerStepThrough]
        public static void IsNotNullOrEmpty(string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        [DebuggerStepThrough]
        public static void IsNotNullOrEmpty(string paramValue, string paramName)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                throw new ArgumentNullException(paramName, string.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsNotNullOrEmpty(string paramValue, string paramName, string message)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        [DebuggerStepThrough]
        public static void IsGreaterThanZero<T>(T paramValue, string paramName, string message)
            where T : IComparable
        {
            IsNotNull(paramValue, paramName, message);

            if (paramValue.CompareTo(1) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        [DebuggerStepThrough]
        public static void IsGreaterThanZero<T>(T paramValue, string paramName)
            where T : IComparable
        {
            IsGreaterThanZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        [DebuggerStepThrough]
        public static void IsGreaterThanZero<T>(T paramValue)
            where T : IComparable
        {
            IsGreaterThanZero(paramValue, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        [DebuggerStepThrough]
        public static void IsGreaterThanOrEqualToZero<T>(T paramValue, string paramName, string message)
            where T : IComparable
        {
            IsNotNull(paramValue, paramName, message);

            if (paramValue.CompareTo(0) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether [is greater than or equal to zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        [DebuggerStepThrough]
        public static void IsGreaterThanOrEqualToZero<T>(T paramValue, string paramName)
            where T : IComparable
        {
            IsGreaterThanOrEqualToZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether [is greater than or equal to zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanOrEqualToZero<T>(T paramValue)
            where T : IComparable
        {
            IsGreaterThanOrEqualToZero(paramValue, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsGreaterThanOrEqualToZero(long paramValue, string paramName, string message)
        {
            IsNotNull(paramValue, paramName, message);

            if (paramValue.CompareTo(0) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether [is greater than or equal to zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsGreaterThanOrEqualToZero(long paramValue, string paramName)
        {
            IsGreaterThanOrEqualToZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether [is greater than or equal to zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanOrEqualToZero(long paramValue)
        {
            IsGreaterThanOrEqualToZero(paramValue, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsGreaterThanZero(long paramValue, string paramName, string message)
        {
            if (paramValue < 1)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsGreaterThanZero(long paramValue, string paramName)
        {
            IsGreaterThanZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanZero(long paramValue)
        {
            IsGreaterThanZero(paramValue, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        public static void AssertEnumMember<TEnum>(TEnum enumValue) where TEnum : struct, IConvertible
        {
            if (Attribute.IsDefined(typeof(TEnum), typeof(FlagsAttribute), false))
            {
                bool isThrowRequired;
                long longValue = enumValue.ToInt64(CultureInfo.InvariantCulture);

                if (longValue == 0)
                {
                    isThrowRequired = !Enum.IsDefined(typeof(TEnum), 0);
                }
                else
                {
                    foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
                    {
                        longValue &= ~value.ToInt64(CultureInfo.InvariantCulture);
                    }

                    isThrowRequired = longValue != 0;
                }

                if (isThrowRequired)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Enum value '{0}' is not valid for flags enumeration '{1}'.", enumValue, typeof(TEnum).FullName));
                }
            }
            else
            {
                if (!Enum.IsDefined(typeof(TEnum), enumValue))
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Enum value '{0}' is not defined for enumeration '{1}'.", enumValue, typeof(TEnum).FullName));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumValue"></param>
        /// <param name="validValues"></param>
        public static void AssertEnumMember<TEnum>(TEnum enumValue, params TEnum[] validValues)
            where TEnum : struct, IConvertible
        {
            IsNotNull(validValues, "validValues");

            if (Attribute.IsDefined(typeof(TEnum), typeof(FlagsAttribute), false))
            {
                bool isThrowRequired;
                long longValue = enumValue.ToInt64(CultureInfo.InvariantCulture);

                if (longValue == 0)
                {
                    isThrowRequired = true;

                    foreach (TEnum value in validValues)
                    {
                        if (value.ToInt64(CultureInfo.InvariantCulture) == 0)
                        {
                            isThrowRequired = false;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (TEnum value in validValues)
                    {
                        longValue &= ~value.ToInt64(CultureInfo.InvariantCulture);
                    }

                    isThrowRequired = longValue != 0;
                }

                if (isThrowRequired)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Enum value '{0}' is not allowed for flags enumeration '{1}'.", enumValue, typeof(TEnum).FullName));
                }
            }
            else
            {
                foreach (TEnum value in validValues)
                {
                    if (enumValue.Equals(value))
                    {
                        return;
                    }
                }

                if (!Enum.IsDefined(typeof(TEnum), enumValue))
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Enum value '{0}' is not defined for enumeration '{1}'.", enumValue, typeof(TEnum).FullName));
                }
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Enum value '{0}' is defined for enumeration '{1}' but it is not permitted in this context.", enumValue, typeof(TEnum).FullName));
            }
        }

        #region Float

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsGreaterThanOrEqualToZero(float paramValue, string paramName, string message)
        {
            IsNotNull(paramValue, paramName, message);

            if (paramValue.CompareTo(0f) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether the value is greater than or equal to zero.
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsGreaterThanOrEqualToZero(float paramValue, string paramName)
        {
            IsGreaterThanOrEqualToZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether the value is greater than or equal to zero.
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanOrEqualToZero(float paramValue)
        {
            IsGreaterThanOrEqualToZero(paramValue, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsGreaterThanZero(float paramValue, string paramName, string message)
        {
            if (paramValue <= 0f)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsGreaterThanZero(float paramValue, string paramName)
        {
            IsGreaterThanZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanZero(float paramValue)
        {
            IsGreaterThanZero(paramValue, string.Empty, string.Empty);
        }

        #endregion

        #region Decimal

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsGreaterThanOrEqualToZero(decimal paramValue, string paramName, string message)
        {
            IsNotNull(paramValue, paramName, message);

            if (paramValue.CompareTo(0m) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether the value is greater than or equal to zero.
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsGreaterThanOrEqualToZero(decimal paramValue, string paramName)
        {
            IsGreaterThanOrEqualToZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether the value is greater than or equal to zero.
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanOrEqualToZero(decimal paramValue)
        {
            IsGreaterThanOrEqualToZero(paramValue, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsGreaterThanZero(decimal paramValue, string paramName, string message)
        {
            if (paramValue <= 0m)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsGreaterThanZero(decimal paramValue, string paramName)
        {
            IsGreaterThanZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanZero(decimal paramValue)
        {
            IsGreaterThanZero(paramValue, string.Empty, string.Empty);
        }

        #endregion

        #region Double

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsGreaterThanOrEqualToZero(double paramValue, string paramName, string message)
        {
            IsNotNull(paramValue, paramName, message);

            if (paramValue.CompareTo(0d) < 0d)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether the value is greater than or equal to zero.
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsGreaterThanOrEqualToZero(double paramValue, string paramName)
        {
            IsGreaterThanOrEqualToZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether the value is greater than or equal to zero.
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanOrEqualToZero(double paramValue)
        {
            IsGreaterThanOrEqualToZero(paramValue, string.Empty, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramValue"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void IsGreaterThanZero(double paramValue, string paramName, string message)
        {
            if (paramValue <= 0d)
            {
                throw new ArgumentOutOfRangeException(paramName, message);
            }
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsGreaterThanZero(double paramValue, string paramName)
        {
            IsGreaterThanZero(paramValue, paramName, string.Empty);
        }

        /// <summary>
        /// Determines whether [is greater than zero] [the specified param value].
        /// </summary>
        /// <param name="paramValue">The param value.</param>
        public static void IsGreaterThanZero(double paramValue)
        {
            IsGreaterThanZero(paramValue, string.Empty, string.Empty);
        }

        #endregion

        public static void IsNotNullOrEmpty(Expression<Func<string>> parameterExpression, string message = "")
        {
            IsNotNullOrEmpty(parameterExpression.Compile()(), GetParameterName(parameterExpression), message);
        }

        /// <summary>
        /// Determines whether expression is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <example>Guard.NotNull(() => someParameter);</example>
        /// <param name="parameterExpression">The parameter expression.</param>
        public static void IsNotNull<T>(Expression<Func<T>> parameterExpression, string message = "")
            where T : class
        {
            IsNotNull(parameterExpression.Compile()(), GetParameterName(parameterExpression), message);
        }

        private static string GetParameterName<T>(Expression<Func<T>> parameterExpression)
        {
            dynamic body = parameterExpression.Body;
            return body.Member.Name;
        }



        /// <summary>
        /// Determines whether [is not null or empty] [the specified array].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        public static void IsNotNullOrEmpty<T>(T[] array, string parameterName)
        {
            if (array == null || array.Length <= 0)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}