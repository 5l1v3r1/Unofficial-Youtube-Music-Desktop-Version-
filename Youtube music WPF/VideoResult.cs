using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_music_WPF
{
    public class VideoResult
    {

        public string videoid { set; get; }
        public bool broadcast { set; get; }
        public string thumbnail { set; get; }
        public string videoname { set; get; }
        public string channelname { set; get; }
        public string channellink { set; get; }


        public VideoResult(){}

        public VideoResult(string id,  string thumbnail, string videoname, string channelname, string channellink)
        {
            this.videoid = id;
            this.thumbnail = thumbnail;
            this.videoname = videoname;
            this.channelname = channelname;
            this.channellink = channellink;
        }
    }
}
