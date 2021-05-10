using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace industry9.Client.Data.Navigation
{
    public class industry9NavigationManager : IDisposable
    {
        private readonly string _baseUrl;
        private readonly NavigationManager _navigationManager;

        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        public industry9NavigationManager(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _baseUrl = _navigationManager.BaseUri;
            _navigationManager.LocationChanged += LocationChanged;
            BuildBreadcrumbs();
        }

        public string PageTitle => BuildBreadcrumbs().FirstOrDefault()?.Title;

        public string Uri => _navigationManager.Uri;
        public string BaseUri => _navigationManager.BaseUri;

        public void NavigateTo(string uri, bool forceLoad = false)
        {
            _navigationManager.NavigateTo(uri, forceLoad);
        }

        public LinkItem[] BuildBreadcrumbs()
        {
            var uri = _navigationManager.Uri.Replace(_baseUrl, "").Trim();
            if (string.IsNullOrEmpty(uri))
            {
                return new LinkItem[0];
            }

            var parts = uri.Split('/');
            return parts.Select(u => new LinkItem(GetLinkName(u), u, GetAbsolutePath(parts))).ToArray();
        }

        private string GetLinkName(string relativePath)
        {
            return relativePath.Replace("_", " ");
        }

        private string GetAbsolutePath(string[] relativeParts)
        {
            return $"{_baseUrl}{string.Join("/", relativeParts)}";
        }

        public void Dispose()
        {
            _navigationManager.LocationChanged -= LocationChanged;
        }
    }
}
