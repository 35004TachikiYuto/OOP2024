using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    public class Song {
       
        //歌のタイトル
        public string Title { get; set; }
        //アーティスト名
        public string ArtistName { get; set; }
        //演奏時間、単位は秒
        public int Lengh { get; set; }

        public Song(string title, string artistName, int length) {
            Title = title;
            ArtistName = artistName;
            Lengh = length;


        }
        
    }
}
