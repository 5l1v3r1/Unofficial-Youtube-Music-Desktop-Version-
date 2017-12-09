using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_music_WPF
{
    class ChannelResult
    {
        public string name { set; get; }
        public string thumbnail { set; get; }
        public string channelid { set; get; }

        public ChannelResult(string name, string thumbnail, string id)
        {
            this.name = name;
            this.thumbnail = thumbnail;
            this.channelid = id;
        }
    }
}
