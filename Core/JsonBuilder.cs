using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Assignment.Core
{
    /// <summary>
    ///     Adds some functionalities to manage json
    /// </summary>
    public static class JsonBuilder
    {
        /// <summary>
        ///     Converts string to object type
        /// </summary>
        /// <param name="filePath">Json</param>
        /// <typeparam name="T">Object Type</typeparam>
        /// <returns>Instance of object type</returns>
        public static T Deserialize<T>(string filePath)
        {
            var path = string.Concat(AppDomain.CurrentDomain.BaseDirectory, filePath);

            var json = File.ReadAllText(Path.Combine(path.Split("\\").ToArray()));

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}