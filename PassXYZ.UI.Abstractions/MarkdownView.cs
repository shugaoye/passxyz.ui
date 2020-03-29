using System;
using Xamarin.Forms;

#if USE_DOTNET_COMMONMARK
using CommonMark;
#endif

namespace PassXYZ.UI.Abstractions
{
    /// <summary>
    /// A View that presents Markdown content. USE_DOTNET_COMMONMARK is defined, if a C# version of commonmark
    /// is used. The default is to use JavaScript version of Markdown parser.
    /// </summary>
    public class MarkdownView : WebView
    {
        private readonly string _baseUrl;

		public MarkdownView() : this(LinkRenderingOption.Underline)
		{

		}

		/// <summary>
		/// Creates a new MarkdownView
		/// </summary>
		/// <param name="linksOption">Tells the view how to render links.</param>
		public MarkdownView(LinkRenderingOption linksOption)
        {
            var baseUrlResolver = DependencyService.Get<IWebViewBaseUrl>();
            if (baseUrlResolver != null)
                _baseUrl = baseUrlResolver.Url;

#if USE_DOTNET_COMMONMARK
            if (linksOption == LinkRenderingOption.Underline)
                CommonMarkSettings.Default.OutputDelegate =
                    (doc, output, settings) =>
                        new UnderlineLinksHtmlFormatter(output, settings).WriteDocument(doc);

            if (linksOption == LinkRenderingOption.None)
                CommonMarkSettings.Default.OutputDelegate =
                    (doc, output, settings) =>
                        new NoneLinksHtmlFormatter(output, settings).WriteDocument(doc);
#endif
        }

#if USE_DOTNET_COMMONMARK
        /// <summary>
        /// Backing store for the MarkdownView.Stylesheet property
        /// </summary>
        public static readonly BindableProperty StylesheetProperty = BindableProperty.Create(
            propertyName: "Stylesheet",
            returnType: typeof(string),
            declaringType: typeof(MarkdownView),
            defaultValue: default(string));

        /// <summary>
        /// Gets or sets the stylesheet that will be applied to the document
        /// </summary>
        public string Stylesheet
        {
            get { return (String)GetValue(StylesheetProperty); }
            set
            {
                SetValue(StylesheetProperty, value);
                SetStylesheet();
            }
        }
#endif

        /// <summary>
        /// Backing storage for the MarkdownView.Markdown property
        /// </summary>
        public static readonly BindableProperty MarkdownProperty = BindableProperty.Create(
            propertyName: "Markdown",
            returnType: typeof(string),
            declaringType: typeof(MarkdownView),
            defaultValue: default(string));

        /// <summary>
        /// The markdown content
        /// </summary>
        public string Markdown
        {
            get { return (String)GetValue(MarkdownProperty); }
            set
            {
                SetValue(MarkdownProperty, value);
                SetWebViewSourceFromMarkdown();
            }
        }

        private void SetWebViewSourceFromMarkdown()
        {
            string head = Properties.Resources.Header;
            string footer = Properties.Resources.Footer;

            var body = head + Markdown + footer;

            Source = new HtmlWebViewSource { Html = body, BaseUrl = _baseUrl };

            // SetStylesheet();
        }

#if USE_DOTNET_COMMONMARK
        private void SetStylesheet()
        {
            if (!String.IsNullOrEmpty(Stylesheet))
            {
                Eval("_sw(\"" + Stylesheet + "\")");
            }
        }
#endif
    }
}

