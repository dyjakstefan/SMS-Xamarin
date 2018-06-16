using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SMS.Views
{
    /// <summary>
    /// Class for MainPage.
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
        /// <summary>
        /// Constructor.
        /// </summary>
		public MainPage ()
		{
			InitializeComponent ();
		}
	}
}