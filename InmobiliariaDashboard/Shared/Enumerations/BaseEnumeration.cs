using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InmobiliariaDashboard.Shared.Enumerations
{
    public interface IBaseEnumeration
    {
        int Value { get; }
        string Code { get; }
        string DisplayName { get; }
    }

    public abstract class BaseEnumeration : IComparable, IBaseEnumeration
    {
        private readonly int _value;
        private readonly string _code;
        private readonly string _displayName;

        protected BaseEnumeration()
        {
        }

        protected BaseEnumeration(int value, string code, string displayName)
        {
            _value = value;
            _code = code;
            _displayName = displayName;
        }

        public int Value => _value;
        public string Code => _code;
        public string DisplayName => _displayName;

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<T> GetAll<T>() where T : BaseEnumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as BaseEnumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = _value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static int AbsoluteDifference(BaseEnumeration firstValue, BaseEnumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static T FromValue<T>(int value) where T : BaseEnumeration, new()
        {
            var matchingItem = parse<T, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromCode<T>(string code) where T : BaseEnumeration, new()
        {
            var matchingItem = parse<T, string>(code, "code", item => item.Code == code);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : BaseEnumeration, new()
        {
            var matchingItem = parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : BaseEnumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((BaseEnumeration)other).Value);
        }
    }
}