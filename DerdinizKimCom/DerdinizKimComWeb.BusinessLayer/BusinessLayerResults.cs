using DerdinizKimComWeb.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.BusinessLayer
{
    public class BusinessLayerResults<T> where T:class
    {
        public List<KeyValuePair<ErrorMessageCode,string>> Errors { get; set; }
        public T Result { get; set; }

        public BusinessLayerResults()
        {
            Errors = new List<KeyValuePair<ErrorMessageCode,string>>();
        }
        public void AddError(ErrorMessageCode code,string message)
        {
            Errors.Add(new KeyValuePair<ErrorMessageCode, string>(code, message));
        }
    }
}
