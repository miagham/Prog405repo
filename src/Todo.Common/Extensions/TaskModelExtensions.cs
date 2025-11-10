using Todo.Common.Models;

namespace Todo.Common.Extensions
{
    //TODO:  b[p]
    public static class TaskModelExtensions
    {
        public static string ToFileName(this TaskModel model) =>
            $"{model.Key}.json";

        public static string ToFileName(string key) =>
            $"{key}.json";

    }
}
