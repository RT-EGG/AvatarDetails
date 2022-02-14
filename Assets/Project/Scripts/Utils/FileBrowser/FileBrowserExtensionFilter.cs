using SFB;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AvatarDetails
{
    [System.Serializable]
    public class FileBrowserExtensionFilter
    {
        [SerializeField] string _name;
        [SerializeField] public string[] _extensions;

        public string Name => _name;
        public string[] Extensions => _extensions;

        public ExtensionFilter ToSFB() => new ExtensionFilter(Name, Extensions);
    }

    public static class FileBrowserExtensionFilterConverter
    {
        public static ExtensionFilter[] ToSFB(this IReadOnlyList<FileBrowserExtensionFilter> inItems)
            => inItems.Select(item => item.ToSFB()).ToArray();
    }
}
