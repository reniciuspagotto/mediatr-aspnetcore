using System.Collections.Generic;

namespace MediatRWithAspNetCore
{
    public class Result
    {
        public Result()
        {
            Errors = new List<string>();
            Data = new object();
        }

        public object Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
