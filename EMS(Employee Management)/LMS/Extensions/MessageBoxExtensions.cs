using System.Windows;

namespace LMS.Extensions
{
    internal static class MessageBoxExtensions
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(
                message,
                "Error",
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }

        public static MessageBoxResult ShowConfirmation(string message)
        {
            var result = MessageBox.Show(
                message,
                "Confirm your action",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            return result;  
        }
    }
}
