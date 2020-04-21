using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace webauthenticator.ViewModels {
    public class MainPageViewModel {

        private const string AUTH_URL_STRING = "https://app.hubspot.com/oauth/authorize";
        private const string OAUTH2_REDIRECT = "https://apollo.designcenter.bz/hubspot";

        private const string CLIENT_ID = "cf4d1cbd-16b5-4b83-a128-9532b21df5a8";
        private readonly string[] SCOPES = new string[] { "contacts" };

        public MainPageViewModel() {}

        Command _doHubSpotLogin = null;
        public Command DoHubSpotLogin => _doHubSpotLogin ?? ( _doHubSpotLogin = new Command( async () => {
            try {
                var url = $"{AUTH_URL_STRING}/?client_id={CLIENT_ID}&redirect_uri={OAUTH2_REDIRECT}&scope={string.Join( ",", SCOPES )}";
                var authResult = await WebAuthenticator.AuthenticateAsync( new Uri( url ), new Uri( OAUTH2_REDIRECT ) );
            } catch (Exception ) { }
        } ) );
    }
}
