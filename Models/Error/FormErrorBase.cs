using System.Collections.Generic;

namespace record_keep_api.Models.Error
{
    public abstract class FormErrorBase
    {
        public List<string> Form { get; set; }

        protected FormErrorBase(params string[] form)
        {
            Form = new List<string>(form);
        }
    }
}