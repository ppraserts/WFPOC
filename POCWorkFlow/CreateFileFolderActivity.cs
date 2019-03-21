using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.IO;

namespace POCWorkFlow
{

    public sealed class CreateFileFolderActivity : CodeActivity<ResultInfo>
    {
        // Define an activity input argument of type string
        public InArgument<string> FileName { get; set; }

        public InArgument<string> FilePathName { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override ResultInfo Execute(CodeActivityContext context)
        {
            var result = new ResultInfo();
            // Obtain the runtime value of the Text input argument
            string filePathName = context.GetValue(this.FilePathName);
            string fileName = context.GetValue(this.FileName);

            if (string.IsNullOrWhiteSpace(filePathName))
            {
                result.Message = "Missing Path For File";
                return result;
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                result.Message = "Missing Path For File";
                return result;
            }

            try
            {
                var fi = new FileInfo($"{filePathName}\\{fileName}");
                DirectoryInfo di = new DirectoryInfo($"{filePathName}");
                if (!di.Exists)
                {
                    di.Create();
                }

                if (!fi.Exists)
                {
                    fi.Create().Dispose();
                }
                result.IsValid = true;
                result.Message = "Create File Success!!!";
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return result;

        }
    }
}
