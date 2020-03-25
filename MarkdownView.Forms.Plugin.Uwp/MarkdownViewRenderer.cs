using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PassXYZ.UI.Uwp
{
    public class MarkdownViewRenderer
    {
        public static void Init()
        {
            DependencyService.Register<WebViewBaseUrl>();
        }
    }
}
