using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myRegistrationSite.Models
{
    public class Attendee
    {
        [DisplayName("あなたのお名前"), Required]
        public string Name { get; set; }

        [DisplayName("あなたの e-mail アドレス"), Required, EmailAddress]
        public string Email { get; set; }

        [DisplayName("ライトニングトークする")]
        public bool beLT { get; set; }

        [DisplayName("懇親会に参加する")]
        public bool beParty { get; set; }

        [DisplayName("登録日時(UTC)")]
        public DateTime CreateAt { get; set; }
    }
}