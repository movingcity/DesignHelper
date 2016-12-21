using System.Windows;
using System.Windows.Media;

namespace ResourcesClient.Controls.Utility
{
    /// <summary>
    /// Utility Helper class
    /// </summary>
    static class Helper
    {
        /// <summary>
        /// Returns the ancestor of the passed DependencyObject in the visual tree.
        /// Returns null if not found
        /// </summary>
        /// <typeparam name="T">the ancestor type to be checked</typeparam>
        /// <param name="current">current object</param>
        /// <returns>ancestor object or null if not found</returns>
        public static T FindVisualAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        /// <summary>
        /// Returns the child of the passed DependencyObject in the visual tree.
        /// Returns null if not found
        /// </summary>
        /// <typeparam name="T">the child type to be checked</typeparam>
        /// <param name="current">current object</param>
        /// <returns>child object or null if not found</returns>
        public static T FindVisualChild<T>(DependencyObject current) where T : DependencyObject
        {
            // Search immediate children first (breadth-first)
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(current, i);

                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);

                    if (childOfChild != null)
                        return childOfChild;
                }
            }

            return null;
        }
    }
}
