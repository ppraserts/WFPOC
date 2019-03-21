using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.IO;

namespace POCWorkFlow
{

    public sealed class ReadTemplateFileActivity : CodeActivity<ResultInfo>
    {
        // Define an activity input argument of type string
        public InArgument<string> FileName { get; set; }
        public InArgument<string> FileTemplate { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override ResultInfo Execute(CodeActivityContext context)
        {
            var result = new ResultInfo();
            try
            {
                // Obtain the runtime value of the Text input argument
                string fileName = context.GetValue(this.FileName);
                string fileTemplate = context.GetValue(this.FileTemplate);

                string template = File.ReadAllText(fileTemplate);
                File.WriteAllText(fileName, template);
                result.IsValid = true;
                result.Message = template;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }

            return result;
        }
    }
}
