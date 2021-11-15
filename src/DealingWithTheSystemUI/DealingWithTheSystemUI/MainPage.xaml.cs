using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace DealingWithTheSystemUI
{
    public partial class MainPage : ContentPage
    {

        private bool _hideHomeIndicator = true;
        private bool _useSafeArea = true;
        private bool _toggleHomeIndicatorBackground = true;
        private bool _hideNavBarSeparator;
        private bool _statusBarTextFollowNavBarTextColor = true;
        private bool _useLargeTitle;

        public MainPage()
        {
            InitializeComponent();

            Init();

        }

        private void Init()
        {
            On<iOS>().SetPrefersHomeIndicatorAutoHidden(_hideHomeIndicator);
            On<iOS>().SetUseSafeArea(_useSafeArea);

            HandleHomeIndicatorBackground();

            if (this.Parent is Xamarin.Forms.NavigationPage navigationPage)
            {
                navigationPage.On<iOS>().SetStatusBarTextColorMode(_statusBarTextFollowNavBarTextColor ? StatusBarTextColorMode.MatchNavigationBarTextLuminosity : StatusBarTextColorMode.DoNotAdjust);

                this.On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
            }
        }


        void StatusBarTextColorSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            _statusBarTextFollowNavBarTextColor = e.Value;

if (this.Parent is Xamarin.Forms.NavigationPage navigationPage)
{
    navigationPage.On<iOS>().SetStatusBarTextColorMode(_statusBarTextFollowNavBarTextColor ? StatusBarTextColorMode.MatchNavigationBarTextLuminosity : StatusBarTextColorMode.DoNotAdjust);
}
        }

        async void StatusBarTextColorDocsLink_Clicked(System.Object sender, System.EventArgs e)
            => await Xamarin.Essentials.Launcher.OpenAsync("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/platform/ios/status-bar-text-color");



        void LargePageTitleSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            _useLargeTitle = e.Value;

            this.On<iOS>().SetLargeTitleDisplay(_useLargeTitle ? LargeTitleDisplayMode.Always : LargeTitleDisplayMode.Never);
        }

        async void LargePageTitleDocsLink_Clicked(System.Object sender, System.EventArgs e)
            => await Xamarin.Essentials.Launcher.OpenAsync("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/platform/ios/page-large-title");


        void NavigationBarSeparatorSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            _hideNavBarSeparator = e.Value;
            if (this.Parent is Xamarin.Forms.NavigationPage navigationPage)
            {
                navigationPage.On<iOS>().SetHideNavigationBarSeparator(_hideNavBarSeparator);
            }
        }

        async void NavigationBarSeparatorDocsLink_Clicked(System.Object sender, System.EventArgs e)
            => await Xamarin.Essentials.Launcher.OpenAsync("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/platform/ios/navigation-bar-separator");



        #region home indicator

        void HomeIndicatorSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            _hideHomeIndicator = e.Value;
            On<iOS>().SetPrefersHomeIndicatorAutoHidden(_hideHomeIndicator);
        }

        async void HomeIndicatorVisibilityDocsLink_Clicked(System.Object sender, System.EventArgs e)
            => await Xamarin.Essentials.Launcher.OpenAsync("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/platform/ios/page-home-indicator");


        void HomeIndicatorBackgroundColor_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            _toggleHomeIndicatorBackground = e.Value;
            HandleHomeIndicatorBackground();
        }

        private void HandleHomeIndicatorBackground()
        {
            this.BackgroundColor = _toggleHomeIndicatorBackground ? Color.DarkGreen : Color.Default;
        }

        #endregion

        #region safe area
        void SafeAreaSwitch_Toggled(System.Object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            _useSafeArea = e.Value;
            On<iOS>().SetUseSafeArea(_useSafeArea);
        }

        async void SafeAreaDocsLink_Clicked(System.Object sender, System.EventArgs e)
            => await Xamarin.Essentials.Launcher.OpenAsync("https://docs.microsoft.com/en-us/xamarin/xamarin-forms/platform/ios/page-safe-area-layout");


        #endregion






    }
}
