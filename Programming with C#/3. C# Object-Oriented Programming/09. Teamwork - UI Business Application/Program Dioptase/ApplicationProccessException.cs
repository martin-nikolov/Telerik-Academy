namespace ProgramDioptase
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    class ApplicationProccessException : ApplicationException
    {
        private const string ErrorMessage =
            "There was an error occurred while processing data, please contact the administrator of the application!";

        public ApplicationProccessException(string message = ErrorMessage, Exception innerEx = null)
            : base(message, innerEx)
        {
            MessageBox.Show(this.Message, "An error occured!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }
    }
}