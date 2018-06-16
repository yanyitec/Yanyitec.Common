using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Yanyitec.Auth
{
    [ProtoContract]
    public class AuthUser :  IAuthUser
    {
        #region IUser/BasUser成员
        /// <summary>
        /// 用户唯一全局Id
        /// </summary>
        [ProtoMember(1)]
        public Guid UserId { get; set; }
        

        /// <summary>
        /// 用户唯一名
        /// </summary>
        [ProtoMember(2)]
        public string UserName { get; set; }
        /// <summary>
        /// 用于显示的名称
        /// </summary>
        [ProtoMember(3)]
        public string DisplayName { get; set; }
        [ProtoMember(4)]
        public string UserInfo { get; set; }
        

        /// <summary>
        /// 数据库分区字段
        /// </summary>
        [ProtoIgnore]
        protected string _JSON;
        public virtual string ToJSON()
        {
            if (_JSON == null)
            {
                lock (this)
                {
                    if (_JSON == null)
                    {
                        _JSON = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                    }
                }
            }
            return _JSON;

        }
        #endregion
        #region IRutnimeUser members
        [ProtoMember(8)]
        public string Token { get; set; }
        [ProtoMember(9)]
        public string ClientIp { get; set; }
        [ProtoMember(10)]
        public IAuthPermissions Permissions
        {
            get;set;
        }
        [ProtoMember(11)]
        public IUser Factor
        {
            get; set;
        }
        [ProtoMember(12)]
        public IDictionary<string, string> Data { get;set; }
        #endregion
    }
}
