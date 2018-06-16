using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Yanyitec.Auth
{
    public class AuthPermissions : Dictionary<string, AuthPermission>, IReadOnlyDictionary<string, IAuthPermission>
    {
        IAuthPermission IReadOnlyDictionary<string, IAuthPermission>.this[string key] {
            get {
                return this[key];
            }
        }

        IEnumerable<string> IReadOnlyDictionary<string, IAuthPermission>.Keys => this.Keys;

        IEnumerable<IAuthPermission> IReadOnlyDictionary<string, IAuthPermission>.Values => this.Values;

        public bool TryGetValue(string key, out IAuthPermission value)
        {
            AuthPermission perm = null;
            var result= base.TryGetValue(key,out perm);
            value = perm;
            return result;
        }

        IEnumerator<KeyValuePair<string, IAuthPermission>> IEnumerable<KeyValuePair<string, IAuthPermission>>.GetEnumerator()
        {
            return new Enumerator(base.GetEnumerator());
        }

        public class Enumerator : IEnumerator<KeyValuePair<string, IAuthPermission>>
        {
            IEnumerator<KeyValuePair<string, AuthPermission>> _InternalEnumerator;
            public Enumerator(IEnumerator<KeyValuePair<string, AuthPermission>> internalEnumerator) {
                this._InternalEnumerator = internalEnumerator;
            }
            public KeyValuePair<string, IAuthPermission> Current {
                get {
                    var pair = this._InternalEnumerator.Current;
                    return new KeyValuePair<string,IAuthPermission>(pair.Key,pair.Value);
                }
            }

            object IEnumerator.Current => this._InternalEnumerator.Current;

            public void Dispose()
            {
                this._InternalEnumerator.Dispose();
            }

            public bool MoveNext()
            {
                return this._InternalEnumerator.MoveNext();
            }

            public void Reset()
            {
                this._InternalEnumerator.Reset();
            }
        }
    }
}
