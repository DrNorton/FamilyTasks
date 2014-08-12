using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Microsoft.Phone.Controls;

namespace FamilyTasks.Mobile.WinPhone.UI
{
    public static class Extensions
    {
        public static void ClearNavigateHistory(this PhoneApplicationPage page)
        {
            while (page.NavigationService.RemoveBackEntry() != null)
            {
            }
        }

        //Поиск предка элемента заданного типа
        public static T TryFindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            //we've reached the end of the tree
            if (parentObject == null) return null;
            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                //use recursion to proceed with next level
                return TryFindParent<T>(parentObject);
        }

        public static T FindFirstElementInVisualTree<T>(this DependencyObject parentElement) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0)
                return null;
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindFirstElementInVisualTree<T>(child);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        public static IEnumerable<T> GetVisualDescendents<T>(this DependencyObject d) where T : DependencyObject
        {
            int childCount = VisualTreeHelper.GetChildrenCount(d);
            for (int n = 0; n < childCount; n++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(d, n);
                if (child is T)
                {
                    yield return (T)child;
                }
                foreach (T match in GetVisualDescendents<T>(child))
                {
                    yield return match;
                }
            }
            yield break;
        }
    }
}
