using System.Collections.Generic;

namespace record_keep_api.Models.Error
{
    public abstract class ErrorBase
    {
        public List<string> Form { get; set; }

        protected ErrorBase(params string[] form)
        {
            Form = new List<string>(form);
        }
    }
}