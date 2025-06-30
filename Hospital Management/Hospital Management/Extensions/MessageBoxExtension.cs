using System.Windows;

namespace Hospital_Management.Extensions
{
    public class MessageBoxExtension
    {
        public static MessageBoxResult QuestionMessage(string message)
        {
            var result = MessageBox.Show(
                message,
                "Confirm your action",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            return result;
        }

        public static MessageBoxResult SuccessMessage(string message)
        {
            var result = MessageBox.Show(
                message,
                "Success",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            return result;
        }
    }
}
