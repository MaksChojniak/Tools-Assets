namespace MChojniakStudio.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using UnityEngine;

    public static class SearchingExtension
    {

        public static IEnumerable<ISearchable> GetMatching(this IEnumerable<ISearchable> source, string value)
        {
            if(source == null || source.Count() <= 0)
                return new List<ISearchable>();

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    return new List<ISearchable>();

            return source.Where(x => x.GetTitle().IndexOf(value, System.StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public static IEnumerable<ISearchable> SortByMatching(this IEnumerable<ISearchable> source, string value)
        {
            if (source == null || source.Count() <= 0)
                return new List<ISearchable>();

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return new List<ISearchable>();

            return source.OrderByDescending(x => Regex.Matches(x.GetTitle(), value, RegexOptions.IgnoreCase).Count)
                .ThenBy(x => x.GetTitle().ToLower());
                // .ThenBy(x => x.GetTitle().IndexOf(value, StringComparison.OrdinalIgnoreCase));
        }


    }

}