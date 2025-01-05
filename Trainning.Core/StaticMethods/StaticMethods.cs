using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainningApp.Core.StaticMethods
{
    public static class StaticMethods
    {
        public static string ConvertToEmbedUrl(string videoUrl)
        {
            if (string.IsNullOrWhiteSpace(videoUrl)) return string.Empty;

            // Verifica se o link é do YouTube
            if (videoUrl.Contains("youtube.com/watch?v="))
            {
                var videoId = videoUrl.Split("watch?v=").LastOrDefault()?.Split('&').FirstOrDefault();
                return $"https://www.youtube.com/embed/{videoId}";
            }
            else if (videoUrl.Contains("youtu.be/"))
            {
                var videoId = videoUrl.Split("youtu.be/").LastOrDefault()?.Split('&').FirstOrDefault();
                return $"https://www.youtube.com/embed/{videoId}";
            }

            // Retorna vazio caso a URL não seja do YouTube
            return string.Empty;
        }

    }
}
