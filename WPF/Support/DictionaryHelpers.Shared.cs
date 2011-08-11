using System;
using System.Collections.Generic;
using System.Linq;

// This code is property of GeniusCode, LLC
// Licensed under MS-PL

namespace WpfApplication1
{
    public static class DictionaryHelpers
    {
        public static TValue GetIfExists<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue elseValueToReturn)
        {
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            else
                return elseValueToReturn;
        }


        public static TValue CreateOrGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> createDelegate)
        {
            bool wasCreated;
            return CreateOrGetValue<TKey, TValue>(dictionary, key, createDelegate, out wasCreated);
        }
        public static TValue CreateOrGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> createDelegate, out bool wasCreated)
        {
            if (dictionary.ContainsKey(key))
            {
                wasCreated = false;
                return dictionary[key];
            }
            else
            {
                TValue result = createDelegate();
                dictionary.Add(key, result);
                wasCreated = true;
                return result;
            }
        }

        /// <summary>
        /// Adds if unique to Dictionary.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="input">The input.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns>Count of unique items added</returns>
        public static int AddIfUnique<TInput, TKey>(this Dictionary<TKey, TInput> dictionary, IEnumerable<TInput> input, Func<TInput, TKey> keySelector)
        {
            int count = 0;
            input.ToList().ForEach(o =>
                {
                    if (AddIfUnique<TInput, TKey>(dictionary, o, keySelector))
                        count++;
                });

            return count;
        }


        /// <summary>
        /// Adds if unique to Dictonary.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="input">The input.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns>whether or not item was added</returns>
        public static bool AddIfUnique<TInput, TKey>(this Dictionary<TKey, TInput> dictionary, TInput input, Func<TInput, TKey> keySelector)
        {
            TKey key = keySelector(input);
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, input);
                return true;
            }
            return false;
        }



        public static int AddIfUniqueOrReplaceIf<TInput, TKey>(this Dictionary<TKey, TInput> dictionary, IEnumerable<TInput> input , Func<TInput, TKey> keySelector, Func<TInput, TInput, bool> replaceFunc)
        {
            int count = 0;
            input.ToList().ForEach(o =>
            {
                if (AddIfUniqueOrReplaceIf<TInput, TKey>(dictionary, o, keySelector, replaceFunc))
                    count++;
            });

            return count;
        }



        public static bool AddIfUniqueOrReplaceIf<TInput, TKey>(this Dictionary<TKey, TInput> dictionary, TInput input, Func<TInput, TKey> keySelector, Func<TInput, TInput, bool> replaceFunc)
        {
            if (AddIfUnique(dictionary, input, keySelector))
                return true;
            else
            {
                TKey key = keySelector(input);
                TInput existingValue = dictionary[key];

                if (replaceFunc(existingValue, input))
                {
                    dictionary[key] = input;
                    return true;
                }
                else
                    return false;
            }
        }

    }
}
